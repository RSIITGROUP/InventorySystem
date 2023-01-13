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
    public partial class DetailEndUser : System.Web.UI.Page
    {
        clsGeneral oGnl = new clsGeneral();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null || Session["UserId"] == null)
            {
                Response.Redirect("~/UserLogin.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    int id = 0;
                    DataSet oDs = new DataSet();
                    oDs = oGnl.GetDataSet("select * from V_DetailEndUsr where ID='" + Request.QueryString["ID"] + "'");

                    id = Convert.ToInt32(oDs.Tables[0].Rows[0]["ID"].ToString());
                    txtNIK.Text = oDs.Tables[0].Rows[0]["NIK"].ToString();
                    txtName.Text = oDs.Tables[0].Rows[0]["Name"].ToString();
                    txtEmail.Text = oDs.Tables[0].Rows[0]["Email"].ToString();
                    txtRegion.Text = oDs.Tables[0].Rows[0]["Region"].ToString();
                    txtDepartment.Text = oDs.Tables[0].Rows[0]["Department"].ToString();
                    txtMobileNo.Text = oDs.Tables[0].Rows[0]["MobileNo"].ToString();
                    txtSAP.Text = oDs.Tables[0].Rows[0]["SAPUsrId"].ToString();
                    txtPeach.Text = oDs.Tables[0].Rows[0]["PeachUsrId"].ToString();
                    txtAQM.Text = oDs.Tables[0].Rows[0]["AQMUsrId"].ToString();
                    txtTalenta.Text = oDs.Tables[0].Rows[0]["TalentaUsrId"].ToString();
                    txtStatus.Text = oDs.Tables[0].Rows[0]["UsrStatus"].ToString();
                    txtRemark.Text = oDs.Tables[0].Rows[0]["Remarks"].ToString();
                    oGnl.SeListBox("select [RID] as [Code], [AssetCode] + ' - ' + [AssetDesc] as [Name] from Asset where [RID] in (select [RID] from [dbo].[EndUsrAssetMap] where [USRID]=" + Request.QueryString["ID"] + " ) and isnull(IsDeleted,'N') ='N'", lstDestination);
                }
            }
        }
    }
}