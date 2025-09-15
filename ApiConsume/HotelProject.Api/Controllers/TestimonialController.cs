using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.Api.Controllers
{
    public class TestimonialController : BaseController<Testimonial, ITestimonialService>
    {
        public TestimonialController(ITestimonialService testimonialService) : base(testimonialService)
        {
        }
    }
}
