using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.Api.Controllers
{
    public class SubscribeController : BaseController<Subscribe, ISubscribeService>
    {
        public SubscribeController(ISubscribeService subscribeService) : base(subscribeService)
        {
        }
    }
}
