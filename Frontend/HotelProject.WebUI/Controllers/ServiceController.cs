using HotelProject.WebUI.Dtos.ServiceDto;
using HotelProject.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
        private readonly ServiceApiService _serviceApiService;
        private readonly CreateServiceApiService _createServiceApiService;
        private readonly UpdateServiceApiService _updateServiceApiService;

        public ServiceController(
            ServiceApiService serviceApiService,
            CreateServiceApiService createServiceApiService,
            UpdateServiceApiService updateServiceApiService)
        {
            _serviceApiService = serviceApiService;
            _createServiceApiService = createServiceApiService;
            _updateServiceApiService = updateServiceApiService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _serviceApiService.GetAllAsync();
            return View(values ?? new List<ResultServiceDto>());
        }

        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddService(CreateServiceDto serviceDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _createServiceApiService.CreateAsync(serviceDto);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteService(int id)
        {
            var result = await _serviceApiService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var service = await _updateServiceApiService.GetByIdAsync(id);
            if (service != null)
            {
                return View(service);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDto viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _updateServiceApiService.UpdateAsync(viewModel);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}