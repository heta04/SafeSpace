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
}