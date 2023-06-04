﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using InvSystem.Class;

namespace InvSystem
{
    public partial class AddGoodsReturn : System.Web.UI.Page
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
                string grState = "";

                lblError.Visible = false;
                lblError.ForeColor = System.Drawing.Color.Red;
                DataSet oDs = new DataSet();
                string sparamVal = "";
                if (!IsPostBack)
                {
                    btnAdd.Text = "Submit";
                    if (Request.QueryString["action"].ToString().Equals("add"))
                    {
                        GenerateCode();
                        sparamVal = "@GRId~" + txtGRId.Text + "|";
                        sparamVal = sparamVal + "@UserId~" + Session["UserId"];
                        oGnl.ExecuteDataQuery("Delete from GRDetailtemp where GRId=@GRId and UserId=@UserId", sparamVal, Convert.ToChar("|"), 1);
                        frame1.Src = "AddGoodsReturnItem.aspx?action=add&&GRID=" + txtGRId.Text + "&&ReqDate=" + txtGRDate.Text;
                    }
                    else
                    {
                        oDs = oGnl.GetDataSet("select * from [GRHeader] where GRId='" + Request.QueryString["GRID"] + "'", 1);
                        if (oDs.Tables[0].Rows.Count > 0)
                        {
                            txtGRId.Text = oDs.Tables[0].Rows[0]["GRID"].ToString();
                            txtGRReason.Text = oDs.Tables[0].Rows[0]["GRReason"].ToString();
                            usrId = oDs.Tables[0].Rows[0]["UsrCreate"].ToString();
                            grState = oDs.Tables[0].Rows[0]["GRState"].ToString();
                            if (oDs.Tables[0].Rows[0]["GRDate"].ToString() != "")
                            {
                                txtGRDate.Text = Convert.ToDateTime(oDs.Tables[0].Rows[0]["GRDate"]).ToString("yyyy-MM-dd");
                            }
                        }

                        if (Request.QueryString["action"].ToString().Equals("edit"))
                        {
                            if (Session["UserId"].Equals(usrId) && grState.Equals("0"))
                            {
                                sparamVal = "@GRId~" + txtGRId.Text + ",";
                                sparamVal = sparamVal + "@UserId~" + Session["UserId"];
                                oGnl.ExecuteDataQuery("Delete from GRDetailtemp where GRId=@GRId and UserId=@UserId", sparamVal, Convert.ToChar(","), 1);
                                oGnl.ExecuteDataQuery("insert into GRDetailtemp (GRId,LineId,UserId,ItemCode,ItemDesc,Qty,Unit) select [GRID],[LineId]," + Session["UserId"] + " [UserId],[ItemCode],[ItemDesc],[Qty],[Unit] from GRDetail where GRId=@GRId", sparamVal, Convert.ToChar(","), 1);
                                txtGRId.ReadOnly = false;
                                txtGRReason.ReadOnly = false;
                                txtGRDate.ReadOnly = false;
                                btnAdd.Visible = true;
                                Reset1.Visible = true;
                                divSave.Visible = true;
                                frame1.Src = "AddGoodsReturnItem.aspx?action=edit&&GRID=" + txtGRId.Text + "&&ReqDate=" + txtGRDate.Text;
                            }
                            else
                            {
                                txtGRId.ReadOnly = true;
                                txtGRReason.ReadOnly = true;
                                txtGRDate.ReadOnly = true;
                                divSave.Visible = false;
                                frame1.Src = "AddGoodsReturnItem.aspx?action=view&&GRID=" + txtGRId.Text + "&&ReqDate=" + txtGRDate.Text;
                            }
                        }
                        else if (Request.QueryString["action"].ToString().Equals("verified"))
                        {
                            sparamVal = "@GRId~" + txtGRId.Text + ",";
                            sparamVal = sparamVal + "@UserId~" + Session["UserId"];
                            oGnl.ExecuteDataQuery("Delete from GRDetailtemp where GRId=@GRId and UserId=@UserId", sparamVal, Convert.ToChar(","), 1);
                            oGnl.ExecuteDataQuery("insert into GRDetailtemp (GRId,LineId,UserId,ItemCode,ItemDesc,Qty,Unit) select [GRID],[LineId]," + Session["UserId"] + " [UserId],[ItemCode],[ItemDesc],[Qty],[Unit] from GRDetail where GRId=@GRId", sparamVal, Convert.ToChar(","), 1);
                            txtGRId.ReadOnly = true;
                            txtGRReason.ReadOnly = true;
                            txtGRDate.ReadOnly = true;
                            divSave.Visible = true;
                            btnAdd.Text = "Verified";
                            frame1.Src = "AddGoodsReturnItem.aspx?action=verified&&GRID=" + txtGRId.Text + "&&ReqDate=" + txtGRDate.Text;
                        }
                    }
                }

            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtGRId.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "GR Id is required";
            }
            else if (txtGRDate.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Request Date is required";
            }
            else if (txtGRReason.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Reason is required";
            }
            else if (IsItemExists(txtGRId.Text) == false)
            {
                lblError.Visible = true;
                lblError.Text = "Item is required";
            }
            else
            {
                int errNo = 0;
                string errMsg = "";
                string sparamVal = "";
                if (Request.QueryString["action"].ToString().Equals("add"))
                {
                    sparamVal = "@action~A|";
                }
                else if (Request.QueryString["action"].ToString().Equals("verified"))
                {
                    sparamVal = "@action~V|";
                }
                else
                {
                    sparamVal = "@action~U|";
                }
                sparamVal = sparamVal + "@GRId~" + txtGRId.Text + "|";
                sparamVal = sparamVal + "@GRDate~" + txtGRDate.Text + "|";
                sparamVal = sparamVal + "@GRReason~" + txtGRReason.Text + "|";
                sparamVal = sparamVal + "@UserId~" + Session["UserId"];

                DataSet oDs = new DataSet();
                oDs = oGnl.ExecuteSP("SP_POST_GR", sparamVal, '|', 1);

                errNo = Convert.ToInt32(oDs.Tables[0].Rows[0]["ERRNO"].ToString());
                errMsg = oDs.Tables[0].Rows[0]["ERRMSG"].ToString();
                txtGRId.Text = oDs.Tables[0].Rows[0]["GRId"].ToString();
                if (errNo == 0)
                {
                    lblError.Visible = true;
                    lblError.ForeColor = System.Drawing.Color.Green;

                    if (Request.QueryString["action"].ToString().Equals("add"))
                    {
                        lblError.Text = "GR is Created";
                        btnAdd.Enabled = false;
                        Reset1.Visible = false;
                    }
                    else
                    {
                        if (Request.QueryString["action"].ToString().Equals("verified"))
                        {
                            lblError.Text = "GR is Verified";
                        }
                        else
                        {
                            lblError.Text = "GR is Updated";
                        }
                        btnAdd.Enabled = false;
                        Reset1.Visible = false;
                    }
                    //frame1.Src = "AddRequestItem.aspx?action=save&&RequestID=" + txtGRId.Text;
                    frame1.Src = "AddGoodsReturnItem.aspx?action=save&&GRID=" + txtGRId.Text + "&&ReqDate=" + txtGRDate.Text;
                }
                else
                {
                    lblError.Visible = true;
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = errMsg;
                }
            }
        }

        protected string GenerateCode()
        {
            string code = "";
            try
            {
                DataSet oDs = new DataSet();
                oDs = oGnl.GetDataSet("select top 1 Right(Year(getDate()),2) +  right('000000' + convert(varchar(6),convert(int,RIGHT(isnull([GRID],'0'),6)) + 1),6)  [Code] from [dbo].[GRHeader] where [GRID] like '" + DateTime.Today.ToString("yy") + "%' order by [GRID] desc", 1);
                if (oDs.Tables[0].Rows.Count > 0)
                {
                    txtGRId.Text = oDs.Tables[0].Rows[0]["Code"].ToString();
                }
                else
                {
                    txtGRId.Text = DateTime.Today.ToString("yy") + "000001";
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
                string strQuery = "select * from [GRDetailTemp] where GRID=" + RequestId + " and UserId = " + Session["UserId"];
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

        protected void txtGRDate_TextChanged(object sender, EventArgs e)
        {
            frame1.Src = "AddGoodsReturnItem.aspx?action=add&&GRID=" + txtGRId.Text + "&&ReqDate=" + txtGRDate.Text;
        }
    }
}