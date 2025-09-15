using HotelProject.Api.Models;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace HotelProject.Api.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IOptions<EmailSettings> emailSettings, ILogger<EmailService> logger)
        {
            _emailSettings = emailSettings.Value;
            _logger = logger;
        }

        public async Task<bool> SendEmailAsync(string toEmail, string toName, string subject, string body, bool isHtml = true)
        {
            try
            {
                var smtpClient = new SmtpClient(_emailSettings.SmtpHost)
                {
                    Port = _emailSettings.SmtpPort,
                    Credentials = new NetworkCredential(_emailSettings.SmtpUsername, _emailSettings.SmtpPassword),
                    EnableSsl = _emailSettings.EnableSsl,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_emailSettings.FromEmail, _emailSettings.FromName),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = isHtml,
                };

                mailMessage.To.Add(new MailAddress(toEmail, toName));

                await smtpClient.SendMailAsync(mailMessage);
                _logger.LogInformation($"Email sent successfully to {toEmail}");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to send email to {toEmail}");
                return false;
            }
        }

        public async Task<bool> SendContactConfirmationAsync(string customerEmail, string customerName, string subject)
        {
            var emailSubject = "Thank you for contacting us!";
            var emailBody = GetContactConfirmationTemplate(customerName, subject);

            return await SendEmailAsync(customerEmail, customerName, emailSubject, emailBody, true);
        }

        public async Task<bool> SendContactNotificationAsync(string customerName, string customerEmail, string subject, string message)
        {
            var emailSubject = $"New Contact Form Submission: {subject}";
            var emailBody = GetContactNotificationTemplate(customerName, customerEmail, subject, message);

            return await SendEmailAsync(_emailSettings.FromEmail, "Hotel Admin", emailSubject, emailBody, true);
        }

        public async Task<bool> SendMessageNotificationAsync(string receiverEmail, string receiverName, string senderName, string subject, string message)
        {
            var emailSubject = $"New Message from {senderName}: {subject}";
            var emailBody = GetMessageNotificationTemplate(receiverName, senderName, subject, message);

            return await SendEmailAsync(receiverEmail, receiverName, emailSubject, emailBody, true);
        }

        public async Task<bool> SendMessageConfirmationAsync(string senderEmail, string senderName, string receiverName, string subject)
        {
            var emailSubject = "Message sent successfully!";
            var emailBody = GetMessageConfirmationTemplate(senderName, receiverName, subject);

            return await SendEmailAsync(senderEmail, senderName, emailSubject, emailBody, true);
        }

        private string GetContactConfirmationTemplate(string customerName, string subject)
        {
            var template = $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <title>Thank You</title>
    <style>
        body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; }}
        .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
        .header {{ background-color: #007bff; color: white; padding: 20px; text-align: center; }}
        .content {{ padding: 20px; background-color: #f8f9fa; }}
        .footer {{ padding: 20px; text-align: center; color: #666; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>Thank You for Contacting Us!</h1>
        </div>
        <div class='content'>
            <p>Dear {customerName},</p>
            <p>Thank you for reaching out to us regarding: <strong>{subject}</strong></p>
            <p>We have received your message and will get back to you within 24 hours.</p>
            <p>Our team is committed to providing you with the best service possible.</p>
            <p>Best regards,<br>Hotel Management Team</p>
        </div>
        <div class='footer'>
            <p>This is an automated message. Please do not reply to this email.</p>
        </div>
    </div>
</body>
</html>";
            return template;
        }

        private string GetContactNotificationTemplate(string customerName, string customerEmail, string subject, string message)
        {
            var template = $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <title>New Contact Form Submission</title>
    <style>
        body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; }}
        .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
        .header {{ background-color: #28a745; color: white; padding: 20px; text-align: center; }}
        .content {{ padding: 20px; background-color: #f8f9fa; }}
        .info-box {{ background-color: white; padding: 15px; margin: 10px 0; border-left: 4px solid #007bff; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>New Contact Form Submission</h1>
        </div>
        <div class='content'>
            <div class='info-box'>
                <strong>Customer Name:</strong> {customerName}
            </div>
            <div class='info-box'>
                <strong>Customer Email:</strong> {customerEmail}
            </div>
            <div class='info-box'>
                <strong>Subject:</strong> {subject}
            </div>
            <div class='info-box'>
                <strong>Message:</strong><br>{message}
            </div>
            <p><strong>Date:</strong> {DateTime.Now:yyyy-MM-dd HH:mm}</p>
        </div>
    </div>
</body>
</html>";
            return template;
        }

        private string GetMessageNotificationTemplate(string receiverName, string senderName, string subject, string message)
        {
            var template = $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <title>New Message</title>
    <style>
        body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; }}
        .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
        .header {{ background-color: #6f42c1; color: white; padding: 20px; text-align: center; }}
        .content {{ padding: 20px; background-color: #f8f9fa; }}
        .message-box {{ background-color: white; padding: 20px; margin: 15px 0; border-radius: 5px; box-shadow: 0 2px 5px rgba(0,0,0,0.1); }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>You Have a New Message</h1>
        </div>
        <div class='content'>
            <p>Dear {receiverName},</p>
            <p>You have received a new message from <strong>{senderName}</strong>:</p>
            <div class='message-box'>
                <h3>{subject}</h3>
                <p>{message}</p>
            </div>
            <p>Please log in to your account to respond to this message.</p>
            <p>Best regards,<br>Hotel Management System</p>
        </div>
    </div>
</body>
</html>";
            return template;
        }

        private string GetMessageConfirmationTemplate(string senderName, string receiverName, string subject)
        {
            var template = $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <title>Message Sent Successfully</title>
    <style>
        body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; }}
        .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
        .header {{ background-color: #28a745; color: white; padding: 20px; text-align: center; }}
        .content {{ padding: 20px; background-color: #f8f9fa; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>Message Sent Successfully!</h1>
        </div>
        <div class='content'>
            <p>Dear {senderName},</p>
            <p>Your message has been successfully sent to <strong>{receiverName}</strong>.</p>
            <p><strong>Subject:</strong> {subject}</p>
            <p>The recipient will be notified via email and can respond to your message.</p>
            <p>Best regards,<br>Hotel Management System</p>
        </div>
    </div>
</body>
</html>";
            return template;
        }
    }
}