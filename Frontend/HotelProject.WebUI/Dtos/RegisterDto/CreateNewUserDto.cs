using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.RegisterDto;

public class CreateNewUserDto
{
    [Required(ErrorMessage = "Name cannot be empty")]
    public string Name { get; set; } = default!;

    [Required(ErrorMessage = "Surname cannot be empty")]
    public string Surname { get; set; } = default!;

    [Required(ErrorMessage = "Username cannot be empty")]
    public string Username { get; set; } = default!;

    [Required(ErrorMessage = "Email cannot be empty")]
    public string Email { get; set; } = default!;

    [Required(ErrorMessage = "City cannot be empty")]
    public string City { get; set; } = default!;

    [Required(ErrorMessage = "Password cannot be empty")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$",
        ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character")]
    public string Password { get; set; } = default!;

    [Required(ErrorMessage = "Confirm Password cannot be empty")]
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public string ConfirmPassword { get; set; } = default!;

}
