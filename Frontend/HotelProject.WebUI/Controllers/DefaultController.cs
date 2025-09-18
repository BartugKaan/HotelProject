using HotelProject.WebUI.Dtos.StaffDto;
using HotelProject.WebUI.Dtos.SubscribeDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers;

public class DefaultController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public DefaultController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public PartialViewResult _NewsletterPartial()
    {
        return PartialView();
    }

    [HttpPost]
    public async Task<PartialViewResult> _NewsletterPartialAsync(CreateSubscribeDto dto)
    {
        if(!ModelState.IsValid)
        {
            return PartialView();
        }

        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(dto);
        StringContent stringContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("http://localhost:5283/api/Subscribe", stringContent);
        if (!responseMessage.IsSuccessStatusCode)
        {
            return PartialView();
            
        }
        return PartialView("Index");

    }
}
