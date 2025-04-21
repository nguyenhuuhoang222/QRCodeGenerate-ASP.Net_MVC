using DemoQRCode.Models;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using static QRCoder.PayloadGenerator;

namespace DemoQRCode.Controllers
{
    public class QRCodeController : Controller
    {
        public ActionResult Index()
        {
            QRCodeModel model = new QRCodeModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(QRCodeModel model)
        {
            Payload? payload = null;

            switch (model.QRCodeType)
            {
                case 1: // SMS
                    payload = new SMS(model.PhoneNumber, model.MessageSMS);
                    break;

                case 2: // WhatsApp
                    payload = new WhatsAppMessage(model.WhatsAppNumber, model.WhatsAppMessage);
                    break;

                case 3: // Email
                    payload = new Mail(model.ReceiveEmailAddress, model.Subject, model.Message);
                    break;

                case 6: // WiFi
                    payload = new WiFi(model.WifiSSID, model.WifiPassword, WiFi.Authentication.WPA);
                    break;

                default:
                    ModelState.AddModelError(string.Empty, "Unsupported QR Code type.");
                    return View(model);
            }

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload.ToString(), QRCodeGenerator.ECCLevel.Q);
            BitmapByteQRCode qrCode = new BitmapByteQRCode(qrCodeData);
            string base64Image = Convert.ToBase64String(qrCode.GetGraphic(20));

            model.QRImageUrl = "data:image/png;base64," + base64Image;

            return View("Index", model);
        }
    }
}