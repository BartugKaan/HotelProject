using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _guestService;

        public GuestController(IGuestService guestService)
        {
            _guestService = guestService;
        }

        [HttpGet]
        public IActionResult GetGuests()
        {
            var values = _guestService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddGuest(Guest guest)
        {
            _guestService.TInsert(guest);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGuest(int id)
        {
            var values = _guestService.TGetById(id);
            if (values == null)
            {
                return NotFound();
            }
            _guestService.TDelete(values);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateGuest(Guest guest)
        {
            _guestService.TUpdate(guest);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetAGuest(int id)
        {
            var values = _guestService.TGetById(id);
            if (values == null)
            {
                return NotFound();
            }
            return Ok(values);
        }
    }
}
