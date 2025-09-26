using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.ContactDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult AddContact()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(CreateContactDto dto)
        {
            try
            {
                dto.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());

                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(dto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                // Use the new email-enabled endpoint
                var response = await client.PostAsync("http://localhost:5283/api/Contact/AddContactWithEmail", stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<dynamic>(responseContent);

                    TempData["Success"] = "Thank you! Your message has been sent successfully. You will receive a confirmation email shortly.";
                }
                else
                {
                    TempData["Error"] = "There was an issue sending your message. Please try again.";
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
