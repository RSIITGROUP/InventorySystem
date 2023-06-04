using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using InvSystem.Class;
using System.Configuration;
using System.Data.SqlClient;

namespace InvSystem
{
    public partial class AddGoodsIssue : System.Web.UI.Page
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
                lblError.Visible = false;
                lblError.ForeColor = System.Drawing.Color.Red;
                DataSet oDs = new DataSet();
                string sparamVal = "";
                if (!IsPostBack)
                {
                    //oGnl.SeDropDown("select RequestID [Code], RequestID [Name] from [RequestHeader] where [RequestState] in ('8002','8004') order by RequestID", ddReqId, 1);
                    
                    if (Request.QueryString["action"].ToString().Equals("add"))
                    {
                        oGnl.SeComboBox("select RequestID [Code], RequestID [Name] from [RequestHeader] where [RequestState] in ('8002','8004') order by RequestID", cbReqId, 1);
                        cbReqId.Items.Insert(0, new ListItem("--Select--", "0"));
                        cbReqId.SelectedValue = "0";
                        GenerateCode();
                        sparamVal = "@GIID~" + txtGIId.Text + "|";
                        sparamVal = sparamVal + "@UserId~" + Session["UserId"];
                        oGnl.ExecuteDataQuery("Delete from GIDetailtemp where [GIID]=@GIID and UserId=@UserId", sparamVal, Convert.ToChar("|"), 1);
                        sparamVal = "@RequestId~" + cbReqId.SelectedItem.Value;
                        oGnl.ExecuteDataQuery("insert into GIDetailtemp select '" + txtGIId.Text + "' as [GIID], LineId," + Session["UserId"] + " [UserId]," + cbReqId.SelectedItem.Value + "[RequestId], ItemCode, ItemDesc, 0 [Qty], Unit from RequestDetail where RequestID=@RequestId", sparamVal, Convert.ToChar("|"), 1);
                        frame1.Src = "AddGoodsIssueItem.aspx?action=add&&GIID=" + txtGIId.Text + "&&RequestId=" + cbReqId.SelectedItem.Value;
                    }
                    else
                    {
                        //oGnl.SeDropDown("select RequestID [Code], RequestID [Name] from [RequestHeader] order by RequestID", cbReqId, 1);
                        oGnl.SeComboBox("select RequestID [Code], RequestID [Name] from [RequestHeader] order by RequestID", cbReqId, 1);
                        txtGIId.Text = Request.QueryString["GIID"];
                        oDs = oGnl.GetDataSet("select top 1 t0.[GIID], T1.[RequestId] from [GIHeader] t0 inner join [GIDetail] T1 on T0.GIID = T1.GIID where T0.[GIID]='" + Request.QueryString["GIID"] + "'", 1);
                        if (oDs.Tables[0].Rows.Count > 0)
                        {
                            txtGIId.Text = oDs.Tables[0].Rows[0]["GIID"].ToString();
                            cbReqId.SelectedValue = oDs.Tables[0].Rows[0]["RequestId"].ToString();
                        }
                        cbReqId.Enabled = false;
                        divSave.Visible = false;
                        frame1.Src = "AddGoodsIssueItem.aspx?action=view&GIID=" + txtGIId.Text + "&&RequestId=" + cbReqId.SelectedItem.Value;
                    }
                }
            }
        }

        protected string GenerateCode()
        {
            string code = "";
            try
            {
                DataSet oDs = new DataSet();
                oDs = oGnl.GetDataSet("select top 1 Right(Year(getDate()),2) +  right('000000' + convert(varchar(6),convert(int,RIGHT(isnull([GIID],'0'),6)) + 1),6)  [Code] from [dbo].[GIHeader] where [GIID] like '" + DateTime.Today.ToString("yy") + "%' order by [GIID] desc", 1);
                if (oDs.Tables[0].Rows.Count > 0)
                {
                    txtGIId.Text = oDs.Tables[0].Rows[0]["Code"].ToString();
                }
                else
                {
                    txtGIId.Text = DateTime.Today.ToString("yy") + "000001";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error:" + ex.ToString();
            }
            return code;
        }

        protected void ddReqId_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sparamVal = "";
            try
            {
                sparamVal = "@GIID~" + txtGIId.Text + "|";
                sparamVal = sparamVal + "@UserId~" + Session["UserId"];
                oGnl.ExecuteDataQuery("Delete from GIDetailtemp where [GIID]=@GIID and UserId=@UserId", sparamVal, Convert.ToChar("|"), 1);
                sparamVal = "@RequestId~" + cbReqId.SelectedItem.Value;
                oGnl.ExecuteDataQuery("insert into GIDetailtemp select '" + txtGIId.Text + "' as [GIID], LineId, " + Session["UserId"] + " [UserId]," + cbReqId.SelectedItem.Value + " [RequestId], ItemCode, ItemDesc, 0 [Qty], Unit from RequestDetail where RequestID=@RequestId", sparamVal, Convert.ToChar("|"), 1);
                frame1.Src = "AddGoodsIssueItem.aspx?action=add&&GIId=" + txtGIId.Text + "&&RequestId=" + cbReqId.SelectedItem.Value;
            }
            catch (Exception ex)
            {
                lblError.Text = "Error:" + ex.ToString();
            }            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (cbReqId.SelectedItem.Value.Equals("0"))
            {
                lblError.Visible = true;
                lblError.Text = "Request Id is required";
            }            
            else if (IsItemExists(txtGIId.Text) == false)
            {
                lblError.Visible = true;
                lblError.Text = "Item is required";
            }
            else if (IsZeroQty(txtGIId.Text) == true)
            {
                lblError.Visible = true;
                lblError.Text = "Quantity must greater than 0";
            }
            else
            {
                int errNo = 0;
                string errMsg = "";
                string sparamVal = "";
                
                sparamVal = "@action~A|";
                sparamVal = sparamVal + "@GIId~" + txtGIId.Text + "|";
                sparamVal = sparamVal + "@ReqId~" + cbReqId.SelectedItem.Value + "|";
                sparamVal = sparamVal + "@UserId~" + Session["UserId"];

                DataSet oDs = new DataSet();
                oDs = oGnl.ExecuteSP("SP_POST_GI", sparamVal, '|', 1);

                errNo = Convert.ToInt32(oDs.Tables[0].Rows[0]["ERRNO"].ToString());
                errMsg = oDs.Tables[0].Rows[0]["ERRMSG"].ToString();
                txtGIId.Text = oDs.Tables[0].Rows[0]["GIID"].ToString();
                if (errNo == 0)
                {
                    lblError.Visible = true;
                    lblError.ForeColor = System.Drawing.Color.Green;

                    lblError.Text = "Good Issue is Created";
                    btnAdd.Enabled = false;
                    Reset1.Visible = false;
                    frame1.Src = "AddGoodsIssueItem.aspx?action=view&GIID=" + txtGIId.Text + "&&RequestId=" + cbReqId.SelectedItem.Value;
                }
                else
                {
                    lblError.Visible = true;
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = errMsg;
                    frame1.Src = "AddGoodsIssueItem.aspx?action=add&&GIID=" + txtGIId.Text + "&&RequestId=" + cbReqId.SelectedItem.Value;
                }
            }
        }

        protected bool IsItemExists(string giId)
        {
            bool isExists = false;
            try
            {
                string strQuery = "select [GIID] from [GIDetailTemp] where [GIID]=" + giId;
                DataSet oDs = new DataSet();
                oDs = oGnl.GetDataSet(strQuery, 1);
                if (oDs.Tables[0].Rows.Count > 0)
                {
                    isExists = true;
                }

            }
            catch (Exception ex)
            {
                lblError.Text = "Error:" + ex.ToString();
            }
            return isExists;
        }

        protected bool IsZeroQty(string giId)
        {
            bool isExists = false;
            try
            {
                string strQuery = "select [GIID] from [GIDetailTemp] where [GIID]=" + giId + " and UserId=" + Session["UserId"] + "and Qty <= 0";
                DataSet oDs = new DataSet();
                oDs = oGnl.GetDataSet(strQuery, 1);
                if (oDs.Tables[0].Rows.Count > 0)
                {
                    isExists = true;
                }

            }
            catch (Exception ex)
            {
                lblError.Text = "Error:" + ex.ToString();
            }
            return isExists;
        }        
    }
}