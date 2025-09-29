namespace HotelProject.WebUI.Dtos.GuestDto;  

public class UpdateGuestDto
{
    public int GueastId { get; set; }
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public string City { get; set; } = default!;
}
