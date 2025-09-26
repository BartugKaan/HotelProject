using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public IActionResult GetStaffs()
        {
            var values = _staffService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddStaff(Staff staff)
        {
            _staffService.TInsert(staff);
            return Ok("AddStaff works : " + staff.StaffId);
        }

        [HttpDelete]
        public IActionResult DeleteStaff(int id)
        {
            var staff = _staffService.TGetById(id);
            _staffService.TDelete(staff);
            return Ok("DeleteStaff works");
        }

        [HttpPut]
        public IActionResult UpdateStaff(Staff staff)
        {
            _staffService.TUpdate(staff);
            return Ok("UpdateStaff works");
        }

        [HttpGet("{id}")]
        public IActionResult GetStaff(int id)
        {
            var staff = _staffService.TGetById(id);
            return Ok($"GetStaff works for id: {staff}");
        }
    }
}
