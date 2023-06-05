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
    public partial class UserApproval : System.Web.UI.Page
    {
        clsGeneral oGnl = new clsGeneral();
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            string strQuerys = "";
            DataSet oDs = new DataSet();
            string usrId = "";
            string reqState = "";
            string approver = "";

            //if (Request.QueryString["action"].ToString().Equals("add"))
            //{
            //    strQuerys = "select t0.UserId, UPPER(CONCAT(T1.FirstName , ' ' , T1.LastName)) [Approver] from [UserApprovalTmp] T0 ";
            //    strQuerys = strQuerys + "inner join Users T1 on T0.ApproverId=t1.Id where T0.UserId=" + Request.QueryString["usr"] + " and T0.UsrId=" + Session["UserId"];
            //}
            //else
            //{
            //    oDs = oGnl.GetDataSet("select T0.RequestState [ReqState], T0.UsrCreate, isnull(t1.Approver,0) Approver from [dbo].[RequestHeader] T0 inner join [Users] T1 on t0.UsrCreate=t1.Id where t0.RequestId='" + Request.QueryString["RequestID"] + "'", 1);
            //    if (oDs.Tables[0].Rows.Count > 0)
            //    {
            //        usrId = oDs.Tables[0].Rows[0]["UsrCreate"].ToString();
            //        reqState = oDs.Tables[0].Rows[0]["ReqState"].ToString();
            //        approver = oDs.Tables[0].Rows[0]["Approver"].ToString();
            //    }
            //    if (Request.QueryString["action"].ToString().Equals("edit"))
            //    {
            //        if (Session["UserId"].Equals(usrId) && reqState.Equals("8001"))
            //        {
            //            //strQuerys = "select *, 0 [Stock], 0 [QtyGI], 0 [RemainingQty] from RequestDetailtemp where Requestid=" + Request.QueryString["RequestID"] + " and UserId=" + Session["UserId"];
            //            strQuerys = "select T0.*, convert(int, a.stock) [Stock], 0 [QtyGI], 0 [RemainingQty] from RequestDetailtemp T0 ";
            //            strQuerys = strQuerys + "inner join(select ROW_NUMBER() over(partition by t0.idbarang order by t0.idbarang, t0.idtrans, t0.tglproduksi desc)[num], ";
            //            strQuerys = strQuerys + "t0.idtrans, t0.tglproduksi, t0.idbarang, t1.nmbarang, t0.stock,t1.satuan ";
            //            strQuerys = strQuerys + "from [CS_Online].dbo.[tbltransaksigudang] t0 inner join[CS_Online].dbo.[tblbarang] t1 on t1.idbarang = t0.idbarang ";
            //            strQuerys = strQuerys + ") a on t0.ItemCode=a.idbarang where a.num = 1 and a.stock > 0  and t0.Requestid=" + Request.QueryString["RequestID"] + " and T0.UserId=" + Session["UserId"];
            //        }
            //        else
            //        {
            //            strQuerys = "select *, 0 [Stock], 0 [QtyGI], 0 [RemainingQty] from RequestDetail where Requestid=" + Request.QueryString["RequestID"];
            //        }
            //    }
            //    else if (Request.QueryString["action"].ToString().Equals("approve"))
            //    {
            //        strQuerys = "select *, 0 [Stock], 0 [QtyGI], 0 [RemainingQty] from RequestDetail where Requestid=" + Request.QueryString["RequestID"];
            //    }
            //    else if (Request.QueryString["action"].ToString().Equals("save"))
            //    {
            //        strQuerys = "select *, 0 [Stock], 0 [QtyGI], 0 [RemainingQty] from RequestDetail where Requestid=" + Request.QueryString["RequestID"];
            //    }
            //    else
            //    {
            //        //strQuerys = "select * from RequestDetail where Requestid=" + Request.QueryString["RequestID"];
            //        strQuerys = "select T0.*, 0 [Stock], sum(t1.Qty)[QtyGI], T0.Qty - isnull(sum(t1.Qty), 0)[RemainingQty] ";
            //        strQuerys = strQuerys + "from RequestDetail T0 ";
            //        strQuerys = strQuerys + "left join [GIDetail] T1 on t0.RequestID = T1.RequestID and t0.LineId = t1.LineId ";
            //        strQuerys = strQuerys + "left join[GIHeader] t2 on t1.GIID = t2.GIID where T0.Requestid=" + Request.QueryString["RequestID"];
            //        strQuerys = strQuerys + " group by t0.RequestID, t0.LineId,t0.ItemCode,t0.ItemDesc,t0.Qty,t0.Unit ";
            //    }
            //}
            strQuerys = "select t0.UserId, UPPER(CONCAT(T1.FirstName , ' ' , T1.LastName)) [ApproverId] from [UserApprovalTmp] T0 ";
            strQuerys = strQuerys + "inner join Users T1 on T0.ApproverId=t1.Id where T0.UserId=" + Request.QueryString["usr"] + " and T0.UsrId=" + Session["UserId"];
            DataTable dt = oGnl.GetDataTable(strQuerys, 1);

            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                GridView1.DataSource = dt;
                GridView1.DataBind();
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                //GridView1.Rows[0].Cells[0].Text = "No Data Found!";
                GridView1.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

            AjaxControlToolkit.ComboBox ddUsrId = GridView1.FooterRow.FindControl("ddApproverFooter") as AjaxControlToolkit.ComboBox;
            string strQuery = "select Id [Code], UPPER(CONCAT(FirstName , ' ' , LastName)) [Name] from Users where Id <> " + Request.QueryString["usr"];
            oGnl.SeComboBox(strQuery, ddUsrId, 1);
            ddUsrId.Items.Insert(0, new ListItem("--Select--", "0"));
            ddUsrId.SelectedValue = "0";
        }

        protected void GridViedReload()
        {
            //string itemcode = ((DropDownList)GridView1.FooterRow.FindControl("ddItemCodeFooter")).SelectedItem.Value;
            string ddUsrId = ((AjaxControlToolkit.ComboBox)GridView1.FooterRow.FindControl("ddApproverFooter")).SelectedItem.Value;            
            GridView1.EditIndex = -1;
            BindGrid();
            ((AjaxControlToolkit.ComboBox)GridView1.FooterRow.FindControl("ddApproverFooter")).SelectedValue = ddUsrId;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    lblErrorMessage.Text = "";
                    lblErrorMessage.ForeColor = System.Drawing.Color.Red;
                    if (((AjaxControlToolkit.ComboBox)GridView1.FooterRow.FindControl("ddApproverFooter")).SelectedItem.Value.Equals("0"))
                    {
                        GridViedReload();
                        lblErrorMessage.Text = "Please Choose Approver";
                        lblErrorMessage.ForeColor = System.Drawing.Color.Red;
                    }
                    else if (Request.QueryString["usr"].Equals("0"))
                    {
                        GridViedReload();
                        lblErrorMessage.Text = "Please Choose User";
                        lblErrorMessage.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        string sparamVal = "@UserId~" + Request.QueryString["usr"] + "|";
                        sparamVal = sparamVal + "@ApproverId~" + (GridView1.FooterRow.FindControl("ddApproverFooter") as AjaxControlToolkit.ComboBox).SelectedItem.Value + "|";
                        sparamVal = sparamVal + "@UsrId~" + Session["UserId"] + "|";
                        sparamVal = sparamVal + "@UserCreate~" + Session["UserId"];
                        oGnl.ExecuteDataQuery("insert into UserApprovalTmp (UserId,ApproverId,UsrId,UserCreate,CreateDate) values (@UserId,@ApproverId,@UsrId,@UserCreate,getdate())", sparamVal, Convert.ToChar("|"), 1);

                        BindGrid();
                        //lblErrorMessage.Text = "New Record Add";
                        //lblErrorMessage.ForeColor = System.Drawing.Color.Green;
                    }

                }
            }
            catch (Exception ex)
            {
                GridViedReload();
                lblErrorMessage.Text = ex.ToString();
                lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                lblErrorMessage.Text = "";
                lblErrorMessage.ForeColor = System.Drawing.Color.Red;
                if (!(GridView1.Rows[e.RowIndex].FindControl("lblApprover") as Label).Text.Trim().Equals("0")) {
                    string sparamVal = "@ApproverId~" + (GridView1.Rows[e.RowIndex].FindControl("lblApprover") as Label).Text.Trim() + ",";
                    sparamVal = sparamVal + "@UsrId~" + Session["UserId"] + ",";
                    sparamVal = sparamVal + "@UserId~" + GridView1.DataKeys[e.RowIndex].Value.ToString();
                    oGnl.ExecuteDataQuery("Delete from UserApprovalTmp where UserId=@UserId and UsrId=@UsrId and ApproverId in (select id from users where UPPER(CONCAT(FirstName , ' ' , LastName)) = @ApproverId)", sparamVal, Convert.ToChar(","), 1);

                    GridView1.EditIndex = -1;
                    BindGrid();
                    //lblSuccessMessage.Text = "Selected Record Deleted";
                    //lblErrorMessage.Text = "Selected Record Updated";
                    //lblErrorMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.ToString();
                lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}