using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/404")]
        public IActionResult NotFound()
        {
            return View();
        }

        [Route("Error/500")]
        public IActionResult InternalServerError()
        {
            return View();
        }

        [Route("Error/{statusCode}")]
        public IActionResult Index(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    return View("NotFound");
                case 500:
                    return View("InternalServerError");
                default:
                    return View("NotFound");
            }
        }
    }
}