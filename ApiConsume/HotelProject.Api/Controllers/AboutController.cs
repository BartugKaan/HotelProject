using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.Api.Controllers
{
    public class AboutController : BaseController<About, IAboutService>
    {
        public AboutController(IAboutService aboutService) : base(aboutService)
        {
        }
    }
}
