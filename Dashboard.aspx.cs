using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    ConnectionSql con = new ConnectionSql();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
                display();
    }

    public void display()
    {
        SortedList s = new SortedList();
        s.Add("@mode", "Display");
        DataTable dt = con.GetDataTableSP("SP_Post", s);
        if (dt != null && dt.Rows.Count > 0)
        {
            datalist1.DataSource = dt;
            datalist1.DataBind();

        }
    }


    protected void lnkimage_Click(object sender, EventArgs e)
    {

    }

    protected void txtsearch_TextChanged(object sender, EventArgs e)
    {
        //txtsearch.Attributes.Add("onkeydown", "return (event.keyCode!=13);");

        string query = "select *,DATEDIFF(DAY, IDate,cast(getdate() as date))" +
        "AS days from dbo.Post where City like '%" + txtsearch.Text + "%'or " +
       "Province like  '%" + txtsearch.Text + "%' or category like '%" + txtsearch.Text + "%' "+
       "or Title like '%" + txtsearch.Text + "%'";

        DataTable dt = con.GetSelectQuety(query);
        
        datalist1.DataSource = dt;
        datalist1.DataBind();
    }
}