using HotelProject.WebUI.Models.Testimonial;

namespace HotelProject.WebUI.Services
{
    public class TestimonialApiService : ApiService<TestimonialViewModel>
    {
        public TestimonialApiService(HttpClient httpClient, IConfiguration configuration)
            : base(httpClient, configuration, "Testimonial")
        {
        }
    }

    public class AddTestimonialApiService : ApiService<AddTestimonialViewModel>
    {
        public AddTestimonialApiService(HttpClient httpClient, IConfiguration configuration)
            : base(httpClient, configuration, "Testimonial")
        {
        }
    }

    public class UpdateTestimonialApiService : ApiService<UpdateTestimonialViewModel>
    {
        public UpdateTestimonialApiService(HttpClient httpClient, IConfiguration configuration)
            : base(httpClient, configuration, "Testimonial")
        {
        }
    }
}