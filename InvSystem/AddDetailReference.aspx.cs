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
    public partial class AddDetailReference : System.Web.UI.Page
    {
        clsGeneral oGnl = new clsGeneral();
        bool bIsExist = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
            lblError.ForeColor = System.Drawing.Color.Red;
            if (IsPostBack)
            {
                if (btnAdd.Text == "Add")
                {
                    int temp = Convert.ToInt32(oGnl.GetValueField("select count(*) from Reference where Name='" + txtName.Text.Trim() + "' and RefCode ='" + drType.SelectedItem.Value + "'"));                    
                    if (temp == 1)
                    {
                        lblError.Text = "Reference already exist";
                        bIsExist = true;
                    }
                }
            }
            else
            {
                oGnl.SeDropDown("SELECT[Code], [Name] FROM [ReferenceType]  ORDER BY [Name]", drType);
                SetStatusDD();
                if (Request.QueryString["Action"] == "edit")
                {
                    btnAdd.Text = "Edit";
                    DataSet oDs = new DataSet();
                    oDs = oGnl.GetDataSet("select [Code], [RefCode], [Name], [Status] from Reference where Code='" + Request.QueryString["Code"] + "'");

                    //SetRefType(Request.QueryString["Action"], oDs.Tables[0].Rows[0]["RefCode"].ToString());
                    oGnl.SeDropDown("SELECT[Code], [Name] FROM [ReferenceType] where [Code]='" + oDs.Tables[0].Rows[0]["RefCode"].ToString() + "' ORDER BY [Name]", drType);
                    txtCode.Text = oDs.Tables[0].Rows[0]["Code"].ToString();
                    txtName.Text = oDs.Tables[0].Rows[0]["Name"].ToString();
                    drType.SelectedValue = oDs.Tables[0].Rows[0]["RefCode"].ToString();
                    drStatus.SelectedValue = oDs.Tables[0].Rows[0]["Status"].ToString();
                }
                else
                {
                    btnAdd.Text = "Add";
                    txtCode.Text = GenerateCode(drType.SelectedItem.Value);
                }
            }
        }

        protected void SetStatusDD()
        {
            try
            {
                drStatus.Items.Add(new ListItem("Active", "A"));
                drStatus.Items.Add(new ListItem("InActive", "I"));
            }
            catch (Exception ex)
            {
                lblError.Text = "Error:" + ex.ToString();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnAdd.Text == "Add")
                {
                    if (!bIsExist)
                    {
                        string sparamVal = "@code:" + txtCode.Text.Trim() + ",";
                        sparamVal = sparamVal + "@RefCode:" + drType.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@name:" + txtName.Text + ",";
                        sparamVal = sparamVal + "@status:" + drStatus.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@UserId:" + Session["UserId"];
                        oGnl.ExecuteDataQuery("insert into Reference ([Code],[RefCode],[Name],[Status],[UserCreate],[CreateDate]) values (@code,@RefCode,@name,@status,@UserId,getdate())", sparamVal);

                        lblError.ForeColor = System.Drawing.Color.Green;
                        lblError.Text = "Add Reference is Success";
                        btnAdd.Enabled = false;
                        //Response.Redirect("DetailReference.aspx");

                    }
                    else
                    {

                    }
                }
                else
                {
                    string sInsUser = "Update Reference set ";
                    sInsUser += "[RefCode]=@RefCode, [Name]=@name, [Status] = @status,[UserUpdate] = @UserId, [UpdateDate] = getdate() ";
                    sInsUser += "where [Code] = @code";                    

                    string sparamVal = "@code:" + txtCode.Text.Trim() + ",";
                    sparamVal = sparamVal + "@RefCode:" + drType.SelectedItem.Value + ",";
                    sparamVal = sparamVal + "@name:" + txtName.Text + ",";
                    sparamVal = sparamVal + "@status:" + drStatus.SelectedItem.Value + ",";
                    sparamVal = sparamVal + "@UserId:" + Session["UserId"];
                    oGnl.ExecuteDataQuery(sInsUser, sparamVal);

                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Update Reference is Success";
                    btnAdd.Enabled = false;
                    //Response.Redirect("DetailReference.aspx");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error:" + ex.ToString();
            }
        }

        protected string GenerateCode(string refType)
        {
            string code = "";
            try
            {
                DataSet oDs = new DataSet();
                oDs = oGnl.GetDataSet("select max(t1.[TagCode]) + right('000' + convert(varchar(3), convert(int,isnull(max(right(t0.code,3)),'0')) + 1),3) [code] from [ReferenceType] T1 left join [Reference] T0 on t0.[RefCode] = T1.[Code] where T1.[Code] = '" + refType + "'");

                code = oDs.Tables[0].Rows[0]["code"].ToString();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error:" + ex.ToString();
            }
            return code;
        }

        protected void drType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCode.Text = GenerateCode(drType.SelectedItem.Value);
        }

        protected void drType_TextChanged(object sender, EventArgs e)
        {
            txtCode.Text = GenerateCode(drType.SelectedItem.Value);
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("AddDetailReference.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = "Error:" + ex.ToString();
            }
        }
    }
}