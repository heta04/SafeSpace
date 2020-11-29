using System;
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
        Button btndashboard = (Button)Page.Master.FindControl("btndashboard");
        Button btnpost = (Button)Page.Master.FindControl("btnpost");
        Button btnsignin = (Button)Page.Master.FindControl("btnsignin");
        Button btncovid = (Button)Page.Master.FindControl("btncovid");
        Button btnabout = (Button)Page.Master.FindControl("btnabout");


        btndashboard.Visible = false;
        btnpost.Visible = false;
        btnsignin.Visible = false;
        btnabout.Visible = false;
        btncovid.Visible = false;
    }

    protected void signup_Click(object sender, EventArgs e)
    {
        Response.Redirect("Registration.aspx");
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        DataTable dt = con.GetSelectQuety("Select * from Registration where Email='" + txtemail.Text + "' and Pass='" + txtpass.Text + "'");
        if (dt != null && dt.Rows.Count > 0)
        {
            Session["Name"] = dt.Rows[0]["FName"].ToString() + " " + dt.Rows[0]["LName"].ToString();
            Session["Id"] = dt.Rows[0]["Id"].ToString();
            Response.Redirect("Dashboard.aspx?Id=" + dt.Rows[0]["Id"].ToString() + "&Name=" + dt.Rows[0]["FName"].ToString() + "+ +" + dt.Rows[0]["LName"].ToString() + "");
            
        }
        else
            Label1.Text = "Invalid Credentials";

     }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        txtemail.Text = "";
        txtpass.Text = "";
    }
}