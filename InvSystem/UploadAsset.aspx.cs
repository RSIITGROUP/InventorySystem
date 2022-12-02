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
                            if (fileSize <= 1048576)
                            {
                                fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                                ExcelPackage package = new ExcelPackage(FileUpload1.FileContent);
                                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                                ExcelWorksheet workSheet = package.Workbook.Worksheets.First();

                                int totCol = workSheet.Dimension.End.Column;
                                //foreach (var firstRowCell in workSheet.Cells[1, 1, 1, workSheet.Dimension.End.Column])
                                //{
                                //    table.Columns.Add(firstRowCell.Text);
                                //}

                                int bulkId = GetBulkId();
                                int nColumn = 0;
                                string sparamVal = "";
                                int errNo = 0;
                                string errMsg = "";
                                DataSet oDs = new DataSet();
                                for (var rowNumber = 2; rowNumber <= workSheet.Dimension.End.Row; rowNumber++)
                                {
                                    var row = workSheet.Cells[rowNumber, 1, rowNumber, workSheet.Dimension.End.Column];
                                    //var newRow = table.NewRow();

                                    nColumn = 1;
                                    sparamVal = "";
                                    errNo = 0;
                                    errMsg = "";

                                    for (var col = 1; col <= totCol; col++)
                                    {
                                        sparamVal = sparamVal + "@" + workSheet.Cells[1, nColumn].Text + ":" + row[rowNumber, col].Text + ",";
                                        nColumn += 1;
                                    }
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
                                    }
                                }

                                string sQlStr = "SELECT [AssetDesc],[ActivaNo],[PurchaseDate],[GRPODocNo]";
                                sQlStr = sQlStr + ",[Placement],[LocationCode],[AreaCode],[Spot]";
                                sQlStr = sQlStr + ",[Type],[Brand],[Model],[Series],[SerialNo]";
                                sQlStr = sQlStr + ",[Color],[ScreenSize],[ScreenResolution],[TouchScreen]";
                                sQlStr = sQlStr + ",[Processor],[VGABrand],[VGAType],[VGASize]";
                                sQlStr = sQlStr + ",[RAMType],[RAMMHz],[RAMSize],[Storagetype],[StorageSize]";
                                sQlStr = sQlStr + ",[ChargerType],[UnitVoltage],[UnitAmps],[UnitWatt]";
                                sQlStr = sQlStr + ",[BatteryType],[BatteryVoltage],[BatteryAmps],[BatteryWatt]";
                                sQlStr = sQlStr + ",[Motherboard],[ChasingSize],[CameraResolution],[ChannelQuantity]";
                                sQlStr = sQlStr + ",[Health],[OS],[Imei],[MACAddress],[IP],[MobileNumber],[Remarks]";
                                sQlStr = sQlStr + "FROM[ASSETDB].[dbo].[Asset_Temp] ";
                                sQlStr = sQlStr + "where[BulkId] = " + bulkId.ToString() + " Order By RID";
                                DataTable dt = oGnl.GetDataTable(sQlStr);

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