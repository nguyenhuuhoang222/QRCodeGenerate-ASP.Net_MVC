using System.Drawing;
using System.Globalization;
using DemoQRCode.Models;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using static QRCoder.PayloadGenerator;

namespace DemoQRCode.Controllers
{
    public class QRCodeController : Controller
    {
        // GET: Hiển thị trang tạo mã QR ban đầu
        // Display the initial QR code generation page
        public ActionResult Index()
        {
            QRCodeModel model = new QRCodeModel();
            return View(model);
        }

        // POST: Xử lý dữ liệu từ form và tạo mã QR
        // Handle form data and generate QR code
        [HttpPost]
        public IActionResult Index(QRCodeModel model)
        {
                
             
            

            Payload? payload = null;

                // Xử lý loại mã QR dựa trên QRCodeType
                // Handle QR code type based on QRCodeType
                switch (model.QRCodeType)
                {
                    case 1: // SMS
                        // Tạo payload cho tin nhắn SMS
                        // Create payload for SMS message
                        payload = new SMS(model.PhoneNumber, model.MessageSMS);
                        break;

                    case 2: // WhatsApp
                        // Tạo payload cho tin nhắn WhatsApp
                        // Create payload for WhatsApp message
                        payload = new WhatsAppMessage(model.WhatsAppNumber, model.WhatsAppMessage);
                        break;

                    case 3: // Email
                        // Tạo payload cho email
                        // Create payload for email
                        payload = new Mail(model.ReceiveEmailAddress, model.EmailSubject, model.EmailMessage);
                        break;

                    case 4: // URL
                        // Tạo payload cho URL
                        // Create payload for URL
                        payload = new Url(model.Url);
                        break;

                    case 5: // WiFi
                        // Tạo payload cho thông tin WiFi
                        // Create payload for WiFi information
                        payload = new WiFi(model.WifiSSID, model.WifiPassword, WiFi.Authentication.WPA);
                        // 99% WiFi ở Việt Nam sử dụng chuẩn WPA
                        // 99% of WiFi in Vietnam uses WPA standard
                        break;

                    case 6: // Văn bản
                        // Text
                        // Tạo mã QR cho văn bản
                        // Generate QR code for text
                        QRCodeGenerator qrGeneratorText = new QRCodeGenerator();
                        QRCodeData qrCodeDataText =
                            qrGeneratorText.CreateQrCode(model.Message, QRCodeGenerator.ECCLevel.Q);

                        // Chuyển mã QR thành hình ảnh base64
                        // Convert QR code to base64 image
                        BitmapByteQRCode qrCodeText = new BitmapByteQRCode(qrCodeDataText);
                        string base64ImageText = Convert.ToBase64String(qrCodeText.GetGraphic(20));

                        // Gán URL hình ảnh mã QR vào model
                        // Assign QR code image URL to the model
                        model.QRImageUrl = "data:image/png;base64," + base64ImageText;
                        break;

                    case 7: // Thông tin liên hệ (VCard)
                        // Contact information (VCard)
                        /*
                         * Nếu bạn sử dụng phiên bản 1.4.1 hoặc cao hơn của QRCodeGenerator,
                         * bạn có thể sử dụng lớp VCard trực tiếp.
                         *
                         * If you are using QRCodeGenerator version 1.4.1 or later,
                         * you can use the VCard class directly.
                         */
                        string vcard =
                            "BEGIN:VCARD\r\n" +
                            "VERSION:2.1\r\n" +
                            $"N:{model.ContactLastName};{model.ContactFirstName}\r\n" +
                            $"FN:{model.ContactFirstName} {model.ContactLastName}\r\n" +
                            $"ORG:{model.ContactCompany}\r\n" +
                            $"TEL:{model.ContactPhone}\r\n" +
                            $"EMAIL:{model.ContactEmail}\r\n" +
                            $"ADR:{model.ContactAddress}\r\n" +
                            "END:VCARD";

                        // Tạo mã QR từ thông tin VCard
                        // Generate QR code from VCard information
                        QRCodeGenerator qrGenerator7 = new QRCodeGenerator();
                        QRCodeData qrCodeData7 = qrGenerator7.CreateQrCode(vcard, QRCodeGenerator.ECCLevel.Q);
                        BitmapByteQRCode qrCode7 = new BitmapByteQRCode(qrCodeData7);
                        string base64Image7 = Convert.ToBase64String(qrCode7.GetGraphic(20));
                        model.QRImageUrl = "data:image/png;base64," + base64Image7;
                        break;

                    default:
                        // Thêm lỗi nếu loại mã QR không được hỗ trợ
                        // Add error if QR code type is unsupported
                        ModelState.AddModelError(string.Empty, "Unsupported QR Code type.");
                        return View(model);
                }

                if (payload != null)
                {
                    // Tạo mã QR từ payload
                    // Generate QR code from payload
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload.ToString(), QRCodeGenerator.ECCLevel.Q);

                    // Chuyển mã QR thành hình ảnh base64
                    // Convert QR code to base64 image
                    BitmapByteQRCode qrCode = new BitmapByteQRCode(qrCodeData);
                    string base64Image = Convert.ToBase64String(qrCode.GetGraphic(20));

                    // Gán URL hình ảnh mã QR vào model
                    // Assign QR code image URL to the model
                    model.QRImageUrl = "data:image/png;base64," + base64Image;
                }

                // Trả về view với model đã cập nhật
                // Return the view with the updated model
                return View("Index", model);
            }
         
        
    }
}

