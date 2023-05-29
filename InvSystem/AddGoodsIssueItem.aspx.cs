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
    public partial class AddGoodsIssueItem : System.Web.UI.Page
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

            if (Request.QueryString["action"].ToString().Equals("add"))
            {
                //strQuerys = "select * from GIDetailtemp where [GIID]=" + Request.QueryString["GIID"] + " and UserId=" + Session["UserId"];
                strQuerys = "select t0.*, t1.RemainingQty from GIDetailtemp t0 ";
                strQuerys = strQuerys + "inner join( ";
                strQuerys = strQuerys + "select T0.RequestID, t0.LineId, t0.ItemCode, T0.Qty -isnull(sum(t1.Qty), 0)[RemainingQty] ";
                strQuerys = strQuerys + "from RequestDetail T0 ";
                strQuerys = strQuerys + "left join [GIDetail] T1 on t0.RequestID = T1.RequestID and t0.LineId = t1.LineId ";
                strQuerys = strQuerys + "left join[GIHeader] t2 on t1.GIID = t2.GIID ";
                strQuerys = strQuerys + "group by t0.RequestID, t0.LineId,t0.ItemCode,t0.Qty) t1 on t0.RequestID = t1.RequestID and t0.LineId = t1.LineId and t1.ItemCode = t0.ItemCode ";
                strQuerys = strQuerys + "where t0.[GIID]=" + Request.QueryString["GIID"] + " and t0.UserId=" + Session["UserId"];
            }
            else
            {
                //strQuerys = "select * from GIDetail where [GIID]=" + Request.QueryString["GIID"];
                strQuerys = "select t0.*, t1.RemainingQty from GIDetail t0 ";
                strQuerys = strQuerys + "inner join( ";
                strQuerys = strQuerys + "select T0.RequestID, t0.LineId, t0.ItemCode, T0.Qty -isnull(sum(t1.Qty), 0)[RemainingQty] ";
                strQuerys = strQuerys + "from RequestDetail T0 ";
                strQuerys = strQuerys + "left join [GIDetail] T1 on t0.RequestID = T1.RequestID and t0.LineId = t1.LineId ";
                strQuerys = strQuerys + "left join[GIHeader] t2 on t1.GIID = t2.GIID ";
                strQuerys = strQuerys + "group by t0.RequestID, t0.LineId,t0.ItemCode,t0.Qty) t1 on t0.RequestID = t1.RequestID and t0.LineId = t1.LineId and t1.ItemCode = t0.ItemCode ";
                strQuerys = strQuerys + "where t0.[GIID]=" + Request.QueryString["GIID"];
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

            if (!Request.QueryString["action"].ToString().Equals("add"))
            {
                this.GridView1.Columns[6].Visible = false;
            }
            else
            {
                this.GridView1.Columns[6].Visible = true;
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
                if (IsQtyExcessive((GridView1.Rows[e.RowIndex].FindControl("lblRequestID") as Label).Text.Trim(), (GridView1.Rows[e.RowIndex].FindControl("lblLineID") as Label).Text.Trim(), (GridView1.Rows[e.RowIndex].FindControl("txtQty") as TextBox).Text.Trim()) == true)
                {
                    lblErrorMessage.Text = "Quantity excessed";
                    lblErrorMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    string sparamVal = "@LineId~" + (GridView1.Rows[e.RowIndex].FindControl("lblLineID") as Label).Text.Trim() + "|";
                    sparamVal = sparamVal + "@UserId~" + Session["UserId"] + "|";
                    sparamVal = sparamVal + "@Qty~" + (GridView1.Rows[e.RowIndex].FindControl("txtQty") as TextBox).Text.Trim() + "|";
                    sparamVal = sparamVal + "@GIID~" + GridView1.DataKeys[e.RowIndex].Value.ToString(); 
                    oGnl.ExecuteDataQuery("update GIDetailtemp set Qty=@Qty where [GIID]=@GIID and LineId=@LineId and UserId=@UserId", sparamVal, Convert.ToChar("|"), 1);

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
                sparamVal = sparamVal + "@GIID~" + GridView1.DataKeys[e.RowIndex].Value.ToString();
                oGnl.ExecuteDataQuery("Delete from GIDetailtemp where [GIID]=@GIID and LineId=@LineId and UserId=@UserId", sparamVal, Convert.ToChar(","), 1);

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

        protected bool IsQtyExcessive(string RequestId, string lineId, String qty)
        {
            bool isExessed = false;
            try
            {
                Int64 qtyAvai = 0;

                string strQuery = "select T1.Qty - SUM(ISNULL(T3.Qty, 0)) [QTY] ";
                strQuery = strQuery + "from RequestHeader t0 ";
                strQuery = strQuery + "inner join RequestDetail t1 on t0.RequestID = t1.RequestID ";
                strQuery = strQuery + "left join GIDetail t3 on t3.RequestID = t1.RequestID  and t3.LineId = t1.LineId ";
                strQuery = strQuery + "left join GIHeader t2 on t3.GIID = t2.GIID ";
                strQuery = strQuery + "and t3.LineId = t1.LineId ";
                strQuery = strQuery + "WHERE T1.RequestID = " + RequestId + " AND T1.LineId = " + lineId;
                strQuery = strQuery + " GROUP BY T1.RequestID,T1.LineId, T1.Qty";
                DataSet oDs = new DataSet();
                oDs = oGnl.GetDataSet(strQuery, 1);
                if (oDs.Tables[0].Rows.Count > 0)
                {
                    qtyAvai = Convert.ToInt64(oDs.Tables[0].Rows[0]["QTY"]);
                }

                if (qtyAvai < Convert.ToInt64(qty))
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