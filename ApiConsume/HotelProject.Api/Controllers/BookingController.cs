using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Api.Controllers
{
    public class BookingController : BaseController<Booking, IBookingService>
    {
        public BookingController(IBookingService service) : base(service)
        {
        }

        [HttpPut("UpdateBookingStatusToApproved")]
        public IActionResult UpdateBookingStatusToApproved(int id)
        {
            try
            {
                _service.ApproveBooking(id);
                return Ok(new { Success = true, Message = "Booking approved successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = $"An error occurred: {ex.Message}" });
            }
        }

        [HttpPut("RejectBooking")]
        public IActionResult RejectBooking(int id)
        {
            try
            {
                _service.RejectBooking(id);
                return Ok(new { Success = true, Message = "Booking rejected successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = $"An error occurred: {ex.Message}" });
            }
        }

        [HttpPut("AddToWaitList")]
        public IActionResult AddToWaitList(int id)
        {
            try
            {
                _service.AddToWaitList(id);
                return Ok(new { Success = true, Message = "Booking added to wait list successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = $"An error occurred: {ex.Message}" });
            }
        }

        [HttpGet("GetByStatus/{status}")]
        public IActionResult GetBookingsByStatus(string status)
        {
            try
            {
                var bookings = _service.GetBookingsByStatus(status);
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = $"An error occurred: {ex.Message}" });
            }
        }
    }
}
