using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using InvSystem.Class;
using System.Collections;

namespace InvSystem
{
    public partial class AddEndUser : System.Web.UI.Page
    {
        bool bIsExist = false;
        bool bIsErr = false;
        ArrayList ar1 = new ArrayList();
        clsGeneral oGnl = new clsGeneral();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null || Session["UserId"] == null)
            {
                Response.Redirect("~/UserLogin.aspx");
            }
            else
            {
                lblError.Text = "";
                lblError.ForeColor = System.Drawing.Color.Red;
                if (IsPostBack)
                {
                    if (btnAdd.Text == "Add")
                    {
                        int temp = Convert.ToInt32(oGnl.GetValueField("select count(*) from [EndUser] where [NIK]='" + txtNIK.Text + "'",1));
                        if (temp == 1)
                        {
                            bIsExist = true;
                        }
                    }
                }
                else
                {
                    SeDropDown("01", ddRegion);
                    SeDropDown("33", ddDepartment);
                    SetStatusDD();
                    oGnl.SeListBox("select [RID] as [Code], [AssetCode] + ' - ' + [AssetDesc] as [Name] from Asset where [RID] not in (select [RID] from [dbo].[EndUsrAssetMap]) and isnull(IsDeleted,'N') ='N'", lstSource, 1);
                    if (Request.QueryString["Action"] == "edit")
                    {
                        int id = 0;
                        btnAdd.Text = "Edit";
                        txtNIK.ReadOnly = true;

                        DataSet oDs = new DataSet();
                        oDs = oGnl.GetDataSet("select * from [EndUser] where [ID]=" + Request.QueryString["ID"] + "", 1);

                        id = Convert.ToInt32(oDs.Tables[0].Rows[0]["ID"].ToString());
                        txtNIK.Text = oDs.Tables[0].Rows[0]["NIK"].ToString();
                        txtName.Text = oDs.Tables[0].Rows[0]["Name"].ToString();
                        txtEmail.Text = oDs.Tables[0].Rows[0]["Email"].ToString();
                        ddRegion.SelectedValue = oDs.Tables[0].Rows[0]["Region"].ToString();
                        ddDepartment.SelectedValue = oDs.Tables[0].Rows[0]["Department"].ToString();
                        txtMobileNo.Text = oDs.Tables[0].Rows[0]["MobileNo"].ToString();
                        txtSapId.Text = oDs.Tables[0].Rows[0]["SAPUsrId"].ToString();
                        txtPeach.Text = oDs.Tables[0].Rows[0]["PeachUsrId"].ToString();
                        txtAQM.Text = oDs.Tables[0].Rows[0]["AQMUsrId"].ToString();
                        txtTalenta.Text = oDs.Tables[0].Rows[0]["TalentaUsrId"].ToString();
                        ddStatus.SelectedValue = oDs.Tables[0].Rows[0]["UsrStatus"].ToString();
                        txtRemark.Text = oDs.Tables[0].Rows[0]["Remarks"].ToString();

                        oGnl.SeListBox("select [RID] as [Code], [AssetCode] + ' - ' + [AssetDesc] as [Name] from Asset where [RID] in (select [RID] from [dbo].[EndUsrAssetMap] where [USRID]=" + Request.QueryString["ID"] + " ) and isnull(IsDeleted,'N') ='N'", lstDestination, 1);
                    }
                    else
                    {
                        btnAdd.Text = "Add";
                        txtNIK.ReadOnly = false;                        
                    }
                }
            }
        }

        protected void SetStatusDD()
        {
            try
            {
                ddStatus.Items.Add(new ListItem("Active", "A"));
                ddStatus.Items.Add(new ListItem("InActive", "I"));
            }
            catch (Exception ex)
            {
                lblError.Text = "Error:" + ex.ToString();
            }
        }

        protected void SeDropDown(string refCode, DropDownList dr)
        {
            try
            {
                oGnl.SeDropDown("SELECT [Code], [Name] FROM [Reference] WHERE [refCode]='" + refCode + "'  and [Status] = 'A' ORDER BY [Name]", dr, 1);
            }
            catch (Exception ex)
            {
                lblError.Text = "Error:" + ex.ToString();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Session["User"] == null || Session["UserId"] == null)
            {
                Response.Redirect("~/UserLogin.aspx");
            }
            else
            {
                try
                {
                    int errNo = 0;
                    string errMsg = "";
                    string sparamVal = "";
                    string sItem = "";

                    if (!bIsExist)
                    {
                        if (btnAdd.Text == "Add")
                        {
                            sparamVal = "@action:A,";
                        }
                        else
                        {
                            sparamVal = "@action:U,";
                        }
                        
                        sparamVal = sparamVal + "@NIK:" + txtNIK.Text + ",";
                        sparamVal = sparamVal + "@Name:" + txtName.Text + ",";
                        sparamVal = sparamVal + "@Email:" + txtEmail.Text + ",";
                        sparamVal = sparamVal + "@Region:" + ddRegion.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@Department:" + ddDepartment.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@MobileNo:" + txtMobileNo.Text + ",";
                        sparamVal = sparamVal + "@SAPUsrId:" + txtSapId.Text + ",";
                        sparamVal = sparamVal + "@PeachUsrId:" + txtPeach.Text + ",";
                        sparamVal = sparamVal + "@AQMUsrId:" + txtAQM.Text + ",";
                        sparamVal = sparamVal + "@TalentaUsrId:" + txtTalenta.Text + ",";
                        sparamVal = sparamVal + "@UsrStatus:" + ddStatus.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@Remarks:" + txtRemark.Text + ",";

                        if (lstDestination.Items.Count > 0)
                        {
                            foreach (ListItem item in lstDestination.Items)
                            {
                                sItem += item.Value + ";";
                            }
                        }
                        sparamVal = sparamVal + "@AssetMap:" + sItem + ",";
                        sparamVal = sparamVal + "@UserId:" + Session["UserId"];

                        DataSet oDs = new DataSet();
                        oDs = oGnl.ExecuteSP("SP_POST_ENDUSR", sparamVal, 1);

                        errNo = Convert.ToInt32(oDs.Tables[0].Rows[0]["ERRNO"].ToString());
                        errMsg = oDs.Tables[0].Rows[0]["ERRMSG"].ToString();
                        if (errNo == 0)
                        {
                            lblError.ForeColor = System.Drawing.Color.Green;

                            if (btnAdd.Text == "Add")
                            {
                                lblError.Text = "Add User is Success";
                                btnAdd.Enabled = false;
                            }
                            else
                            {
                                lblError.Text = "Update User is Success";
                            }
                        }
                        else
                        {
                            lblError.ForeColor = System.Drawing.Color.Red;
                            lblError.Text = errMsg;
                        }
                    }
                    else
                    {
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = "User is already exist";
                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = "Error:" + ex.ToString();
                }
            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            if (lstSource.SelectedIndex >= 0)
            {
                for (int i = 0; i < lstSource.Items.Count; i++)
                {
                    if (lstSource.Items[i].Selected)
                    {
                        if (!ar1.Contains(lstSource.Items[i]))
                        {
                            ar1.Add(lstSource.Items[i]);
                        }
                    }
                }
                for (int i = 0; i < ar1.Count; i++)
                {
                    if (!lstDestination.Items.Contains(((ListItem)ar1[i])))
                    {
                        lstDestination.Items.Add(((ListItem)ar1[i]));
                    }
                    lstSource.Items.Remove(((ListItem)ar1[i]));
                }
                lstDestination.SelectedIndex = -1;
                ar1 = null;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (lstDestination.SelectedIndex >= 0)
            {
                for (int i = 0; i < lstDestination.Items.Count; i++)
                {
                    if (lstDestination.Items[i].Selected)
                    {
                        if (!ar1.Contains(lstDestination.Items[i]))
                        {
                            ar1.Add(lstDestination.Items[i]);
                        }
                    }
                }
                for (int i = 0; i < ar1.Count; i++)
                {
                    if (!lstSource.Items.Contains(((ListItem)ar1[i])))
                    {
                        lstSource.Items.Add(((ListItem)ar1[i]));
                    }
                    lstDestination.Items.Remove(((ListItem)ar1[i]));
                }
                lstSource.SelectedIndex = -1;
                ar1 = null;
            }
        }
    }
}