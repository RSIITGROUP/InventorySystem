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
    public partial class ListGoodsIssue : System.Web.UI.Page
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
                    this.BindGrid();
                }
            }
        }

        private void BindGrid()
        {
            string strQuery = "select distinct t0.GIID, T1.RequestID, t0.CreateDate [GIDate],  t2.FirstName + ' ' + t2.LastName [GIUsr] from GIHeader T0 inner join GIDetail t1 on T0.GIID=T1.GIID inner join [Users] t2 on t0.UsrCreate = t2.Id";

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