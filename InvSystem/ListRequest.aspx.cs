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
            string strQuery = "select RequestID [ReqID], RequestDesc [ReqDesc], RequestDate [ReqDate], t1.[Name] [ReqState], t2.FirstName + ' ' + t2.LastName [ReqUsr],t3.FirstName + ' ' + t3.LastName [ReqApr] ";
            strQuery = strQuery + "from [RequestHeader] t0 inner join [Reference] t1 on t0.RequestState=t1.Code and t1.RefCode= 34 inner join [Users] t2 on t0.UsrCreate = t2.Id inner join [Users] t3 on t2.[Approver] = t3.Id";

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
        }

        protected void Approve_Command(object sender, CommandEventArgs e)
        {
            if (Session["User"] == null || Session["UserId"] == null)
            {
                Response.Redirect("~/UserLogin.aspx");
            }
            else
            {
                string assetCode = (string)e.CommandArgument;
                if (assetCode != "")
                {
                    Response.Redirect("AddRequest.aspx?ReqID=" + e.CommandArgument + "&Action=approve");
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
    }
}