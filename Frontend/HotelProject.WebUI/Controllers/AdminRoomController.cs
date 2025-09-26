using HotelProject.WebUI.Dtos.RoomDto;
using HotelProject.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminRoomController : Controller
    {
        private readonly RoomApiService _roomApiService;
        private readonly CreateRoomApiService _createRoomApiService;
        private readonly UpdateRoomApiService _updateRoomApiService;

        public AdminRoomController(
            RoomApiService roomApiService,
            CreateRoomApiService createRoomApiService,
            UpdateRoomApiService updateRoomApiService)
        {
            _roomApiService = roomApiService;
            _createRoomApiService = createRoomApiService;
            _updateRoomApiService = updateRoomApiService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _roomApiService.GetAllAsync();
            return View(values ?? new List<ResultRoomDto>());
        }

        [HttpGet]
        public IActionResult AddRoom()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom(CreateRoomDto viewModel)
        {
            var result = await _createRoomApiService.CreateAsync(viewModel);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteRoom(int id)
        {
            var result = await _roomApiService.DeleteAsync(id);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRoom(int id)
        {
            var room = await _updateRoomApiService.GetByIdAsync(id);
            if (room != null)
            {
                return View(room);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRoom(UpdateRoomDto viewModel)
        {
            var result = await _updateRoomApiService.UpdateAsync(viewModel);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
