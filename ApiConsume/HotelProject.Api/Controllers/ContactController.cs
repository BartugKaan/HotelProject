using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        public readonly IContactService _service;

        public ContactController(IContactService contactService)
        {
            _service = contactService;
        }

        [HttpGet]
        public IActionResult GetContact()
        {
            var values = _service.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            contact.ContactDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            _service.TInsert(contact);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var service = _service.TGetById(id);
            if (service == null)
            {
                return NotFound();
            }
            _service.TDelete(service);
            return Ok();
        }

        [HttpPut("UpdateBooking")]
        public IActionResult UpdateContact(Contact contact)
        {
            _service.TUpdate(contact);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Getcontact(int id)
        {
            var contact = _service.TGetById(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }
    }
}
