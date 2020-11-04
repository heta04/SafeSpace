using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections;
using System.Text;
using System.Security.Cryptography;
using System.IO;
public class ConnectionSql
{
    String constr = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

    public static string KEY = "K6u8#m2a";
    public ConnectionSql()
    {
    }

    public DataTable GetSelectQuety(string query)
    {
        DataTable dt = new DataTable();
        SqlConnection conn = null;
        try
        {
            conn = new SqlConnection(constr);
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


    public int ExecuteNonQuery1(string str)
    {

        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand(str, con);
        int result = 0;
        try
        {
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            ex.ToString();
            result = -1;
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex2)
            {
                ex2.ToString();
                // ErrHandler.WriteError(ex2.ToString());
            }
            // ErrHandler.WriteError(ex.ToString());
        }

        return result;

    }
    public Object ExecuteScalarQuery(String str)
    {

        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand(str, con);

        Object result = null;

        try
        {

            con.Open();
            result = cmd.ExecuteScalar();

        }
        catch (Exception ex)
        {
            ex.ToString();
            if (con.State == ConnectionState.Open)
                con.Close();

        }
        finally
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }


        return result;
    }

    public SqlDataReader GetDataReaderQuery(string str)
    {
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand(str, con);
        SqlDataReader dr;


        try
        {
            con.Open();
            dr = cmd.ExecuteReader();
        }

        catch (Exception ex)
        {
            ex.ToString();
            //	websurveytool.ErrHandler.WriteError(ex.ToString);
            return null;
        }
        dr.Close();
        // Return the datareader result
        return dr;

    }

    public int ExecuteNonQuerySP(string sp, SortedList sl)
    {
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand(sp, con);
        int result = 0;

        try
        {
            cmd.CommandType = CommandType.StoredProcedure;

            for (int x = 0; x <= sl.Count - 1; x++)
            {
                cmd.Parameters.AddWithValue((String)sl.GetKey(x), sl.GetByIndex(x));
            }

            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            ex.ToString();
            result = -1;
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex2)
            {
                ex2.ToString();
                // ErrHandler.WriteError(ex2.ToString());
            }
            // ErrHandler.WriteError(ex.ToString());
        }
        return result;
    }
    public Object ExecuteScalarSP(String sp, SortedList sl)
    {
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand(sp, con);
        Object result = null;

        try
        {
            cmd.CommandType = CommandType.StoredProcedure;

            for (int i = 0; i < sl.Count; i++)
                cmd.Parameters.AddWithValue((String)sl.GetKey(i), sl.GetByIndex(i));


            con.Open();
            result = cmd.ExecuteScalar();
            //myConnection.Close();
        }
        catch (Exception ex)
        {
            ex.ToString();
            if (con.State == ConnectionState.Open)
                con.Close();
            // ErrHandler.WriteError(ex.ToString());
        }
        finally
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }
        return result;
    }
    public SqlDataReader GetDataReaderSP(string sSQL, SortedList paramList)
    {

        SqlConnection con = new SqlConnection(constr);

        SqlCommand cmd = new SqlCommand(sSQL, con);
        SqlDataReader dr;
        int x;

        try
        {
            cmd.CommandType = CommandType.StoredProcedure;
            for (x = 0; x <= paramList.Count - 1; x++)
            {
                cmd.Parameters.AddWithValue((String)paramList.GetKey(x), paramList.GetByIndex(x));
            }
            con.Open();

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (Exception ex)
        {
            ex.ToString();
            //	websurveytool.ErrHandler.WriteError(ex.ToString);
            return null;
        }

        // Return the datareader result
        return dr;
    }

    public DataTable GetDataReaderSPTable(string sSQL, SortedList paramList)
    {

        SqlConnection con = new SqlConnection(constr);

        SqlCommand cmd = new SqlCommand(sSQL, con);
        SqlDataReader dr;
        DataTable dt = new DataTable();
        int x;

        try
        {
            cmd.CommandType = CommandType.StoredProcedure;
            for (x = 0; x <= paramList.Count - 1; x++)
            {
                cmd.Parameters.AddWithValue((String)paramList.GetKey(x), paramList.GetByIndex(x));
            }
            con.Open();

            // dr = cmd.ExecuteReader();
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (Exception ex)
        {
            ex.ToString();
            //	websurveytool.ErrHandler.WriteError(ex.ToString);
            return null;
        }

        // Return the datareader result
        dt.Load(dr);
        return dt;
    }
    public DataTable GetDataTableSP(string sSQL, SortedList paramList)
    {
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand(sSQL, con);
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        int x;
        try
        {
            cmd.CommandType = CommandType.StoredProcedure;
            for (x = 0; x <= paramList.Count - 1; x++)
            {
                cmd.Parameters.AddWithValue((String)paramList.GetKey(x), paramList.GetByIndex(x));
            }
            con.Open();
            da.SelectCommand = cmd;
            da.Fill(dt);
            if (con.State == ConnectionState.Open)
                con.Close();
            //                da = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (Exception ex)
        {
            ex.ToString();
            return null;
        }
        return dt;
    }



    public string DecryptQueryString(string stringToDecrypt)
    {
        byte[] key = { };
        byte[] IV = { 0x01, 0x12, 0x23, 0x34, 0x45, 0x56, 0x67, 0x78 };
        stringToDecrypt = stringToDecrypt.Replace(" ", "+");
        byte[] inputByteArray = new byte[stringToDecrypt.Length];

        try
        {
            key = Encoding.UTF8.GetBytes(KEY);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(stringToDecrypt);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            Encoding encoding = Encoding.UTF8;
            return encoding.GetString(ms.ToArray());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public string EncryptQueryString(string stringToEncrypt)
    {
        byte[] key = { };
        byte[] IV = { 0x01, 0x12, 0x23, 0x34, 0x45, 0x56, 0x67, 0x78 };
        try
        {
            key = Encoding.UTF8.GetBytes(KEY);
            using (DESCryptoServiceProvider oDESCrypto = new DESCryptoServiceProvider())
            {
                byte[] inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
                MemoryStream oMemoryStream = new MemoryStream();
                CryptoStream oCryptoStream = new CryptoStream(oMemoryStream,
                oDESCrypto.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                oCryptoStream.Write(inputByteArray, 0, inputByteArray.Length);
                oCryptoStream.FlushFinalBlock();
                return Convert.ToBase64String(oMemoryStream.ToArray());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public string datemmddyy(string str)
    {
        string dt = "";
        if (str.Length > 0)
        {
            //27/12/2007
            string mm, dd, yyyy;
            string[] str1 = str.Split('/');
            dd = str1[1];
            mm = str1[0];
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
            dt = dd + "/" + mm + "/" + yyyy;
        }
        return dt;
    }
    public string datemmddyyWithZero(string str)
    {
        string dt = "";
        if (str.Length > 0)
        {
            //27/12/2007
            string mm, dd, yyyy;
            string[] str1 = str.Split('/');
            dd = str1[1];
            mm = str1[0];
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
            dt = mm + "/" + dd + "/" + yyyy;
        }
        return dt;
    }
}