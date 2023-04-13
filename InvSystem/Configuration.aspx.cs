using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using InvSystem.Class;
using System.Collections;

namespace InvSystem
{
    public partial class Configuration : System.Web.UI.Page
    {
        ArrayList ar1 = new ArrayList();
        clsGeneral oGnl = new clsGeneral();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null || Session["UserId"] == null)
            {
                Response.Redirect("~/UserLogin.aspx");
            }
            else
            {
                lblError.Text = "";
                lblError.ForeColor = System.Drawing.Color.Red;
                if (!IsPostBack)
                {
                    oGnl.SeDropDown("SELECT [Code], [Name] FROM [Reference] WHERE [refCode]='04' and [Status] = 'A' ORDER BY [Name]", ddType, 1);
                    oGnl.SeListBox("select InfID as [Code], InfName as [Name] from AssetDetailField where InfID not in (select InfID from [AssetConfiguration] where [Type]='S001')", lstSource, 1);
                    oGnl.SeListBox("select InfID as [Code], InfName as [Name] from AssetDetailField where InfID in (select InfID from [AssetConfiguration] where [Type]='S001')", lstDestination, 1);
                }                    
            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            if (ddType.SelectedItem.Value != "S001")
            {
                if (lstSource.SelectedIndex >= 0)
                {
                    for (int i = 0; i < lstSource.Items.Count; i++)
                    {
                        if (lstSource.Items[i].Selected)
                        {
                            if (!ar1.Contains(lstSource.Items[i]))
                            {
                                ar1.Add(lstSource.Items[i]);
                            }
                        }
                    }
                    for (int i = 0; i < ar1.Count; i++)
                    {
                        if (!lstDestination.Items.Contains(((ListItem)ar1[i])))
                        {
                            lstDestination.Items.Add(((ListItem)ar1[i]));
                        }
                        lstSource.Items.Remove(((ListItem)ar1[i]));
                    }
                    lstDestination.SelectedIndex = -1;
                    ar1 = null;
                }
            }
            else
            {
                lblError.Text = "Type should be selected";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (ddType.SelectedItem.Value != "S001")
            {
                if (lstDestination.SelectedIndex >= 0)
                {
                    for (int i = 0; i < lstDestination.Items.Count; i++)
                    {
                        if (lstDestination.Items[i].Selected)
                        {
                            if (!ar1.Contains(lstDestination.Items[i]))
                            {
                                ar1.Add(lstDestination.Items[i]);
                            }
                        }
                    }
                    for (int i = 0; i < ar1.Count; i++)
                    {
                        if (!lstSource.Items.Contains(((ListItem)ar1[i])))
                        {
                            lstSource.Items.Add(((ListItem)ar1[i]));
                        }
                        lstDestination.Items.Remove(((ListItem)ar1[i]));
                    }
                    lstSource.SelectedIndex = -1;
                    ar1 = null;
                }
            }
            else
            {
                lblError.Text = "Type should be selected";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddType.SelectedItem.Value != "S001")
            {
                if (lstDestination.Items.Count > 0)
                {
                    string sItem = "";
                    int errNo = 0;
                    string errMsg = "";
                    string sparamVal = "";
                    foreach (ListItem item in lstDestination.Items)
                    {
                        sItem += item.Value + ";";
                    }
                    sparamVal = sparamVal + "@Type~" + ddType.SelectedItem.Value + "|";
                    sparamVal = sparamVal + "@AssetConf~" + sItem + "|";
                    sparamVal = sparamVal + "@UserId~" + Session["UserId"];

                    DataSet oDs = new DataSet();
                    oDs = oGnl.ExecuteSP("SP_POST_ASSETCONFIGURATION", sparamVal, '|', 1);

                    errNo = Convert.ToInt32(oDs.Tables[0].Rows[0]["ERRNO"].ToString());
                    errMsg = oDs.Tables[0].Rows[0]["ERRMSG"].ToString();
                    if (errNo != 0)
                    {
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = errMsg;
                    }
                    else
                    {
                        lblError.ForeColor = System.Drawing.Color.Green;
                        lblError.Text = "Configuration Updated";
                    }
                }
                else
                {
                    lblError.Text = "No Destination List";
                }
            }
            else
            {
                lblError.Text = "Type should be selected";
            }
        }

        protected void ddType_SelectedIndexChanged(object sender, EventArgs e)
        {
            oGnl.SeListBox("select InfID as [Code], InfName as [Name] from AssetDetailField where InfID not in (select InfID from [AssetConfiguration] where [Type]='" + ddType.SelectedItem.Value + "')", lstSource, 1);
            oGnl.SeListBox("select InfID as [Code], InfName as [Name] from AssetDetailField where InfID in (select InfID from [AssetConfiguration] where [Type]='" + ddType.SelectedItem.Value + "')", lstDestination, 1);

        }

    }
}