
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

[DataContract]
public class Synchr
{
    [DataMember]
    public string UserId { get; set; }
    public string Customer_Id { get; set; }
    public string Dairy_Code { get; set; }
    public string Dairy_Name { get; set; }
    public string Customer_Name { get; set; }
    public string City { get; set; }
    public string Add1 { get; set; }
    public string Email { get; set; }
    public string AdharNo { get; set; }
    public string PanNo { get; set; }
    public string Jdate { get; set; }
    public string Designation { get; set; }
    public string Qualification { get; set; }
    public string UserType { get; set; }
    public string Grade { get; set; }
    public string BDate { get; set; }

    public string Center_Code { get; set; }
    public string MPin { get; set; }
    public string Insertted { get; set; }
    public string Photo { get; set; }

    public string date { get; set; }
    public string InTime { get; set; }
    public string latitude { get; set; }
    public string longitude { get; set; }
    public string imeinumber { get; set; }

    public string AttechFileName { get; set; }
    public string Comment { get; set; }

}



public class Synchronize_data : System.Web.Services.WebService
{
    String constr = System.Configuration.ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
    private WebProxy objProxy1 = null;
    ConnectionSql con = new ConnectionSql();
    public Synchronize_data()
    {

    }


    ////////////////////////////////////////// LOGIN //////////////////////////////////////////////////////////////////

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string UpdateProfile(string DataTableValue)
    {
        DataTable Main_table = JsonConvert.DeserializeObject<DataTable>(DataTableValue);
        string data = "";
        Synchr[] obj = new Synchr[1];
        obj[0] = new Synchr();
        obj[0].Insertted = data;
        return new JavaScriptSerializer().Serialize(obj);
    }


}