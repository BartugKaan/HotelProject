using AutoMapper;
using HotelProject.DtoLayer.Dtos.Room;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.Api.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<RoomAddDto, Room>();
            CreateMap<Room, RoomAddDto>();
            CreateMap<UpdateRoomDto, Room>();
            CreateMap<Room, UpdateRoomDto>();
        }
    }
}
