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

    }

    protected void lnkpass_Click(object sender, EventArgs e)
    {
        divpass.Visible = true;
        divinfo.Visible = false;
        lnkpass.Style.Add("color", "#41b3a3");
        lnkinfo.Style.Add("color", "#565656");
        lnkpass.Style.Add("font-size", "23px");
        lnkinfo.Style.Add("font-size", "16px");


    }

    protected void lnkinfo_Click(object sender, EventArgs e)
    {
        divpass.Visible = false;
        divinfo.Visible = true;
        lnkinfo.Style.Add("color", "#41b3a3");
        lnkpass.Style.Add("color", "#565656");
        lnkinfo.Style.Add("font-size", "23px");
        lnkpass.Style.Add("font-size", "16px");

        display();
      
    }

    protected void btnpsubmit_Click(object sender, EventArgs e)
    {
        DataTable dt = con.GetSelectQuety("select * from Registration where Id='" + Session["Id"].ToString() + "' and Pass='" + txtcpass.Text + "'");
        if(dt!=null && dt.Rows.Count > 0)
        {
            SortedList s = new SortedList();              
            s.Add("@mode", "Updatepass");
            s.Add("@Id", Session["Id"].ToString());
            s.Add("@Pass", txtnpass.Text);


            int i = con.ExecuteNonQuerySP("SP_Registration", s);
            if (i > 0)
            {
                Label2.Text = "Password updated successfully";
            }

            else
            {
                Label2.Text = "some error occured";
            }
        }
    }

    protected void btnpcancel_Click(object sender, EventArgs e)
    {

    }

    protected void btnicancel_Click(object sender, EventArgs e)
    {

    }

    protected void btnisubmit_Click(object sender, EventArgs e)
    {
        SortedList s = new SortedList();
        s.Add("@mode", "Update");
        s.Add("@Id", Session["Id"].ToString());
        s.Add("@FName", txtfname.Text.ToUpper());
        s.Add("@Lname", txtlname.Text.ToUpper());
        s.Add("@Email", txtemail.Text);
        s.Add("@PNo", txtphone.Text);
        s.Add("@City", txtcity.Text);
       

        int i = con.ExecuteNonQuerySP("SP_Registration", s);
        if (i > 0)
        {
            Label1.Text = "Data updated successfully";
            display();
        }

        else
        {
            Label1.Text = "some error occured";
            display();
        }
    }


    public void display()
    {
        DataTable dt = con.GetSelectQuety("select * from Registration where Id='" + Session["Id"].ToString() + "'");
        if (dt != null && dt.Rows.Count > 0)
        {
            txtlname.Text = dt.Rows[0]["FName"].ToString();
            txtfname.Text = dt.Rows[0]["LName"].ToString();
            txtemail.Text = dt.Rows[0]["Email"].ToString();
            txtcity.Text = dt.Rows[0]["City"].ToString();
            txtphone.Text = dt.Rows[0]["PNo"].ToString();

        }
    }
}