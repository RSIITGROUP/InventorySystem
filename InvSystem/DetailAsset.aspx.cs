using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using InvSystem.Class;

namespace InvSystem
{
    public partial class DetailAsset : System.Web.UI.Page
    {
        clsGeneral oGnl = new clsGeneral();
        System.Web.UI.HtmlControls.HtmlControl div;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null || Session["UserId"] == null)
            {
                Response.Redirect("~/UserLogin.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    int iRID = 0;
                    DataSet oDs = new DataSet();
                    oDs = oGnl.GetDataSet("select * from V_DetailAsset where AssetCode='" + Request.QueryString["assetCode"] + "'");

                    iRID = Convert.ToInt32(oDs.Tables[0].Rows[0]["RID"].ToString());
                    txtAssetCode.Text = oDs.Tables[0].Rows[0]["AssetCode"].ToString();
                    txtAssetDesc.Text = oDs.Tables[0].Rows[0]["AssetDesc"].ToString();
                    txtGRPODocNum.Text = oDs.Tables[0].Rows[0]["GRPODocNo"].ToString();
                    txtActivaNO.Text = oDs.Tables[0].Rows[0]["ActivaNo"].ToString();
                    if (oDs.Tables[0].Rows[0]["PurchaseDate"].ToString() != "")
                    {
                        txtPurchaseDate.Text = Convert.ToDateTime(oDs.Tables[0].Rows[0]["PurchaseDate"]).ToString("yyyy-MM-dd");
                    }
                    //txtPurchaseDate.Text = Convert.ToDateTime(oDs.Tables[0].Rows[0]["PurchaseDate"]).ToString("yyyy-MM-dd");
                    txtGRPODocNum.Text = oDs.Tables[0].Rows[0]["GRPODocNo"].ToString();
                    txtType.Text = oDs.Tables[0].Rows[0]["Type"].ToString();
                    txtBrand.Text = oDs.Tables[0].Rows[0]["Brand"].ToString();
                    txtModel.Text = oDs.Tables[0].Rows[0]["Model"].ToString();
                    txtSeries.Text = oDs.Tables[0].Rows[0]["Series"].ToString();
                    txtSerialNo.Text = oDs.Tables[0].Rows[0]["SerialNo"].ToString();
                    txtColor.Text = oDs.Tables[0].Rows[0]["Color"].ToString();
                    txtScrSize.Text = oDs.Tables[0].Rows[0]["ScreenSize"].ToString();
                    txtScrRsl.Text = oDs.Tables[0].Rows[0]["ScreenResolution"].ToString();
                    txtTchScr.Text = oDs.Tables[0].Rows[0]["TouchScreen"].ToString();
                    txtProcessor.Text = oDs.Tables[0].Rows[0]["Processor"].ToString();
                    txtVGABrand.Text = oDs.Tables[0].Rows[0]["VGABrand"].ToString();
                    txtVGAType.Text = oDs.Tables[0].Rows[0]["VGAType"].ToString();
                    txtVGASize.Text = oDs.Tables[0].Rows[0]["VGASize"].ToString();
                    txtRAMType.Text = oDs.Tables[0].Rows[0]["RAMType"].ToString();
                    txtRAMMHz.Text = oDs.Tables[0].Rows[0]["RAMMHz"].ToString();
                    txtRAMSize.Text = oDs.Tables[0].Rows[0]["RAMSize"].ToString();
                    txtStrType.Text = oDs.Tables[0].Rows[0]["Storagetype"].ToString();
                    txtStrSize.Text = oDs.Tables[0].Rows[0]["StorageSize"].ToString();
                    txtChrType.Text = oDs.Tables[0].Rows[0]["ChargerType"].ToString();
                    txtUnitVoltage.Text = oDs.Tables[0].Rows[0]["UnitVoltage"].ToString();
                    txtUnitAmps.Text = oDs.Tables[0].Rows[0]["UnitAmps"].ToString();
                    txtUnitWatt.Text = oDs.Tables[0].Rows[0]["UnitWatt"].ToString();
                    txtBtrType.Text = oDs.Tables[0].Rows[0]["BatteryType"].ToString();
                    txtBtrVoltage.Text = oDs.Tables[0].Rows[0]["BatteryVoltage"].ToString();
                    txtBtrAmps.Text = oDs.Tables[0].Rows[0]["BatteryAmps"].ToString();
                    txtBtrWatt.Text = oDs.Tables[0].Rows[0]["BatteryWatt"].ToString();
                    txtMotherboard.Text = oDs.Tables[0].Rows[0]["Motherboard"].ToString();
                    txtCshSize.Text = oDs.Tables[0].Rows[0]["ChasingSize"].ToString();
                    txtResolution.Text = oDs.Tables[0].Rows[0]["CameraResolution"].ToString();
                    txtCameraType.Text = oDs.Tables[0].Rows[0]["CameraType"].ToString();
                    txtOperatingSystem.Text = oDs.Tables[0].Rows[0]["OperatingSystem"].ToString();
                    txtImei.Text = oDs.Tables[0].Rows[0]["Imei"].ToString();
                    txtMacAddr.Text = oDs.Tables[0].Rows[0]["MACAddress"].ToString();
                    txtIP.Text = oDs.Tables[0].Rows[0]["IP"].ToString();
                    txtPhone.Text = oDs.Tables[0].Rows[0]["MobileNumber"].ToString();
                    txtRemark.Text = oDs.Tables[0].Rows[0]["Remarks"].ToString();
                    txtPlacement.Text = oDs.Tables[0].Rows[0]["Placement"].ToString();
                    txtLocation.Text = oDs.Tables[0].Rows[0]["Location"].ToString();
                    txtArea.Text = oDs.Tables[0].Rows[0]["Area"].ToString();
                    txtSpot.Text = oDs.Tables[0].Rows[0]["Spot"].ToString();
                    txtHealth.Text = oDs.Tables[0].Rows[0]["Health"].ToString();
                    txtHostName.Text = oDs.Tables[0].Rows[0]["HostName"].ToString();
                    txtUser.Text = oDs.Tables[0].Rows[0]["User"].ToString();

                    txtTypeQuality.Text = oDs.Tables[0].Rows[0]["TypeQuality"].ToString();
                    txtTypePort.Text = oDs.Tables[0].Rows[0]["TypePort"].ToString();
                    txtTypeSystem.Text = oDs.Tables[0].Rows[0]["TypeSystem"].ToString();
                    txtPortQuantity.Text = oDs.Tables[0].Rows[0]["PortQuantity"].ToString();
                    txtSFPPortQuantity.Text = oDs.Tables[0].Rows[0]["SFPPortQuantity"].ToString();
                    txtFrequencyBand.Text = oDs.Tables[0].Rows[0]["FrequencyBand"].ToString();
                    txtTypeConnectivity.Text = oDs.Tables[0].Rows[0]["TypeConnectivity"].ToString();
                    txtTypeFunctionality.Text = oDs.Tables[0].Rows[0]["TypeFunctionality"].ToString();

                    string sqlStr = "SELECT T0.[Version], T1.Name [PlacementCharacteristic], T2.Name [Location], T3.Name [Area],";
                    sqlStr = sqlStr + "T0.[Spot], T4.[Name] [User], REPLACE(CONVERT(NVARCHAR, T0.[CreateDate], 106), ' ', '-')[CreateDate]";
                    sqlStr = sqlStr + "FROM [PlacementHistory] T0 ";
                    sqlStr = sqlStr + "Inner Join Reference T1 on T0.CharacteristicCode = T1.Code ";
                    sqlStr = sqlStr + "Inner Join Reference T2 on T0.LocationCode = T2.Code ";
                    sqlStr = sqlStr + "Inner Join Reference T3 on T0.AreaCode = T3.Code ";
                    sqlStr = sqlStr + "Inner Join EndUser T4 on T0.[User] = T4.[ID] ";
                    sqlStr = sqlStr + "where [RID] = " + iRID;
                    sqlStr = sqlStr + " order by T0.[Version] desc";

                    BindGrid(GridView1, sqlStr);

                    sqlStr = "select T0.[Version], T1.Name [Health], ";
                    sqlStr = sqlStr + "REPLACE(CONVERT(NVARCHAR,T0.[CreateDate], 106), ' ', '-') [CreateDate]";
                    sqlStr = sqlStr + "from [dbo].[HealtHistory] T0 ";
                    sqlStr = sqlStr + "Inner Join Reference T1 on T0.HealthCode = T1.Code ";
                    sqlStr = sqlStr + "where[RID] = " + iRID;
                    sqlStr = sqlStr + "order by T0.[Version] desc";

                    BindGrid(GridView2, sqlStr);

                    SetVisibleDiv(txtType.Text);
                }
            }
        }

        private void BindGrid(GridView gv, string sSqlStr)
        {
            gv.DataSource = oGnl.GetDataTable(sSqlStr);
            gv.DataBind();

            //Required for jQuery DataTables to work.
            gv.UseAccessibleHeader = true;
            gv.HeaderRow.TableSection = TableRowSection.TableHeader;
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
            sparamVal = sparamVal + "@action:2";
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