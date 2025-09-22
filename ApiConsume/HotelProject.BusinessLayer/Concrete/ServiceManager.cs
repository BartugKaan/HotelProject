using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete;

public class ServiceManager : IServiceService
{

    private readonly IServicesDal _serviceDal;
    public ServiceManager(IServicesDal serviceService)
    {
        _serviceDal = serviceService;
    }

    public void TDelete(Service t)
    {
        _serviceDal.Delete(t);
    }

    public List<Service> TGetAll()
    {
        return _serviceDal.GetAll();
    }

    public Service TGetById(int id)
    {
        return _serviceDal.GetById(id);
    }

    public void TInsert(Service t)
    {
        _serviceDal.Insert(t);
    }

    public void TUpdate(Service t)
    {
        _serviceDal.Update(t);
    }
}
