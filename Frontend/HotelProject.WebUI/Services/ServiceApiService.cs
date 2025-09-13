using HotelProject.WebUI.Dtos.ServiceDto;

namespace HotelProject.WebUI.Services
{
    public class ServiceApiService : ApiService<ResultServiceDto>
    {
        public ServiceApiService(HttpClient httpClient, IConfiguration configuration)
            : base(httpClient, configuration, "Service")
        {
        }
    }

    public class CreateServiceApiService : ApiService<CreateServiceDto>
    {
        public CreateServiceApiService(HttpClient httpClient, IConfiguration configuration)
            : base(httpClient, configuration, "Service")
        {
        }
    }

    public class UpdateServiceApiService : ApiService<UpdateServiceDto>
    {
        public UpdateServiceApiService(HttpClient httpClient, IConfiguration configuration)
            : base(httpClient, configuration, "Service")
        {
        }
    }
}