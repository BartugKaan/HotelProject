namespace HotelProject.WebUI.Dtos.RoomDto
{
    public class CreateRoomDto
    {
        public string RoomNumber { get; set; } = default!;
        public string CoverImage { get; set; } = default!;
        public float Price { get; set; }
        public string Title { get; set; } = default!;
        public int BedCount { get; set; }
        public int BathCount { get; set; }
        public string Description { get; set; } = default!;
    }
}
