using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;
using System.Collections;
using System.Net;
using System.Text.RegularExpressions;
using System.Configuration;



/// <summary>
/// Summary description for Function
/// </summary>

public class Function
{


    public string DuplicateMessage = "Record already exists..";
    public string AuthMsgInsert = "Sorry,You do not  have permission to insert...";//You are not authorize for insert";
    public string AuthMsgUpdate = "Sorry,You do not  have permission to update...";//You are not authorize for update";

    public string InsertMessage = "Record successfully inserted!";
    public string ErrorMessage = "Some error occured. Please try again!";
    public string DeleteMessage = "Record successfully deleted.";
    public string UpdatedMessage = "Record successfully updated.";
    public string ActiveMessage = "Record successfully activated.";
    public string DeActiveMessage = "Record successfully deactivated.";
    public string TestMessage = "Test generated successfully.";
    public string QuestionPaperSet = "Now Question Paper is Set for Examination.";
    public string RecordNotAvailable = "Record not avaliable.";
    public string UploadStatus = "Upload status: File uploaded successfully.";
    public string Duplicate = "Duplicate Records Founds";

    public DateTime Current_datetime = System.DateTime.Now.AddMinutes(750);



    public Function()
    {

    }


    public string dateTimeWithZero(string str)
    {
        string dt = "";
        if (str.Length > 0)
        {
            //27/12/2007
            string mm, dd, yyyy;
            string[] str1 = str.Split('.');
            dd = str1[0];
            mm = str1[1];
            yyyy = str1[2];
            //======== Change By Vishal (14 08 2008 8:57 AM)===========
            if (dd.Length < 2)
            {
                dd = "0" + dd;
            }
            if (mm.Length < 2)
            {
                mm = "0" + mm;
            }
            if (yyyy.Length > 4)
            {
                yyyy = yyyy.Substring(2, 4);
            }
            //=========== End Vishal Changes ===========================
            dt = yyyy + "-" + mm + "-" + dd + " " + str1[3];
        }
        return dt;
    }
    public string DateFormatWithMMDDYY(string str)
    {
        string dt = "";
        if (str.Length > 0)
        {
            //27/12/2007
            string mm, dd, yyyy;
            string[] str1 = str.Split('.');
            dd = str1[0];
            mm = str1[1];
            yyyy = str1[2];

            if (yyyy.Length > 4)
            {
                yyyy = yyyy.Substring(0, 4);
            }
            if (mm.Length < 2)
            {
                mm = "0" + mm;
            }
            if (dd.Length < 2)
            {
                dd = "0" + dd;
            }

            dt = yyyy + "-" + mm + "-" + dd;
        }
        return dt;
    }
    public string dateTimeconvert24(string str)
    {
        string dt = "";
        if (str.Length > 0)
        {
            //27/12/2007
            string mm, dd, yyyy;
            string[] str1 = str.Split('.');
            dd = str1[0];
            mm = str1[1];
            yyyy = str1[2];
            //======== Change By Vishal (14 08 2008 8:57 AM)===========
            if (dd.Length < 2)
            {
                dd = "0" + dd;
            }
            if (mm.Length < 2)
            {
                mm = "0" + mm;
            }
            if (yyyy.Length > 4)
            {
                yyyy = yyyy.Substring(2, 4);
            }
            //=========== End Vishal Changes ===========================
            if (str1[3].IndexOf('A') >= 0)
            {
                dt = dd + "/" + mm + "/" + yyyy + " " + str1[3].Substring(0, 5) + ":00";
            }
            else
            {
                if (str1[3].Substring(0, 2) == "12")
                    dt = dd + "/" + mm + "/" + yyyy + " " + str1[3].Substring(0, 5) + ":00";
                else
                    dt = dd + "/" + mm + "/" + yyyy + " " + Convert.ToString(Convert.ToInt32(str1[3].Substring(0, 2)) + 12) + str1[3].Substring(2, 3) + ":00";
            }
        }
        return dt;
    }


    public DataTable GetTime(ConnectionSql con)
    {
        SortedList s1 = new SortedList();
        s1.Add("@mode", "BindActive");
        DataTable dt = con.GetDataTableSP("SP_MstShiftMaster", s1);
        return dt;
    }
    public DataTable GetSelectQuety(string query)
    {
        DataTable dt = new DataTable();
        SqlConnection conn = null;
        try
        {
            string connString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            dt.Load(dr);
        }
        catch (SqlException ex)
        {
            // handle error 
        }

        catch (Exception ex)
        {
            // handle error 
        }

        finally
        {
            conn.Close();
        }
        return dt;
    }

    public void DataFormFillUpdate(ConnectionSql con, string Id, string User, string IPAdd)
    {
        SortedList s1 = new SortedList();
        s1.Add("@mode", "UpdateFillFormStatus");
        s1.Add("@Id", Id);
        s1.Add("@UpdatedBy", User);
        s1.Add("@IpAddress", IPAdd);
        con.ExecuteNonQuerySP("SP_Mst_ScheduleMaster", s1);
    }



