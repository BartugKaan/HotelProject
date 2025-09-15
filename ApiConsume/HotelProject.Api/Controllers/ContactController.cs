using HotelProject.Api.Services;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Api.Controllers
{
    public class ContactController : BaseController<Contact, IContactService>
    {
        private readonly IEmailService _emailService;

        public ContactController(IContactService contactService, IEmailService emailService) : base(contactService)
        {
            _emailService = emailService;
        }

        [HttpPost("AddContactWithDate")]
        public async Task<IActionResult> AddContactWithDate(Contact contact)
        {
            try
            {
                contact.ContactDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());

                // Save contact to database
                _service.TInsert(contact);

                // Send confirmation email to customer
                var confirmationSent = await _emailService.SendContactConfirmationAsync(
                    contact.Email,
                    contact.Name,
                    contact.Subject
                );

                // Send notification email to hotel admin
                var notificationSent = await _emailService.SendContactNotificationAsync(
                    contact.Name,
                    contact.Email,
                    contact.Subject,
                    contact.Message
                );

                var response = new
                {
                    Success = true,
                    Message = "Contact message sent successfully",
                    EmailConfirmationSent = confirmationSent,
                    EmailNotificationSent = notificationSent
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = $"An error occurred: {ex.Message}" });
            }
        }

        // Override base Add method to include email functionality
        [HttpPost("AddContactWithEmail")]
        public async Task<IActionResult> AddContactWithEmail([FromBody] Contact contact)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid contact data");
                }

                contact.ContactDate = DateTime.Now;

                // Save contact to database
                _service.TInsert(contact);

                // Send emails asynchronously
                var confirmationTask = _emailService.SendContactConfirmationAsync(
                    contact.Email,
                    contact.Name,
                    contact.Subject
                );

                var notificationTask = _emailService.SendContactNotificationAsync(
                    contact.Name,
                    contact.Email,
                    contact.Subject,
                    contact.Message
                );

                await Task.WhenAll(confirmationTask, notificationTask);

                var response = new
                {
                    Success = true,
                    Message = "Contact message sent successfully and emails were dispatched",
                    ContactId = contact.ContactId
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = $"An error occurred: {ex.Message}" });
            }
        }
    }
}
