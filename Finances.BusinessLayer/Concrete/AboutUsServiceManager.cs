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
    public class AboutUsServiceManager : IAboutUsServiceService
    {
        private readonly IAboutUsServiceDal _aboutUsServiceDal;
        private readonly IUowDal _uowDal;

        public AboutUsServiceManager(IAboutUsServiceDal aboutUsServiceDal, IUowDal uowDal)
        {
            _aboutUsServiceDal = aboutUsServiceDal;
            _uowDal = uowDal;
        }

        public void TAdd(AboutUsService entity)
        {
            _aboutUsServiceDal.Add(entity);
            _uowDal.Save();
        }

        public void TDelete(AboutUsService entity)
        {
            _aboutUsServiceDal.Delete(entity);
            _uowDal.Save();
        }

        public AboutUsService TGetByID(int id)
        {
            return _aboutUsServiceDal.GetByID(id);
        }

        public List<AboutUsService> TGetList()
        {
            return _aboutUsServiceDal.GetList();
        }

        public void TMultiUpdate(List<AboutUsService> entities)
        {
            _aboutUsServiceDal.MultiUpdate(entities);
            _uowDal.Save();
        }

        public void TUpdate(AboutUsService entity)
        {
            _aboutUsServiceDal.Update(entity);
            _uowDal.Save();
        }
    }
}
