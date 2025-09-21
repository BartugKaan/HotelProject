using System.ComponentModel.DataAnnotations;

namespace HotelProject.DtoLayer.Dtos.Room;

public sealed class RoomAddDto
{
    [Required(ErrorMessage = "Please Enter a Room Number")]
    public string RoomNumber { get; set; } = default!;
    public string CoverImage { get; set; }
    [Required(ErrorMessage = "Please Enter a Price")]
    public float Price { get; set; }
    [Required(ErrorMessage = "Please Enter a Title")]
    public string Title { get; set; } = default!;
    [Required(ErrorMessage = "Please Enter a Bed Count")]
    public int BedCount { get; set; }
    [Required(ErrorMessage = "Please Enter a Bath Count")]
    public int BathCount { get; set; }
    [Required(ErrorMessage = "Please Enter a Room Description")]
    public string Description { get; set; } = default!;
}
