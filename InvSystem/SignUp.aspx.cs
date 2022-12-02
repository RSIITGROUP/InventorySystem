using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InvSystem.Class;

namespace InvSystem
{
    public partial class SignUp : System.Web.UI.Page
    {
        clsGeneral oGnl = new clsGeneral();
        bool bIsExist = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
            lblError.ForeColor = System.Drawing.Color.Red;
            if (IsPostBack)
            {
                int temp = Convert.ToInt32(oGnl.GetValueField("select count(*) from Users where UserName='" + txtUserName.Text + "'"));
                if (temp == 1)
                {
                    lblError.Text = "User already exist";
                    bIsExist = true;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bIsExist)
                {
                    string sparamVal = "@firstname:" + txtFirstName.Text.Trim() + ",";
                    sparamVal = sparamVal + "@lastname:" + txtLastName.Text + ",";
                    sparamVal = sparamVal + "@usrname:" + txtUserName.Text.Trim() + ",";
                    sparamVal = sparamVal + "@email:" + txtEmail.Text + ",";
                    sparamVal = sparamVal + "@password:" + oGnl.Encrypt(txtPassword.Text);
                    oGnl.ExecuteDataQuery("insert into Users (FirstName,LastName,UserName,Email,Password) values (@firstname,@lastname,@usrname,@email,@password)", sparamVal)
                   
                   /* Response.Write("Registration is Success")*/;
                    lblError.Text = "Sign Up is Success";
                    lblError.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error:" + ex.ToString();
            }
        }
    }
}