using System.ComponentModel.DataAnnotations;

namespace DemoQRCode.Models;

public class QRCodeModel
{
    public int QRCodeType { get; set; } // QR Code type

    public string QRImageUrl { get; set; } = ""; // QR code image URL

    // Email
    [Required(ErrorMessage = "Recipient email address is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address format.")]
    public string ReceiveEmailAddress { get; set; } = ""; // Recipient email address

    [Required(ErrorMessage = "Email subject is required.")]
    public string EmailSubject { get; set; } = ""; // Email subject

    [Required(ErrorMessage = "Email content is required.")]
    public string EmailMessage { get; set; } = ""; // Email content

    // SMS
    [Required(ErrorMessage = "Phone number is required.")]
    [Phone(ErrorMessage = "Invalid phone number format.")]
    public string PhoneNumber { get; set; } = ""; // Phone number

    [Required(ErrorMessage = "SMS message is required.")]
    public string MessageSMS { get; set; } = ""; // SMS message

    // WhatsApp
    [Phone(ErrorMessage = "Invalid WhatsApp number format.")]
    public string WhatsAppNumber { get; set; } = ""; // WhatsApp number

    public string WhatsAppMessage { get; set; } = ""; // WhatsApp message

    // WiFi
    public string WifiSSID { get; set; } = ""; // WiFi SSID
    public string WifiPassword { get; set; } = ""; // WiFi password

    // URL
    [Required(ErrorMessage = "URL is required.")]
    [Url(ErrorMessage = "Invalid URL format.")]
    public string Url { get; set; } = ""; // URL link

    // Location
    public string Latitude { get; set; } = ""; // Latitude
    public string Longitude { get; set; } = ""; // Longitude

    // Text
    public string Message { get; set; } = ""; // Text content

    // Contact Info
    public string ContactFirstName { get; set; }
    public string ContactLastName { get; set; }

    [Phone(ErrorMessage = "Invalid contact phone number format.")]
    public string ContactPhone { get; set; }

    [EmailAddress(ErrorMessage = "Invalid contact email address format.")]
    public string ContactEmail { get; set; }

    public string? ContactCompany { get; set; }
    public string? ContactAddress { get; set; }
}