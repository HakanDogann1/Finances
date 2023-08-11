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
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;
        private readonly IUowDal _uowDal;

        public ContactManager(IContactDal contactDal, IUowDal uowDal)
        {
            _contactDal = contactDal;
            _uowDal = uowDal;
        }

        public void TAdd(Contact entity)
        {
            _contactDal.Add(entity);
            _uowDal.Save();
        }

        public void TDelete(Contact entity)
        {
            _contactDal.Delete(entity);
            _uowDal.Save();
        }

        public Contact TGetByID(int id)
        {
            return _contactDal.GetByID(id);
        }

        public List<Contact> TGetList()
        {
            return _contactDal.GetList();
        }

        public void TMultiUpdate(List<Contact> entities)
        {
            _contactDal.MultiUpdate(entities);
            _uowDal.Save();
        }

        public void TUpdate(Contact entity)
        {
            _contactDal.Update(entity);
            _uowDal.Save();
        }
    }
}
