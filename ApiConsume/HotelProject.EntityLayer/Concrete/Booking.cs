namespace HotelProject.EntityLayer.Concrete
{
    public class Booking
    {
        public int BookingId { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string AdultCount { get; set; } = default!;
        public string ChildrenCount { get; set; } = default!;
        public string RoomCount { get; set; } = default!;
        public string SpecialRequest { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Status { get; set; }



    }
}
