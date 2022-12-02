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
    public partial class AddAssets : System.Web.UI.Page
    {
        bool bIsExist = false;
        bool bIsErr = false;
        clsGeneral oGnl = new clsGeneral();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null || Session["UserId"] == null)
            {
                Response.Redirect("~/UserLogin.aspx");
            }
            else {
                lblError.Text = "";
                lblError.ForeColor = System.Drawing.Color.Red;
                if (IsPostBack)
                {
                    if (btnAdd.Text == "Add")
                    {
                        int temp = Convert.ToInt32(oGnl.GetValueField("select count(*) from Asset where AssetCode='" + txtAssetCode.Text + "'"));
                        if (temp == 1)
                        {
                            bIsExist = true;
                        }
                        else
                        {
                            temp = Convert.ToInt32(oGnl.GetValueField("select count(*) from Asset where AssetCode <> '" + txtAssetCode.Text + "' and SerialNo=RTRIM(LTRIM('" + txtSeriesNo.Text + "'))"));
                            if (temp == 1)
                            {
                                bIsExist = true;
                            }
                        }
                    }
                }
                else
                {
                    SeDropDown("01", ddLocation);
                    SeDropDown("02", ddPlacement);
                    SeDropDown("03", ddArea);
                    SeDropDown("04", ddType);
                    SeDropDown("05", ddBrand);
                    SeDropDown("06", ddVGABrand);
                    SeDropDown("07", ddVGAType);
                    SeDropDown("08", ddRAMType);
                    SeDropDown("09", ddStrType);
                    SeDropDown("10", ddChrType);
                    SeDropDown("11", ddColor);
                    SeDropDown("12", ddOS);
                    SeDropDown("13", ddCshSize);
                    SeDropDown("14", ddHealth);
                    SeDropDown("15", ddTchScr);
                    if (Request.QueryString["Action"] == "edit")
                    {
                        int iRID = 0;
                        btnAdd.Text = "Edit";
                        txtAssetCode.ReadOnly = true;

                        DataSet oDs = new DataSet();
                        oDs = oGnl.GetDataSet("select * from Asset where AssetCode='" + Request.QueryString["assetCode"] + "'");

                        iRID = Convert.ToInt32(oDs.Tables[0].Rows[0]["RID"].ToString());
                        txtAssetCode.Text = oDs.Tables[0].Rows[0]["AssetCode"].ToString();
                        txtAssetDesc.Text = oDs.Tables[0].Rows[0]["AssetDesc"].ToString();
                        txtGRPODocNum.Text = oDs.Tables[0].Rows[0]["GRPODocNo"].ToString();
                        txtActivaNO.Text = oDs.Tables[0].Rows[0]["ActivaNo"].ToString();
                        if (oDs.Tables[0].Rows[0]["PurchaseDate"].ToString() != "")
                        {
                            txtPurchaseDate.Text = Convert.ToDateTime(oDs.Tables[0].Rows[0]["PurchaseDate"]).ToString("yyyy-MM-dd");
                        }
                        txtGRPODocNum.Text = oDs.Tables[0].Rows[0]["GRPODocNo"].ToString();
                        ddType.SelectedValue = oDs.Tables[0].Rows[0]["Type"].ToString();
                        ddBrand.SelectedValue = oDs.Tables[0].Rows[0]["Brand"].ToString();
                        txtModel.Text = oDs.Tables[0].Rows[0]["Model"].ToString();
                        txtSeries.Text = oDs.Tables[0].Rows[0]["Series"].ToString();
                        txtSeriesNo.Text = oDs.Tables[0].Rows[0]["SerialNo"].ToString();
                        ddColor.SelectedValue = oDs.Tables[0].Rows[0]["Color"].ToString();
                        ddType.SelectedValue = oDs.Tables[0].Rows[0]["ScreenSize"].ToString();
                        txtScrRsl.Text = oDs.Tables[0].Rows[0]["ScreenResolution"].ToString();
                        ddTchScr.SelectedValue = oDs.Tables[0].Rows[0]["TouchScreen"].ToString();
                        txtProcessor.Text = oDs.Tables[0].Rows[0]["Processor"].ToString();
                        ddVGABrand.SelectedValue = oDs.Tables[0].Rows[0]["VGABrand"].ToString();
                        ddVGAType.SelectedValue = oDs.Tables[0].Rows[0]["VGAType"].ToString();
                        txtVGASize.Text = oDs.Tables[0].Rows[0]["VGASize"].ToString();
                        ddRAMType.SelectedValue = oDs.Tables[0].Rows[0]["RAMType"].ToString();
                        txtRAMMHz.Text = oDs.Tables[0].Rows[0]["RAMMHz"].ToString();
                        txtRAMSize.Text = oDs.Tables[0].Rows[0]["RAMSize"].ToString();
                        ddStrType.SelectedValue = oDs.Tables[0].Rows[0]["Storagetype"].ToString();
                        txtStrSize.Text = oDs.Tables[0].Rows[0]["StorageSize"].ToString();
                        ddChrType.SelectedValue = oDs.Tables[0].Rows[0]["ChargerType"].ToString();
                        txtVoltage.Text = oDs.Tables[0].Rows[0]["UnitVoltage"].ToString();
                        txtAmps.Text = oDs.Tables[0].Rows[0]["UnitAmps"].ToString();
                        txtWatt.Text = oDs.Tables[0].Rows[0]["UnitWatt"].ToString();
                        txtBtrType.Text = oDs.Tables[0].Rows[0]["BatteryType"].ToString();
                        txtBtrVoltage.Text = oDs.Tables[0].Rows[0]["BatteryVoltage"].ToString();
                        txtBtrAmps.Text = oDs.Tables[0].Rows[0]["BatteryAmps"].ToString();
                        txtBtrWatt.Text = oDs.Tables[0].Rows[0]["BatteryWatt"].ToString();
                        txtMotherboard.Text = oDs.Tables[0].Rows[0]["Motherboard"].ToString();
                        ddCshSize.SelectedValue = oDs.Tables[0].Rows[0]["ChasingSize"].ToString();
                        txtResolution.Text = oDs.Tables[0].Rows[0]["CameraResolution"].ToString();
                        txtCnlQty.Text = oDs.Tables[0].Rows[0]["ChannelQuantity"].ToString();
                        ddOS.SelectedValue = oDs.Tables[0].Rows[0]["OS"].ToString();
                        txtImei.Text = oDs.Tables[0].Rows[0]["Imei"].ToString();
                        txtMacAddr.Text = oDs.Tables[0].Rows[0]["MACAddress"].ToString();   
                        txtIP.Text = oDs.Tables[0].Rows[0]["IP"].ToString();
                        txtPhone.Text = oDs.Tables[0].Rows[0]["MobileNumber"].ToString();
                        txtRemark.Text = oDs.Tables[0].Rows[0]["Remarks"].ToString();

                        oDs = null;
                        oDs = new DataSet();
                        oDs = oGnl.GetDataSet("select top 1 CharacteristicCode, LocationCode, AreaCode, Spot from PlacementHistory where RID=" + iRID + "order by [Version] desc");

                        if (oDs.Tables[0].Rows.Count > 0)
                        {
                            ddPlacement.SelectedValue = oDs.Tables[0].Rows[0]["CharacteristicCode"].ToString();
                            ddLocation.SelectedValue = oDs.Tables[0].Rows[0]["LocationCode"].ToString();
                            ddArea.SelectedValue = oDs.Tables[0].Rows[0]["AreaCode"].ToString();
                            txtSpot.Text = oDs.Tables[0].Rows[0]["Spot"].ToString();
                        }
                        
                        oDs = null;
                        oDs = new DataSet();
                        oDs = oGnl.GetDataSet("select top 1 HealthCode from HealtHistory where RID=" + iRID + "order by [Version] desc");
                        if (oDs.Tables[0].Rows.Count > 0)
                        {
                            ddHealth.SelectedValue = oDs.Tables[0].Rows[0]["HealthCode"].ToString();
                        }

                        txtAssetCode.ReadOnly = true;
                    }
                    else
                    {
                        btnAdd.Text = "Add";
                        GenerateCode();
                        txtAssetCode.ReadOnly = true;
                        txtVGASize.Text = "0";
                        txtRAMSize.Text = "0";
                        txtStrSize.Text = "0";
                        txtVoltage.Text = "0";
                        txtAmps.Text = "0";
                        txtWatt.Text = "0";
                        txtBtrVoltage.Text = "0";
                        txtBtrAmps.Text = "0";
                        txtBtrWatt.Text = "0";
                        txtCnlQty.Text = "0";
                    }
                }
            }            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Session["User"] == null || Session["UserId"] == null)
            {
                Response.Redirect("~/UserLogin.aspx");
            }
            else
            {
                try
                {
                    int errNo = 0;
                    string errMsg = "";
                    string sparamVal = "";
                    string tValue = "0";

                    if (ddPlacement.SelectedItem.Value == "02")
                    {
                        if (ddLocation.SelectedItem.Value == "01" || ddArea.SelectedItem.Value == "01" || txtSpot.Text.Trim() == "")
                        {
                            bIsErr = true;
                            lblError.Text = "Location, Area And Spot must be filled for this Placement";
                        }
                    }
                    if (!bIsExist)
                    {
                        if (btnAdd.Text == "Add")
                        {
                            sparamVal = "@action:A,";
                        }
                        else
                        {
                            sparamVal = "@action:U,";
                        }

                        sparamVal = sparamVal + "@AssetCode:" + txtAssetCode.Text + ",";
                        sparamVal = sparamVal + "@AssetDesc:" + txtAssetDesc.Text + ",";
                        sparamVal = sparamVal + "@ActivaNo:" + txtActivaNO.Text + ",";
                        sparamVal = sparamVal + "@PurchaseDate:" + txtPurchaseDate.Text + ",";
                        sparamVal = sparamVal + "@GRPODocNo:" + txtGRPODocNum.Text + ",";
                        sparamVal = sparamVal + "@Placement:" + ddPlacement.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@LocationCode:" + ddLocation.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@AreaCode:" + ddArea.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@Spot:" + txtSpot.Text + ",";
                        sparamVal = sparamVal + "@Type:" + ddType.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@Brand:" + ddBrand.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@Model:" + txtModel.Text + ",";
                        sparamVal = sparamVal + "@Series:" + txtSeries.Text + ",";
                        sparamVal = sparamVal + "@SerialNo:" + txtSeriesNo.Text + ",";
                        sparamVal = sparamVal + "@Color:" + ddColor.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@ScreenSize:" + txtScrSize.Text + ",";
                        sparamVal = sparamVal + "@ScreenResolution:" + txtScrRsl.Text + ",";
                        sparamVal = sparamVal + "@TouchScreen:" + ddTchScr.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@Processor:" + txtProcessor.Text + ",";
                        sparamVal = sparamVal + "@VGABrand:" + ddVGABrand.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@VGAType:" + ddVGAType.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@VGASize:" + txtVGASize.Text + ",";
                        sparamVal = sparamVal + "@RAMType:" + ddRAMType.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@RAMMHz:" + txtRAMMHz.Text + ",";
                        sparamVal = sparamVal + "@RAMSize:" + txtRAMSize.Text + ",";
                        sparamVal = sparamVal + "@Storagetype:" + ddStrType.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@StorageSize:" + txtStrSize.Text + ",";
                        sparamVal = sparamVal + "@ChargerType:" + ddChrType.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@UnitVoltage:" + txtVoltage.Text + ",";
                        tValue = "0";
                        if (txtAmps.Text == ""){tValue = "0";}else { tValue = txtAmps.Text; }
                        sparamVal = sparamVal + "@UnitAmps:" + tValue + ",";
                        tValue = "0";
                        if (txtWatt.Text == "") { tValue = "0"; } else { tValue = txtWatt.Text; }
                        sparamVal = sparamVal + "@UnitWatt:" + tValue + ",";
                        sparamVal = sparamVal + "@BatteryType:" + txtBtrType.Text + ",";
                        sparamVal = sparamVal + "@BatteryVoltage:" + txtBtrVoltage.Text + ",";
                        tValue = "0";
                        if (txtBtrAmps.Text == "") { tValue = "0"; } else { tValue = txtBtrAmps.Text; }
                        sparamVal = sparamVal + "@BatteryAmps:" + tValue + ",";
                        tValue = "0";
                        if (txtBtrWatt.Text == "") { tValue = "0"; } else { tValue = txtBtrWatt.Text; }
                        sparamVal = sparamVal + "@BatteryWatt:" + tValue + ",";
                        sparamVal = sparamVal + "@Motherboard:" + txtMotherboard.Text + ",";
                        sparamVal = sparamVal + "@ChasingSize:" + ddCshSize.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@CameraResolution:" + txtResolution.Text + ",";
                        sparamVal = sparamVal + "@ChannelQuantity:" + txtCnlQty.Text + ",";
                        sparamVal = sparamVal + "@Health:" + ddHealth.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@OS:" + ddOS.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@Imei:" + txtImei.Text + ",";
                        sparamVal = sparamVal + "@MACAddress:" + txtMacAddr.Text + ",";
                        sparamVal = sparamVal + "@IP:" + txtIP.Text + ",";
                        sparamVal = sparamVal + "@MobileNumber:" + txtPhone.Text + ",";
                        sparamVal = sparamVal + "@Remarks:" + txtRemark.Text + ",";
                        sparamVal = sparamVal + "@UserId:" + Session["UserId"];

                        DataSet oDs = new DataSet();
                        oDs = oGnl.ExecuteSP("SP_VAL_ASSET", sparamVal);

                        errNo = Convert.ToInt32(oDs.Tables[0].Rows[0]["ERRNO"].ToString());
                        errMsg = oDs.Tables[0].Rows[0]["ERRMSG"].ToString();
                        if (errNo != 0)
                        {
                            lblError.ForeColor = System.Drawing.Color.Red;
                            lblError.Text = errMsg;
                        }

                        if (errNo == 0)
                        {
                            oDs = oGnl.ExecuteSP("SP_POST_ASSET", sparamVal);

                            errNo = Convert.ToInt32(oDs.Tables[0].Rows[0]["ERRNO"].ToString());
                            errMsg = oDs.Tables[0].Rows[0]["ERRMSG"].ToString();
                            if (errNo == 0)
                            {
                                lblError.ForeColor = System.Drawing.Color.Green;

                                if (btnAdd.Text == "Add")
                                {
                                    lblError.Text = "Add Asset is Success";
                                }
                                else
                                {
                                    lblError.Text = "Update Asset is Success";
                                }
                            }
                            else
                            {
                                lblError.ForeColor = System.Drawing.Color.Red;
                                lblError.Text = errMsg;
                            }
                        }                        
                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = "Error:" + ex.ToString();
                }
            }
            
        }

        protected void SeDropDown(string refCode, DropDownList dr)
        {
            try
            {
                oGnl.SeDropDown("SELECT [Code], [Name] FROM [Reference] WHERE [refCode]='" + refCode + "'  and [Status] = 'A' ORDER BY [Code]", dr);
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
                oDs = oGnl.GetDataSet("select 'RSI-IT-' + Right(Year(getDate()),2) + '-' + right('0000' + convert(varchar(4),convert(int,RIGHT(isnull([AssetCode],'0'),4)) + 1),4) [Code] from [dbo].[Asset] where [AssetCode] like 'RSI-IT-" + DateTime.Today.ToString("yy") + "-%' order by [AssetCode] desc");
                if (oDs.Tables[0].Rows.Count > 0)
                {
                    txtAssetCode.Text = oDs.Tables[0].Rows[0]["Code"].ToString();
                }
                else
                {
                    txtAssetCode.Text = "RSI-IT-" + DateTime.Today.ToString("yy") + "-0001";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error:" + ex.ToString();
            }
            return code;
        }
    }
}