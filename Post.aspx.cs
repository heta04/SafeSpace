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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SortedList s = new SortedList();
        s.Add("@mode", "Insert");
        s.Add("@FName", txtFName.Text.ToUpper());
        s.Add("@Lname", txtLName.Text.ToUpper());
        s.Add("@Email", txtemail.Text);
        s.Add("@PNo", txtPNo.Text);
        s.Add("@Address", txtAdd.Text);
        s.Add("@City", txtCity.Text);
        s.Add("@Country", txtCountry.Text);
        s.Add("@Province", txtProvince.Text);
        s.Add("@category", ddlcatageory.Text);
        s.Add("@Title", txttitle.Text);
        s.Add("@Description", txtDesc.Text);
        s.Add("@ZipCode", txtZip.Text);
        s.Add("@CId", Session["Id"]);


        int i = con.ExecuteNonQuerySP("SP_Post",s);
        if (i > 0)
        {
            Response.Write("<script>alert('Data Posted Successfully');</script>");
            Response.Redirect("dashboard.aspx");
        }

        else
            Response.Write("<script>alert('Some error Encountered');</script>");


      

    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        txtFName.Text = "";
        txtLName.Text = "";
        txtPNo.Text = "";
        txtProvince.Text = "";
        txtCity.Text = "";
        txtAdd.Text = "";
        txtemail.Text = "";
        txtDesc.Text = "";
        txttitle.Text = "";
        txtZip.Text = "";


    }


    public void display()
    {
        DataTable dt = con.GetSelectQuety("select * from Registration where Id='" + Session["Id"].ToString() + "'");
        if (dt != null && dt.Rows.Count > 0)
        {
            txtFName.Text = dt.Rows[0]["FName"].ToString();
            txtLName.Text = dt.Rows[0]["LName"].ToString();
            txtemail.Text = dt.Rows[0]["Email"].ToString();
            txtCity.Text = dt.Rows[0]["City"].ToString();
            txtPNo.Text = dt.Rows[0]["PNo"].ToString();

        }
    }
}