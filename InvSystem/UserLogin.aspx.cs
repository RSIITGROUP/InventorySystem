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
                int temp = Convert.ToInt32(oGnl.GetValueField("select count(*) from Users where UserName='" + txtUserName.Text.Trim() + "'", 1));

                if (temp == 1)
                {
                    string sPassword = oGnl.GetValueField("select Password from Users where UserName='" + txtUserName.Text.Trim() + "'", 1);
                    // if (sPassword == oGnl.Encrypt(txtPassword.Text))
                    if (IsCorrectPws(txtUserName.Text, txtPassword.Text))
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
                    lblError.Text = "Username not found";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.ToString();
            }
        }

        public bool IsCorrectPws(string username, string password)
        {
            string sDomainName = "";
            DataSet oDs = new DataSet();
            oDs = oGnl.GetDataSet("select [name] from Reference where Code='9001'", 1);
            sDomainName = oDs.Tables[0].Rows[0]["name"].ToString();

            using (var context = new PrincipalContext(ContextType.Domain, sDomainName))
            {
                return context.ValidateCredentials(username, password);
            }
        }

    }
}