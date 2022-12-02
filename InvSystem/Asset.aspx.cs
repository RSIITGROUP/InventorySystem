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
            DataTable dt = oGnl.GetDataTable("SELECT[AssetCode], [AssetDesc], [ActivaNo], REPLACE(CONVERT(NVARCHAR,[PurchaseDate], 106), ' ', '-')[PurchaseDate],  [GRPODocNo] FROM[Asset]");
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
    }
}