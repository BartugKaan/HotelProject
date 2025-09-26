using HotelProject.WebUI.Dtos.SendMessageDto;
using HotelProject.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SendMessageController : Controller
    {
        private readonly SendMessageApiService _sendMessageApiService;
        private readonly CreateSendMessageApiService _createSendMessageApiService;

        public SendMessageController(
            SendMessageApiService sendMessageApiService,
            CreateSendMessageApiService createSendMessageApiService)
        {
            _sendMessageApiService = sendMessageApiService;
            _createSendMessageApiService = createSendMessageApiService;
        }

        public async Task<IActionResult> Index()
        {
            var messages = await _sendMessageApiService.GetAllAsync();
            return View(messages ?? new List<ResultSendMessageDto>());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSendMessageDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(dto);
                }

                dto.Date = DateTime.Now;

                var result = await _createSendMessageApiService.CreateAsync(dto);
                if (result)
                {
                    TempData["Success"] = "Message sent successfully! Both sender and receiver will be notified via email.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = "There was an issue sending your message. Please try again.";
                    return View(dto);
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"An error occurred: {ex.Message}";
                return View(dto);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var message = await _sendMessageApiService.GetByIdAsync(id);
            if (message != null)
            {
                return View(message);
            }
            return NotFound();
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _sendMessageApiService.DeleteAsync(id);
                if (result)
                {
                    TempData["Success"] = "Message deleted successfully.";
                }
                else
                {
                    TempData["Error"] = "There was an issue deleting the message.";
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"An error occurred: {ex.Message}";
            }

            return RedirectToAction("Index");
        }
    }
}