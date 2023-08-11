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
    public class HappyCustomerManager : IHappyCustomerService
    {
        private readonly IHappyCustomerDal _happyCustomerDal;
        private readonly IUowDal _uowDal;

        public HappyCustomerManager(IHappyCustomerDal happyCustomerDal, IUowDal uowDal)
        {
            _happyCustomerDal = happyCustomerDal;
            _uowDal = uowDal;
        }

        public void TAdd(HappyCustomer entity)
        {
            _happyCustomerDal.Add(entity);
            _uowDal.Save();
        }

        public void TDelete(HappyCustomer entity)
        {
           _happyCustomerDal.Delete(entity);
            _uowDal.Save();
        }

        public HappyCustomer TGetByID(int id)
        {
            return _happyCustomerDal.GetByID(id);
        }

        public List<HappyCustomer> TGetList()
        {
            return _happyCustomerDal.GetList();
        }

        public void TMultiUpdate(List<HappyCustomer> entities)
        {
            _happyCustomerDal.MultiUpdate(entities);
            _uowDal.Save();
        }

        public void TUpdate(HappyCustomer entity)
        {
            _happyCustomerDal.Update(entity);
            _uowDal.Save();
        }
    }
}
