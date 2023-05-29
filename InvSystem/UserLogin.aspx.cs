using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InvSystem.Class;
using System.Data;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices;
using System.Net.NetworkInformation;

namespace InvSystem
{
    public partial class UserLogin : System.Web.UI.Page
    {
        clsGeneral oGnl = new clsGeneral();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                Response.Redirect("~/Home.aspx");
            }
            else
            {
                lblError.Text = "";
                lblError.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (oGnl.IsDBConnect(1) && oGnl.IsDBConnect(2))
                {
                    int temp = Convert.ToInt32(oGnl.GetValueField("select count(*) from Users where UserName='" + txtUserName.Text.Trim() + "'", 1));

                    if (temp == 1)
                    {
                        string sPassword = oGnl.GetValueField("select Password from Users where UserName='" + txtUserName.Text.Trim() + "'", 1);
                        string sUserDomain = oGnl.decryptStr(oGnl.GetDataSet("select [name] from Reference where Code='9002' and [status]='A'", 1).Tables[0].Rows[0]["name"].ToString());
                        string sPwdDomain = oGnl.decryptStr(oGnl.GetDataSet("select [name] from Reference where Code='9003' and [status]='A'", 1).Tables[0].Rows[0]["name"].ToString());
                        string sIp = oGnl.GetDataSet("select [name] from Reference where Code='9004' and [status]='A'", 1).Tables[0].Rows[0]["name"].ToString();
                        // if (sPassword == oGnl.Encrypt(txtPassword.Text))
                        if (PingHost(sIp))
                        {
                            if (IsCorrectPws(txtUserName.Text, txtPassword.Text, sUserDomain, sPwdDomain))
                            {
                                Session["User"] = txtUserName.Text.Trim();
                                Session["UserId"] = oGnl.GetValueField("select Id from Users where UserName='" + txtUserName.Text.Trim() + "'", 1);
                                lblError.Text = "User Name and Password match";
                                lblError.ForeColor = System.Drawing.Color.Green;
                                Response.Redirect("Home.aspx");
                            }
                            else
                            {
                                lblError.Text = "Incorrect User Name and Password";
                            }
                        }
                        else
                        {
                            lblError.Text = "Server is busy. Please wait.";
                        }
                    }
                    else
                    {
                        lblError.Text = "Username not found";
                    }
                }
                else
                {
                    lblError.Text = "Server is busy. Please wait.";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.ToString();
            }
        }

        public bool IsCorrectPws(string username, string password, string sUserDomain, string sPwdDomain)
        {
            string sDomainName = "";
            DataSet oDs = new DataSet();
            oDs = oGnl.GetDataSet("select [name] from Reference where Code='9001' and [status]='A'", 1);
            sDomainName = oDs.Tables[0].Rows[0]["name"].ToString();

            using (var context = new PrincipalContext(ContextType.Domain, sDomainName, sUserDomain, sPwdDomain))
            {
                return context.ValidateCredentials(username, password);
            }
        }

        public bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
        }
    }
}