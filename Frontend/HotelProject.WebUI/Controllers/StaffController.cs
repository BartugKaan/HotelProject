using HotelProject.WebUI.Models.Staff;
using HotelProject.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StaffController : Controller
    {
        private readonly StaffApiService _staffApiService;
        private readonly AddStaffApiService _addStaffApiService;
        private readonly UpdateStaffApiService _updateStaffApiService;

        public StaffController(
            StaffApiService staffApiService,
            AddStaffApiService addStaffApiService,
            UpdateStaffApiService updateStaffApiService)
        {
            _staffApiService = staffApiService;
            _addStaffApiService = addStaffApiService;
            _updateStaffApiService = updateStaffApiService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _staffApiService.GetAllAsync();
            return View(values ?? new List<StaffViewModel>());
        }

        [HttpGet]
        public IActionResult AddStaff()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStaff(AddStaffViewModel viewModel)
        {
            var result = await _addStaffApiService.CreateAsync(viewModel);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteStaff(int id)
        {
            var result = await _staffApiService.DeleteAsync(id);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStaff(int id)
        {
            var staff = await _updateStaffApiService.GetByIdAsync(id);
            if (staff != null)
            {
                return View(staff);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStaff(UpdateStaffViewModel viewModel)
        {
            var result = await _updateStaffApiService.UpdateAsync(viewModel);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
