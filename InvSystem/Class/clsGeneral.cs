using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace InvSystem.Class
{
    public class clsGeneral
    {
        public DataSet GetDataSet(string sSqlStr, int typeConn)
        {
            string conStr = "";
            if (typeConn == 1) { conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; }
            else { conStr = ConfigurationManager.ConnectionStrings["whsConnection"].ConnectionString; }
            SqlConnection oCon = new SqlConnection(conStr);
            SqlDataAdapter oDA = new SqlDataAdapter(sSqlStr, oCon);
            DataSet oDs = new DataSet();
            oDA.Fill(oDs);

            return oDs;
        }

        public DataTable GetDataTable(string sSqlStr, int typeConn)
        {
            DataTable dt = new DataTable();
            string conStr = "";
            if (typeConn == 1) { conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; }
            else { conStr = ConfigurationManager.ConnectionStrings["whsConnection"].ConnectionString; }
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(sSqlStr, con))
                {
                   sda.Fill(dt);
                }
            }

            return dt;
        }

        public void SeDropDown(string sSqlStr, DropDownList dr, int typeConn)
        {
            DataTable dt = new DataTable();
            string conStr = "";
            if (typeConn == 1) { conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; }
            else { conStr = ConfigurationManager.ConnectionStrings["whsConnection"].ConnectionString; }

            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sSqlStr))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    dr.DataSource = cmd.ExecuteReader();
                    dr.DataTextField = "Name";
                    dr.DataValueField = "Code";
                    dr.DataBind();
                    con.Close();
                }
            }            
        }

        public void SeComboBox(string sSqlStr, AjaxControlToolkit.ComboBox cb, int typeConn)
        {
            DataTable dt = new DataTable();
            string conStr = "";
            if (typeConn == 1) { conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; }
            else { conStr = ConfigurationManager.ConnectionStrings["whsConnection"].ConnectionString; }

            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sSqlStr))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    cb.DataSource = cmd.ExecuteReader();
                    cb.DataTextField = "Name";
                    cb.DataValueField = "Code";
                    cb.DataBind();
                    con.Close();
                }
            }
        }


        public void SeListBox(string sSqlStr, ListBox dr, int typeConn)
        {
            DataTable dt = new DataTable();
            string conStr = "";
            if (typeConn == 1) { conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; }
            else { conStr = ConfigurationManager.ConnectionStrings["whsConnection"].ConnectionString; }

            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sSqlStr))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    dr.DataSource = cmd.ExecuteReader();
                    dr.DataTextField = "Name";
                    dr.DataValueField = "Code";
                    dr.DataBind();
                    con.Close();
                }
            }
        }

        public string Encrypt(string clearText)
        {
            string EncryptionKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public string encryptStr(string sData)
        {
            byte[] result = null;
            byte[] data = UTF8Encoding.UTF8.GetBytes(sData);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes("AquaFarm"));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    result = transform.TransformFinalBlock(data, 0, data.Length);
                }
            }
            return Convert.ToBase64String(result, 0, result.Length);
        }

        public string decryptStr(string sData)
        {
            byte[] result = null;
            byte[] data = Convert.FromBase64String(sData);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes("AquaFarm"));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    result = transform.TransformFinalBlock(data, 0, data.Length);

                }
            }
            return UTF8Encoding.UTF8.GetString(result);
        }

        public string GetValueField(string sSqlStr, int typeConn)
        {
            string conStr = "";
            if (typeConn == 1) { conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; }
            else { conStr = ConfigurationManager.ConnectionStrings["whsConnection"].ConnectionString; }
            SqlConnection oCon = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            oCon.Open();
            SqlCommand oComm = new SqlCommand(sSqlStr, oCon);
            string sValue = oComm.ExecuteScalar().ToString();
            oCon.Close();
            return sValue;
        }

        public void ExecuteDataQuery(string sSqlStr, string sPrmVal, char separator, int typeConn)
        {
            string[] sParam = sPrmVal.Split(separator);
            string[] sValue = null;

            string conStr = "";
            if (typeConn == 1) { conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; }
            else { conStr = ConfigurationManager.ConnectionStrings["whsConnection"].ConnectionString; }
            SqlConnection oCon = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            oCon.Open();
            SqlCommand oComm = new SqlCommand(sSqlStr, oCon);
            
            foreach (string str in sParam)
            {
                sValue= str.Split('~');
                oComm.Parameters.AddWithValue(sValue[0], sValue[1]);
            }

            oComm.ExecuteNonQuery();
            oCon.Close();
        }

        public DataSet ExecuteSP(string sSqlStr, string sPrmVal, char separator, int typeConn)
        {
            string[] sParam = sPrmVal.Split(separator);
            string[] sValue = null;

            string conStr = "";
            if (typeConn == 1) { conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; }
            else { conStr = ConfigurationManager.ConnectionStrings["whsConnection"].ConnectionString; }
            SqlConnection oCon = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            //oCon.Open();
            SqlCommand oComm = new SqlCommand(sSqlStr, oCon);

            if (!sPrmVal.Equals(""))
            {
                foreach (string str in sParam)
                {
                    sValue = str.Split('~');
                    oComm.Parameters.AddWithValue(sValue[0], sValue[1]);
                }
            }
            oComm.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oDA = new SqlDataAdapter();
            oDA.SelectCommand = oComm;
            DataSet oDs = new DataSet();
            oDA.Fill(oDs);
            //oCon.Close();

            return oDs;
        }

        public bool IsDBConnect(int typeConn)
        {
            string conStr = "";
            if (typeConn == 1) { conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; }
            else { conStr = ConfigurationManager.ConnectionStrings["whsConnection"].ConnectionString; }
            try
            {
                using (var con = new SqlConnection(conStr))
                {
                    con.Open();
                    con.Close();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}