using System.ComponentModel.DataAnnotations;

namespace HotelProject.DtoLayer.Dtos.Room;

public sealed class UpdateRoomDto
{
    public int RoomId { get; set; }

    [Required(ErrorMessage = "Please Enter a Room Number")]
    public string RoomNumber { get; set; } = default!;

    [Required(ErrorMessage = "Please Enter a Cover Image URL")]
    public string CoverImage { get; set; }

    [Required(ErrorMessage = "Please Enter a Price")]
    [MaxLength(5000, ErrorMessage = "Price cannot exceed 5000")]
    public float Price { get; set; }

    [Required(ErrorMessage = "Please Enter a Title")]
    [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
    public string Title { get; set; } = default!;

    [Required(ErrorMessage = "Please Enter a Bed Count")]
    [MaxLength(10, ErrorMessage = "Bed Count cannot exceed 10")]
    public int BedCount { get; set; }

    [Required(ErrorMessage = "Please Enter a Bath Count")]
    [MaxLength(10, ErrorMessage = "Bath Count cannot exceed 10")]
    public int BathCount { get; set; }

    [Required(ErrorMessage = "Please Enter a Room Description")]
    [MaxLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
    public string Description { get; set; } = default!;
}
