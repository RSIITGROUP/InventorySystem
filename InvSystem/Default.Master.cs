using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using InvSystem.Class;

namespace InvSystem
{
    public partial class Default : System.Web.UI.MasterPage
    {
        System.Web.UI.WebControls.LinkButton lButton;
        clsGeneral oGnl = new clsGeneral();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                string sparamVal = "";
                DataSet oDs = new DataSet();

                oDs = oGnl.ExecuteSP("SP_REQUEST_CLOSED", sparamVal, '|', 1);

                sparamVal = sparamVal + "@UsrId~" + Session["UserId"];
                oDs = oGnl.ExecuteSP("SP_GET_LISTMENU", sparamVal, '|', 1);
                if (oDs.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in oDs.Tables[0].Rows)
                    {
                        lButton = (System.Web.UI.WebControls.LinkButton)mains.FindControl(row[0].ToString());
                        lButton.Visible = true;
                    }
                }

                LinkButton2.Visible = false;
                //LinkButton3.Visible = false;
                LinkButton4.Visible = true;
                LinkButton5.Visible = true;
                LinkButton5.Text = "Hello " + Session["User"].ToString();
            }
            else
            {
                References.Visible = false;
                LinkButton2.Visible = true;
                //LinkButton3.Visible = true;
                LinkButton4.Visible = false;
                LinkButton5.Visible = false;
                navbarInventory.Visible = false;
                AssetAttributes.Visible = false;
                EndUser.Visible = false;
                navbarConfig.Visible = false;
                UserAccessMenu.Visible = false;
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
            Response.Redirect("~/asset.aspx?loc=0");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/configuration.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EndUser.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserAccessMenu.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddRequest.aspx?action=add");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ListRequest.aspx?Itemcode=&fil1=0&fil2=0");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ListApproval.aspx");
        }

        protected void LinkButton13_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddGoodsIssue.aspx?action=add");
        }

        protected void LinkButton14_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ListGoodsIssue.aspx");
        }

        protected void LinkButton15_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserAD.aspx");
        }

        protected void LinkButton16_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddGoodsReturn.aspx?action=add");
        }

        protected void LinkButton17_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ListGoodsReturn.aspx");
        }

        protected void LinkButton18_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VerifiedGoodsReturn.aspx");
        }
    }
}