using HotelProject.WebUI.Dtos.RoomDto;

namespace HotelProject.WebUI.Services
{
    public class RoomApiService : ApiService<ResultRoomDto>
    {
        public RoomApiService(HttpClient httpClient, IConfiguration configuration)
            : base(httpClient, configuration, "Room")
        {
        }
    }

    public class CreateRoomApiService : ApiService<CreateRoomDto>
    {
        public CreateRoomApiService(HttpClient httpClient, IConfiguration configuration)
            : base(httpClient, configuration, "Room")
        {
        }
    }

    public class UpdateRoomApiService : ApiService<UpdateRoomDto>
    {
        public UpdateRoomApiService(HttpClient httpClient, IConfiguration configuration)
            : base(httpClient, configuration, "Room")
        {
        }
    }
}