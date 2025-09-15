using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.Api.Controllers
{
    public class StaffController : BaseController<Staff, IStaffService>
    {
        public StaffController(IStaffService staffService) : base(staffService)
        {
        }
    }
}
