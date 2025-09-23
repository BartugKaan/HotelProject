using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.RegisterDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers;

public class RegisterController : Controller
{

    private readonly UserManager<AppUser> _userManager;

    public RegisterController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(CreateNewUserDto userDto)
    {
        if(!ModelState.IsValid)
        {
            return View();
        }
        var appUser = new AppUser()
        {
            Name = userDto.Name,
            Surname = userDto.Surname,
            UserName = userDto.Username,
            Email = userDto.Email,
            City = userDto.City
        };
        var result = await _userManager.CreateAsync(appUser, userDto.Password);
        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Login");
        }
        return View();
    }
}
