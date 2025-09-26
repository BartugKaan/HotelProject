using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BookingAdminController : Controller
    {
        private readonly BookingApiService _bookingApiService;
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingAdminController(BookingApiService bookingApiService, IHttpClientFactory httpClientFactory)
        {
            _bookingApiService = bookingApiService;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var values = await _bookingApiService.GetAllAsync();
            return View(values ?? new List<ResultBookingDto>());
        }

        public async Task<IActionResult> ApprovedReservation(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.PutAsync($"http://localhost:5283/api/Booking/UpdateBookingStatusToApproved?id={id}", null);

                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Booking approved successfully!";
                }
                else
                {
                    TempData["Error"] = "Failed to approve booking.";
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"An error occurred: {ex.Message}";
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RejectReservation(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.PutAsync($"http://localhost:5283/api/Booking/RejectBooking?id={id}", null);

                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Booking rejected successfully!";
                }
                else
                {
                    TempData["Error"] = "Failed to reject booking.";
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"An error occurred: {ex.Message}";
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddToWaitList(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.PutAsync($"http://localhost:5283/api/Booking/AddToWaitList?id={id}", null);

                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Booking added to wait list successfully!";
                }
                else
                {
                    TempData["Error"] = "Failed to add booking to wait list.";
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"An error occurred: {ex.Message}";
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var booking = await _bookingApiService.GetByIdAsync(id);
            if (booking != null)
            {
                return View(booking);
            }
            TempData["Error"] = "Booking not found.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var booking = await _bookingApiService.GetByIdAsync(id);
            if (booking != null)
            {
                // DTO dönüşümü burada yapılacak
                return View(booking);
            }
            TempData["Error"] = "Booking not found.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(ResultBookingDto booking)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(booking);
                }

                var result = await _bookingApiService.UpdateAsync(booking);
                if (result)
                {
                    TempData["Success"] = "Booking updated successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = "Failed to update booking.";
                    return View(booking);
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"An error occurred: {ex.Message}";
                return View(booking);
            }
        }
    }
}
