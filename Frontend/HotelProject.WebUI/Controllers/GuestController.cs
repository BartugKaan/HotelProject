using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GuestController : Controller
    {
        private readonly GuestApiService _guestApiService;
        private readonly CreateGuestApiService _createGuestApiService;
        private readonly UpdateGuestApiService _updateGuestApiService;

        public GuestController(
            GuestApiService guestApiService,
            CreateGuestApiService createGuestApiService,
            UpdateGuestApiService updateGuestApiService)
        {
            _guestApiService = guestApiService;
            _createGuestApiService = createGuestApiService;
            _updateGuestApiService = updateGuestApiService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _guestApiService.GetAllAsync();
            return View(values ?? new List<ResultGuestDto>());
        }

        [HttpGet]
        public IActionResult AddGuest()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGuest(CreateGuestDto viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _createGuestApiService.CreateAsync(viewModel);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteGuest(int id)
        {
            var result = await _guestApiService.DeleteAsync(id);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateGuest(int id)
        {
            var guest = await _updateGuestApiService.GetByIdAsync(id);
            if (guest != null)
            {
                return View(guest);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGuest(UpdateGuestDto viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _updateGuestApiService.UpdateAsync(viewModel);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}