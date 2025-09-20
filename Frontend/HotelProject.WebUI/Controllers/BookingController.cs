using HotelProject.WebUI.Dtos.BookingDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
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
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(dto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:5283/api/Booking", stringContent);

                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Booking successfully created!";
                    return RedirectToAction("Index");
                }
                else
                {
                    var errorContent = await responseMessage.Content.ReadAsStringAsync();
                    TempData["Error"] = $"Booking failed. Error: {errorContent}";
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