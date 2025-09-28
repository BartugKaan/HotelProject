using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete;

public class ContactManager : IContactService
{

    public readonly IContactDal _dal;

    public ContactManager(IContactDal dal)
    {
        _dal = dal;
    }

    public void TDelete(Contact t)
    {
        _dal.Delete(t);
    }

    public List<Contact> TGetAll()
    {
        return _dal.GetAll();
    }

    public Contact TGetById(int id)
    {
        return _dal.GetById(id);
    }

    public void TInsert(Contact t)
    {
        _dal.Insert(t);
    }

    public void TUpdate(Contact t)
    {
        _dal.Update(t);
    }
}
