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
    public partial class AddGoodsReturnItem : System.Web.UI.Page
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
            string grState = "";
            //string approver = "";

            if (Request.QueryString["action"].ToString().Equals("add"))
            {
                strQuerys = "select * from GRDetailtemp where GRid=" + Request.QueryString["GRID"] + " and UserId=" + Session["UserId"];
            }
            else
            {
                oDs = oGnl.GetDataSet("select * from [GRHeader] where GRId='" + Request.QueryString["ReqID"] + "'", 1);
                if (oDs.Tables[0].Rows.Count > 0)
                {
                    usrId = oDs.Tables[0].Rows[0]["UsrCreate"].ToString();
                    grState = oDs.Tables[0].Rows[0]["GRState"].ToString();
                }
                if (Request.QueryString["action"].ToString().Equals("edit"))
                {
                    if (Session["UserId"].Equals(usrId) && grState.Equals("0"))
                    {
                        strQuerys = "select * from GRDetailtemp where GRid=" + Request.QueryString["GRID"] + " and UserId=" + Session["UserId"];
                    }
                    else
                    {
                        strQuerys = "select * from GRDetail where GRid=" + Request.QueryString["GRID"];
                    }
                }
                else if (Request.QueryString["action"].ToString().Equals("verified"))
                {
                    strQuerys = "select * from GRDetailtemp where GRid=" + Request.QueryString["GRID"] + " and UserId=" + Session["UserId"];
                }
                else if (Request.QueryString["action"].ToString().Equals("save"))
                {
                    strQuerys = "select * from GRDetail where GRid=" + Request.QueryString["GRID"];
                }
                else
                {
                    strQuerys = "select * from GRDetail where GRid=" + Request.QueryString["GRID"];
                    //strQuerys = "select T0.*, sum(t1.Qty)[QtyGI], SUm(T0.Qty) - isnull(sum(t1.Qty), 0)[RemainingQty] ";
                    //strQuerys = strQuerys + "from RequestDetail T0 ";
                    //strQuerys = strQuerys + "left join [GIDetail] T1 on t0.RequestID = T1.RequestID and t0.LineId = t1.LineId ";
                    //strQuerys = strQuerys + "left join[GIHeader] t2 on t1.GIID = t2.GIID where T0.Requestid=" + Request.QueryString["RequestID"];
                    //strQuerys = strQuerys + " group by t0.RequestID, t0.LineId,t0.ItemCode,t0.ItemDesc,t0.Qty,t0.Unit ";
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
            if (Request.QueryString["action"].ToString().Equals("add") || (Request.QueryString["action"].ToString().Equals("edit") && Session["UserId"].Equals(usrId)))
            {
                Label lblRequestID = GridView1.FooterRow.FindControl("lblGRIDFooter") as Label;
                lblRequestID.Text = Request.QueryString["GRID"];

                Label lblLineID = GridView1.FooterRow.FindControl("lblLineIDFooter") as Label;
                oDs = oGnl.GetDataSet("select isnull(max(LineId),0) + 1 [LineId] from [GRDetailtemp] where GRId='" + Request.QueryString["GRID"] + "' and UserId=" + Session["UserId"], 1);
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

                string strQuery = "select t1.ItemCode [Code], t1.ItemCode [Name] from RequestHeader t0 inner join RequestDetail t1 on t0.RequestID = t1.RequestID ";
                strQuery = strQuery + "inner join Users t2 on t0.UsrCreate = t2.Id inner join Users t3 on t2.WorkGroup = t3.WorkGroup ";
                strQuery = strQuery + "where t0.RequestState not in ('8001', '8003') and t3.Id = " + Session["UserId"] + " ";
                strQuery = strQuery + "and t0.RequestDate = convert(date, '" + Request.QueryString["ReqDate"] + "') order by t1.ItemCode";

                oGnl.SeComboBox(strQuery, ddItemCode, 1);
                ddItemCode.Items.Insert(0, new ListItem("--Select--", "0"));
                ddItemCode.SelectedValue = "0";
                //this.GridView1.Columns[5].Visible = false;
                this.GridView1.Columns[6].Visible = true;
            }
            else if (Request.QueryString["action"].ToString().Equals("save"))
            {
                //this.GridView1.Columns[5].Visible = false;
                this.GridView1.Columns[6].Visible = false;
                //this.GridView1.Columns[8].Visible = false;
                GridView1.FooterRow.Visible = false;
            }
            else if (Request.QueryString["action"].ToString().Equals("verified"))
            {
                //this.GridView1.Columns[5].Visible = true;
                this.GridView1.Columns[6].Visible = true;
                //this.GridView1.Columns[8].Visible = false;
                GridView1.FooterRow.Visible = false;
            }
            else
            {
                //this.GridView1.Columns[5].Visible = true;
                this.GridView1.Columns[6].Visible = false;
                //this.GridView1.Columns[8].Visible = false;
                GridView1.FooterRow.Visible = false;
            }
        }

        protected void GridViedReload()
        {
            //string itemcode = ((DropDownList)GridView1.FooterRow.FindControl("ddItemCodeFooter")).SelectedItem.Value;
            string itemcode = ((AjaxControlToolkit.ComboBox)GridView1.FooterRow.FindControl("ddItemCodeFooter")).SelectedItem.Value;
            string itemdesc = (GridView1.FooterRow.FindControl("lblItemDescFooter") as Label).Text;
            string qty = (GridView1.FooterRow.FindControl("txtQtyFooter") as TextBox).Text;
            string unit = (GridView1.FooterRow.FindControl("lblUnitFooter") as Label).Text;
            GridView1.EditIndex = -1;
            BindGrid();
            //((DropDownList)GridView1.FooterRow.FindControl("ddItemCodeFooter")).SelectedValue = itemcode;
            ((AjaxControlToolkit.ComboBox)GridView1.FooterRow.FindControl("ddItemCodeFooter")).SelectedValue = itemcode;
            (GridView1.FooterRow.FindControl("lblItemDescFooter") as Label).Text = itemdesc;
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
                    else if (IsQtyExcessive((GridView1.FooterRow.FindControl("lblGRIDFooter") as Label).Text.Trim(), (GridView1.FooterRow.FindControl("lblLineIDFooter") as Label).Text.Trim(), Request.QueryString["ReqDate"], (GridView1.FooterRow.FindControl("ddItemCodeFooter") as AjaxControlToolkit.ComboBox).SelectedItem.Value, (GridView1.FooterRow.FindControl("txtQtyFooter") as TextBox).Text.ToString()) == true)
                    {
                        GridViedReload();
                        lblErrorMessage.Text = "Quantity excessed";
                        lblErrorMessage.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        string sparamVal = "@GRId~" + (GridView1.FooterRow.FindControl("lblGRIDFooter") as Label).Text.Trim() + "|";
                        sparamVal = sparamVal + "@LineId~" + (GridView1.FooterRow.FindControl("lblLineIDFooter") as Label).Text.Trim() + "|";
                        sparamVal = sparamVal + "@UserId~" + Session["UserId"] + "|";
                        sparamVal = sparamVal + "@ItemCode~" + (GridView1.FooterRow.FindControl("ddItemCodeFooter") as AjaxControlToolkit.ComboBox).SelectedItem.Value + "|";
                        sparamVal = sparamVal + "@ItemDesc~" + (GridView1.FooterRow.FindControl("lblItemDescFooter") as Label).Text.Trim() + "|";
                        sparamVal = sparamVal + "@Qty~" + (GridView1.FooterRow.FindControl("txtQtyFooter") as TextBox).Text.Trim() + "|";
                        sparamVal = sparamVal + "@Unit~" + (GridView1.FooterRow.FindControl("lblUnitFooter") as Label).Text.Trim();
                        oGnl.ExecuteDataQuery("insert into GRDetailtemp (GRId,LineId,UserId,ItemCode,ItemDesc,Qty,Unit) values (@GRId,@LineId,@UserId,@ItemCode,@ItemDesc,@Qty,@Unit)", sparamVal, Convert.ToChar("|"), 1);

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
                if (((GridView1.Rows[e.RowIndex].FindControl("txtQty") as TextBox).Text.Trim().Equals("")) || (Convert.ToInt64((GridView1.Rows[e.RowIndex].FindControl("txtQty") as TextBox).Text.ToString()) <= 0))
                {
                    lblErrorMessage.Text = "Quantity should be greater than 0";
                    lblErrorMessage.ForeColor = System.Drawing.Color.Red;
                    GridView1.EditIndex = e.RowIndex;
                }
                else if (IsQtyExcessive(GridView1.DataKeys[e.RowIndex].Value.ToString(), (GridView1.Rows[e.RowIndex].FindControl("lblLineID") as Label).Text.Trim(), Request.QueryString["ReqDate"],(GridView1.Rows[e.RowIndex].FindControl("lblItemCode") as Label).Text.Trim(), (GridView1.Rows[e.RowIndex].FindControl("txtQty") as TextBox).Text.Trim()) == true)
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
                    sparamVal = sparamVal + "@GRId~" + GridView1.DataKeys[e.RowIndex].Value.ToString();
                    oGnl.ExecuteDataQuery("update GRDetailtemp set Qty=@Qty where GRId=@GRId and LineId=@LineId and UserId=@UserId", sparamVal, Convert.ToChar("|"), 1);

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
                sparamVal = sparamVal + "@GRId~" + GridView1.DataKeys[e.RowIndex].Value.ToString();
                oGnl.ExecuteDataQuery("Delete from GRDetailtemp where GRId=@GRId and LineId=@LineId and UserId=@UserId", sparamVal, Convert.ToChar(","), 1);

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
                oDs = oGnl.GetDataSet("select nmbarang, satuan from [tblbarang] where idbarang='" + ItemCode + "'", 2);
                if (oDs.Tables[0].Rows.Count > 0)
                {
                    GridView1.EditIndex = -1;
                    BindGrid();
                    (GridView1.FooterRow.FindControl("lblItemDescFooter") as Label).Text = oDs.Tables[0].Rows[0]["nmbarang"].ToString();
                    (GridView1.FooterRow.FindControl("lblUnitFooter") as Label).Text = oDs.Tables[0].Rows[0]["satuan"].ToString();
                    //((DropDownList)GridView1.FooterRow.FindControl("ddItemCodeFooter")).SelectedValue = ItemCode;
                    ((AjaxControlToolkit.ComboBox)GridView1.FooterRow.FindControl("ddItemCodeFooter")).SelectedValue = ItemCode;
                }
                else
                {
                    GridView1.EditIndex = -1;
                    BindGrid();
                    (GridView1.FooterRow.FindControl("lblItemDescFooter") as Label).Text = "";
                    (GridView1.FooterRow.FindControl("lblUnitFooter") as Label).Text = "";
                    ((AjaxControlToolkit.ComboBox)GridView1.FooterRow.FindControl("ddItemCodeFooter")).SelectedValue = ItemCode;
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.ToString();
                lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected bool IsQtyExcessive(string GRID, string lineId, string sDate, string itemCode, String qty)
        {
            bool isExessed = false;
            try
            {
                Int64 stock = 0;
                Int64 qtyused = 0;
                string strQuery = "select sum(isnull(t4.Qty,0)) [stock] ";
                strQuery = strQuery + "from RequestHeader t0 inner join RequestDetail t1 on t0.RequestID = t1.RequestID ";
                strQuery = strQuery + "inner join Users t2 on t0.UsrCreate = t2.Id inner join Users t3 on t2.WorkGroup = t3.WorkGroup ";
                strQuery = strQuery + "left join GIDetail t4 on t4.RequestID = t1.RequestID and t4.LineId = t1.LineId ";
                strQuery = strQuery + "left join GIHeader t5 on t4.GIID = t5.GIID ";
                strQuery = strQuery + "where t0.RequestState not in ('8001', '8003') ";
                strQuery = strQuery + "and t3.Id = " + Session["UserId"] + "  and t0.RequestDate = convert(date, '" + sDate + "')  and t1.ItemCode =" + itemCode;
                
                DataSet oDs = new DataSet();
                oDs = oGnl.GetDataSet(strQuery, 1);
                if (oDs.Tables[0].Rows.Count > 0)
                {
                    stock = Convert.ToInt64(oDs.Tables[0].Rows[0]["stock"]);
                }

                strQuery = "select sum(isnull(a.Qty,0)) QTY from( ";
                strQuery = strQuery + "select sum(qty) Qty from[dbo].[GRDetail] t0 ";
                strQuery = strQuery + "inner join[dbo].[GRHeader] t1 on t0.GRID= t1.GRID ";
                strQuery = strQuery + "inner join Users t2 on t1.UsrCreate= t2.Id ";
                strQuery = strQuery + "inner join Users t3 on t2.WorkGroup= t3.WorkGroup ";
                strQuery = strQuery + "Where t0.ItemCode = '" + itemCode + "' and t3.Id=" + Session["UserId"] + " and t1.GRDate = convert(date, '" + sDate + "') and t0.GRID <> " + GRID + " ";
                strQuery = strQuery + "union ";
                strQuery = strQuery + "select sum(qty) Qty from[GRDetailTemp] where ItemCode = '" + itemCode + "' and GRID = " + GRID   + " and LineId <> " + lineId + " and UserId = " + Session["UserId"] + ")a ";

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