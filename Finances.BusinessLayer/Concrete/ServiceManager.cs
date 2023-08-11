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
    public class ServiceManager : IServiceService
    {
        private readonly IServiceDal _serviceDal;
        private readonly IUowDal _uowDal;

        public ServiceManager(IServiceDal serviceDal, IUowDal uowDal)
        {
            _serviceDal = serviceDal;
            _uowDal = uowDal;
        }

        public void TAdd(Service entity)
        {
            _serviceDal.Add(entity);
            _uowDal.Save();
        }

        public void TDelete(Service entity)
        {
            _serviceDal.Delete(entity);
            _uowDal.Save();
        }

        public Service TGetByID(int id)
        {
            return _serviceDal.GetByID(id);
        }

        public List<Service> TGetList()
        {
            return _serviceDal.GetList();
        }

        public void TMultiUpdate(List<Service> entities)
        {
            _serviceDal.MultiUpdate(entities);
            _uowDal.Save();
        }

        public void TUpdate(Service entity)
        {
            _serviceDal.Update(entity);
            _uowDal.Save();
        }
    }
}
