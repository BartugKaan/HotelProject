using HotelProject.WebUI.Models.Staff;

namespace HotelProject.WebUI.Services
{
    public class StaffApiService : ApiService<StaffViewModel>
    {
        public StaffApiService(HttpClient httpClient, IConfiguration configuration)
            : base(httpClient, configuration, "Staff")
        {
        }
    }

    public class AddStaffApiService : ApiService<AddStaffViewModel>
    {
        public AddStaffApiService(HttpClient httpClient, IConfiguration configuration)
            : base(httpClient, configuration, "Staff")
        {
        }
    }

    public class UpdateStaffApiService : ApiService<UpdateStaffViewModel>
    {
        public UpdateStaffApiService(HttpClient httpClient, IConfiguration configuration)
            : base(httpClient, configuration, "Staff")
        {
        }
    }
}