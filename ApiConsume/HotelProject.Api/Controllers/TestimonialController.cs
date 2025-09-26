using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet]
        public IActionResult GetTestimonials()
        {
            var values = _testimonialService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddTestimonial(Testimonial testimonial)
        {
            _testimonialService.TInsert(testimonial);
            return Ok("AddTestimonial works : " + testimonial.TestimonialId);
        }

        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var testimonial = _testimonialService.TGetById(id);
            _testimonialService.TDelete(testimonial);
            return Ok("DeleteTestimonial works");
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {
            _testimonialService.TUpdate(testimonial);
            return Ok("UpdateTestimonial works");
        }

        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var testimonial = _testimonialService.TGetById(id);
            return Ok($"GetTestimonial works for id: {testimonial}");
        }
    }
}
