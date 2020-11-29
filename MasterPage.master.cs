using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Id"] != null)
            {

                lblname1.Text = Session["Name"].ToString();
                lblname2.Text = Session["Name"].ToString();

                divprofile.Visible = true;
                divsignin.Visible = false;

            }
            else
            {
                divprofile.Visible = false;
                divsignin.Visible = true;
            }
        }
    }

    protected void btndashboard_Click(object sender, EventArgs e)
    {
        Response.Redirect("dashboard.aspx");
    }

    protected void btnpost_Click(object sender, EventArgs e)
    {
        if(Session["Id"]!=null)
             Response.Redirect("Post.aspx");
        else
            Response.Redirect("Login.aspx");

    }

    protected void btnprofile_Click(object sender, EventArgs e)
    {
        Response.Redirect("Profile.aspx");
    }

    protected void btnmypost_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewPost.aspx");

    }

    protected void btnlogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Dashboard.aspx");
    }

    protected void btnlogout_Click(object sender, EventArgs e)
    {
        Session["Id"] = null;
        Session["Name"] = null;

        Response.Redirect("Dashboard.aspx");
       }

    protected void btnsignin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

    protected void btnabout_Click(object sender, EventArgs e)
    {
        
        ScriptManager.RegisterStartupScript(this,this.GetType(), "popup", "window.open('About/SS_Documentation.pdf' ,'_blank');", true);
    }

    protected void btncovid_Click(object sender, EventArgs e)
    {
        Response.Redirect("Covid_19.aspx");

    }

    
    protected void btnlogo_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Dashboard.aspx");

    }
}
