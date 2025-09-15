using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.Api.Controllers
{
    public class GuestController : BaseController<Guest, IGuestService>
    {
        public GuestController(IGuestService guestService) : base(guestService)
        {
        }
    }
}
