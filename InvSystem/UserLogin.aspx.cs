using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InvSystem.Class;

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
            int temp = Convert.ToInt32(oGnl.GetValueField("select count(*) from Users where UserName='" + txtUserName.Text.Trim() + "'"));

            if (temp == 1)
            {
                string sPassword = oGnl.GetValueField("select Password from Users where UserName='" + txtUserName.Text.Trim() + "'");
                if (sPassword == oGnl.Encrypt(txtPassword.Text))
                {
                    Session["User"] = txtUserName.Text.Trim();
                    Session["UserId"] = oGnl.GetValueField("select Id from Users where UserName='" + txtUserName.Text.Trim() + "'");
                    lblError.Text = "User Name and Password match";
                    lblError.ForeColor = System.Drawing.Color.Green;
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    lblError.Text = "User Name and Password not match";
                }
            }
            else
            {
                lblError.Text = "Incorrect Correct";
            }
        }

    }
}