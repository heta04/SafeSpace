using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Xml;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{
    ConnectionSql con = new ConnectionSql();
    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public DataTable Getdata()
    {
        var jsonString = new WebClient().DownloadString("https://api.opencovid.ca/");
        string query = "SELECT JSON_QUERY('" + jsonString + "', '$.summary') AS 'Result'";
        DataTable dt = con.GetSelectQuety(query);
        DataTable Main_table=null;
        //json eg: [{"active_cases":60691,"active_cases_change":990,"cases":5286,"cumulative_cases":345733,"cumulative_deaths":11651.0,"cumulative_recovered":273391.0,"cumulative_testing":12296446.0,"date":"24-11-2020","deaths":104.0,"province":"Canada","recovered":4192.0,"testing":69742.0,"testing_info":"NULL"}],"version":"2020-11-24 21:33 EST"}] 
        if (dt != null && dt.Rows.Count > 0)
        {
             Main_table = JsonConvert.DeserializeObject<DataTable>(dt.Rows[0]["Result"].ToString());
        }
        return Main_table;
    }

    public static DataTable Getdataactive()
    {
        string before = DateTime.Today.ToString("dd-MM-yyyy");
        string after = DateTime.Today.AddDays(-7).ToString("dd-MM-yyyy");
        string s1 = "https://api.opencovid.ca/timeseries?stat=cases&after=" + after + "&before=" + before + "";
        var jsonString = new WebClient().DownloadString("https://api.opencovid.ca/timeseries?stat=cases&after=" + after + "&before=" + before + "");

        // List<User> UserList = JsonConvert.DeserializeObject<List<User>>(jsonString);
        var jsonLinq = JObject.Parse(jsonString);

        // Find the first array using Linq
        var srcArray = jsonLinq.Descendants().Where(d => d is JArray).First();
        var trgArray = new JArray();
        foreach (JObject row in srcArray.Children<JObject>())
        {
            var cleanRow = new JObject();
            foreach (JProperty column in row.Properties())
            {
                // Only include JValue types
                if (column.Value is JValue)
                {
                    cleanRow.Add(column.Name, column.Value);
                }
            }

            trgArray.Add(cleanRow);
        }
        string s = trgArray.ToString();

        DataTable dt = JsonConvert.DeserializeObject<DataTable>(trgArray.ToString());
        return dt;
    
    }

    public static DataTable Getdataactiveprov()
    {
        string before = DateTime.Today.ToString("dd-MM-yyyy");
        string after = DateTime.Today.AddMonths(-6).ToString("dd-MM-yyyy");
        var jsonString = new WebClient().DownloadString("https://api.opencovid.ca/timeseries?stat=cases&after=" + after + "&before=" + before + "");

        // List<User> UserList = JsonConvert.DeserializeObject<List<User>>(jsonString);
        var jsonLinq = JObject.Parse(jsonString);

        // Find the first array using Linq
        var srcArray = jsonLinq.Descendants().Where(d => d is JArray).First();
        var trgArray = new JArray();
        foreach (JObject row in srcArray.Children<JObject>())
        {
            var cleanRow = new JObject();
            foreach (JProperty column in row.Properties())
            {
                // Only include JValue types
                if (column.Value is JValue)
                {
                    cleanRow.Add(column.Name, column.Value);
                }
            }

            trgArray.Add(cleanRow);
        }
        string s = trgArray.ToString();

        DataTable dt = JsonConvert.DeserializeObject<DataTable>(trgArray.ToString());
        return dt;

    }

    public static DataTable getgeomap()
    {
        string date = DateTime.Today.AddDays(-2).ToString("dd-MM-yyyy");
        var jsonString = new WebClient().DownloadString("https://api.opencovid.ca/timeseries?stat=active&date="+date+"");

        // List<User> UserList = JsonConvert.DeserializeObject<List<User>>(jsonString);
        var jsonLinq = JObject.Parse(jsonString);

        // Find the first array using Linq
        var srcArray = jsonLinq.Descendants().Where(d => d is JArray).First();
        var trgArray = new JArray();
        foreach (JObject row in srcArray.Children<JObject>())
        {
            var cleanRow = new JObject();
            foreach (JProperty column in row.Properties())
            {
                // Only include JValue types
                if (column.Value is JValue)
                {
                    cleanRow.Add(column.Name, column.Value);
                }
            }

            trgArray.Add(cleanRow);
        }
        string s = trgArray.ToString();

        DataTable dt = JsonConvert.DeserializeObject<DataTable>(trgArray.ToString());
        return dt;

    }

    public static DataTable getmortality()
    {

        string before = DateTime.Today.ToString("dd-MM-yyyy");
        string after = DateTime.Today.AddMonths(-6).ToString("dd-MM-yyyy");
        var jsonString = new WebClient().DownloadString("https://api.opencovid.ca/timeseries?stat=mortality&after=" + after + "&before=" + before + "");
     
        // List<User> UserList = JsonConvert.DeserializeObject<List<User>>(jsonString);
        var jsonLinq = JObject.Parse(jsonString);

        // Find the first array using Linq
        var srcArray = jsonLinq.Descendants().Where(d => d is JArray).First();
        var trgArray = new JArray();
        foreach (JObject row in srcArray.Children<JObject>())
        {
            var cleanRow = new JObject();
            foreach (JProperty column in row.Properties())
            {
                // Only include JValue types
                if (column.Value is JValue)
                {
                    cleanRow.Add(column.Name, column.Value);
                }
            }

            trgArray.Add(cleanRow);
        }
        string s = trgArray.ToString();

        DataTable dt = JsonConvert.DeserializeObject<DataTable>(trgArray.ToString());
        return dt;

    }

    public static DataTable getrecovered()
    {

        string before = DateTime.Today.ToString("dd-MM-yyyy");
        string after = DateTime.Today.AddMonths(-6).ToString("dd-MM-yyyy");
        var jsonString = new WebClient().DownloadString("https://api.opencovid.ca/timeseries?stat=recovered&after=" + after + "&before=" + before + "");

        // List<User> UserList = JsonConvert.DeserializeObject<List<User>>(jsonString);
        var jsonLinq = JObject.Parse(jsonString);

        // Find the first array using Linq
        var srcArray = jsonLinq.Descendants().Where(d => d is JArray).First();
        var trgArray = new JArray();
        foreach (JObject row in srcArray.Children<JObject>())
        {
            var cleanRow = new JObject();
            foreach (JProperty column in row.Properties())
            {
                // Only include JValue types
                if (column.Value is JValue)
                {
                    cleanRow.Add(column.Name, column.Value);
                }
            }

            trgArray.Add(cleanRow);
        }
        string s = trgArray.ToString();

        DataTable dt = JsonConvert.DeserializeObject<DataTable>(trgArray.ToString());
        return dt;

    }

}


