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
    public partial class EndUser : System.Web.UI.Page
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
            string strQuery = "SELECT t0.[ID], t0.[NIK], t0.[Name], t1.[Name] [Region], t1.[Name] [Department], case when t0.[UsrStatus] = 'A' then 'Active' else 'Inactive' end[Status], t0.[Remarks] ";
            strQuery = strQuery + "FROM[EndUser] T0 inner join Reference T1 on t0.Region = t1.Code inner join Reference T2 on t0.Department = t2.Code WHERE isnull(T0.[IsDeleted],'N') in ('N','') and ltrim(rtrim(NIK)) <> 'NA'";
            
            DataTable dt = oGnl.GetDataTable(strQuery);
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

        protected void Edit_Command(object sender, CommandEventArgs e)
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
                    Response.Redirect("AddEndUser.aspx?ID=" + e.CommandArgument + "&Action=edit");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["User"] == null || Session["UserId"] == null)
            {
                Response.Redirect("~/UserLogin.aspx");
            }
            else
            {
                Response.Redirect("~/AddEndUser.aspx?Action=new");
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex == 0)
            {
                e.Row.RowType = DataControlRowType.Header;

            }
        }

        //protected void Remove_Command(object sender, CommandEventArgs e)
        //{
        //    if (Session["User"] == null || Session["UserId"] == null)
        //    {
        //        Response.Redirect("~/UserLogin.aspx");
        //    }
        //    else
        //    {
        //        string assetCode = (string)e.CommandArgument;
        //        if (assetCode != "")
        //        {
        //            try
        //            {
        //                string sparamVal = "@AssetCode:" + assetCode + ",";
        //                sparamVal = sparamVal + "@UserId:" + Session["UserId"];
        //                oGnl.ExecuteDataQuery("Update [Asset] set [IsDeleted]='Y',[UserUpdate] = @UserId, [UpdateDate]=getdate() where [AssetCode] = @AssetCode", sparamVal);
        //                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert(' Asset [" + assetCode + "] has been successfully deleted')", true);
        //                GridView1.DataSource = null;
        //                this.BindGrid();
        //            }
        //            catch (Exception ex)
        //            {
        //                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error : " + ex.ToString() + "')", true);
        //            }
        //        }
        //    }
        //}
    }
}