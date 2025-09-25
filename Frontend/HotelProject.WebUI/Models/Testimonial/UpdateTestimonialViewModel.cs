namespace HotelProject.WebUI.Models.Testimonial
{
    public class UpdateTestimonialViewModel
    {
        public int TestimonialId { get; set; }
        public string Name { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Image { get; set; }
    }
}
