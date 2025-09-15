using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.Room;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Api.Controllers
{
    public class RoomController : BaseController<Room, IRoomService>
    {
        private readonly IMapper _mapper;

        public RoomController(IRoomService roomService, IMapper mapper) : base(roomService)
        {
            _mapper = mapper;
        }

        [HttpPost("AddRoomDto")]
        public IActionResult AddRoomWithDto(RoomAddDto roomAddDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model state");
            }
            var room = _mapper.Map<Room>(roomAddDto);
            return Add(room);
        }

        [HttpPut("UpdateRoomDto")]
        public IActionResult UpdateRoomWithDto(UpdateRoomDto roomDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model state");
            }
            var room = _mapper.Map<Room>(roomDto);
            return Update(room);
        }

        // Backward compatibility için eski endpoint'leri koru
        [HttpPost("CreateRoom")]
        public IActionResult CreateRoom(RoomAddDto roomAddDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model state");
            }
            var room = _mapper.Map<Room>(roomAddDto);
            return Add(room);
        }

        [HttpPut("UpdateRoom")]
        public IActionResult UpdateRoomLegacy(UpdateRoomDto roomDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model state");
            }
            var room = _mapper.Map<Room>(roomDto);
            return Update(room);
        }
    }
}
