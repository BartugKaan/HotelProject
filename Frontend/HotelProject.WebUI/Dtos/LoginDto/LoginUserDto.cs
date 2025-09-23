using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.LoginDto;

public class LoginUserDto
{
    [Required(ErrorMessage = "Userrname cannot be empty")]
    public string Username { get; set; } = default!;

    [Required(ErrorMessage = "Password cannot be empty")]
    public string Password { get; set; } = default!;
}
