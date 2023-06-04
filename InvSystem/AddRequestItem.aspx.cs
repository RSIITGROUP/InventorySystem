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
    public partial class AddRequestItem : System.Web.UI.Page
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
            
            if (Request.QueryString["action"].ToString().Equals("add"))
            {
                //strQuerys = "select *, 0 [Stock], 0 [QtyGI], 0 [RemainingQty] from RequestDetailtemp where Requestid=" + Request.QueryString["RequestID"] + " and UserId=" + Session["UserId"];

                strQuerys = "select T0.*, convert(int, a.stock) [Stock], 0 [QtyGI], 0 [RemainingQty] from RequestDetailtemp T0 ";
                strQuerys = strQuerys + "inner join(select ROW_NUMBER() over(partition by t0.idbarang order by t0.idbarang, t0.idtrans, t0.tglproduksi desc)[num], ";
                strQuerys = strQuerys + "t0.idtrans, t0.tglproduksi, t0.idbarang, t1.nmbarang, t0.stock,t1.satuan ";
                strQuerys = strQuerys + "from [CS_Online].dbo.[tbltransaksigudang] t0 inner join[CS_Online].dbo.[tblbarang] t1 on t1.idbarang = t0.idbarang ";
                strQuerys = strQuerys + ") a on t0.ItemCode=a.idbarang where a.num = 1 and a.stock > 0  and t0.Requestid=" + Request.QueryString["RequestID"] + " and T0.UserId=" + Session["UserId"];
            }
            else
            {
                oDs = oGnl.GetDataSet("select T0.RequestState [ReqState], T0.UsrCreate, isnull(t1.Approver,0) Approver from [dbo].[RequestHeader] T0 inner join [Users] T1 on t0.UsrCreate=t1.Id where t0.RequestId='" + Request.QueryString["RequestID"] + "'", 1);
                if (oDs.Tables[0].Rows.Count > 0)
                {
                    usrId = oDs.Tables[0].Rows[0]["UsrCreate"].ToString();
                    reqState = oDs.Tables[0].Rows[0]["ReqState"].ToString();
                    approver = oDs.Tables[0].Rows[0]["Approver"].ToString();
                }
                if (Request.QueryString["action"].ToString().Equals("edit"))
                {
                    if (Session["UserId"].Equals(usrId) && reqState.Equals("8001"))
                    {
                        //strQuerys = "select *, 0 [Stock], 0 [QtyGI], 0 [RemainingQty] from RequestDetailtemp where Requestid=" + Request.QueryString["RequestID"] + " and UserId=" + Session["UserId"];
                        strQuerys = "select T0.*, convert(int, a.stock) [Stock], 0 [QtyGI], 0 [RemainingQty] from RequestDetailtemp T0 ";
                        strQuerys = strQuerys + "inner join(select ROW_NUMBER() over(partition by t0.idbarang order by t0.idbarang, t0.idtrans, t0.tglproduksi desc)[num], ";
                        strQuerys = strQuerys + "t0.idtrans, t0.tglproduksi, t0.idbarang, t1.nmbarang, t0.stock,t1.satuan ";
                        strQuerys = strQuerys + "from [CS_Online].dbo.[tbltransaksigudang] t0 inner join[CS_Online].dbo.[tblbarang] t1 on t1.idbarang = t0.idbarang ";
                        strQuerys = strQuerys + ") a on t0.ItemCode=a.idbarang where a.num = 1 and a.stock > 0  and t0.Requestid=" + Request.QueryString["RequestID"] + " and T0.UserId=" + Session["UserId"];
                    }
                    else
                    {
                        strQuerys = "select *, 0 [Stock], 0 [QtyGI], 0 [RemainingQty] from RequestDetail where Requestid=" + Request.QueryString["RequestID"];
                    }
                }
                else if (Request.QueryString["action"].ToString().Equals("approve"))
                {
                    strQuerys = "select *, 0 [Stock], 0 [QtyGI], 0 [RemainingQty] from RequestDetail where Requestid=" + Request.QueryString["RequestID"];
                }
                else if (Request.QueryString["action"].ToString().Equals("save"))
                {
                    strQuerys = "select *, 0 [Stock], 0 [QtyGI], 0 [RemainingQty] from RequestDetail where Requestid=" + Request.QueryString["RequestID"];
                }
                else
                {
                    //strQuerys = "select * from RequestDetail where Requestid=" + Request.QueryString["RequestID"];
                    strQuerys = "select T0.*, 0 [Stock], sum(t1.Qty)[QtyGI], T0.Qty - isnull(sum(t1.Qty), 0)[RemainingQty] ";
                    strQuerys = strQuerys + "from RequestDetail T0 ";
                    strQuerys = strQuerys + "left join [GIDetail] T1 on t0.RequestID = T1.RequestID and t0.LineId = t1.LineId ";
                    strQuerys = strQuerys + "left join[GIHeader] t2 on t1.GIID = t2.GIID where T0.Requestid=" + Request.QueryString["RequestID"];
                    strQuerys = strQuerys + " group by t0.RequestID, t0.LineId,t0.ItemCode,t0.ItemDesc,t0.Qty,t0.Unit ";
                }
            }
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
                GridView1.Rows[0].Cells[0].Text = "No Data Found!";
                GridView1.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
            if (Request.QueryString["action"].ToString().Equals("add") || (Request.QueryString["action"].ToString().Equals("edit") && Session["UserId"].Equals(usrId) && reqState.Equals("8001")))
            {
                Label lblRequestID = GridView1.FooterRow.FindControl("lblRequestIDFooter") as Label;
                lblRequestID.Text = Request.QueryString["RequestID"];

                Label lblLineID = GridView1.FooterRow.FindControl("lblLineIDFooter") as Label;
                oDs = oGnl.GetDataSet("select isnull(max(LineId),0) + 1 [LineId] from [RequestDetailtemp] where RequestId='" + Request.QueryString["RequestID"] + "' and UserId=" + Session["UserId"], 1);
                if (oDs.Tables[0].Rows.Count > 0)
                {
                    lblLineID.Text = oDs.Tables[0].Rows[0]["LineId"].ToString();
                }
                else
                {
                    lblLineID.Text = "1";
                }

                //DropDownList ddItemCode = GridView1.FooterRow.FindControl("ddItemCodeFooter") as DropDownList;
                AjaxControlToolkit.ComboBox ddItemCode = GridView1.FooterRow.FindControl("ddItemCodeFooter") as AjaxControlToolkit.ComboBox;
                string strQuery = "select a.idbarang [Code], a.idbarang [Name] from (";
                strQuery = strQuery + "select ROW_NUMBER() over(partition by t0.idbarang order by t0.idbarang, t0.idtrans, t0.tglproduksi desc)[num], ";
                strQuery = strQuery + "t0.idtrans, t0.tglproduksi, t0.idbarang, t1.nmbarang, t0.stock,t1.satuan ";
                strQuery = strQuery + "from [tbltransaksigudang] t0 inner join [tblbarang] t1 on t1.idbarang = t0.idbarang ";
                strQuery = strQuery + ") a where a.num = 1 and a.stock > 0 order by a.idbarang";
                //oGnl.SeDropDown(strQuery, ddItemCode, 2);
                oGnl.SeComboBox(strQuery, ddItemCode, 2);
                ddItemCode.Items.Insert(0, new ListItem("--Select--", "0"));
                ddItemCode.SelectedValue = "0";
                this.GridView1.Columns[4].Visible = true;
                this.GridView1.Columns[6].Visible = false;
                this.GridView1.Columns[7].Visible = false;
            }
            else if (Request.QueryString["action"].ToString().Equals("save"))
            {
                this.GridView1.Columns[4].Visible = false;
                this.GridView1.Columns[6].Visible = false;
                this.GridView1.Columns[7].Visible = false;
                this.GridView1.Columns[9].Visible = false;
                GridView1.FooterRow.Visible = false;
            }
            else
            {
                this.GridView1.Columns[4].Visible = false;
                this.GridView1.Columns[6].Visible = true;
                this.GridView1.Columns[7].Visible = true;
                this.GridView1.Columns[9].Visible = false;
                GridView1.FooterRow.Visible = false;
            }
        }

        protected void GridViedReload()
        {
            //string itemcode = ((DropDownList)GridView1.FooterRow.FindControl("ddItemCodeFooter")).SelectedItem.Value;
            string itemcode = ((AjaxControlToolkit.ComboBox)GridView1.FooterRow.FindControl("ddItemCodeFooter")).SelectedItem.Value;
            string itemdesc = (GridView1.FooterRow.FindControl("lblItemDescFooter") as Label).Text;
            string stock = (GridView1.FooterRow.FindControl("lblStockFooter") as TextBox).Text;
            string qty = (GridView1.FooterRow.FindControl("txtQtyFooter") as TextBox).Text;
            string unit = (GridView1.FooterRow.FindControl("lblUnitFooter") as Label).Text;
            GridView1.EditIndex = -1;
            BindGrid();
            //((DropDownList)GridView1.FooterRow.FindControl("ddItemCodeFooter")).SelectedValue = itemcode;
            ((AjaxControlToolkit.ComboBox)GridView1.FooterRow.FindControl("ddItemCodeFooter")).SelectedValue = itemcode;
            (GridView1.FooterRow.FindControl("lblItemDescFooter") as Label).Text = itemdesc;
            (GridView1.FooterRow.FindControl("lblStockFooter") as Label).Text = stock;
            (GridView1.FooterRow.FindControl("txtQtyFooter") as TextBox).Text = qty;
            (GridView1.FooterRow.FindControl("lblUnitFooter") as Label).Text = unit;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    lblErrorMessage.Text = "";
                    lblErrorMessage.ForeColor = System.Drawing.Color.Red;
                    if ((GridView1.FooterRow.FindControl("lblItemDescFooter") as Label).Text.Trim().Equals(""))
                    {
                        GridViedReload();
                        lblErrorMessage.Text = "Please Choose The Item";
                        lblErrorMessage.ForeColor = System.Drawing.Color.Red;
                    }
                    else if (((GridView1.FooterRow.FindControl("txtQtyFooter") as TextBox).Text.ToString().Equals("")) || (Convert.ToInt64((GridView1.FooterRow.FindControl("txtQtyFooter") as TextBox).Text.ToString()) <= 0))
                    {
                        GridViedReload();
                        lblErrorMessage.Text = "Quantity should be greater than 0";
                        lblErrorMessage.ForeColor = System.Drawing.Color.Red;
                    }
                    else if (IsQtyExcessive((GridView1.FooterRow.FindControl("lblRequestIDFooter") as Label).Text.Trim(), (GridView1.FooterRow.FindControl("lblLineIDFooter") as Label).Text.Trim(), (GridView1.FooterRow.FindControl("ddItemCodeFooter") as AjaxControlToolkit.ComboBox).SelectedItem.Value, (GridView1.FooterRow.FindControl("txtQtyFooter") as TextBox).Text.ToString()) == true)
                    {
                        GridViedReload();
                        lblErrorMessage.Text = "Quantity excessed";
                        lblErrorMessage.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        string sparamVal = "@RequestId~" + (GridView1.FooterRow.FindControl("lblRequestIDFooter") as Label).Text.Trim() + "|";
                        sparamVal = sparamVal + "@LineId~" + (GridView1.FooterRow.FindControl("lblLineIDFooter") as Label).Text.Trim() + "|";
                        sparamVal = sparamVal + "@UserId~" + Session["UserId"] + "|";
                        sparamVal = sparamVal + "@ItemCode~" + (GridView1.FooterRow.FindControl("ddItemCodeFooter") as AjaxControlToolkit.ComboBox).SelectedItem.Value + "|";
                        sparamVal = sparamVal + "@ItemDesc~" + (GridView1.FooterRow.FindControl("lblItemDescFooter") as Label).Text.Trim() + "|";
                        sparamVal = sparamVal + "@Qty~" + (GridView1.FooterRow.FindControl("txtQtyFooter") as TextBox).Text.Trim() + "|";
                        sparamVal = sparamVal + "@Unit~" + (GridView1.FooterRow.FindControl("lblUnitFooter") as Label).Text.Trim();
                        oGnl.ExecuteDataQuery("insert into RequestDetailtemp (RequestId,LineId,UserId,ItemCode,ItemDesc,Qty,Unit) values (@RequestId,@LineId,@UserId,@ItemCode,@ItemDesc,@Qty,@Unit)", sparamVal, Convert.ToChar("|"), 1);

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
        
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            lblErrorMessage.Text = "";
            lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            lblErrorMessage.Text = "";
            lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            GridView1.EditIndex = -1;
            BindGrid();
        }       

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                lblErrorMessage.Text = "";
                lblErrorMessage.ForeColor = System.Drawing.Color.Red;
                if (IsQtyExcessive(GridView1.DataKeys[e.RowIndex].Value.ToString(), (GridView1.Rows[e.RowIndex].FindControl("lblLineID") as Label).Text.Trim(), (GridView1.Rows[e.RowIndex].FindControl("lblItemCode") as Label).Text.Trim(), (GridView1.Rows[e.RowIndex].FindControl("txtQty") as TextBox).Text.Trim()) == true)
                {
                    lblErrorMessage.Text = "Quantity excessed";
                    lblErrorMessage.ForeColor = System.Drawing.Color.Red;
                    GridView1.EditIndex = e.RowIndex;
                }
                else
                {
                    string sparamVal = "@LineId~" + (GridView1.Rows[e.RowIndex].FindControl("lblLineID") as Label).Text.Trim() + "|";
                    sparamVal = sparamVal + "@UserId~" + Session["UserId"] + "|";
                    sparamVal = sparamVal + "@Qty~" + (GridView1.Rows[e.RowIndex].FindControl("txtQty") as TextBox).Text.Trim() + "|";
                    sparamVal = sparamVal + "@RequestId~" + GridView1.DataKeys[e.RowIndex].Value.ToString();
                    oGnl.ExecuteDataQuery("update RequestDetailtemp set Qty=@Qty where RequestId=@RequestId and LineId=@LineId and UserId=@UserId", sparamVal, Convert.ToChar("|"), 1);

                    GridView1.EditIndex = -1;
                    BindGrid(); 
                }
                //lblErrorMessage.Text = "Selected Record Updated";
                //lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            }
            catch (Exception ex)
            {
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
                string sparamVal = "@LineId~" + (GridView1.Rows[e.RowIndex].FindControl("lblLine") as Label).Text.Trim() + ",";
                sparamVal = sparamVal + "@UserId~" + Session["UserId"] + ",";
                sparamVal = sparamVal + "@RequestId~" + GridView1.DataKeys[e.RowIndex].Value.ToString();
                oGnl.ExecuteDataQuery("Delete from RequestDetailtemp where RequestId=@RequestId and LineId=@LineId and UserId=@UserId", sparamVal, Convert.ToChar(","), 1);

                GridView1.EditIndex = -1;
                BindGrid();
                //lblSuccessMessage.Text = "Selected Record Deleted";
                //lblErrorMessage.Text = "Selected Record Updated";
                //lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.ToString();
                lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void ddItemCodeFooter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                //DropDownList ddItemCode = (DropDownList)GridView1.FooterRow.FindControl("ddItemCodeFooter");
                AjaxControlToolkit.ComboBox ddItemCode = (AjaxControlToolkit.ComboBox)GridView1.FooterRow.FindControl("ddItemCodeFooter");
                string ItemCode = ddItemCode.SelectedItem.Value;
                
                DataSet oDs = new DataSet();
                //oDs = oGnl.GetDataSet("select nmbarang, satuan from [tblbarang] where idbarang='" + ItemCode + "'", 2);

                string strQuery = "select a.nmbarang, a.satuan, a.idbarang, convert(int,a.stock) stock from (";
                strQuery = strQuery + "select ROW_NUMBER() over(partition by t0.idbarang order by t0.idbarang, t0.idtrans, t0.tglproduksi desc)[num], ";
                strQuery = strQuery + "t0.idtrans, t0.tglproduksi, t0.idbarang, t1.nmbarang, t0.stock,t1.satuan ";
                strQuery = strQuery + "from [tbltransaksigudang] t0 inner join [tblbarang] t1 on t1.idbarang = t0.idbarang ";
                strQuery = strQuery + ") a where a.num = 1 and a.stock > 0 and a.idbarang='" + ItemCode + "'";

                oDs = oGnl.GetDataSet(strQuery, 2);
                if (oDs.Tables[0].Rows.Count > 0)
                {
                    GridView1.EditIndex = -1;
                    BindGrid();
                    (GridView1.FooterRow.FindControl("lblItemDescFooter") as Label).Text = oDs.Tables[0].Rows[0]["nmbarang"].ToString();
                    (GridView1.FooterRow.FindControl("lblUnitFooter") as Label).Text = oDs.Tables[0].Rows[0]["satuan"].ToString();
                    (GridView1.FooterRow.FindControl("lblStockFooter") as Label).Text = oDs.Tables[0].Rows[0]["stock"].ToString();
                    ((AjaxControlToolkit.ComboBox)GridView1.FooterRow.FindControl("ddItemCodeFooter")).SelectedValue = ItemCode;
                }
                else
                {
                    GridView1.EditIndex = -1;
                    BindGrid();
                    (GridView1.FooterRow.FindControl("lblItemDescFooter") as Label).Text = "";
                    (GridView1.FooterRow.FindControl("lblUnitFooter") as Label).Text = "";
                    (GridView1.FooterRow.FindControl("lblStockFooter") as Label).Text = "0";
                    ((AjaxControlToolkit.ComboBox)GridView1.FooterRow.FindControl("ddItemCodeFooter")).SelectedValue = ItemCode;
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.ToString();
                lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected bool IsQtyExcessive(string RequestId,string lineId, string itemCode,String qty)
        {
            bool isExessed = false;
            try
            {
                Int64 stock = 0;
                Int64 qtyused = 0;
                string strQuery = "select a.stock from (";
                strQuery = strQuery + "select ROW_NUMBER() over(partition by t0.idbarang order by t0.idbarang, t0.idtrans, t0.tglproduksi desc)[num], ";
                strQuery = strQuery + "t0.idtrans, t0.tglproduksi, t0.idbarang, t1.nmbarang, t0.stock,t1.satuan ";
                strQuery = strQuery + "from [tbltransaksigudang] t0 inner join [tblbarang] t1 on t1.idbarang = t0.idbarang ";
                strQuery = strQuery + ") a where a.num = 1 and a.stock > 0 AND a.idbarang='" + itemCode + "'";
                DataSet oDs = new DataSet();
                oDs = oGnl.GetDataSet(strQuery, 2);
                if (oDs.Tables[0].Rows.Count > 0)
                {
                    stock = Convert.ToInt64(oDs.Tables[0].Rows[0]["stock"]);
                }

                strQuery = "select sum(isnull(a.Qty,0)) QTY from( ";
                strQuery = strQuery + "select sum(qty) Qty from[dbo].[RequestDetail] t0 ";
                strQuery = strQuery + "inner join[dbo].[RequestHeader] t1 on t0.RequestID= t1.RequestID ";
                strQuery = strQuery + "and t1.RequestState in (1,2) and t0.ItemCode = '" + itemCode + "' and t0.RequestID <> " + RequestId + " ";
                strQuery = strQuery + "union ";
                strQuery = strQuery + "select sum(qty) Qty from[RequestDetailTemp] where ItemCode = '" + itemCode + "' and RequestID = " + RequestId + " and LineId <> " + lineId + " and UserId = " + Session["UserId"] +")a ";

                oDs = oGnl.GetDataSet(strQuery, 1);
                if (oDs.Tables[0].Rows.Count > 0)
                {
                    qtyused = Convert.ToInt64(oDs.Tables[0].Rows[0]["QTY"]);
                }

                if (stock < qtyused + Convert.ToInt64(qty))
                {
                    isExessed = true;
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.ToString();
                lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            }
            return isExessed;
        }
    }
}