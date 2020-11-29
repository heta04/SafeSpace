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
       // ScriptManager.RegisterStartupScript(this, GetType(), "alert", "myfunction();", true);


        if (!IsPostBack) 
            display();
    }


    public void display()
    {
        DataTable dt = con.GetSelectQuety("Select * from Post where CId='"+Session["Id"].ToString()+"'");
        if (dt != null && dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
    }

  
   
    protected void btnclose_Click(object sender, ImageClickEventArgs e)
    {
        divpopup.Visible = false;
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        SortedList s = new SortedList();
        s.Add("@mode", "Update");
        s.Add("@FName", txtfname.Text.ToUpper());
        s.Add("@Lname", txtlname.Text.ToUpper());
        s.Add("@Email", txtemail.Text);
        s.Add("@PNo", txtpno.Text);
        s.Add("@Address", txtadd.Text);
        s.Add("@City", txtcity.Text);
        s.Add("@Country", txtcountry.Text);
        s.Add("@Province", txtprovince.Text);
        s.Add("@category", ddlcatageory.Text);
        s.Add("@Title", txttitle.Text);
        s.Add("@Description", txtDesc.Text);
        s.Add("@ZipCode", txtzipcode.Text);
        s.Add("@Id", ViewState["Id"]);


        int i = con.ExecuteNonQuerySP("sp_post", s);
        if (i > 0)
        {
            Response.Write("<script>alert('data updated succesfully');</script>");

            display();
        }

        else
            Response.Write("<script>alert('some error occured !!!');</script>");

    }

    protected void btncancel_Click(object sender, EventArgs e)
    {

    }

    public void display2()
    {
        DataTable dt = con.GetSelectQuety("select * from Post where Id='" + ViewState["Id"].ToString() + "'");
        if(dt!=null && dt.Rows.Count > 0)
        {
            Response.Write("<script>alert('some error occured !!!');</script>");

            txtfname.Text = dt.Rows[0]["FName"].ToString();
            txtlname.Text= dt.Rows[0]["LName"].ToString(); 
            txtemail.Text = dt.Rows[0]["Email"].ToString(); 
            txtpno.Text  = dt.Rows[0]["PNo"].ToString(); 
            txtadd.Text = dt.Rows[0]["Address"].ToString(); 
            txtcity.Text = dt.Rows[0]["City"].ToString(); 
            txtcountry.Text = dt.Rows[0]["Country"].ToString(); 
            txtprovince.Text= dt.Rows[0]["Province"].ToString(); 
            ddlcatageory.Text= dt.Rows[0]["category"].ToString(); 
            txttitle.Text= dt.Rows[0]["Title"].ToString(); 
            txtDesc.Text= dt.Rows[0]["Description"].ToString(); 
            txtzipcode.Text= dt.Rows[0]["ZipCode"].ToString();

        //    txtfname.ReadOnly = true;
        //    txtlname.ReadOnly = true;
        //    txtemail.ReadOnly = true;
        //    txtpno.ReadOnly = true;
        //    txtadd.ReadOnly = true;
        //    txtcity.ReadOnly = true;
        //    txtcountry.ReadOnly = true;
        //    txtprovince.ReadOnly = true;
        //    txttitle.ReadOnly = true;
        //    txtDesc.ReadOnly = true;
        //    txtzipcode.ReadOnly = true;
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ViewState["Id"] = null;
        if (e.CommandName.ToString() == "Editclick")
        {

            ViewState["Id"] = e.CommandArgument.ToString();
            mp1.Show();
            display2();

            
            

        }
        else if (e.CommandName.ToString() == "Viewclick")
        {
            ViewState["Id"] = e.CommandArgument.ToString();
          
            btnupdate.Visible = false;
            btncancel.Visible = false;
            mp1.Show();
            display2();
        }
        else if (e.CommandName.ToString() == "Deleteclick")
        {
            ViewState["Id"] = e.CommandArgument.ToString();
            int i = con.ExecuteNonQuery1("Delete from Post where Id='" + ViewState["Id"].ToString() + "'");
            if (i > 0)
            {
                Response.Write("<script>alert('data deleted successfully');</script>");
                display();
            }
            else
            {
                Response.Write("<script>alert('some error occured !!! cannot delete data');</script>");
                display();
            }
        }

    }

    protected void btnedit_Click(object sender, ImageClickEventArgs e)
    {
       // divpopup.Style.Add("display", "block");
    }

    protected void Unnamed_Click(object sender, ImageClickEventArgs e)
    {

    }
}