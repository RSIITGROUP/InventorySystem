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
    public partial class CreateRequest : System.Web.UI.Page
    {
        clsGeneral oGnl = new clsGeneral();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            this.BindGrid();
        }

        private void BindGrid()
        {
            string strQuery = "select t1.[ItemCode],t1.[ItemDesc],t1.[Qty], t1.[Unit] from [dbo].[RequestHeader] T0 inner join [dbo].[RequestDetail] T1 on T0.RequestId=T1.RequestId";
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
                    Response.Redirect("AddAssets.aspx?assetCode=" + e.CommandArgument + "&Action=edit");
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
                Response.Redirect("~/AddAssets.aspx?Action=new");
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex == 0)
            {
                e.Row.RowType = DataControlRowType.Header;

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Session["User"] == null || Session["UserId"] == null)
            {
                Response.Redirect("~/UserLogin.aspx");
            }
            else
            {
                Response.Redirect("~/UploadAsset.aspx");
            }
        }

        

        protected void Remove_Command(object sender, CommandEventArgs e)
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
                    try
                    {
                        string sparamVal = "@AssetCode:" + assetCode + ",";
                        sparamVal = sparamVal + "@UserId:" + Session["UserId"];
                        oGnl.ExecuteDataQuery("Update [Asset] set [IsDeleted]='Y',[UserUpdate] = @UserId, [UpdateDate]=getdate() where [AssetCode] = @AssetCode", sparamVal, Convert.ToChar(","), 1);
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert(' Asset [" + assetCode + "] has been successfully deleted')", true);
                        GridView1.DataSource = null;
                        this.BindGrid();
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error : " + ex.ToString() + "')", true);
                    }
                }
            }
        }
    }
}