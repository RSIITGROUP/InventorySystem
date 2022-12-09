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
                    txtVoltage.Text = oDs.Tables[0].Rows[0]["UnitVoltage"].ToString();
                    txtAmps.Text = oDs.Tables[0].Rows[0]["UnitAmps"].ToString();
                    txtWatt.Text = oDs.Tables[0].Rows[0]["UnitWatt"].ToString();
                    txtBtrType.Text = oDs.Tables[0].Rows[0]["BatteryType"].ToString();
                    txtBtrVoltage.Text = oDs.Tables[0].Rows[0]["BatteryVoltage"].ToString();
                    txtBtrAmps.Text = oDs.Tables[0].Rows[0]["BatteryAmps"].ToString();
                    txtBtrWatt.Text = oDs.Tables[0].Rows[0]["BatteryWatt"].ToString();
                    txtMotherboard.Text = oDs.Tables[0].Rows[0]["Motherboard"].ToString();
                    txtCshSize.Text = oDs.Tables[0].Rows[0]["ChasingSize"].ToString();
                    txtResolution.Text = oDs.Tables[0].Rows[0]["CameraResolution"].ToString();
                    txtCnlQty.Text = oDs.Tables[0].Rows[0]["ChannelQuantity"].ToString();
                    txtOS.Text = oDs.Tables[0].Rows[0]["OS"].ToString();
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

                    string sqlStr = "SELECT T0.[Version], T1.Name [PlacementCharacteristic], T2.Name [Location], T3.Name [Area],";
                    sqlStr = sqlStr + "T0.[Spot], T0.[User], REPLACE(CONVERT(NVARCHAR, T0.[CreateDate], 106), ' ', '-')[CreateDate]";
                    sqlStr = sqlStr + "FROM [PlacementHistory] T0 ";
                    sqlStr = sqlStr + "Inner Join Reference T1 on T0.CharacteristicCode = T1.Code ";
                    sqlStr = sqlStr + "Inner Join Reference T2 on T0.LocationCode = T2.Code ";
                    sqlStr = sqlStr + "Inner Join Reference T3 on T0.AreaCode = T3.Code ";
                    sqlStr = sqlStr + "where[RID] = " + iRID;
                    sqlStr = sqlStr + "order by T0.[Version] desc";

                    BindGrid(GridView1, sqlStr);

                    sqlStr = "select T0.[Version], T1.Name [Health], ";
                    sqlStr = sqlStr + "REPLACE(CONVERT(NVARCHAR,T0.[CreateDate], 106), ' ', '-') [CreateDate]";
                    sqlStr = sqlStr + "from [dbo].[HealtHistory] T0 ";
                    sqlStr = sqlStr + "Inner Join Reference T1 on T0.HealthCode = T1.Code ";
                    sqlStr = sqlStr + "where[RID] = " + iRID;
                    sqlStr = sqlStr + "order by T0.[Version] desc";

                    BindGrid(GridView2, sqlStr);
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
    }
}