namespace HotelProject.WebUI.Dtos.AboutDto
{
    public class ResultAboutDto
    {
        public int AboutId { get; set; }
        public string Title { get; set; } = default!;
        public string SpanTitle { get; set; } = default!;
        public string Content { get; set; } = default!;
        public int RoomCount { get; set; }
        public int StaffCount { get; set; }
        public int CustomerCount { get; set; }
    }
}
