namespace HotelProject.Api.Services
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(string toEmail, string toName, string subject, string body, bool isHtml = true);
        Task<bool> SendContactConfirmationAsync(string customerEmail, string customerName, string subject);
        Task<bool> SendContactNotificationAsync(string customerName, string customerEmail, string subject, string message);
        Task<bool> SendMessageNotificationAsync(string receiverEmail, string receiverName, string senderName, string subject, string message);
        Task<bool> SendMessageConfirmationAsync(string senderEmail, string senderName, string receiverName, string subject);
    }
}