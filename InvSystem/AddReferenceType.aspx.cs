using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InvSystem.Class;
//using System.Configuration;
//using System.Data.SqlClient;
using System.Data;

namespace InvSystem
{
    public partial class AddReferenceType : System.Web.UI.Page
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
                    int temp = Convert.ToInt32(oGnl.GetValueField("select count(*) from ReferenceType where Name='" + txtType.Text.Trim() + "'"));
                    if (temp == 1)
                    {
                        lblError.Text = "Reference Type is already exist";
                        bIsExist = true;
                    }
                    else if (CheckTagCode() == true)
                    {
                        lblError.Text = "Tag Code is already exist";
                        bIsExist = true;
                    }
                }
            }
            else
            {
                if (Request.QueryString["Action"] == "edit")
                {
                    btnAdd.Text = "Edit";

                    DataSet oDs = new DataSet();
                    oDs = oGnl.GetDataSet("select [Code], isnull([Name],'') [Name], [TagCode] from ReferenceType where Code='" + Request.QueryString["Code"] + "'");

                    txtCode.Text = oDs.Tables[0].Rows[0]["Code"].ToString();
                    txtType.Text = oDs.Tables[0].Rows[0]["Name"].ToString();
                    txtTagCode.Text = oDs.Tables[0].Rows[0]["TagCode"].ToString();
                }
                else
                {
                    btnAdd.Text = "Add";
                    txtCode.Text = GenerateCode();
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTagCode.Text.Trim().Length == 1)
                {
                    if (btnAdd.Text == "Add")
                    {
                        if (!bIsExist)
                        {
                            string sparamVal = "@code:" + txtCode.Text.Trim() + ",";
                            sparamVal = sparamVal + "@name:" + txtType.Text + ",";
                            sparamVal = sparamVal + "@TagCode:" + txtTagCode.Text.Trim() + ",";
                            sparamVal = sparamVal + "@UserId:" + Session["UserId"];
                            oGnl.ExecuteDataQuery("insert into ReferenceType ([Code],[Name],[TagCode],[UserCreate],[CreateDate]) values (@code,@name,@TagCode,@UserId,getdate())", sparamVal);

                            lblError.ForeColor = System.Drawing.Color.Green;
                            lblError.Text = "Add Reference Type is Successfull";
                            btnAdd.Enabled = false;
                            //Response.Redirect("ReferenceType.aspx");
                        }
                    }
                    else
                    {
                        string sInsUser = "Update ReferenceType set ";
                        sInsUser += "[Name]=@name, [TagCode] = @TagCode,[UserUpdate] = @UserId, [UpdateDate] = getdate() ";
                        sInsUser += "where [Code] = @code";
                        string sparamVal = "@code:" + txtCode.Text.Trim() + ",";
                        sparamVal = sparamVal + "@name:" + txtType.Text + ",";
                        sparamVal = sparamVal + "@TagCode:" + txtTagCode.Text.Trim() + ",";
                        sparamVal = sparamVal + "@UserId:" + Session["UserId"];
                        oGnl.ExecuteDataQuery(sInsUser, sparamVal);

                        lblError.ForeColor = System.Drawing.Color.Green;
                        lblError.Text = "Update Reference Type is Successfull";
                        btnAdd.Enabled = false;
                        //Response.Redirect("ReferenceType.aspx");
                    }
                }
                else
                {
                    lblError.Text = "Tag Code must be one character";
                    lblError.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error:" + ex.ToString();
            }
        }

        protected string GenerateCode()
        {
            string code = "";
            try
            {
                DataSet oDs = new DataSet();
                oDs = oGnl.GetDataSet("select right('00' + convert(varchar(2), convert(int,isnull(max(code),'0')) + 1),2) [code] from ReferenceType");

                code = oDs.Tables[0].Rows[0]["code"].ToString();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error:" + ex.ToString();
            }
            return code;
        }

        protected bool CheckTagCode()
        {
            bool tagcode = false;
            try
            {
                int temp = Convert.ToInt32(oGnl.GetValueField("select count(*) from ReferenceType where [TagCode]='" + txtTagCode.Text.Trim() + "'"));
                if (temp == 1)
                {
                    tagcode = true;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error:" + ex.ToString();
            }
            return tagcode;
        }
    }
}