using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using HotelProject.Api.Services;
using Microsoft.AspNetCore.Mvc;
using HotelProject.Api.Models;
using System.Net;

namespace HotelProject.Api.Controllers
{
    public class SendMessageController : BaseController<SendMessage, ISendMessageService>
    {
        private readonly IEmailService _emailService;

        public SendMessageController(ISendMessageService sendMessageService, IEmailService emailService)
            : base(sendMessageService)
        {
            _emailService = emailService;
        }

        [HttpPost("AddMessageWithEmail")]
        public async Task<IActionResult> AddWithEmail([FromBody] SendMessage sendMessage)
        {
            try
            {
                if (sendMessage == null)
                {
                    return BadRequest(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Message data is required.",
                        StatusCode = HttpStatusCode.BadRequest
                    });
                }

                sendMessage.Date = DateTime.Now;

                _service.TInsert(sendMessage);

                // Send email notification to receiver
                var receiverEmailSent = await _emailService.SendMessageNotificationAsync(
                    sendMessage.ReceiverMail,
                    sendMessage.ReceiverName,
                    sendMessage.SenderName,
                    sendMessage.Title,
                    sendMessage.Content
                );

                // Send confirmation email to sender
                var senderEmailSent = await _emailService.SendMessageConfirmationAsync(
                    sendMessage.SenderMail,
                    sendMessage.SenderName,
                    sendMessage.ReceiverName,
                    sendMessage.Title
                );

                var emailStatus = receiverEmailSent && senderEmailSent
                    ? "Emails sent successfully to both parties."
                    : "Message saved but there was an issue sending some emails.";

                return Ok(new ApiResponse<SendMessage>
                {
                    Success = true,
                    Message = $"Message sent successfully! {emailStatus}",
                    Data = sendMessage,
                    StatusCode = HttpStatusCode.OK
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<object>
                {
                    Success = false,
                    Message = $"An error occurred while sending the message: {ex.Message}",
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
        }
    }
}

