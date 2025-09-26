using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.LoginDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers;

public class LoginController : Controller
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;

    public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(LoginUserDto userDto)
    {
        if (!ModelState.IsValid)
        {
            return View(userDto);
        }

        try
        {
            var result = await _signInManager.PasswordSignInAsync(userDto.Username, userDto.Password, false, true);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(userDto.Username);
                if (user != null)
                {
                    var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
                    if (isAdmin)
                    {
                        TempData["Success"] = $"Welcome back, {user.Name} {user.Surname}!";
                        return RedirectToAction("Index", "Staff");
                    }
                    else
                    {
                        await _signInManager.SignOutAsync();
                        ModelState.AddModelError("", "You don't have admin privileges to access the admin panel.");
                        return View(userDto);
                    }
                }
            }
            else if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Your account has been locked. Please try again later.");
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password.");
            }
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", "An error occurred during login. Please try again.");
        }

        return View(userDto);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        TempData["Success"] = "You have been successfully logged out.";
        return RedirectToAction("Index", "Login");
    }

    public IActionResult AccessDenied()
    {
        return View();
    }
}
