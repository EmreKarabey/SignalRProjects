using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using ZXing;

namespace SignalRWebUI.Controllers
{
    [Authorize]
    public class QrCodeController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string value)
        {
            using var memoryStream = new MemoryStream();

            QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();

            QRCodeData qrCodeData = qRCodeGenerator.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);

            QRCode qrCode = new QRCode(qrCodeData);

            using (Bitmap image = qrCode.GetGraphic(10))
            {
                image.Save(memoryStream,ImageFormat.Png);

                ViewBag.QrCodeImage = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());


            }
                return View();
        }

      

   
        [HttpPost]
        public IActionResult QrCodeReader(IFormFile file)
        {
          
            if (file == null || file.Length == 0)
            {
                ViewBag.VSuccess = "Lütfen bir resim dosyası seçin.";
                return View();
            }

            try
            {
               
                var barcodeReader = new ZXing.Windows.Compatibility.BarcodeReader();
                barcodeReader.Options.PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.QR_CODE };

                
                using (var stream = file.OpenReadStream())
                {
                    using (var bitmap = (Bitmap)Image.FromStream(stream))
                    {
                        var result = barcodeReader.Decode(bitmap);

                        if (result != null)
                        {
                           ViewBag.VSuccess = result.Text; 
                        }
                        else
                        {
                           ViewBag.VSuccess = "QR Kod okunamadı. Resim net olmayabilir.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.VSuccess = "Hata oluştu: " + ex.Message;
            }

            return View("Index");
        }
    }
}
