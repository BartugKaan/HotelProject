using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.Api.Controllers
{
    public class ServiceController : BaseController<Service, IServiceService>
    {
        public ServiceController(IServiceService service) : base(service)
        {
        }
    }
}