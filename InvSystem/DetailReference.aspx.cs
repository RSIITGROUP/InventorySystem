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
    public partial class DetailReference : System.Web.UI.Page
    {
        clsGeneral oGnl = new clsGeneral();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }

        private void BindGrid()
        {
            DataTable dt = oGnl.GetDataTable("SELECT t0.[Code], t1.[name] [Reference Type], t0.[Name], case when t0.[Status] ='A' then 'Active' else 'InActive' end [Status], REPLACE(CONVERT(NVARCHAR,t0.[CreateDate], 106), ' ', '-') [CreateDate] FROM [Reference] t0 inner join [ReferenceType] t1 on T0.[RefCode] = T1.[Code]");
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
            string Code = (string)e.CommandArgument;
            if (Code != "")
            {
                Response.Redirect("AddDetailReference.aspx?Code=" + e.CommandArgument + "&Action=edit");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddDetailReference.aspx?Action=new");
        }
    }
}