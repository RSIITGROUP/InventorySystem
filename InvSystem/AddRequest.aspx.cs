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
    public partial class AddRequest : System.Web.UI.Page
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
                string usrId = "";
                string reqState = "";
                string approver = "";

                lblError.Visible = false;
                lblError.ForeColor = System.Drawing.Color.Red;
                DataSet oDs = new DataSet();
                string sparamVal = "";
                if (!IsPostBack)
                {
                    SeDropDown("36", ddWorkGroup);
                    SeDropDown("37", ddPurpose);
                    SeDropDown("38", ddReqDesc);
                    if (Request.QueryString["action"].ToString().Equals("add"))
                    {
                        GenerateCode();
                        sparamVal = "@RequestId~" + txtReqId.Text + "|";
                        sparamVal = sparamVal + "@UserId~" + Session["UserId"];
                        oGnl.ExecuteDataQuery("Delete from RequestDetailtemp where RequestId=@RequestId and UserId=@UserId", sparamVal, Convert.ToChar("|"), 1);
                        frame1.Src = "AddRequestItem.aspx?action=add&&RequestID=" + txtReqId.Text;
                        divapproval.Visible = false;
                        frame2.Src = "ApproveRequest.aspx?action=approve&&RequestID=" + txtReqId.Text;
                    }
                    else
                    {
                        approver = "0";
                        oDs = oGnl.GetDataSet("select T0.RequestState [ReqState], T0.UsrCreate from [dbo].[RequestHeader] T0 where t0.RequestId='" + Request.QueryString["ReqID"] + "'", 1);
                        if (oDs.Tables[0].Rows.Count > 0)
                        {
                            usrId = oDs.Tables[0].Rows[0]["UsrCreate"].ToString();
                            reqState = oDs.Tables[0].Rows[0]["ReqState"].ToString();
                        }

                        oDs = oGnl.GetDataSet("select t1.ApproverId from [dbo].[RequestHeader] T0 left join [UserApproval] T1 on t0.UsrCreate= t1.UserID where t0.RequestId='" + Request.QueryString["ReqID"] + "' and t1.ApproverId=" + Session["UserId"], 1);
                        if (oDs.Tables[0].Rows.Count > 0)
                        {
                            approver = oDs.Tables[0].Rows[0]["ApproverId"].ToString();
                        }

                        oDs = oGnl.GetDataSet("select * from [RequestHeader] where RequestId='" + Request.QueryString["ReqID"] + "'", 1);
                        if (oDs.Tables[0].Rows.Count > 0)
                        {
                            txtReqId.Text = oDs.Tables[0].Rows[0]["RequestID"].ToString();
                            //txtReqDesc.Text = oDs.Tables[0].Rows[0]["RequestDesc"].ToString();
                            ddReqDesc.SelectedValue = oDs.Tables[0].Rows[0]["RequestDesc"].ToString();
                            ddWorkGroup.SelectedValue = oDs.Tables[0].Rows[0]["WorkGroup"].ToString();
                            ddPurpose.SelectedValue = oDs.Tables[0].Rows[0]["Purpose"].ToString();
                            if (oDs.Tables[0].Rows[0]["RequestDate"].ToString() != "")
                            {
                                txtReqDate.Text = Convert.ToDateTime(oDs.Tables[0].Rows[0]["RequestDate"]).ToString("yyyy-MM-dd");
                            }
                        }

                        if (Request.QueryString["action"].ToString().Equals("edit"))
                        {
                            if (Session["UserId"].Equals(usrId) && reqState.Equals("8001"))
                            {
                                sparamVal = "@RequestId~" + txtReqId.Text + ",";
                                sparamVal = sparamVal + "@UserId~" + Session["UserId"];
                                oGnl.ExecuteDataQuery("Delete from RequestDetailtemp where RequestId=@RequestId and UserId=@UserId", sparamVal, Convert.ToChar(","), 1);
                                oGnl.ExecuteDataQuery("insert into RequestDetailtemp (RequestId,LineId,UserId,ItemCode,ItemDesc,Qty,Unit) select [RequestID],[LineId]," + Session["UserId"] + " [UserId],[ItemCode],[ItemDesc],[Qty],[Unit] from RequestDetail where RequestId=@RequestId", sparamVal, Convert.ToChar(","), 1);
                                txtReqId.ReadOnly = false;
                                //txtReqDesc.ReadOnly = false;
                                ddReqDesc.Enabled = true;
                                ddWorkGroup.Enabled = true;
                                ddPurpose.Enabled = true;
                                txtReqDate.ReadOnly = false;
                                btnAdd.Visible = true;
                                Reset1.Visible = true;
                                divSave.Visible = true;
                                frame1.Src = "AddRequestItem.aspx?action=edit&RequestID=" + txtReqId.Text;
                                divapproval.Visible = false;
                            }
                            else
                            {
                                txtReqId.ReadOnly = true;
                                //txtReqDesc.ReadOnly = true;
                                ddReqDesc.Enabled = false;
                                ddWorkGroup.Enabled = false;
                                ddPurpose.Enabled = false;
                                txtReqDate.ReadOnly = true;
                                divSave.Visible = false;
                                frame1.Src = "AddRequestItem.aspx?action=view&RequestID=" + txtReqId.Text;
                                divapproval.Visible = true;
                            }
                            frame2.Src = "ApproveRequest.aspx?action=approve&&RequestID=" + txtReqId.Text;
                        }
                        else if (Request.QueryString["action"].ToString().Equals("approve"))
                        {
                            txtReqId.ReadOnly = true;
                            //txtReqDesc.ReadOnly = true;
                            ddReqDesc.Enabled = false;
                            ddWorkGroup.Enabled = false;
                            ddPurpose.Enabled = false;
                            txtReqDate.ReadOnly = true;
                            divSave.Visible = false;
                            if (Session["UserId"].Equals(approver) && reqState.Equals("8001"))
                            {
                                frame1.Src = "AddRequestItem.aspx?action=approve&RequestID=" + txtReqId.Text;
                                divapproval.Visible = true;
                            }
                            else
                            {
                                frame1.Src = "AddRequestItem.aspx?action=view&RequestID=" + txtReqId.Text;
                                divapproval.Visible = true;
                            }
                            frame2.Src = "ApproveRequest.aspx?action=approve&&RequestID=" + txtReqId.Text;
                        }
                        else if (Request.QueryString["action"].ToString().Equals("close"))
                        {
                            txtReqId.ReadOnly = true;
                            //txtReqDesc.ReadOnly = true;
                            ddReqDesc.Enabled = false;
                            ddWorkGroup.Enabled = false;
                            ddPurpose.Enabled = false;
                            txtReqDate.ReadOnly = true;
                            divSave.Visible = false;
                            frame1.Src = "AddRequestItem.aspx?action=close&RequestID=" + txtReqId.Text;
                            divapproval.Visible = true;
                            frame2.Src = "ApproveRequest.aspx?action=close&&RequestID=" + txtReqId.Text;
                        }
                        else
                        {
                            txtReqId.ReadOnly = true;
                            //txtReqDesc.ReadOnly = true;
                            ddReqDesc.Enabled = false;
                            ddWorkGroup.Enabled = false;
                            ddPurpose.Enabled = false;
                            txtReqDate.ReadOnly = true;
                            divSave.Visible = false;
                            frame1.Src = "AddRequestItem.aspx?action=view&RequestID=" + txtReqId.Text;
                            divapproval.Visible = true;
                            frame2.Src = "ApproveRequest.aspx?action=approve&&RequestID=" + txtReqId.Text;
                        }
                    }                    
                }
                
            }

        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex == 0)
            {
                e.Row.RowType = DataControlRowType.Header;

            }
        }    
        

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int errNo = 0;
            string errMsg = "";
            string sparamVal = "";
            if (Request.QueryString["action"].ToString().Equals("add"))
            {
                sparamVal = "@action~A|";
            }
            else
            {
                sparamVal = "@action~U|";
            }
            sparamVal = sparamVal + "@ReqId~" + txtReqId.Text + "|";
            sparamVal = sparamVal + "@ReqDate~" + txtReqDate.Text + "|";
            sparamVal = sparamVal + "@ReqDesc~" + ddReqDesc.SelectedItem.Value + "|";
            sparamVal = sparamVal + "@WorkGroup~" + ddWorkGroup.SelectedItem.Value + "|";
            sparamVal = sparamVal + "@Purpose~" + ddPurpose.SelectedItem.Value + "|";
            sparamVal = sparamVal + "@UserId~" + Session["UserId"];

            DataSet oDs = new DataSet();
            oDs = oGnl.ExecuteSP("SP_VAL_REQUEST", sparamVal, '|', 1);
            errNo = Convert.ToInt32(oDs.Tables[0].Rows[0]["ERRNO"].ToString());
            errMsg = oDs.Tables[0].Rows[0]["ERRMSG"].ToString();
            if (errNo == 0)
            {
                oDs = oGnl.ExecuteSP("SP_POST_REQUEST", sparamVal, '|', 1);
                errNo = Convert.ToInt32(oDs.Tables[0].Rows[0]["ERRNO"].ToString());
                errMsg = oDs.Tables[0].Rows[0]["ERRMSG"].ToString();
                txtReqId.Text = oDs.Tables[0].Rows[0]["RequestId"].ToString();
                if (errNo == 0)
                {
                    lblError.Visible = true;
                    lblError.ForeColor = System.Drawing.Color.Green;

                    if (Request.QueryString["action"].ToString().Equals("add"))
                    {
                        lblError.Text = "Request is Created";
                        btnAdd.Enabled = false;
                        Reset1.Visible = false;
                    }
                    else
                    {
                        lblError.Text = "Request is Updated";
                        btnAdd.Enabled = false;
                        Reset1.Visible = false;
                    }
                    frame1.Src = "AddRequestItem.aspx?action=save&&RequestID=" + txtReqId.Text;
                }
                else
                {
                    lblError.Visible = true;
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = errMsg;
                }
            }
            else
            {
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = errMsg;
            }
            //if (txtReqId.Text == "")
            //{
            //    lblError.Visible = true;
            //    lblError.Text = "Request Id is required";
            //}
            //else if (txtReqDate.Text == "")
            //{
            //    lblError.Visible = true;
            //    lblError.Text = "Request Date is required";
            //}
            ////else if (txtReqDesc.Text == "")
            ////{
            ////    lblError.Visible = true;
            ////    lblError.Text = "Request Description is required";
            ////}
            //else if (IsItemExists(txtReqId.Text) == false)
            //{
            //    lblError.Visible = true;
            //    lblError.Text = "Item is required";
            //}
            //else
            //{

            //}
        }
        
        protected string GenerateCode()
        {
            string code = "";
            try
            {
                DataSet oDs = new DataSet();
                oDs = oGnl.GetDataSet("select top 1 Right(Year(getDate()),2) +  right('000000' + convert(varchar(6),convert(int,RIGHT(isnull([RequestID],'0'),6)) + 1),6)  [Code] from [dbo].[RequestHeader] where [RequestID] like '" + DateTime.Today.ToString("yy") + "%' order by [RequestID] desc", 1);
                if (oDs.Tables[0].Rows.Count > 0)
                {
                    txtReqId.Text = oDs.Tables[0].Rows[0]["Code"].ToString();
                }
                else
                {
                    txtReqId.Text = DateTime.Today.ToString("yy") + "000001";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error:" + ex.ToString();
            }
            return code;
        }

        protected bool IsItemExists(string RequestId)
        {
            bool isExists = false;
            try
            {
                string strQuery = "select * from [RequestDetailTemp] where RequestID=" + RequestId + " and UserId = " + Session["UserId"];
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
    }
}