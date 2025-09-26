using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminContactController : Controller
    {
        private readonly ContactApiService _contactApiService;

        public AdminContactController(ContactApiService contactApiService)
        {
            _contactApiService = contactApiService;
        }

        public async Task<IActionResult> InboxAsync()
        {
            var values = await _contactApiService.GetAllAsync();
            return View(values ?? new List<ResultContactDto>());
        }

        public PartialViewResult SidebarAdminContactPartial()
        {
            return PartialView();
        }

        public PartialViewResult SidebarAdminContactCategoryPartial()
        {
            return PartialView();
        }
    }
}
