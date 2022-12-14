using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Data;
using OfficeOpenXml;
using InvSystem.Class;

namespace InvSystem
{
    public partial class UploadAsset : System.Web.UI.Page
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
                Label1.Text = "";
                Label1.ForeColor = Color.Green;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton linkDownload = sender as LinkButton;
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string downloadFile = "~/template/TemplateUpload.xlsx";
            Response.AddHeader("Content-Disposition", "attachment;filename=TemplateUpload.xlsx");
            Response.TransmitFile(Server.MapPath(downloadFile));
            Response.End();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string fileName = "";
            if (Session["User"] == null || Session["UserId"] == null)
            {
                Response.Redirect("~/UserLogin.aspx");
            }
            else
            {
                if (FileUpload1.HasFile)
                {
                    try
                    {
                        string[] extFile = { ".xls", ".xlsx" };
                        string fileExt = Path.GetExtension(FileUpload1.PostedFile.FileName);
                        bool isValidFile = extFile.Contains(fileExt);
                        if (!isValidFile)
                        {
                            Label1.Text = "Please Upload Only Excel File";
                            Label1.ForeColor = Color.Red;
                        }
                        else
                        {
                            int fileSize = FileUpload1.PostedFile.ContentLength;
                            if (fileSize <= 2097152)
                            {
                                fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                                ExcelPackage package = new ExcelPackage(FileUpload1.FileContent);
                                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                                ExcelWorksheet workSheet = package.Workbook.Worksheets.First();
                                int colNum = 0;
                                int errNo = 0;
                                string colHeader = "";
                                string sparamVal = "";
                                string errMsg = "";

                                int bulkId = GetBulkId();
                                DataSet oDs = new DataSet();
                                ClsAsset oAsset = new ClsAsset();
                                DataTable dt = new DataTable();
                                //foreach (var firstRowCell in workSheet.Cells[1, 1, 1, workSheet.Dimension.End.Column])
                                //{
                                //    dt.Columns.Add(firstRowCell.Text);
                                //}
                                for (var rowNumber = 2; rowNumber <= workSheet.Dimension.End.Row; rowNumber++)
                                {
                                    //colNum = 1;
                                    sparamVal = "";
                                    var row = workSheet.Cells[rowNumber, 1, rowNumber, workSheet.Dimension.End.Column];
                                    for (var colNumber = 1; colNumber <= workSheet.Dimension.End.Column; colNumber++)
                                    {
                                        colHeader = workSheet.Cells[1, colNumber].Text;
                                        if (colHeader == "AssetDesc") { oAsset.AssetDesc = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "ActivaNo") { oAsset.ActivaNo = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "PurchaseDate") { oAsset.PurchaseDate = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "GRPODocNo") { oAsset.GRPODocNo = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "Health") { oAsset.Health = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "Placement") { oAsset.Placement = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "LocationCode") { oAsset.LocationCode = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "AreaCode") { oAsset.AreaCode = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "Spot") { oAsset.Spot = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "User") { oAsset.User = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "Type") { oAsset.Type = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "Brand") { oAsset.Brand = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "Model") { oAsset.Model = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "Series") { oAsset.Series = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "SerialNo") { oAsset.SerialNo = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "HostName") { oAsset.HostName = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "Color") { oAsset.Color = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "ScreenSize") { oAsset.ScreenSize = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "ScreenResolution") { oAsset.ScreenreSolution = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "TouchScreen") { oAsset.TouchScreen = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "Processor") { oAsset.Processor = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "VGABrand") { oAsset.VgaBrand = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "VGAType") { oAsset.VgaType = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "VGASize") { oAsset.VgaSize = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "RAMType") { oAsset.RamType = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "RAMMHz") { oAsset.RamMhz = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "RAMSize") { oAsset.RamSize = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "Storagetype") { oAsset.StorageType = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "StorageSize") { oAsset.StorageSize = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "ChargerType") { oAsset.ChargerType = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "UnitVoltage") { oAsset.UnitVoltage = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "UnitAmps") { oAsset.UnitAmps = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "UnitWatt") { oAsset.UnitWatt = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "BatteryType") { oAsset.BatteryType = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "BatteryVoltage") { oAsset.BatteryVoltage = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "BatteryAmps") { oAsset.BatteryAmps = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "BatteryWatt") { oAsset.BatteryWatt = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "Motherboard") { oAsset.MotherBoard = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "ChasingSize") { oAsset.ChasingSize = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "CameraResolution") { oAsset.CameraResolution = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "ChannelQuantity") { oAsset.ChannelQuantity = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "OS") { oAsset.OS = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "Imei") { oAsset.Imei = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "MACAddress") { oAsset.MacAddress = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "IP") { oAsset.IP = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "MobileNumber") { oAsset.MobileNumber = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "Remarks") { oAsset.Remarks = workSheet.Cells[rowNumber, colNumber].Text; }
                                        //colNum = colNum + 1;
                                    }
                                    if (errNo == 0)
                                    {
                                        sparamVal = sparamVal + "@AssetDesc:" + oAsset.AssetDesc + ",";
                                        sparamVal = sparamVal + "@ActivaNo:" + oAsset.ActivaNo + ",";
                                        sparamVal = sparamVal + "@PurchaseDate:" + oAsset.PurchaseDate + ",";
                                        sparamVal = sparamVal + "@GRPODocNo:" + oAsset.GRPODocNo + ",";
                                        sparamVal = sparamVal + "@Placement:" + oAsset.Placement + ",";
                                        sparamVal = sparamVal + "@LocationCode:" + oAsset.LocationCode + ",";
                                        sparamVal = sparamVal + "@AreaCode:" + oAsset.AreaCode + ",";
                                        sparamVal = sparamVal + "@Spot:" + oAsset.Spot + ",";
                                        sparamVal = sparamVal + "@Type:" + oAsset.Type + ",";
                                        sparamVal = sparamVal + "@Brand:" + oAsset.Brand + ",";
                                        sparamVal = sparamVal + "@Model:" + oAsset.Model + ",";
                                        sparamVal = sparamVal + "@Series:" + oAsset.Series + ",";
                                        sparamVal = sparamVal + "@SerialNo:" + oAsset.SerialNo + ",";
                                        sparamVal = sparamVal + "@Color:" + oAsset.Color + ",";
                                        sparamVal = sparamVal + "@ScreenSize:" + oAsset.ScreenSize + ",";
                                        sparamVal = sparamVal + "@ScreenResolution:" + oAsset.ScreenreSolution + ",";
                                        sparamVal = sparamVal + "@TouchScreen:" + oAsset.TouchScreen + ",";
                                        sparamVal = sparamVal + "@Processor:" + oAsset.Processor + ",";
                                        sparamVal = sparamVal + "@VGABrand:" + oAsset.VgaBrand + ",";
                                        sparamVal = sparamVal + "@VGAType:" + oAsset.VgaType + ",";
                                        sparamVal = sparamVal + "@VGASize:" + oAsset.VgaSize + ",";
                                        sparamVal = sparamVal + "@RAMType:" + oAsset.RamType + ",";
                                        sparamVal = sparamVal + "@RAMMHz:" + oAsset.RamMhz + ",";
                                        sparamVal = sparamVal + "@RAMSize:" + oAsset.RamSize + ",";
                                        sparamVal = sparamVal + "@Storagetype:" + oAsset.StorageType + ",";
                                        sparamVal = sparamVal + "@StorageSize:" + oAsset.StorageSize + ",";
                                        sparamVal = sparamVal + "@ChargerType:" + oAsset.ChargerType + ",";
                                        sparamVal = sparamVal + "@UnitVoltage:" + oAsset.UnitVoltage + ",";
                                        sparamVal = sparamVal + "@UnitAmps:" + oAsset.UnitAmps + ",";
                                        sparamVal = sparamVal + "@UnitWatt:" + oAsset.UnitWatt + ",";
                                        sparamVal = sparamVal + "@BatteryType:" + oAsset.BatteryType + ",";
                                        sparamVal = sparamVal + "@BatteryVoltage:" + oAsset.BatteryVoltage + ",";
                                        sparamVal = sparamVal + "@BatteryAmps:" + oAsset.BatteryAmps + ",";
                                        sparamVal = sparamVal + "@BatteryWatt:" + oAsset.BatteryWatt + ",";
                                        sparamVal = sparamVal + "@Motherboard:" + oAsset.MotherBoard + ",";
                                        sparamVal = sparamVal + "@ChasingSize:" + oAsset.ChasingSize + ",";
                                        sparamVal = sparamVal + "@CameraResolution:" + oAsset.CameraResolution + ",";
                                        sparamVal = sparamVal + "@ChannelQuantity:" + oAsset.ChannelQuantity + ",";
                                        sparamVal = sparamVal + "@Health:" + oAsset.Health + ",";
                                        sparamVal = sparamVal + "@OS:" + oAsset.OS + ",";
                                        sparamVal = sparamVal + "@Imei:" + oAsset.Imei + ",";
                                        sparamVal = sparamVal + "@MACAddress:" + oAsset.MacAddress + ",";
                                        sparamVal = sparamVal + "@IP:" + oAsset.IP + ",";
                                        sparamVal = sparamVal + "@MobileNumber:" + oAsset.MobileNumber + ",";
                                        sparamVal = sparamVal + "@Remarks:" + oAsset.Remarks + ",";
                                        sparamVal = sparamVal + "@HostName:" + oAsset.HostName + ",";
                                        sparamVal = sparamVal + "@User:" + oAsset.User + ",";
                                        sparamVal = sparamVal + "@BulkId:" + bulkId.ToString() + ",@UserId:" + Session["UserId"];
                                        oDs = oGnl.ExecuteSP("SP_POST_ASSETTEMP", sparamVal);

                                        errNo = Convert.ToInt32(oDs.Tables[0].Rows[0]["ERRNO"].ToString());
                                        errMsg = oDs.Tables[0].Rows[0]["ERRMSG"].ToString();
                                        if (errNo != 0)
                                        {
                                            Label1.ForeColor = System.Drawing.Color.Red;
                                            Label1.Text = errMsg;
                                            break;
                                        }
                                    }

                                }
                                if (errNo == 0)
                                {
                                    sparamVal = "";
                                    sparamVal = "@BulkId:" + bulkId.ToString();
                                    oDs = oGnl.ExecuteSP("SP_VALIDATE_ASSET", sparamVal);

                                    errNo = Convert.ToInt32(oDs.Tables[0].Rows[0]["ERRNO"].ToString());
                                    errMsg = oDs.Tables[0].Rows[0]["ERRMSG"].ToString();
                                    if (errNo != 0)
                                    {
                                        Label1.ForeColor = System.Drawing.Color.Red;
                                        Label1.Text = errMsg;
                                    }
                                }

                                if (errNo == 0)
                                {
                                    sparamVal = "";
                                    sparamVal = "@BulkId:" + bulkId.ToString();
                                    oDs = oGnl.ExecuteSP("SP_POST_ASSETBULK", sparamVal);

                                    errNo = Convert.ToInt32(oDs.Tables[0].Rows[0]["ERRNO"].ToString());
                                    errMsg = oDs.Tables[0].Rows[0]["ERRMSG"].ToString();
                                    if (errNo != 0)
                                    {
                                        Label1.ForeColor = System.Drawing.Color.Red;
                                        Label1.Text = errMsg;
                                    }
                                    else
                                    {
                                        Label1.ForeColor = System.Drawing.Color.Green;
                                        Label1.Text = "Upload Asset is Success";
                                        Button2.Enabled = false;
                                    }
                                }


                                string sQlStr = "SELECT [AssetDesc],[ActivaNo],[PurchaseDate],[GRPODocNo]";
                                sQlStr = sQlStr + ",[Placement],[LocationCode],[AreaCode],[Spot],[User]";
                                sQlStr = sQlStr + ",[Type],[Brand],[Model],[Series],[SerialNo],[HostName]";
                                sQlStr = sQlStr + ",[Color],[ScreenSize],[ScreenResolution],[TouchScreen]";
                                sQlStr = sQlStr + ",[Processor],[VGABrand],[VGAType],[VGASize]";
                                sQlStr = sQlStr + ",[RAMType],[RAMMHz],[RAMSize],[Storagetype],[StorageSize]";
                                sQlStr = sQlStr + ",[ChargerType],[UnitVoltage],[UnitAmps],[UnitWatt]";
                                sQlStr = sQlStr + ",[BatteryType],[BatteryVoltage],[BatteryAmps],[BatteryWatt]";
                                sQlStr = sQlStr + ",[Motherboard],[ChasingSize],[CameraResolution],[ChannelQuantity]";
                                sQlStr = sQlStr + ",[Health],[OS],[Imei],[MACAddress],[IP],[MobileNumber],[Remarks],[HostName],[User]";
                                sQlStr = sQlStr + "FROM [dbo].[Asset_Temp] ";
                                sQlStr = sQlStr + "where[BulkId] = " + bulkId.ToString() + " Order By RID";
                                dt = oGnl.GetDataTable(sQlStr);

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

                                //int totCol = workSheet.Dimension.End.Column;
                                //int totRow = workSheet.Dimension.End.Row;

                                ////int nColumn = 0;
                                //string sparamVal = "";

                                //var dataTable = workSheet.Cells["A1:AU" + totRow].ToDataTable(c =>
                                //{
                                //    c.DataTableName = "MyDataTable";
                                //    c.DataTableNamespace = "MyNamespace";
                                //    c.FirstRowIsColumnNames = true;
                                //});

                                //DataTable dts = new DataTable();
                                //dts = dataTable;
                                //DataRow[] dr = dts.Select();
                                //int errNo = 0;
                                //string errMsg = "";
                                //DataSet oDs = new DataSet();
                                //foreach (DataRow row in dr)
                                //{
                                //    if (errNo == 0)
                                //    {
                                //        sparamVal = sparamVal + "@AssetDesc:" + row["AssetDesc"].ToString() + ",";
                                //        sparamVal = sparamVal + "@ActivaNo:" + row["ActivaNo"].ToString() + ",";
                                //        sparamVal = sparamVal + "@PurchaseDate:" + row["PurchaseDate"].ToString() + ",";
                                //        sparamVal = sparamVal + "@GRPODocNo:" + row["GRPODocNo"].ToString() + ",";
                                //        sparamVal = sparamVal + "@Placement:" + row["Placement"].ToString() + ",";
                                //        sparamVal = sparamVal + "@LocationCode:" + row["LocationCode"].ToString() + ",";
                                //        sparamVal = sparamVal + "@AreaCode:" + row["AreaCode"].ToString() + ",";
                                //        sparamVal = sparamVal + "@Spot:" + row["Spot"].ToString() + ",";
                                //        sparamVal = sparamVal + "@Type:" + row["Type"].ToString() + ",";
                                //        sparamVal = sparamVal + "@Brand:" + row["Brand"].ToString() + ",";
                                //        sparamVal = sparamVal + "@Model:" + row["Model"].ToString() + ",";
                                //        sparamVal = sparamVal + "@Series:" + row["Series"].ToString() + ",";
                                //        sparamVal = sparamVal + "@SerialNo:" + row["SerialNo"].ToString() + ",";
                                //        sparamVal = sparamVal + "@Color:" + row["Color"].ToString() + ",";
                                //        sparamVal = sparamVal + "@ScreenSize:" + row["ScreenSize"].ToString() + ",";
                                //        sparamVal = sparamVal + "@ScreenResolution:" + row["ScreenResolution"].ToString() + ",";
                                //        sparamVal = sparamVal + "@TouchScreen:" + row["TouchScreen"].ToString() + ",";
                                //        sparamVal = sparamVal + "@Processor:" + row["Processor"].ToString() + ",";
                                //        sparamVal = sparamVal + "@VGABrand:" + row["VGABrand"].ToString() + ",";
                                //        sparamVal = sparamVal + "@VGAType:" + row["VGAType"].ToString() + ",";
                                //        sparamVal = sparamVal + "@VGASize:" + row["VGASize"].ToString() + ",";
                                //        sparamVal = sparamVal + "@RAMType:" + row["RAMType"].ToString() + ",";
                                //        sparamVal = sparamVal + "@RAMMHz:" + row["RAMMHz"].ToString() + ",";
                                //        sparamVal = sparamVal + "@RAMSize:" + row["RAMSize"].ToString() + ",";
                                //        sparamVal = sparamVal + "@Storagetype:" + row["Storagetype"].ToString() + ",";
                                //        sparamVal = sparamVal + "@StorageSize:" + row["StorageSize"].ToString() + ",";
                                //        sparamVal = sparamVal + "@ChargerType:" + row["ChargerType"].ToString() + ",";
                                //        sparamVal = sparamVal + "@UnitVoltage:" + row["UnitVoltage"].ToString() + ",";
                                //        sparamVal = sparamVal + "@UnitAmps:" + row["UnitAmps"].ToString() + ",";
                                //        sparamVal = sparamVal + "@UnitWatt:" + row["UnitWatt"].ToString() + ",";
                                //        sparamVal = sparamVal + "@BatteryType:" + row["BatteryType"].ToString() + ",";
                                //        sparamVal = sparamVal + "@BatteryVoltage:" + row["BatteryVoltage"].ToString() + ",";
                                //        sparamVal = sparamVal + "@BatteryAmps:" + row["BatteryAmps"].ToString() + ",";
                                //        sparamVal = sparamVal + "@BatteryWatt:" + row["BatteryWatt"].ToString() + ",";
                                //        sparamVal = sparamVal + "@Motherboard:" + row["Motherboard"].ToString() + ",";
                                //        sparamVal = sparamVal + "@ChasingSize:" + row["ChasingSize"].ToString() + ",";
                                //        sparamVal = sparamVal + "@CameraResolution:" + row["CameraResolution"].ToString() + ",";
                                //        sparamVal = sparamVal + "@ChannelQuantity:" + row["ChannelQuantity"].ToString() + ",";
                                //        sparamVal = sparamVal + "@Health:" + row["Health"].ToString() + ",";
                                //        sparamVal = sparamVal + "@OS:" + row["OS"].ToString() + ",";
                                //        sparamVal = sparamVal + "@Imei:" + row["Imei"].ToString() + ",";
                                //        sparamVal = sparamVal + "@MACAddress:" + row["MACAddress"].ToString() + ",";
                                //        sparamVal = sparamVal + "@IP:" + row["IP"].ToString() + ",";
                                //        sparamVal = sparamVal + "@MobileNumber:" + row["MobileNumber"].ToString() + ",";
                                //        sparamVal = sparamVal + "@Remarks:" + row["Remarks"].ToString() + ",";
                                //        sparamVal = sparamVal + "@HostName:" + row["HostName"].ToString() + ",";
                                //        sparamVal = sparamVal + "@User:" + row["User"].ToString() + ",";
                                //        sparamVal = sparamVal + "@BulkId:" + bulkId.ToString() + ",@UserId:" + Session["UserId"];
                                //        oDs = oGnl.ExecuteSP("SP_POST_ASSETTEMP", sparamVal);

                                //        errNo = Convert.ToInt32(oDs.Tables[0].Rows[0]["ERRNO"].ToString());
                                //        errMsg = oDs.Tables[0].Rows[0]["ERRMSG"].ToString();
                                //        if (errNo != 0)
                                //        {
                                //            Label1.ForeColor = System.Drawing.Color.Red;
                                //            Label1.Text = errMsg;
                                //            break;
                                //        }                                        
                                //    }
                                //}

                                //if (errNo == 0)
                                //{
                                //    sparamVal = "";
                                //    sparamVal = "@BulkId:" + bulkId.ToString();
                                //    oDs = oGnl.ExecuteSP("SP_VALIDATE_ASSET", sparamVal);

                                //    errNo = Convert.ToInt32(oDs.Tables[0].Rows[0]["ERRNO"].ToString());
                                //    errMsg = oDs.Tables[0].Rows[0]["ERRMSG"].ToString();
                                //    if (errNo != 0)
                                //    {
                                //        Label1.ForeColor = System.Drawing.Color.Red;
                                //        Label1.Text = errMsg;
                                //    }
                                //}

                                //if (errNo == 0)
                                //{
                                //    sparamVal = "";
                                //    sparamVal = "@BulkId:" + bulkId.ToString();
                                //    oDs = oGnl.ExecuteSP("SP_POST_ASSETBULK", sparamVal);

                                //    errNo = Convert.ToInt32(oDs.Tables[0].Rows[0]["ERRNO"].ToString());
                                //    errMsg = oDs.Tables[0].Rows[0]["ERRMSG"].ToString();
                                //    if (errNo != 0)
                                //    {
                                //        Label1.ForeColor = System.Drawing.Color.Red;
                                //        Label1.Text = errMsg;
                                //    }
                                //    else
                                //    {
                                //        Label1.ForeColor = System.Drawing.Color.Green;
                                //        Label1.Text = "Upload Asset is Success";
                                //        Button2.Enabled = false;
                                //    }
                                //}


                                //string sQlStr = "SELECT [AssetDesc],[ActivaNo],[PurchaseDate],[GRPODocNo]";
                                //sQlStr = sQlStr + ",[Placement],[LocationCode],[AreaCode],[Spot]";
                                //sQlStr = sQlStr + ",[Type],[Brand],[Model],[Series],[SerialNo]";
                                //sQlStr = sQlStr + ",[Color],[ScreenSize],[ScreenResolution],[TouchScreen]";
                                //sQlStr = sQlStr + ",[Processor],[VGABrand],[VGAType],[VGASize]";
                                //sQlStr = sQlStr + ",[RAMType],[RAMMHz],[RAMSize],[Storagetype],[StorageSize]";
                                //sQlStr = sQlStr + ",[ChargerType],[UnitVoltage],[UnitAmps],[UnitWatt]";
                                //sQlStr = sQlStr + ",[BatteryType],[BatteryVoltage],[BatteryAmps],[BatteryWatt]";
                                //sQlStr = sQlStr + ",[Motherboard],[ChasingSize],[CameraResolution],[ChannelQuantity]";
                                //sQlStr = sQlStr + ",[Health],[OS],[Imei],[MACAddress],[IP],[MobileNumber],[Remarks],[HostName],[User]";
                                //sQlStr = sQlStr + "FROM [dbo].[Asset_Temp] ";
                                //sQlStr = sQlStr + "where[BulkId] = " + bulkId.ToString() + " Order By RID";
                                //DataTable dt = oGnl.GetDataTable(sQlStr);

                                //GridView1.DataSource = dt;
                                //GridView1.DataBind();

                                //if (GridView1.Rows.Count <= 0)
                                //{
                                //    dt.Rows.Add(dt.NewRow());
                                //    GridView1.DataSource = dt;
                                //    GridView1.DataBind();
                                //    GridView1.Rows[0].Visible = false;
                                //}

                                ////Required for jQuery DataTables to work.
                                //GridView1.UseAccessibleHeader = true;
                                //GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                            }
                            else
                            {
                                Label1.Text = "Attachement file size should not be greater than 1 MB";
                                Label1.ForeColor = Color.Red;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Label1.Text = ex.ToString();
                        Label1.ForeColor = Color.Red;
                    }
                }
                else
                {
                    Label1.Text = "Please Upload The Excel File";
                    Label1.ForeColor = Color.Red;
                }
            }            
        }

        protected int GetBulkId()
        {
            int bulkId = 0;
            try
            {
                DataSet oDs = new DataSet();
                oDs = oGnl.GetDataSet("select isnull(max([BulkId]),0) + 1 [bulkId] from [Asset_Temp]");

                bulkId = Convert.ToInt32(oDs.Tables[0].Rows[0]["bulkId"].ToString());
            }
            catch (Exception ex)
            {
                Label1.Text = "Error:" + ex.ToString();
            }
            return bulkId;
        }
    }
}