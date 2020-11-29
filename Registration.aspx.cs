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

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        DataTable dt = con.GetSelectQuety("Select * from Registration where Email='" + txtemail.Text + "'");
        if (dt != null && dt.Rows.Count > 0)
        {
            Label1.Text = "Email Id already registered";
        }
        else
        {
            SortedList s = new SortedList();
            s.Add("@mode", "Insert");
            s.Add("@FName", txtfname.Text.ToUpper());
            s.Add("@Lname", txtlname.Text.ToUpper());
            s.Add("@Email", txtemail.Text);
            s.Add("@PNo", txtpnumber.Text);
            s.Add("@City", txtcity.Text);
            s.Add("@Pass", txtpass.Text);


            int i = con.ExecuteNonQuerySP("SP_Registration", s);
            if (i > 0)
            {
                Response.Write("<script>alert('Registered Successfully');</script>");
                Response.Redirect("Login.aspx");
            }

            else
                Response.Write("<script>alert('Some error Encountered');</script>");

        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtfname.Text = "";
        txtlname.Text = "";
        txtemail.Text = "";
        txtcity.Text = "";
        txtpnumber.Text = "";
        txtpass.Text = "";
        txtrpass.Text = "";


    }

    protected void lnklogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}