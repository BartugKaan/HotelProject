using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete;

public class RoomManager : IRoomService
{
    private readonly IRoomDal _roomDal;

    public RoomManager(IRoomDal roomDal)
    {
        _roomDal = roomDal;
    }

    public void TDelete(Room t)
    {
        _roomDal.Delete(t);
    }

    public List<Room> TGetAll()
    {
        return _roomDal.GetAll();
    }

    public Room TGetById(int id)
    {
        return _roomDal.GetById(id);
    }

    public void TInsert(Room t)
    {
        _roomDal.Insert(t);
    }

    public void TUpdate(Room t)
    {
        _roomDal.Update(t);
    }
}
