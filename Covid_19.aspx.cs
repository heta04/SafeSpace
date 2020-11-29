using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Web.Services;
using System.Globalization;

public partial class _Default : System.Web.UI.Page
{
    WebService ws = new WebService();
    protected void Page_Load(object sender, EventArgs e)
    {
        getdata();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "geochart", "geochart();", true);

        ScriptManager.RegisterStartupScript(this, this.GetType(), "createCharts", "weeklyavg();", true);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "active", "active();", true);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "combo", "combo();", true); 
        
        //getactive(rdbprov.SelectedValue);
        //  getaverageweekly();
    }


    public void getdata()
    {
        DataTable dt = ws.Getdata();
        if(dt!=null && dt.Rows.Count > 0)
        {
            lblcases.Text = dt.Rows[0]["cumulative_cases"].ToString();
            lblAcases.Text = dt.Rows[0]["active_cases"].ToString();
            lbldeath.Text = dt.Rows[0]["cumulative_deaths"].ToString();
            lblrec.Text = dt.Rows[0]["cumulative_recovered"].ToString();

            lblcases2.Text = dt.Rows[0]["cases"].ToString() +" (new)";
            lblAcases2.Text = dt.Rows[0]["active_cases_change"].ToString()+" +";
            lbldeath2.Text = dt.Rows[0]["deaths"].ToString() + " (new)";
            lblrec2.Text = dt.Rows[0]["recovered"].ToString() + " (new)";

        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "counter", "counter();", true);

    }
    [WebMethod]
    public static List<ChartDetails> Getaverageweekly()
    {
        DataTable dt = WebService.Getdataactive();
        string[] selectedColumns = new[] { "cases", "province" };
        DataTable dt1 = new DataView(dt).ToTable(false, selectedColumns);


        var data = dt1.AsEnumerable();

        var query = from d in data
                    group d by d.Field<string>("province") into g
                    select new
                    {
                        Prov = g.Key,
                        Avg =g.Average(e => (e.Field<long>("cases")))
                    };

        DataTable dt2 = new DataTable();
        dt2.Columns.Add("Province");
        dt2.Columns.Add("Cases");
        foreach (var q in query)
        {
            DataRow dr = dt2.NewRow();
            dr["Province"] = q.Prov;
            dr["Cases"] = q.Avg;
            dt2.Rows.Add(dr);
        }

        dt2.Rows[0]["Province"] = "Alberta";
        dt2.Rows[1]["Province"] = "British Columbia";
        dt2.Rows[2]["Province"] = "Manitoba";
        dt2.Rows[3]["Province"] = "New Brunswick";
        dt2.Rows[4]["Province"] = "Newfoundland and Labrador";
        dt2.Rows[5]["Province"] = "Nova Scotia";
        dt2.Rows[6]["Province"] = "Nunavut";
        dt2.Rows[7]["Province"] = "Northwest Territories";
        dt2.Rows[8]["Province"] = "Ontario";
        dt2.Rows[9]["Province"] = "Prince Edward Island";
        dt2.Rows[10]["Province"] = "Quebec";
        dt2.Rows[11]["Province"] = "Saskatchewan";
        dt2.Rows[12]["Province"] = "Yukon";


        List<ChartDetails> dataList = new List<ChartDetails>();

        foreach (DataRow dtrow in dt2.Rows)
        {
            ChartDetails details = new ChartDetails();
            details.province = dtrow[0].ToString();
            details.average = Math.Ceiling(Convert.ToDecimal(dtrow[1].ToString()));
            dataList.Add(details);
          }

        return dataList;
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "average", "drawchart('" + dataList + "');", true);

    }

    [WebMethod]
    public static List<ChartDetails> getactive(string Prov)
    {

        DataTable dt1 = null;
        DataTable dt3 = null;

        if (HttpContext.Current.Session["getactive1"] != null && HttpContext.Current.Session["getactive2"] != null)
        {
            dt1 = (DataTable)HttpContext.Current.Session["getactive1"];
            dt3 = (DataTable)HttpContext.Current.Session["getactive2"];

        }
        else
        {
            DataTable dt = WebService.Getdataactiveprov();
            string[] selectedColumns = new[] { "cases", "date_report", "province" };
             dt1 = new DataView(dt).ToTable(false, selectedColumns);

            DataTable dt2 = WebService.getrecovered();
            string[] selectedColumns2 = new[] { "recovered", "date_recovered", "province" };
             dt3 = new DataView(dt2).ToTable(false, selectedColumns2);

            HttpContext.Current.Session["getactive1"] = dt1;
            HttpContext.Current.Session["getactive2"] = dt3;
        }

        dt1 = dt1.Select("province = '" + Prov + "'", "date_report ASC").CopyToDataTable();
        dt3 = dt3.Select("province = '" + Prov + "'", "date_recovered ASC").CopyToDataTable();


        var temp = dt1.AsEnumerable().OrderBy(x =>DateTime.ParseExact(x.Field<string>("date_report"), "dd-MM-yyyy", CultureInfo.InvariantCulture))
            .GroupBy(grp => new { Month = Convert.ToDateTime(grp["date_report"]).Month})
                                  .Select(val =>
                                  {
                                      var row = dt1.NewRow();

                                      row["cases"] = val.Sum(amt => Convert.ToDecimal(amt["cases"]));
                                      row["date_report"] = val.FirstOrDefault()["date_report"];
                                      return row;
                                  }
                                      )
                                  .CopyToDataTable();

        var temp2 = dt3.AsEnumerable().OrderBy(x => DateTime.ParseExact(x.Field<string>("date_recovered"), "dd-MM-yyyy", CultureInfo.InvariantCulture))
            .GroupBy(grp => new { Month = Convert.ToDateTime(grp["date_recovered"]).Month })
                                  .Select(val =>
                                  {
                                      var row = dt3.NewRow();

                                      row["recovered"] = val.Sum(amt => Convert.ToDecimal(amt["recovered"]));
                                      row["date_recovered"] = val.FirstOrDefault()["date_recovered"];
                                      return row;
                                  }
                                      )
                                  .CopyToDataTable();
        temp.Columns.Add("recovered");
        for (int i = 0; i < temp2.Rows.Count; i++)
        {
            temp.Rows[i]["recovered"] = temp2.Rows[i]["recovered"];
        }
        List<ChartDetails> dataList = new List<ChartDetails>();

        

        foreach (DataRow dtrow in temp.Rows)
        {
            ChartDetails details = new ChartDetails();
            details.cases = Convert.ToDecimal(dtrow[0].ToString());
            details.recovered = Convert.ToDecimal(dtrow[3].ToString());

            details.date = (Convert.ToDateTime(dtrow[1].ToString()).ToString("MMM"));
            dataList.Add(details);
        }
        
        var data1 = JsonConvert.SerializeObject(dataList);
        return dataList;
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "active", "active('"+data1+"');", true);
    }


    [WebMethod]
    public static List<ChartDetails> getgeomapdata()
    {
        DataTable dt = WebService.getgeomap();
        string[] selectedColumns = new[] { "active_cases", "province", "date_active" };
        DataTable dt1 = new DataView(dt).ToTable(false, selectedColumns);

        dt1.Rows[0]["province"] = "Alberta";
        dt1.Rows[1]["province"]="British Columbia";
        dt1.Rows[2]["province"]="Manitoba";
        dt1.Rows[3]["province"]= "New Brunswick";
        dt1.Rows[4]["province"] = "Newfoundland and Labrador";
        dt1.Rows[5]["province"]="Nova Scotia";
        dt1.Rows[6]["province"]="Nunavut";
        dt1.Rows[7]["province"] = "Northwest Territories";
        dt1.Rows[8]["province"] = "Ontario";
        dt1.Rows[9]["province"]="Prince Edward Island";	
        dt1.Rows[10]["province"]="Quebec";
        dt1.Rows[11]["province"]="Saskatchewan";
        dt1.Rows[12]["province"]="Yukon";
        dt1.Rows[13]["province"]="Repatriated Travellers";

        List<ChartDetails> dataList = new List<ChartDetails>();

        foreach (DataRow dtrow in dt1.Rows)
        {
            ChartDetails details = new ChartDetails();
            details.cases = Convert.ToDecimal(dtrow[0].ToString());
            details.province = (dtrow[1].ToString());
            details.date1 = Convert.ToInt32(Convert.ToDateTime(dtrow[2].ToString()).ToString("dd"));
            dataList.Add(details);
        }
        var data1 = JsonConvert.SerializeObject(dataList);
        return dataList;
    }

    [WebMethod]
    public static List<ChartDetails> Getcombo(string Prov)
    {
        DataTable dt3 = null;

        if (HttpContext.Current.Session["getcombo"] != null )
        {
            dt3 = (DataTable)HttpContext.Current.Session["getcombo"];

        }
        else
        {
            DataTable dt2 = WebService.getmortality();
            string[] selectedColumns2 = new[] { "deaths", "date_death_report", "province" };
             dt3 = new DataView(dt2).ToTable(false, selectedColumns2);
        }
       
        dt3 = dt3.Select("province = '" + Prov + "'", "date_death_report ASC").CopyToDataTable();

       
        
        var temp2 = dt3.AsEnumerable().OrderBy(x => DateTime.ParseExact(x.Field<string>("date_death_report"), "dd-MM-yyyy", CultureInfo.InvariantCulture))
            .GroupBy(grp => new { Month = Convert.ToDateTime(grp["date_death_report"]).Month })
                                  .Select(val =>
                                  {
                                      var row = dt3.NewRow();

                                      row["deaths"] = val.Sum(amt => Convert.ToDecimal(amt["deaths"]));
                                      row["date_death_report"] = val.FirstOrDefault()["date_death_report"];
                                      return row;
                                  }
                                      )
                                  .CopyToDataTable();


      
        List <ChartDetails> dataList = new List<ChartDetails>();

        foreach (DataRow dtrow in temp2.Rows)
        {
            ChartDetails details = new ChartDetails();
            details.deaths = Convert.ToDecimal(dtrow[0].ToString()); 
            details.date = Convert.ToDateTime(dtrow[1].ToString()).ToString("MMM");
            dataList.Add(details);
        }
        
        var data1 = JsonConvert.SerializeObject(dataList);
        return dataList;
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "active", "active('"+data1+"');", true);
    }

}





public class ChartDetails
{
    public string province { get; internal set; }
    public decimal average { get; internal set; }
    public decimal cases { get; internal set; }
    public string date { get; internal set; }

    public Int32 date1{ get; internal set; }
    public decimal deaths { get; internal set; }
    public decimal recovered { get; internal set; }
}