    public int ActivityCode(string Activity)
    {
        int code = 0;
        if (Activity == "Milk Collection (દૂધ ઉઘરાટ)")
        {
            code = 1;
        }
        else if (Activity == "Supervision (સુપરવિઝન)")
        {
            code = 2;
        }
        else if (Activity == "Route Duty (રૂટ ડ્યુટી)")
        {
            code = 3;

        }
        else if (Activity == "Cluster Visit (કલસ્ટર મુલાકાત)")
        {
            code = 4;
        }
        else if (Activity == "Dock Duty(ડૉક ડ્યુટી)")
        {
            code = 5;
        }
        else if (Activity == "BMC Visit (બી.એમ.સી.મુલાકાત)")
        {
            code = 6;
        }
        else if (Activity == "ISO Internal Audit (આઈ.એસ.ઓં.ઇન્ટર્નલ ઓડીટ)")
        {
            code = 7;
        }
        else if (Activity == "Tanker / Route Checking (ટેન્કર/રૂટ ચેકીંગ)")
        {
            code = 8;
        }
        else if (Activity == "New Society/Center/Branch/Farm Survey (નવિન દુધ મંડળી /કેન્દ્ર /શાખા ફોમ સર્વે)")
        {
            code = 9;
        }
        else if (Activity == "Society AGM Visit (સાધારણ સભા હાજરી)")
        {
            code = 10;
        }
        else if (Activity == "Can Stock Verification (કેન સ્ટોક વેરીફીકેશન)")
        {
            code = 11;
        }
        else if (Activity == "Price Difference Payment Verification (ભાવફેર ચુકવણી ચકાસણી)")
        {
            code = 12;
        }
        else if (Activity == "Tree Plantation Information (વૃક્ષારોપણ મહિતી)")
        {
            code = 13;
        }
        else if (Activity == "Tree Plantation checking (વૃક્ષારોપણ ચકાસણી)")
        {
            code = 14;
        }
        else if (Activity == "Red Tag Day Information (રેડ ટેગ ડે માહિતી)")
        {
            code = 15;
        }
        else if (Activity == "Deworming Campaign Information(કૃમિ નિવારણ અભિયાન માહિતી)")
        {
            code = 16;
        }
        else if (Activity == "Annual Target Information (વાર્ષિક ટારગેટ માહિતી)")
        {
            code = 17;
        }
        else if (Activity == "MIS Information (એમ.આઈ.એસ. માહિતી)")
        {
            code = 18;
        }
        else if (Activity == "Year Detail (દૂધ મંડળી વાર્ષિક માહિતી ફોર્મ)")
        {
            code = 19;
        }
      
        else if (Activity == "Other (અન્ય કામગીરી )")
        {
            code = 20;
        }
        else if (Activity == "MC Meeting (એમ સી મીટીંગ)")
        {
            code = 21;
        }
        else if (Activity == "Director Society Visit (ડીરેક્ટર સોસાયટી વીઝીટ)")
        {
            code = 22;
        }
        else if (Activity == "Director Dcs Visit (ડીરેક્ટર ડીસીએસ વીઝીટ)")
        {
            code = 23;
        }
        else if (Activity == "Supervisor Verification(સુપરવાઈઝર વેરીફિકેશન)")
        {
            code = 24;
        }
        else if (Activity == "Tour Diary(પ્રવાસ નોંધ)")
        {
            code = 25;
        }
        else if (Activity == "Pre Animal Loan Verification(પશુ ધિરાણ પૂર્વે ખરાઈ)")
        {
            code = 26;
        }
         else if (Activity == "DCS Building-Godown Survey(દૂધ ઘર ગોડાઉન સર્વે)")
        {
            code = 27;
        }

        else if (Activity == "Milking Machine Survey(મિલ્કિંગ મશીન સર્વે ફોમ)")
        {
            code = 28;
        }
        else if (Activity == "Post Animal Purchase Verification(પશુ ધિરાણ આપ્યા બાદ ની ખરાઈ)")
        {
            code = 29;
        }
        else if (Activity == "Fooder Seed(ઘાસચારા બિયારણ માહિતી)")
        {
            code = 30;
        }
        else if (Activity == "Sour Curd Society Wise(ખાટુ દૂધ-દહીં ની માહિતી)")
        {
            code = 31;
        }
        else if (Activity == "Sour Curd Monthly(ખાટુ દૂધ-દહીં ની ટકાવારી માહિતી)")
        {
            code = 32;
        }
        else if (Activity == "Society Wise Oil-Insect(તૈલી પદાથ-ઇન્સેક્ટ ની માહિતી)")
        {
            code = 33;
        }

        else if (Activity == "Community Fodder Farm Survey Form(સહિયારા ઘાસચારા ફાર્મનું સર્વે ફોર્મ)")
        {
            code = 34;
        }
        else if (Activity == "Milk Transport Route(દૂધ પરિવાહન રૂટ)")
        {
            code = 35;
        }
        return code;
    }
}
