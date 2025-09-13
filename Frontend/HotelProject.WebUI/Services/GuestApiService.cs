using HotelProject.WebUI.Dtos.GuestDto;

namespace HotelProject.WebUI.Services
{
    public class GuestApiService : ApiService<ResultGuestDto>
    {
        public GuestApiService(HttpClient httpClient, IConfiguration configuration)
            : base(httpClient, configuration, "Guest")
        {
        }
    }

    public class CreateGuestApiService : ApiService<CreateGuestDto>
    {
        public CreateGuestApiService(HttpClient httpClient, IConfiguration configuration)
            : base(httpClient, configuration, "Guest")
        {
        }
    }

    public class UpdateGuestApiService : ApiService<UpdateGuestDto>
    {
        public UpdateGuestApiService(HttpClient httpClient, IConfiguration configuration)
            : base(httpClient, configuration, "Guest")
        {
        }
    }
}