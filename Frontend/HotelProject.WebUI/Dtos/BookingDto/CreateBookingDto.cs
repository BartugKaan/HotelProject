using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.BookingDto
{
    public class CreateBookingDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = default!;
        
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; } = default!;
        
        [Required(ErrorMessage = "Check-in date is required")]
        public DateTime CheckIn { get; set; }
        
        [Required(ErrorMessage = "Check-out date is required")]
        public DateTime CheckOut { get; set; }
        
        [Required(ErrorMessage = "Adult count is required")]
        public string AdultCount { get; set; } = default!;
        
        [Required(ErrorMessage = "Children count is required")]
        public string ChildrenCount { get; set; } = default!;
        
        [Required(ErrorMessage = "Room count is required")]
        public string RoomCount { get; set; } = default!;
        
        public string SpecialRequest { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        
        public string Status { get; set; } = "Pending";
    }
}