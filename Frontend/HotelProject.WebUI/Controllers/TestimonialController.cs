using HotelProject.WebUI.Models.Testimonial;
using HotelProject.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TestimonialController : Controller
    {
        private readonly TestimonialApiService _testimonialApiService;
        private readonly AddTestimonialApiService _addTestimonialApiService;
        private readonly UpdateTestimonialApiService _updateTestimonialApiService;

        public TestimonialController(
            TestimonialApiService testimonialApiService,
            AddTestimonialApiService addTestimonialApiService,
            UpdateTestimonialApiService updateTestimonialApiService)
        {
            _testimonialApiService = testimonialApiService;
            _addTestimonialApiService = addTestimonialApiService;
            _updateTestimonialApiService = updateTestimonialApiService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _testimonialApiService.GetAllAsync();
            return View(values ?? new List<TestimonialViewModel>());
        }

        [HttpGet]
        public IActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTestimonial(AddTestimonialViewModel viewModel)
        {
            var result = await _addTestimonialApiService.CreateAsync(viewModel);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var result = await _testimonialApiService.DeleteAsync(id);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var testimonial = await _updateTestimonialApiService.GetByIdAsync(id);
            if (testimonial != null)
            {
                return View(testimonial);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialViewModel viewModel)
        {
            var result = await _updateTestimonialApiService.UpdateAsync(viewModel);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
