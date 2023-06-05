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
    public partial class SelfRequestList : System.Web.UI.Page
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

            string strQuery = "";
            strQuery = "select distinct T0.RequestID [ReqID], t5.[Name] [ReqDesc], T0.RequestDate [ReqDate], t2.[Name] [ReqState], t3.FirstName + ' ' + t3.LastName [ReqUsr],t4.FirstName + ' ' + t4.LastName [ReqApr] ";
            strQuery = strQuery + "from [RequestHeader] t0 inner join [RequestDetail] t1 on t0.RequestId=t1.RequestId ";
            strQuery = strQuery + "inner join [Reference] t2 on t0.RequestState=t2.Code and t2.RefCode= 34 left join [Users] t3 on t0.UsrCreate = t3.Id ";
            strQuery = strQuery + "left join [Reference] t5 on t0.RequestDesc=t5.Code and t5.RefCode= 38 ";
            strQuery = strQuery + "left join [Users] t4 on t0.UsrApprove = t4.Id where t0.UsrCreate=" + Session["UserId"];
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