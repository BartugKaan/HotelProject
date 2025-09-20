using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _service;

        public BookingController(IBookingService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetBooking()
        {
            var values = _service.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {
            _service.TInsert(booking);
            return Ok("AddService works : " + booking.BookingId);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var service = _service.TGetById(id);
            if (service == null)
            {
                return NotFound();
            }
            _service.TDelete(service);
            return Ok("DeleteService works");
        }

        [HttpPut]
        public IActionResult UpdateBooking(Booking booking)
        {
            _service.TUpdate(booking);
            return Ok("UpdateService works");
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var booking = _service.TGetById(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }
    }
}
