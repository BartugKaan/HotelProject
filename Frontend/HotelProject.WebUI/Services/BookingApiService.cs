using HotelProject.WebUI.Dtos.BookingDto;

namespace HotelProject.WebUI.Services
{
    public class BookingApiService : ApiService<ResultBookingDto>
    {
        public BookingApiService(HttpClient httpClient, IConfiguration configuration)
            : base(httpClient, configuration, "Booking")
        {
        }
    }

    public class CreateBookingApiService : ApiService<CreateBookingDto>
    {
        public CreateBookingApiService(HttpClient httpClient, IConfiguration configuration)
            : base(httpClient, configuration, "Booking")
        {
        }
    }
}