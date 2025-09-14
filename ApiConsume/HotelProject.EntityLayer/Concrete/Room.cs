namespace HotelProject.EntityLayer.Concrete;

public class Room
{
    public int RoomId { get; set; }
    public string RoomNumber { get; set; } = default!;
    public string CoverImage { get; set; }
    public float Price { get; set; }
    public string Title { get; set; } = default!;
    public int BedCount { get; set; }
    public int BathCount { get; set; }
    public string Description { get; set; } = default!;
}
