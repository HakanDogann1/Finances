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
    public class AccountManager : IAccountService
    {
        private readonly IAccountDal _accountDal;
        private readonly IUowDal _uowDal;

        public AccountManager(IAccountDal accountDal, IUowDal uowDal)
        {
            _accountDal = accountDal;
            _uowDal = uowDal;
        }

        public void TAdd(Account entity)
        {
            _accountDal.Add(entity);
            _uowDal.Save();
        }

        public void TDelete(Account entity)
        {
           _accountDal.Delete(entity);
            _uowDal.Save();
        }

        public Account TGetByID(int id)
        {
           return _accountDal.GetByID(id);
        }

        public List<Account> TGetList()
        {
            return _accountDal.GetList();
        }

        public void TMultiUpdate(List<Account> entities)
        {
            _accountDal.MultiUpdate(entities);
            _uowDal.Save();
        }

        public void TUpdate(Account entity)
        {
            _accountDal.Update(entity);
            _uowDal.Save();
        }
    }
}
