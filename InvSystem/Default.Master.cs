using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvSystem
{
    public partial class Default : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                LinkButton1.Visible = true;
                LinkButton2.Visible = false;
                LinkButton3.Visible = false;
                LinkButton4.Visible = true;
                LinkButton5.Visible = true;
                LinkButton6.Visible = true;
                LinkButton7.Visible = true;
                LinkButton5.Text = "Hello " + Session["User"].ToString();
            }
            else
            {
                LinkButton1.Visible = false;
                LinkButton2.Visible = true;
                LinkButton3.Visible = true;
                LinkButton4.Visible = false;
                LinkButton5.Visible = false;
                LinkButton6.Visible = false;
                LinkButton7.Visible = false;
                //Response.Redirect("~/UserLogin.aspx");
            }
        }

        //protected void btnLogout_Click(object sender, EventArgs e)
        //{
        //    Session["User"] = null;
        //    Response.Redirect("Login.aspx");
        //}

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Response.Redirect("~/signup.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Response.Redirect("~/userlogin.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Response.Redirect("~/userlogin.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/reference.aspx");
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/asset.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/configuration.aspx");
        }
    }
}