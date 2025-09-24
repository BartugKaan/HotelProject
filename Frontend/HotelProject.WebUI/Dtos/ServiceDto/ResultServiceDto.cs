namespace HotelProject.WebUI.Dtos.ServiceDto;

public sealed class ResultServiceDto
{
    public int ServiceId { get; set; }
    public string Icon { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
}
