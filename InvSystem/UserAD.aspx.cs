using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InvSystem.Class;
using System.Data;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices;

namespace InvSystem
{
    public partial class UserAD : System.Web.UI.Page
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
                    errText.Visible = false;
                    lblError.Text = "";
                    this.BindGrid();
                }
            }
        }

        private void BindGrid()
        {
            string strQuery = "SELECT [UserName],[FirstName],[LastName],[Email] FROM [Users]";

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

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["User"] == null || Session["UserId"] == null)
                {
                    Response.Redirect("~/UserLogin.aspx");
                }
                else
                {
                    string sDomainName = "";
                    string sparamVal = "";
                    string sUserDomain = "";
                    string sPwdDomain = "";
                    int errNo = 0;
                    string errMsg = "";
                    DataSet oDs = new DataSet();

                    sDomainName = oGnl.GetDataSet("select [name] from Reference where Code='9001'", 1).Tables[0].Rows[0]["name"].ToString();
                    sUserDomain = oGnl.decryptStr(oGnl.GetDataSet("select [name] from Reference where Code='9002'", 1).Tables[0].Rows[0]["name"].ToString());
                    sPwdDomain = oGnl.decryptStr(oGnl.GetDataSet("select [name] from Reference where Code='9003'", 1).Tables[0].Rows[0]["name"].ToString());

                    using (var context = new PrincipalContext(ContextType.Domain, sDomainName, sUserDomain, sPwdDomain))
                    {
                        using (var searcher = new PrincipalSearcher(new UserPrincipal(context)))
                        {
                            foreach (var result in searcher.FindAll())
                            {
                                DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
                                if (de.Properties["givenName"].Value != null)
                                {
                                    if (de.Properties["userPrincipalName"].Value.ToString().Contains("@regalsprings.com"))
                                    {
                                        sparamVal = "";
                                        sparamVal = sparamVal + "@username~" + de.Properties["samAccountName"].Value + "|";
                                        sparamVal = sparamVal + "@firsname~" + de.Properties["givenName"].Value + "|";
                                        sparamVal = sparamVal + "@lastname~" + de.Properties["sn"].Value + "|";
                                        sparamVal = sparamVal + "@email~" + de.Properties["userPrincipalName"].Value;

                                        oDs = oGnl.ExecuteSP("SP_POST_USERAD", sparamVal, '|', 1);

                                        errNo = Convert.ToInt32(oDs.Tables[0].Rows[0]["ERRNO"].ToString());
                                        errMsg = oDs.Tables[0].Rows[0]["ERRMSG"].ToString();
                                        if (errNo != 0)
                                        {
                                            errText.Visible = true;
                                            lblError.ForeColor = System.Drawing.Color.Red;
                                            lblError.Text = errMsg;
                                            break;
                                        }
                                    }
                                }
                            }

                            if (errNo == 0)
                            {
                                errText.Visible = true;
                                lblError.ForeColor = System.Drawing.Color.Green;
                                lblError.Text = "Sync User AD success";
                            }
                        }
                    }
                    this.BindGrid();
                }
            }
            catch (Exception ex)
            {
                errText.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = ex.ToString();
                this.BindGrid();
            }
        }
    }
}