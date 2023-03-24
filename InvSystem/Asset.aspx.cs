using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InvSystem.Class;
using System.Data;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Drawing.Printing;

namespace InvSystem
{
    public partial class Asset : System.Web.UI.Page
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
                if (!this.IsPostBack)
                {
                    this.BindGrid();
                }
            }
        }

        private void BindGrid()
        {
            string strQuery = "SELECT t0.[AssetCode], t0.[AssetDesc], t0.[ActivaNo], t0.[SerialNo], t2.[Name] [User],  [GRPODocNo], T0.[Remarks] [Remark] ";
            strQuery = strQuery + "FROM [Asset] T0 left join PlacementHistory T1 on t0.RID = t1.RID and t0.PlacementVersion = t1.[Version] Left JOIN [EndUser] T2 on T2.[ID] = T1.[User] WHERE isnull(T0.[IsDeleted],'N') in ('N','')";
            DataTable dt = oGnl.GetDataTable(strQuery, 1);
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

        protected void Edit_Command(object sender, CommandEventArgs e)
        {
            if (Session["User"] == null || Session["UserId"] == null)
            {
                Response.Redirect("~/UserLogin.aspx");
            }
            else
            {
                string assetCode = (string)e.CommandArgument;
                if (assetCode != "")
                {
                    Response.Redirect("AddAssets.aspx?assetCode=" + e.CommandArgument + "&Action=edit");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["User"] == null || Session["UserId"] == null)
            {
                Response.Redirect("~/UserLogin.aspx");
            }
            else
            {
                Response.Redirect("~/AddAssets.aspx?Action=new");
            }

        }

        protected DataTable GetDataTable(GridView dtg)
        {
            DataTable dt = new DataTable();

            // add the columns to the datatable            
            if (dtg.HeaderRow != null)
            {

                for (int i = 0; i < dtg.HeaderRow.Cells.Count; i++)
                {
                    dt.Columns.Add(dtg.HeaderRow.Cells[i].Text);
                }
            }

            //  add each of the data rows to the table
            foreach (GridViewRow row in dtg.Rows)
            {
                DataRow dr;
                dr = dt.NewRow();

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dr[i] = row.Cells[i].Text.Replace(" ", "");
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex == 0)
            {
                e.Row.RowType = DataControlRowType.Header;

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Session["User"] == null || Session["UserId"] == null)
            {
                Response.Redirect("~/UserLogin.aspx");
            }
            else
            {
                Response.Redirect("~/UploadAsset.aspx");
            }
        }

        protected void Print_Command(object sender, CommandEventArgs e)
        {
            if (Session["User"] == null || Session["UserId"] == null)
            {
                Response.Redirect("~/UserLogin.aspx");
            }
            else
            {
                string assetCode = (string)e.CommandArgument;
                if (assetCode != "")
                {
                   // string barCode = txtBarcode.Text;
                   // string data = txtBarcode.Text;
                    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                    using (Bitmap bitMap = new Bitmap(assetCode.Length * 22, 80))
                    {
                        using (Graphics graphics = Graphics.FromImage(bitMap))
                        {
                            Font oFont = new Font("IDAutomationHC39M Free Version", 16);
                            PointF point = new PointF(2f, 2f);
                            SolidBrush blackBrush = new SolidBrush(Color.Black);
                            SolidBrush whiteBrush = new SolidBrush(Color.White);
                            graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
                            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
                            graphics.DrawString(assetCode, oFont, blackBrush, point);
                            graphics.Flush();
                        }
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteImage = ms.ToArray();
                            File.WriteAllBytes(Server.MapPath("~/barcodes/" + assetCode + ".png"), byteImage);

                            Convert.ToBase64String(byteImage);
                            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                        }
                        //PlaceHolder1.Controls.Add(imgBarCode);

                        Process printjob = new Process();
                        printjob.StartInfo.FileName = Server.MapPath("~/barcodes/" + assetCode + ".png");
                        printjob.StartInfo.Verb = "Print";//Print
                        printjob.StartInfo.CreateNoWindow = true;
                        printjob.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        GetDefaultPrinter();
                        printjob.Start();
                        Response.Redirect("~/Asset.aspx");
                    }
                }
            }
        }

        private string GetDefaultPrinter()
        {
            PrinterSettings settings = new PrinterSettings();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                settings.PrinterName = printer;
                if (settings.IsDefaultPrinter)
                {
                    return printer;
                }
            }
            return string.Empty;
        }

        protected void Remove_Command(object sender, CommandEventArgs e)
        {
            if (Session["User"] == null || Session["UserId"] == null)
            {
                Response.Redirect("~/UserLogin.aspx");
            }
            else
            {
                string assetCode = (string)e.CommandArgument;
                if (assetCode != "")
                {
                    try
                    {
                        string sparamVal = "@AssetCode:" + assetCode + ",";
                        sparamVal = sparamVal + "@UserId:" + Session["UserId"];
                        oGnl.ExecuteDataQuery("Update [Asset] set [IsDeleted]='Y',[UserUpdate] = @UserId, [UpdateDate]=getdate() where [AssetCode] = @AssetCode", sparamVal, Convert.ToChar(","), 1);
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert(' Asset [" + assetCode + "] has been successfully deleted')", true);
                        GridView1.DataSource = null;
                        this.BindGrid();
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error : " + ex.ToString() + "')", true);
                    }                    
                }
            }
        }
    }
}