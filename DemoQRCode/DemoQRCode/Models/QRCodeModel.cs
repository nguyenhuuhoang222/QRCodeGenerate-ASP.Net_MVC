namespace DemoQRCode.Models;

public class QRCodeModel
{
    public int QRCodeType { get; set; }
    public string QRImageUrl { get; set; } = "";
    
    //email
    public string ReceiveEmailAddress { get; set; } = "";
    public string Subject { get; set; } = "";
    public string Message { get; set; } = "";
    
    //sms
    public string PhoneNumber { get; set; } = "";
    public string MessageSMS { get; set; } = "";
    
    //whatsapp
    public string WhatsAppNumber { get; set; } = "";
    public string WhatsAppMessage { get; set; } = "";
    
    //telegram
    public string TelegramNumber { get; set; } = "";
    public string TelegramMessage { get; set; } = "";
    
    //zalo 
    public string ZaloNumber { get; set; } = "";
    public string ZaloMessage { get; set; } = "";
    
    //wifi
    public string WifiSSID { get; set; } = "";
    public string WifiPassword { get; set; } = "";
}
