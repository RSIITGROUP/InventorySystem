using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InvSystem.Class;
using System.Data;

namespace InvSystem
{
    public partial class ListRequest : System.Web.UI.Page
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
                if (!this.IsPostBack)
                {
                    Response.AppendHeader("Refresh", "20");
                    this.BindGrid();
                }
            }
        }

        private void BindGrid()
        {  
            oGnl.SeDropDown("select [Code],[Name] from Reference where refcode='34'", ddState, 1);
            ddState.Items.Insert(0, new ListItem("--Select--", "0"));
            ddState.SelectedValue = Request.QueryString["fil1"].ToString();

            ddType.Items.Add(new ListItem("--Select--", "0"));
            ddType.Items.Add(new ListItem("Detail", "1"));
            ddType.Items.Add(new ListItem("Summary", "2"));
            ddType.SelectedValue = Request.QueryString["fil2"].ToString();

            string strQuery = "";
            if (ddType.SelectedItem.Value.Equals("2"))
            {
                strQuery = "select 0 [ReqID],T1.ItemCode,T1.ItemDesc, SUm(T1.Qty) [QtyRequest], sum(t3.Qty) [QtyGI], SUm(T1.Qty) - isnull(sum(t3.Qty),0) [RemainingQty], T1.Unit, '' [ReqDesc], '' [ReqDate], '' [ReqState], '' [ReqUsr],'' [ReqApr] ";
                strQuery = strQuery + "from RequestHeader T0 ";
                strQuery = strQuery + "INNER JOIN RequestDetail T1 ON T0.RequestID = T1.RequestID ";
                strQuery = strQuery + "left join [GIDetail] t3 on t3.LineId=t1.LineId and t3.RequestID=t1.RequestID  ";
                strQuery = strQuery + "left join [GIHeader] t2 on t2.GIID=t3.GIID ";
                if (!ddState.SelectedItem.Value.Equals("0"))
                {
                    strQuery = strQuery + "where t0.RequestState='" + ddState.SelectedItem.Value + "' ";
                    if (!Request.QueryString["ItemCode"].ToString().Equals(""))
                    {
                        strQuery = strQuery + "and t1.ItemCode='" + Request.QueryString["ItemCode"].ToString() + "' ";
                    }
                }
                else
                {
                    if (!Request.QueryString["ItemCode"].ToString().Equals(""))
                    {
                        strQuery = strQuery + "where t1.ItemCode='" + Request.QueryString["ItemCode"].ToString() + "' ";
                    }
                }
                strQuery = strQuery + "Group By T1.ItemCode,T1.ItemDesc, T1.Unit ";
            }
            else
            {
                strQuery = "select distinct T0.RequestID [ReqID], '' [ItemCode], '' [ItemDesc], 0 [QtyRequest], 0 [QtyGI], 0 [RemainingQty], '' [Unit], T0.RequestDesc [ReqDesc], T0.RequestDate [ReqDate], t2.[Name] [ReqState], t3.FirstName + ' ' + t3.LastName [ReqUsr],t4.FirstName + ' ' + t4.LastName [ReqApr] ";
                strQuery = strQuery + "from [RequestHeader] t0 inner join [RequestDetail] t1 on t0.RequestId=t1.RequestId ";
                strQuery = strQuery + "inner join [Reference] t2 on t0.RequestState=t2.Code and t2.RefCode= 34 left join [Users] t3 on t0.UsrCreate = t3.Id left join [Users] t4 on t3.[Approver] = t4.Id ";
                if (!ddState.SelectedItem.Value.Equals("0"))
                {
                    strQuery = strQuery + "where t0.RequestState='" + ddState.SelectedItem.Value + "' ";
                    if (!Request.QueryString["ItemCode"].ToString().Equals(""))
                    {
                        strQuery = strQuery + "and t1.ItemCode='" + Request.QueryString["ItemCode"].ToString() + "' ";
                    }
                }
                else
                {
                    if (!Request.QueryString["ItemCode"].ToString().Equals(""))
                    {
                        strQuery = strQuery + "where t1.ItemCode='" + Request.QueryString["ItemCode"].ToString() + "' ";
                    }
                }
            }
            //string strQuery = "select RequestID [ReqID], RequestDesc [ReqDesc], RequestDate [ReqDate], t1.[Name] [ReqState], t2.FirstName + ' ' + t2.LastName [ReqUsr],t3.FirstName + ' ' + t3.LastName [ReqApr] ";
            //strQuery = strQuery + "from [RequestHeader] t0 inner join [Reference] t1 on t0.RequestState=t1.Code and t1.RefCode= 34 left join [Users] t2 on t0.UsrCreate = t2.Id inner left [Users] t3 on t2.[Approver] = t3.Id";

            DataTable dt = oGnl.GetDataTable(strQuery, 1);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            if (GridView1.Rows.Count <= 0)
            {
                dt.Rows.Add(dt.NewRow());
                GridView1.DataSource = dt;
                GridView1.DataBind();
                GridView1.Rows[0].Visible = false;
            }

            //Required for jQuery DataTables to work.
            GridView1.UseAccessibleHeader = true;
            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

            if (ddType.SelectedItem.Value.Equals("2"))
            {
                this.GridView1.Columns[0].Visible = false;
                this.GridView1.Columns[1].Visible = true;
                this.GridView1.Columns[2].Visible = true;
                this.GridView1.Columns[3].Visible = true;
                this.GridView1.Columns[4].Visible = true;
                this.GridView1.Columns[5].Visible = true;
                this.GridView1.Columns[6].Visible = true;
                this.GridView1.Columns[7].Visible = false;
                this.GridView1.Columns[8].Visible = false;
                this.GridView1.Columns[9].Visible = false;
                this.GridView1.Columns[10].Visible = false;
                this.GridView1.Columns[11].Visible = false;
            }
            else
            {
                this.GridView1.Columns[0].Visible = true;
                this.GridView1.Columns[1].Visible = false;
                this.GridView1.Columns[2].Visible = false;
                this.GridView1.Columns[3].Visible = false;
                this.GridView1.Columns[4].Visible = false;
                this.GridView1.Columns[5].Visible = false;
                this.GridView1.Columns[6].Visible = false;
                this.GridView1.Columns[7].Visible = true;
                this.GridView1.Columns[8].Visible = true;
                this.GridView1.Columns[9].Visible = true;
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex == 0)
            {
                e.Row.RowType = DataControlRowType.Header;

            }
        }

        protected void ddType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("~/ListRequest.aspx?Itemcode=&fil1=" + ddState.SelectedValue + "&fil2=" + ddType.SelectedValue);
        }

        protected void ddState_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("~/ListRequest.aspx?Itemcode=&fil1=" + ddState.SelectedValue + "&fil2=" + ddType.SelectedValue);
        }
    }
}