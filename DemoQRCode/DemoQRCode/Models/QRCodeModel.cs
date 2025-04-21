namespace DemoQRCode.Models;

public class QRCodeModel
{
    public int QRCodeType { get; set; } // Loại mã QR (QR Code type)
    public string QRImageUrl { get; set; } = ""; // URL hình ảnh mã QR (QR code image URL)
    
    // Email
    public string ReceiveEmailAddress { get; set; } = ""; // Địa chỉ email nhận (Recipient email address)
    public string EmailSubject { get; set; } = ""; // Chủ đề email (Email subject)
    public string EmailMessage { get; set; } = ""; // Nội dung email (Email content)
    
    // SMS
    public string PhoneNumber { get; set; } = ""; // Số điện thoại (Phone number)
    public string MessageSMS { get; set; } = ""; // Tin nhắn SMS (SMS message)
    
    // WhatsApp
    public string WhatsAppNumber { get; set; } = ""; // Số WhatsApp (WhatsApp number)
    public string WhatsAppMessage { get; set; } = ""; // Tin nhắn WhatsApp (WhatsApp message)

    // WiFi
    public string WifiSSID { get; set; } = ""; // Tên WiFi (WiFi SSID)
    public string WifiPassword { get; set; } = ""; // Mật khẩu WiFi (WiFi password)
    
    // URL
    public string Url { get; set; } = ""; // Đường dẫn URL (URL link)
    
    // Location
    public string Latitude { get; set; } = ""; // Vĩ độ (Latitude)
    public string Longitude { get; set; } = ""; // Kinh độ (Longitude)
    
    // Text
    public string Message { get; set; } = ""; // Nội dung văn bản (Text content)
    
    // Contact Info
    public string ContactFirstName { get; set; }
    public string ContactLastName { get; set; }
    public string ContactPhone { get; set; }
    public string ContactEmail { get; set; }
    public string? ContactCompany { get; set; }
    public string? ContactAddress { get; set; }

}