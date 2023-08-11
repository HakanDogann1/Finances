using Finances.BusinessLayer.Abstract;
using Finances.DataAccessLayer.Abstract;
using Finances.DataAccessLayer.UnitOfWork;
using Finances.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.BusinessLayer.Concrete
{
    public class AboutUsManager : IAboutUsService
    {
        private readonly IAboutUsDal _aboutUsDal;
        private readonly IUowDal _uowDal;

        public AboutUsManager(IAboutUsDal aboutUsDal, IUowDal uowDal)
        {
            _aboutUsDal = aboutUsDal;
            _uowDal = uowDal;
        }

        public void TAdd(AboutUs entity)
        {
            _aboutUsDal.Add(entity);
            _uowDal.Save();
        }

        public void TDelete(AboutUs entity)
        {
            _aboutUsDal.Delete(entity);
            _uowDal.Save();
        }

        public AboutUs TGetByID(int id)
        {
            return _aboutUsDal.GetByID(id);
        }

        public List<AboutUs> TGetList()
        {
            return _aboutUsDal.GetList();
        }

        public void TMultiUpdate(List<AboutUs> entities)
        {
           _aboutUsDal.MultiUpdate(entities);
            _uowDal.Save();
        }

        public void TUpdate(AboutUs entity)
        {
            _aboutUsDal.Update(entity);
            _uowDal.Save();
        }
    }
}
