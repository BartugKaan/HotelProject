namespace HotelProject.EntityLayer.Concrete
{
    public class Guest
    {

        public int GueastId { get; set; }
        public string Name { get; set; } = default!;
        public string Surname { get; set; } = default!;
        public string City { get; set; } = default!;
    }
}
