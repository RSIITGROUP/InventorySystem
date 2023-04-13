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
        bool isReload = false;
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
                if (!IsPostBack)
                {
                    oGnl.SeDropDown("SELECT [Code], [Name] FROM [Reference] WHERE [refCode]='04' and [Status] = 'A' ORDER BY [Name]", ddType, 1);
                    CopyTemplate("S001");
                }
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
                                //int colNum = 0;
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
                                        else if (colHeader == "CameraType") { oAsset.CameraType = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "OperatingSystem") { oAsset.OperatingSystem = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "Imei") { oAsset.Imei = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "MACAddress") { oAsset.MacAddress = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "IP") { oAsset.IP = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "MobileNumber") { oAsset.MobileNumber = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "Remarks") { oAsset.Remarks = workSheet.Cells[rowNumber, colNumber].Text; }

                                        else if (colHeader == "TypeQuality") { oAsset.TypeQuality = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "TypePort") { oAsset.TypePort = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "TypeSystem") { oAsset.TypeSystem = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "PortQuantity") { oAsset.PortQuantity = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "SFPPortQuantity") { oAsset.SfpPortQuantity = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "FrequencyBand") { oAsset.FrequencyBand = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "TypeConnectivity") { oAsset.TypeConnectivity = workSheet.Cells[rowNumber, colNumber].Text; }
                                        else if (colHeader == "TypeFunctionality") { oAsset.TypeFunctionality = workSheet.Cells[rowNumber, colNumber].Text; }
                                        //colNum = colNum + 1;
                                    }
                                    if (errNo == 0)
                                    {
                                        sparamVal = sparamVal + "@AssetDesc~" + oAsset.AssetDesc + "|";
                                        sparamVal = sparamVal + "@ActivaNo~" + oAsset.ActivaNo + "|";
                                        sparamVal = sparamVal + "@PurchaseDate~" + oAsset.PurchaseDate + "|";
                                        sparamVal = sparamVal + "@GRPODocNo~" + oAsset.GRPODocNo + "|";
                                        sparamVal = sparamVal + "@Placement~" + oAsset.Placement + "|";
                                        sparamVal = sparamVal + "@LocationCode~" + oAsset.LocationCode + "|";
                                        sparamVal = sparamVal + "@AreaCode~" + oAsset.AreaCode + "|";
                                        sparamVal = sparamVal + "@Spot~" + oAsset.Spot + "|";
                                        sparamVal = sparamVal + "@Type~" + oAsset.Type + "|";
                                        sparamVal = sparamVal + "@Brand~" + oAsset.Brand + "|";
                                        sparamVal = sparamVal + "@Model~" + oAsset.Model + "|";
                                        sparamVal = sparamVal + "@Series~" + oAsset.Series + "|";
                                        sparamVal = sparamVal + "@SerialNo~" + oAsset.SerialNo + "|";
                                        sparamVal = sparamVal + "@Color~" + oAsset.Color + "|";
                                        sparamVal = sparamVal + "@ScreenSize~" + oAsset.ScreenSize + "|";
                                        sparamVal = sparamVal + "@ScreenResolution~" + oAsset.ScreenreSolution + "|";
                                        sparamVal = sparamVal + "@TouchScreen~" + oAsset.TouchScreen + "|";
                                        sparamVal = sparamVal + "@Processor~" + oAsset.Processor + "|";
                                        sparamVal = sparamVal + "@VGABrand~" + oAsset.VgaBrand + "|";
                                        sparamVal = sparamVal + "@VGAType~" + oAsset.VgaType + "|";
                                        sparamVal = sparamVal + "@VGASize~" + oAsset.VgaSize + "|";
                                        sparamVal = sparamVal + "@RAMType~" + oAsset.RamType + "|";
                                        sparamVal = sparamVal + "@RAMMHz~" + oAsset.RamMhz + "|";
                                        sparamVal = sparamVal + "@RAMSize~" + oAsset.RamSize + "|";
                                        sparamVal = sparamVal + "@Storagetype~" + oAsset.StorageType + "|";
                                        sparamVal = sparamVal + "@StorageSize~" + oAsset.StorageSize + "|";
                                        sparamVal = sparamVal + "@ChargerType~" + oAsset.ChargerType + "|";
                                        sparamVal = sparamVal + "@UnitVoltage~" + oAsset.UnitVoltage + "|";
                                        sparamVal = sparamVal + "@UnitAmps~" + oAsset.UnitAmps + "|";
                                        sparamVal = sparamVal + "@UnitWatt~" + oAsset.UnitWatt + "|";
                                        sparamVal = sparamVal + "@BatteryType~" + oAsset.BatteryType + "|";
                                        sparamVal = sparamVal + "@BatteryVoltage~" + oAsset.BatteryVoltage + "|";
                                        sparamVal = sparamVal + "@BatteryAmps~" + oAsset.BatteryAmps + "|";
                                        sparamVal = sparamVal + "@BatteryWatt~" + oAsset.BatteryWatt + "|";
                                        sparamVal = sparamVal + "@Motherboard~" + oAsset.MotherBoard + "|";
                                        sparamVal = sparamVal + "@ChasingSize~" + oAsset.ChasingSize + "|";
                                        sparamVal = sparamVal + "@CameraResolution~" + oAsset.CameraResolution + "|";
                                        sparamVal = sparamVal + "@CameraType~" + oAsset.CameraType + "|";
                                        sparamVal = sparamVal + "@Health~" + oAsset.Health + "|";
                                        sparamVal = sparamVal + "@OperatingSystem~" + oAsset.OperatingSystem + "|";
                                        sparamVal = sparamVal + "@Imei~" + oAsset.Imei + "|";
                                        sparamVal = sparamVal + "@MACAddress~" + oAsset.MacAddress + "|";
                                        sparamVal = sparamVal + "@IP~" + oAsset.IP + "|";
                                        sparamVal = sparamVal + "@MobileNumber~" + oAsset.MobileNumber + "|";
                                        sparamVal = sparamVal + "@Remarks~" + oAsset.Remarks + "|";
                                        sparamVal = sparamVal + "@HostName~" + oAsset.HostName + "|";
                                        sparamVal = sparamVal + "@User~" + oAsset.User + "|";

                                        sparamVal = sparamVal + "@TypeQuality~" + oAsset.TypeQuality + "|";
                                        sparamVal = sparamVal + "@TypePort~" + oAsset.TypePort + "|";
                                        sparamVal = sparamVal + "@TypeSystem~" + oAsset.TypeSystem + "|";
                                        sparamVal = sparamVal + "@PortQuantity~" + oAsset.PortQuantity + "|";
                                        sparamVal = sparamVal + "@SFPPortQuantity~" + oAsset.SfpPortQuantity + "|";
                                        sparamVal = sparamVal + "@FrequencyBand~" + oAsset.FrequencyBand + "|";
                                        sparamVal = sparamVal + "@TypeConnectivity~" + oAsset.TypeConnectivity + "|";
                                        sparamVal = sparamVal + "@TypeFunctionality~" + oAsset.TypeFunctionality + "|";
                                        //sparamVal = sparamVal + "@UserId:" + Session["UserId"] + ",";
                                        sparamVal = sparamVal + "@BulkId~" + bulkId.ToString() + ",@UserId~" + Session["UserId"];
                                        oDs = oGnl.ExecuteSP("SP_POST_ASSETTEMP", sparamVal, '|', 1);                                       

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
                                    sparamVal = "@BulkId~" + bulkId.ToString();
                                    oDs = oGnl.ExecuteSP("SP_VALIDATE_ASSET", sparamVal, '|', 1);

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
                                    sparamVal = "@BulkId~" + bulkId.ToString();
                                    oDs = oGnl.ExecuteSP("SP_POST_ASSETBULK", sparamVal, '|', 1);

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
                                sQlStr = sQlStr + ",[Motherboard],[ChasingSize],[CameraResolution],[CameraType]";
                                sQlStr = sQlStr + ",[Health],[OperatingSystem],[Imei],[MACAddress],[IP],[MobileNumber],[Remarks]";
                                sQlStr = sQlStr + ",[TypeQuality],[TypePort],[TypeSystem],[PortQuantity],[SFPPortQuantity]";
                                sQlStr = sQlStr + ",[FrequencyBand],[TypeConnectivity],[TypeFunctionality],[HostName],[User]";
                                sQlStr = sQlStr + "FROM [dbo].[Asset_Temp] ";
                                sQlStr = sQlStr + "where[BulkId] = " + bulkId.ToString() + " Order By RID";
                                dt = oGnl.GetDataTable(sQlStr, 1);

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
                oDs = oGnl.GetDataSet("select isnull(max([BulkId]),0) + 1 [bulkId] from [Asset_Temp]", 1);

                bulkId = Convert.ToInt32(oDs.Tables[0].Rows[0]["bulkId"].ToString());
            }
            catch (Exception ex)
            {
                Label1.Text = "Error:" + ex.ToString();
            }
            return bulkId;
        }

        protected void ddType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CopyTemplate(ddType.SelectedItem.Value);
        }

        protected void CopyTemplate(string sType)
        {
            FileInfo existingFile = new FileInfo(Server.MapPath("~/template/TemplateUploadOri.xlsx"));
            DeleteColExl(existingFile, sType);
            //FileInfo currentFile = new FileInfo(Server.MapPath("~/template/TemplateUpload.xlsx"));
            //while (isReload == true)
            //{               
            //    DeleteColExl(currentFile, sType);
            //}

            //using (ExcelPackage package = new ExcelPackage(existingFile))
            //{
            //    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //    //get the first worksheet in the workbook
            //    ExcelWorksheet worksheet = package.Workbook.Worksheets.First();
            //    int colCount = worksheet.Dimension.End.Column;  //get Column Count
            //    DataSet oDs = new DataSet();
            //    int tField = 0;
            //    int sfirs = 0;
            //    if (sType != "S001")
            //    {
            //        oDs = oGnl.GetDataSet("select InfName as [Name] from AssetDetailField where InfID not in (select InfID from [AssetConfiguration] where [Type]='" + sType + "') order by InfID");
            //        //for (int col = 1; col <= colCount; col++)
            //        //{
            //        //    if (oDs.Tables[0].Rows.Count > 0)
            //        //    {
            //        //        foreach (DataRow row in oDs.Tables[0].Rows)
            //        //        {
            //        //            if (worksheet.Cells[1, col].Text == row[0].ToString())
            //        //            {
            //        //                worksheet.DeleteColumn(col);
            //        //                tField = tField + 1;
            //        //            }
            //        //            if (oDs.Tables[0].Rows.Count == tField)
            //        //            {
            //        //                break;
            //        //            }
            //        //        }
            //        //    }
            //        //}
            //        for (int col = 1; col <= colCount; col++)
            //        {
            //            if (oDs.Tables[0].Rows.Count > 0)
            //            {
            //                foreach (DataRow row in oDs.Tables[0].Rows)
            //                {
            //                    if (worksheet.Cells[1, col].Text == row[0].ToString())
            //                    {
            //                        //worksheet.DeleteColumn(col);
            //                        if (sfirs == 0)
            //                        {
            //                            sfirs = col;
            //                        }
            //                        tField = tField + 1;
            //                    }
            //                    //if (oDs.Tables[0].Rows.Count == tField)
            //                    //{
            //                    //    break;
            //                    //}
            //                }
            //            }
            //        }
            //        if (sfirs != 0)
            //        {
            //            worksheet.DeleteColumn(sfirs, tField);
            //        }
            //    }                
            //    package.SaveAs(Server.MapPath("~/template/TemplateUpload.xlsx"));
            //}
        }

        protected void DeleteColExl(FileInfo existingFile, string sType)
        {
            isReload = false;
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                //get the first worksheet in the workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.First();
                int colCount = worksheet.Dimension.End.Column;  //get Column Count
                DataSet oDs = new DataSet();
                int tField = 0;
                int sfirs = 0;
                int iCurPos = 0;
                int tColumn = 0;
                if (sType != "S001")
                {
                    oDs = oGnl.GetDataSet("select InfName as [Name] from AssetDetailField where InfID not in (select InfID from [AssetConfiguration] where [Type]='" + sType + "') order by InfID", 1);
                    tColumn = oDs.Tables[0].Rows.Count;
                    for (int col = 1; col <= colCount; col++)
                    {
                        if (oDs.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow row in oDs.Tables[0].Rows)
                            {
                                if (worksheet.Cells[1, col].Text == row[0].ToString())
                                {
                                    //worksheet.DeleteColumn(col);

                                    if (sfirs == 0)
                                    {
                                        sfirs = col;
                                    }

                                    if (iCurPos != 0)
                                    {
                                        if (iCurPos + 1 != col)
                                        {
                                            isReload = true;
                                            break;
                                        }

                                    }
                                    iCurPos = col;                                    
                                    tField = tField + 1;
                                }
                            }
                        }
                    }
                    if (sfirs != 0)
                    {
                        ExcelComment cmd = worksheet.Cells[1, sfirs, 1, sfirs + tField].Comment;
                        worksheet.Comments.Remove(cmd);
                        //cmd = worksheet.Cells[1, (55 - tField) + 1, 1, 55].Comment;
                        //worksheet.Comments.Remove(cmd);
                        worksheet.DeleteColumn(sfirs, tField);
                    }
                }

                package.SaveAs(Server.MapPath("~/template/TemplateUpload.xlsx"));

                if (isReload == true)
                {
                    FileInfo currentFile = new FileInfo(Server.MapPath("~/template/TemplateUpload.xlsx"));
                    DeleteColExl(currentFile, sType);
                }
            }            
        }
    }
}