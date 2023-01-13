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
        System.Web.UI.HtmlControls.HtmlControl div;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null || Session["UserId"] == null)
            {
                Response.Redirect("~/UserLogin.aspx");            }
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
                            temp = Convert.ToInt32(oGnl.GetValueField("select count(*) from Asset where AssetCode <> '" + txtAssetCode.Text + "' and SerialNo=RTRIM(LTRIM('" + txtSerialNo.Text + "'))"));
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
                    SeDropDown("12", ddOperatingSystem);
                    SeDropDown("13", ddCshSize);
                    SeDropDown("14", ddHealth);
                    SeDropDown("15", ddTchScr);
                    SeDropDown("16", ddScrSize);
                    SeDropDown("17", ddScrRsl);
                    SeDropDown("18", ddBtrType);
                    SeDropDown("19", ddProcessor);
                    SeDropDown("20", ddTypeQuality);
                    SeDropDown("21", ddTypePort);
                    SeDropDown("22", ddTypeSystem);
                    SeDropDown("23", ddPortQuantity);
                    SeDropDown("24", ddSFPPortQuantity);
                    SeDropDown("25", ddFrequencyBand);
                    SeDropDown("26", ddTypeConnectivity);
                    SeDropDown("27", ddTypeFunctionality);
                    SeDropDown("28", ddUnitVoltage);
                    SeDropDown("29", ddUnitAmps);
                    SeDropDown("30", ddUnitWatt);
                    SeDropDown("28", ddBtrVoltage);
                    SeDropDown("29", ddBtrAmps);
                    SeDropDown("30", ddBtrWatt);
                    SeDropDown("31", ddCameraType);
                    SeDropDown("32", ddResolution);
                    oGnl.SeDropDown("select convert(nvarchar,[ID]) [Code], [Name] from EndUser where (UsrStatus='A' or ltrim(rtrim(NIK))='NA') order by [Name]", ddUser);

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
                        txtSerialNo.Text = oDs.Tables[0].Rows[0]["SerialNo"].ToString();
                        ddColor.SelectedValue = oDs.Tables[0].Rows[0]["Color"].ToString();
                        ddScrSize.SelectedValue = oDs.Tables[0].Rows[0]["ScreenSize"].ToString();
                        ddScrRsl.SelectedValue = oDs.Tables[0].Rows[0]["ScreenResolution"].ToString();
                        ddTchScr.SelectedValue = oDs.Tables[0].Rows[0]["TouchScreen"].ToString();
                        ddProcessor.SelectedValue = oDs.Tables[0].Rows[0]["Processor"].ToString();
                        ddVGABrand.SelectedValue = oDs.Tables[0].Rows[0]["VGABrand"].ToString();
                        ddVGAType.SelectedValue = oDs.Tables[0].Rows[0]["VGAType"].ToString();
                        txtVGASize.Text = oDs.Tables[0].Rows[0]["VGASize"].ToString();
                        ddRAMType.SelectedValue = oDs.Tables[0].Rows[0]["RAMType"].ToString();
                        txtRAMMHz.Text = oDs.Tables[0].Rows[0]["RAMMHz"].ToString();
                        txtRAMSize.Text = oDs.Tables[0].Rows[0]["RAMSize"].ToString();
                        ddStrType.SelectedValue = oDs.Tables[0].Rows[0]["Storagetype"].ToString();
                        txtStrSize.Text = oDs.Tables[0].Rows[0]["StorageSize"].ToString();
                        ddChrType.SelectedValue = oDs.Tables[0].Rows[0]["ChargerType"].ToString();
                        ddUnitVoltage.SelectedValue = oDs.Tables[0].Rows[0]["UnitVoltage"].ToString();
                        ddUnitAmps.SelectedValue = oDs.Tables[0].Rows[0]["UnitAmps"].ToString();
                        ddUnitWatt.SelectedValue = oDs.Tables[0].Rows[0]["UnitWatt"].ToString();
                        ddBtrType.SelectedValue = oDs.Tables[0].Rows[0]["BatteryType"].ToString();
                        ddBtrVoltage.SelectedValue = oDs.Tables[0].Rows[0]["BatteryVoltage"].ToString();
                        ddBtrAmps.SelectedValue = oDs.Tables[0].Rows[0]["BatteryAmps"].ToString();
                        ddBtrWatt.SelectedValue = oDs.Tables[0].Rows[0]["BatteryWatt"].ToString();
                        txtMotherboard.Text = oDs.Tables[0].Rows[0]["Motherboard"].ToString();
                        ddCshSize.SelectedValue = oDs.Tables[0].Rows[0]["ChasingSize"].ToString();
                        ddResolution.SelectedValue = oDs.Tables[0].Rows[0]["CameraResolution"].ToString();
                        ddCameraType.SelectedValue = oDs.Tables[0].Rows[0]["CameraType"].ToString();
                        ddOperatingSystem.SelectedValue = oDs.Tables[0].Rows[0]["OperatingSystem"].ToString();
                        txtImei.Text = oDs.Tables[0].Rows[0]["Imei"].ToString();
                        txtMacAddr.Text = oDs.Tables[0].Rows[0]["MACAddress"].ToString();   
                        txtIP.Text = oDs.Tables[0].Rows[0]["IP"].ToString();
                        txtPhone.Text = oDs.Tables[0].Rows[0]["MobileNumber"].ToString();
                        txtRemark.Text = oDs.Tables[0].Rows[0]["Remarks"].ToString();
                        txtHostName.Text = oDs.Tables[0].Rows[0]["HostName"].ToString();

                        ddTypeQuality.SelectedValue = oDs.Tables[0].Rows[0]["TypeQuality"].ToString();
                        ddTypePort.SelectedValue = oDs.Tables[0].Rows[0]["TypePort"].ToString();
                        ddTypeSystem.SelectedValue = oDs.Tables[0].Rows[0]["TypeSystem"].ToString();
                        ddPortQuantity.SelectedValue = oDs.Tables[0].Rows[0]["PortQuantity"].ToString();
                        ddSFPPortQuantity.SelectedValue = oDs.Tables[0].Rows[0]["SFPPortQuantity"].ToString();
                        ddFrequencyBand.SelectedValue = oDs.Tables[0].Rows[0]["FrequencyBand"].ToString();
                        ddTypeConnectivity.SelectedValue = oDs.Tables[0].Rows[0]["TypeConnectivity"].ToString();
                        ddTypeFunctionality.SelectedValue = oDs.Tables[0].Rows[0]["TypeFunctionality"].ToString();

                        oDs = null;
                        oDs = new DataSet();
                        oDs = oGnl.GetDataSet("select top 1 CharacteristicCode, LocationCode, AreaCode, Spot, [User] from PlacementHistory where RID=" + iRID + "order by [Version] desc");

                        if (oDs.Tables[0].Rows.Count > 0)
                        {
                            ddPlacement.SelectedValue = oDs.Tables[0].Rows[0]["CharacteristicCode"].ToString();
                            ddLocation.SelectedValue = oDs.Tables[0].Rows[0]["LocationCode"].ToString();
                            ddArea.SelectedValue = oDs.Tables[0].Rows[0]["AreaCode"].ToString();
                            txtSpot.Text = oDs.Tables[0].Rows[0]["Spot"].ToString();
                            ddUser.SelectedValue = oDs.Tables[0].Rows[0]["User"].ToString();
                        }
                        
                        oDs = null;
                        oDs = new DataSet();
                        oDs = oGnl.GetDataSet("select top 1 HealthCode from HealtHistory where RID=" + iRID + "order by [Version] desc");
                        if (oDs.Tables[0].Rows.Count > 0)
                        {
                            ddHealth.SelectedValue = oDs.Tables[0].Rows[0]["HealthCode"].ToString();
                        }

                        txtAssetCode.ReadOnly = true;
                        ddType.Enabled = false;
                    }
                    else
                    {
                        btnAdd.Text = "Add";
                        GenerateCode();
                        txtAssetCode.ReadOnly = true;
                        txtVGASize.Text = "0";
                        txtRAMSize.Text = "0";
                        txtStrSize.Text = "0";   
                        ddType.Enabled = true;
                    }
                    SetVisibleDiv(ddType.SelectedItem.Value);
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
                        sparamVal = sparamVal + "@SerialNo:" + txtSerialNo.Text + ",";
                        sparamVal = sparamVal + "@Color:" + ddColor.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@ScreenSize:" + ddScrSize.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@ScreenResolution:" + ddScrRsl.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@TouchScreen:" + ddTchScr.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@Processor:" + ddProcessor.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@VGABrand:" + ddVGABrand.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@VGAType:" + ddVGAType.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@VGASize:" + txtVGASize.Text + ",";
                        sparamVal = sparamVal + "@RAMType:" + ddRAMType.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@RAMMHz:" + txtRAMMHz.Text + ",";
                        sparamVal = sparamVal + "@RAMSize:" + txtRAMSize.Text + ",";
                        sparamVal = sparamVal + "@Storagetype:" + ddStrType.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@StorageSize:" + txtStrSize.Text + ",";
                        sparamVal = sparamVal + "@ChargerType:" + ddChrType.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@UnitVoltage:" + ddUnitVoltage.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@UnitAmps:" + ddUnitAmps.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@UnitWatt:" + ddUnitWatt.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@BatteryType:" + ddBtrType.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@BatteryVoltage:" + ddBtrVoltage.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@BatteryAmps:" + ddBtrAmps.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@BatteryWatt:" + ddBtrWatt.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@Motherboard:" + txtMotherboard.Text + ",";
                        sparamVal = sparamVal + "@ChasingSize:" + ddCshSize.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@CameraResolution:" + ddResolution.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@CameraType:" + ddCameraType.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@Health:" + ddHealth.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@OperatingSystem:" + ddOperatingSystem.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@Imei:" + txtImei.Text + ",";
                        sparamVal = sparamVal + "@MACAddress:" + txtMacAddr.Text + ",";
                        sparamVal = sparamVal + "@IP:" + txtIP.Text + ",";
                        sparamVal = sparamVal + "@MobileNumber:" + txtPhone.Text + ",";
                        sparamVal = sparamVal + "@Remarks:" + txtRemark.Text + ",";
                        sparamVal = sparamVal + "@HostName:" + txtHostName.Text + ",";
                        sparamVal = sparamVal + "@User:" + ddUser.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@TypeQuality:" + ddTypeQuality.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@TypePort:" + ddTypePort.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@TypeSystem:" + ddTypeSystem.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@PortQuantity:" + ddPortQuantity.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@SFPPortQuantity:" + ddSFPPortQuantity.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@FrequencyBand:" + ddFrequencyBand.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@TypeConnectivity:" + ddTypeConnectivity.SelectedItem.Value + ",";
                        sparamVal = sparamVal + "@TypeFunctionality:" + ddTypeFunctionality.SelectedItem.Value + ",";
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
                                    btnAdd.Enabled = false;
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
                    else
                    {
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = "Asset is already exist";
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
                oGnl.SeDropDown("SELECT [Code], [Name] FROM [Reference] WHERE [refCode]='" + refCode + "'  and [Status] = 'A' ORDER BY [Name]", dr);
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

        protected void ddType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetVisibleDiv(ddType.SelectedItem.Value);
        }

        protected void SetVisibleDiv(string type)
        {
            string sparamVal = "";
            Processor.Visible = false;
            OperatingSystem.Visible = false;
            Motherboard.Visible = false;
            ScreenSize.Visible = false;
            ScreenResolution.Visible = false;
            TouchScreen.Visible = false;
            VGABrand.Visible = false;
            VGAType.Visible = false;
            VGASize.Visible = false;
            RAMType.Visible = false;
            RAMMHz.Visible = false;
            RAMSize.Visible = false;
            Storagetype.Visible = false;
            StorageSize.Visible = false;
            ChargerType.Visible = false;
            UnitVoltage.Visible = false;
            UnitAmps.Visible = false;
            UnitWatt.Visible = false;
            BatteryType.Visible = false;
            BatteryVoltage.Visible = false;
            BatteryAmps.Visible = false;
            BatteryWatt.Visible = false;
            ChasingSize.Visible = false;
            CameraResolution.Visible = false;
            CameraType.Visible = false;
            HostName.Visible = false;
            MACAddress.Visible = false;
            TypeConnectivity.Visible = false;
            TypeFunctionality.Visible = false;
            IP.Visible = false;
            Imei.Visible = false;
            MobileNumber.Visible = false;
            Remarks.Visible = false;
            TypeQuality.Visible = false;
            TypePort.Visible = false;
            TypeSystem.Visible = false;
            PortQuantity.Visible = false;
            SFPPortQuantity.Visible = false;
            FrequencyBand.Visible = false;
            TypeConnectivity.Visible = false;
            TypeFunctionality.Visible = false;

            Detail1.Visible = false;
            Detail2.Visible = false;
            Detail3.Visible = false;
            Detail4.Visible = false;
            Detail5.Visible = false;
            Detail6.Visible = false;
            Detail7.Visible = false;
            Detail8.Visible = false;

            DataSet oDs = new DataSet();
            sparamVal = sparamVal + "@type:" + type + ",";
            sparamVal = sparamVal + "@action:1";
            oDs = oGnl.ExecuteSP("SP_GET_LISTFIELD", sparamVal);
            if (oDs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in oDs.Tables[0].Rows)
                {
                    div = (System.Web.UI.HtmlControls.HtmlControl)mains.FindControl(row[0].ToString());
                    div.Visible = true;
                }
                Detail9.Visible = true;
            }
            else
            {
                Detail9.Visible = false;
            }
        }
    }
}