using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.SubscribeDto
{
    public class CreateSubscribeDto
    {
        [EmailAddress(ErrorMessage = "Please enter a valid E-Mail address")]
        [MinLength(5, ErrorMessage = "E-Mail needs to be at least 5 character")]
        public string Mail { get; set; } = default!;
    }
}
