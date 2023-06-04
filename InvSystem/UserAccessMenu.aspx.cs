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
    public partial class UserAccessMenu : System.Web.UI.Page
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
                    DataSet oDs = new DataSet();
                    oGnl.SeComboBox("select Id [Code], UPPER(CONCAT(FirstName , ' ' , LastName)) [Name] from Users ORDER BY CONCAT(FirstName , ' ' , LastName)", ddUsers, 1);
                    ddUsers.Items.Insert(0, new ListItem("--Select--", "0"));
                    ddUsers.SelectedValue = "0";
                    oGnl.SeListBox("SELECT MenuId [Code], MenuName [Name] FROM [Menus] where MenuId not in (SELECT [MenuId] FROM [dbo].[UserMenu] where [UserId] = " + ddUsers.SelectedItem.Value + ")", lstSource, 1);
                    oGnl.SeListBox("SELECT MenuId [Code], MenuName [Name] FROM [Menus] where MenuId in (SELECT [MenuId] FROM [dbo].[UserMenu] where [UserId] = " + ddUsers.SelectedItem.Value + ")", lstDestination, 1);
                    oGnl.SeComboBox("select Id [Code], UPPER(CONCAT(FirstName , ' ' , LastName)) [Name] from Users where id not in (" + ddUsers.SelectedItem.Value + ") ORDER BY CONCAT(FirstName , ' ' , LastName)", ddApprovers, 1);
                    ddApprovers.Items.Insert(0, new ListItem("--Select--", "0"));
                    oDs = oGnl.GetDataSet("select isnull(Approver,0) [Approver] from Users where id='" + ddUsers.SelectedItem.Value + "'", 1);
                    if (oDs.Tables[0].Rows.Count > 0)
                    {
                        ddApprovers.SelectedValue = oDs.Tables[0].Rows[0]["Approver"].ToString();
                    }
                    oGnl.SeDropDown("SELECT [Code], [Name] FROM [Reference] WHERE [refCode]= 36  and [Status] = 'A' ORDER BY [Name]", ddWorkGroup, 1);
                    //frame1.Src = "ApproverConfiguration.aspx?usr=" + ddUser.SelectedItem.Value;
                }
            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
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

        protected void btnBack_Click(object sender, EventArgs e)
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

        protected void ddUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet oDs = new DataSet();
            oGnl.SeListBox("SELECT MenuId [Code], MenuName [Name] FROM [Menus] where MenuId not in (SELECT [MenuId] FROM [dbo].[UserMenu] where [UserId] = " + ddUsers.SelectedItem.Value + ")", lstSource, 1);
            oGnl.SeListBox("SELECT MenuId [Code], MenuName [Name] FROM [Menus] where MenuId in (SELECT [MenuId] FROM [dbo].[UserMenu] where [UserId] = " + ddUsers.SelectedItem.Value + ")", lstDestination, 1);
            //frame1.Src = "ApproverConfiguration.aspx?usr=" + ddUser.SelectedItem.Value;
            oGnl.SeComboBox("select Id [Code], UPPER(CONCAT(FirstName , ' ' , LastName)) [Name] from Users where id not in (" + ddUsers.SelectedItem.Value + ") ORDER BY CONCAT(FirstName , ' ' , LastName)", ddApprovers, 1);
            ddApprovers.Items.Insert(0, new ListItem("--Select--", "0"));
            oDs = oGnl.GetDataSet("select isnull(Approver,0) [Approver], isnull(workgroup,'0001') [WorkGroup] from Users where id='" + ddUsers.SelectedItem.Value + "'", 1);
            if (oDs.Tables[0].Rows.Count > 0)
            {
                ddApprovers.SelectedValue = oDs.Tables[0].Rows[0]["Approver"].ToString();
                ddWorkGroup.SelectedValue = oDs.Tables[0].Rows[0]["WorkGroup"].ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
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
                sparamVal = sparamVal + "@UsrId~" + ddUsers.SelectedItem.Value + "|";
                sparamVal = sparamVal + "@MenuId~" + sItem + "|";
                sparamVal = sparamVal + "@UserId~" + Session["UserId"];

                DataSet oDs = new DataSet();
                oDs = oGnl.ExecuteSP("SP_POST_USERMENUS", sparamVal, '|', 1);

                errNo = Convert.ToInt32(oDs.Tables[0].Rows[0]["ERRNO"].ToString());
                errMsg = oDs.Tables[0].Rows[0]["ERRMSG"].ToString();
                if (errNo != 0)
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = errMsg;
                }
                else
                {
                    sparamVal = "@Approver~" + ddApprovers.SelectedItem.Value + ",";
                    sparamVal = sparamVal + "@WorkGroup~" + ddWorkGroup.SelectedItem.Value + ",";
                    sparamVal = sparamVal + "@usrid~" + ddUsers.SelectedItem.Value;
                    oGnl.ExecuteDataQuery("Update [Users] set [Approver]=@Approver, [WorkGroup]=@WorkGroup where id=@usrid", sparamVal, Convert.ToChar(","), 1);
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Configuration Updated";
                }
            }
            else
            {
                lblError.Text = "No Destination List";
            }
        }
    }
}