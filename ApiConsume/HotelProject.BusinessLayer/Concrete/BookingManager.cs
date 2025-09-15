using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public void ApproveBooking(int id)
        {

            var value = _bookingDal.GetById(id);
            if (value != null)
            {
                value.Status = "Approved";
                _bookingDal.Update(value);
            }
            return;

        }

        public void RejectBooking(int id)
        {
            var value = _bookingDal.GetById(id);
            if (value != null)
            {
                value.Status = "Rejected";
                _bookingDal.Update(value);
            }
        }

        public void AddToWaitList(int id)
        {
            var value = _bookingDal.GetById(id);
            if (value != null)
            {
                value.Status = "Waiting";
                _bookingDal.Update(value);
            }
        }

        public List<Booking> GetBookingsByStatus(string status)
        {
            return _bookingDal.GetAll().Where(b => b.Status == status).ToList();
        }

        public void TDelete(Booking t)
        {
            _bookingDal.Delete(t);
        }

        public List<Booking> TGetAll()
        {
            return _bookingDal.GetAll();
        }

        public Booking TGetById(int id)
        {
            return _bookingDal.GetById(id);
        }

        public void TInsert(Booking t)
        {
            _bookingDal.Insert(t);
        }

        public void TUpdate(Booking t)
        {
            _bookingDal.Update(t);
        }
    }
}
