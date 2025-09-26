using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRooms()
        {
            return Ok("GetRooms works");
        }

        [HttpPost]
        public IActionResult AddRoom()
        {
            return Ok("AddRoom works");
        }

        [HttpDelete]
        public IActionResult DeleteRoom()
        {
            return Ok("DeleteRoom works");
        }

        [HttpPut]
        public IActionResult UpdateRoom()
        {
            return Ok("UpdateRoom works");
        }

        [HttpGet("{id}")]
        public IActionResult GetRoom(int id)
        {
            return Ok($"GetRoom works for id: {id}");
        }
    }
}
