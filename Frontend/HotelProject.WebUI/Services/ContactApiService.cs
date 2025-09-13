using HotelProject.WebUI.Dtos.ContactDto;

namespace HotelProject.WebUI.Services
{
    public class ContactApiService : ApiService<ResultContactDto>
    {
        public ContactApiService(HttpClient httpClient, IConfiguration configuration)
            : base(httpClient, configuration, "Contact")
        {
        }
    }

    public class CreateContactApiService : ApiService<CreateContactDto>
    {
        public CreateContactApiService(HttpClient httpClient, IConfiguration configuration)
            : base(httpClient, configuration, "Contact")
        {
        }
    }
}