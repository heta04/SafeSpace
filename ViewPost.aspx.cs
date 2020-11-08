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
        if(!IsPostBack)
        display();
    }


    public void display()
    {
        SortedList s = new SortedList();
        s.Add("@mode", "Display");
        DataTable dt = con.GetDataTableSP("SP_Post", s);
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
        s.Add("@CId", ViewState["CId"]);


        int i = con.ExecuteNonQuerySP("SP_Post", s);
        if (i > 0)
        {
            Label1.Text = "Data updated successfully"; 
        }

        else
            Label1.Text = "some error encountered";

    }

    protected void btncancel_Click(object sender, EventArgs e)
    {

    }

    public void display2()
    {
        DataTable dt = con.GetSelectQuety("select * from Post where CId='" + ViewState["CId"] + "'");
        if(dt!=null && dt.Rows.Count > 0)
        {
            txtfname.Text = dt.Rows[0]["FName"].ToString();
            txtlname.Text= dt.Rows[0]["LName"].ToString(); ;
            txtemail.Text = dt.Rows[0]["Email"].ToString(); ;
            txtpno.Text  = dt.Rows[0]["PNo"].ToString(); ;
            txtadd.Text = dt.Rows[0]["Address"].ToString(); ;
            txtcity.Text = dt.Rows[0]["City"].ToString(); ;
            txtcountry.Text = dt.Rows[0]["Country"].ToString(); 
            txtprovince.Text= dt.Rows[0]["Province"].ToString(); 
            ddlcatageory.Text= dt.Rows[0]["category"].ToString(); 
            txttitle.Text= dt.Rows[0]["Title"].ToString(); 
            txtDesc.Text= dt.Rows[0]["Description"].ToString(); 
            txtzipcode.Text= dt.Rows[0]["ZipCode"].ToString();


            txtfname.Enabled = false;
            txtlname.Enabled = false;
            txtemail.Enabled = false;
            txtpno.Enabled = false;
            txtadd.Enabled = false;
            txtcity.Enabled = false;
            txtcountry.Enabled = false;
            txtprovince.Enabled = false;
            ddlcatageory.Enabled = false;
            txttitle.Enabled = false;
            txtDesc.Enabled = false;
            txtzipcode.Enabled = false;
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ViewState["CId"] = null;
        if (e.CommandName.ToString() == "Editclick")
        {
            ViewState["CId"] = e.CommandArgument.ToString();
            divpopup.Style.Add("display", "block");
        }
        else if (e.CommandName.ToString() == "Viewclick")
        {
            ViewState["CId"] = e.CommandArgument.ToString();
            divpopup.Style.Add("display", "block");

            btnupdate.Visible = false;
            btncancel.Visible = false;
            display2();
        }
        else if (e.CommandName.ToString() == "Deleteclick")
        {
            ViewState["CId"] = e.CommandArgument.ToString();
            int i = con.ExecuteNonQuery1("Delete from Post where CId='" + ViewState["CId"].ToString() + "'");
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
        divpopup.Style.Add("display", "block");
    }
}