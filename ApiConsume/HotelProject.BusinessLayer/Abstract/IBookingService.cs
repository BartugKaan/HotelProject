using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Abstract;

public interface IBookingService : IGenericService<Booking>
{
    void ApproveBooking(int id);
    void RejectBooking(int id);
    void AddToWaitList(int id);
    List<Booking> GetBookingsByStatus(string status);
}
