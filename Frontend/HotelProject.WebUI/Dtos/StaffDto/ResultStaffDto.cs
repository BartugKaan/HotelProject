namespace HotelProject.WebUI.Dtos.StaffDto
{
    public class ResultStaffDto
    {
        public int StaffId { get; set; }
        public string Name { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string? FacebookLink { get; set; }
        public string? TwitterLink { get; set; }
        public string? InstegramLink { get; set; }
        public string Image { get; set; } = default!;
    }
}
