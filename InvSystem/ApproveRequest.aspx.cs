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
    public partial class ApproveRequest : System.Web.UI.Page
    {
        clsGeneral oGnl = new clsGeneral();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        private void BindGrid()
        {
            DataSet oDs = new DataSet();
            string usrId = "";
            string reqState = "";
            string approver = "";
            string comment = "";
            string state = "";

            oDs = oGnl.GetDataSet("select T0.RequestState [ReqState], T0.UsrCreate, isnull(t1.Approver,0) Approver,t0.[Comment],t0.[RequestState], t0.[ProcessedRemark] from [dbo].[RequestHeader] T0 inner join [Users] T1 on t0.UsrCreate=t1.Id where t0.RequestId='" + Request.QueryString["RequestId"] + "'", 1);
            if (oDs.Tables[0].Rows.Count > 0)
            {
                usrId = oDs.Tables[0].Rows[0]["UsrCreate"].ToString();
                reqState = oDs.Tables[0].Rows[0]["ReqState"].ToString();
                approver = oDs.Tables[0].Rows[0]["Approver"].ToString();
                if (reqState.Equals("8005"))
                {
                    comment = oDs.Tables[0].Rows[0]["ProcessedRemark"].ToString();
                }
                else
                {
                    comment = oDs.Tables[0].Rows[0]["Comment"].ToString();
                }
                state = oDs.Tables[0].Rows[0]["RequestState"].ToString();
            }
            
            txtRemark.Text = comment;
            if (Session["UserId"].Equals(approver) && reqState.Equals("8001"))
            {
                oGnl.SeDropDown("select [Code],[Name] from Reference where refcode='34' and Code not in ('8001','8004','8005') order by name", ddState, 1);
                ddState.Items.Insert(0, new ListItem("--Select--", "0"));
                txtRemark.ReadOnly = false;
                ddState.Enabled = true;
                btnAdd.Visible = true;
            }
            else if (Request.QueryString["action"].ToString().Equals("close") && reqState.Equals("8004"))
            {
                oGnl.SeDropDown("select [Code],[Name] from Reference where refcode='34' and Code in ('8005') order by name", ddState, 1);
                ddState.Items.Insert(0, new ListItem("--Select--", "0"));
                txtRemark.ReadOnly = false;
                txtRemark.Text = "";
                ddState.Enabled = true;
                btnAdd.Visible = true;
            }
            else
            {
                oGnl.SeDropDown("select [Code],[Name] from Reference where refcode='34' and code='" + state + "' order by name", ddState, 1);                
                txtRemark.ReadOnly = true;
                ddState.Enabled = false;
                btnAdd.Visible = false;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string sparamVal = "";
                DataSet oDs = new DataSet();
                if (!ddState.SelectedItem.Value.Equals("0") && !txtRemark.Text.Trim().Equals(""))
                {
                    if (Request.QueryString["action"].ToString().Equals("close"))
                    {
                        sparamVal = sparamVal + "@RequestID~" + Request.QueryString["RequestID"] + ",";
                        sparamVal = sparamVal + "@RequestState~" + ddState.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@ProcessedRemark~" + txtRemark.Text + ",";
                        sparamVal = sparamVal + "@UsrProcessed~" + Session["UserId"];
                        oGnl.ExecuteDataQuery("Update [RequestHeader] set [RequestState]=@RequestState, [ProcessedRemark]=@ProcessedRemark, [UsrProcessed]=@UsrProcessed,ProcessedDate=getdate() where RequestID=@RequestID", sparamVal, Convert.ToChar(","), 1);
                    }
                    else
                    {
                        sparamVal = sparamVal + "@RequestID~" + Request.QueryString["RequestID"] + ",";
                        sparamVal = sparamVal + "@RequestState~" + ddState.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@Comment~" + txtRemark.Text + ",";
                        sparamVal = sparamVal + "@UsrApprove~" + Session["UserId"];
                        oGnl.ExecuteDataQuery("Update [RequestHeader] set [RequestState]=@RequestState, [Comment]=@Comment, [UsrApprove]=@UsrApprove,ApproveDate=getdate() where RequestID=@RequestID", sparamVal, Convert.ToChar(","), 1);
                    }

                    lblError.Visible = true;
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Request state change";
                    btnAdd.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = ex.ToString();
            }
        }
    }
}