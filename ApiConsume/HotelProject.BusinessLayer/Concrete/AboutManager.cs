using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        public readonly IAboutDal aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            this.aboutDal = aboutDal;
        }

        public void TDelete(About t)
        {
            aboutDal.Delete(t);
        }

        public List<About> TGetAll()
        {
            return aboutDal.GetAll();
        }

        public About TGetById(int id)
        {
            return aboutDal.GetById(id);
        }

        public void TInsert(About t)
        {
            aboutDal.Insert(t);
        }

        public void TUpdate(About t)
        {
            aboutDal.Update(t);
        }
    }
}
