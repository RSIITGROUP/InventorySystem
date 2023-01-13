using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;

namespace InvSystem
{
    public partial class TestBarcode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string barCode = Request.QueryString["code"];
                for (int i = 1; i <= 5; i++)
                {
                    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                    using (Bitmap bitMap = new Bitmap(barCode.Length * 22, 80))
                    {
                        using (Graphics graphics = Graphics.FromImage(bitMap))
                        {
                            Font oFont = new Font("IDAutomationHC39M Free Version", 16);
                            PointF point = new PointF(2f, 2f);
                            SolidBrush blackBrush = new SolidBrush(Color.Black);
                            SolidBrush whiteBrush = new SolidBrush(Color.White);
                            graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
                            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
                            graphics.DrawString(barCode, oFont, blackBrush, point);
                            graphics.Flush();
                        }
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteImage = ms.ToArray();
                            File.WriteAllBytes(Server.MapPath("~/barcodes/" + barCode + ".png"), byteImage);

                            Convert.ToBase64String(byteImage);
                            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                        }
                        PlaceHolder1.Controls.Add(imgBarCode);
                    }
                }
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:CallPrint('bill'); ", true);
            }
        }
    }
}