namespace HotelProject.WebUI.Dtos.ContactDto
{
    public class ResultContactDto
    {
        public int ContactId { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Subject { get; set; } = default!;
        public String Message { get; set; } = default!;
        public DateTime ContactDate { get; set; }
    }
}
