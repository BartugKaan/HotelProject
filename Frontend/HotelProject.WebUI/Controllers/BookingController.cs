using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly CreateBookingApiService _createBookingApiService;

        public BookingController(CreateBookingApiService createBookingApiService)
        {
            _createBookingApiService = createBookingApiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult AddBooking()
        {
            return PartialView(new CreateBookingDto());
        }

        [HttpPost]
        public async Task<IActionResult> AddBooking(CreateBookingDto dto)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(dto);
            }

            try
            {
                var result = await _createBookingApiService.CreateAsync(dto);
                if (result)
                {
                    TempData["Success"] = "Booking successfully created!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = "Booking failed. Please try again.";
                    return PartialView(dto);
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"An error occurred: {ex.Message}";
                return PartialView(dto);
            }
        }
    }
}