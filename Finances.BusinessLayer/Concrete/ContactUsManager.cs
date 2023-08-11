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
    public class ContactUsManager : IContactUsService
    {
        private readonly IContactUsDal _contactUsDal;
        private readonly IUowDal _uowDal;

        public ContactUsManager(IContactUsDal contactUsDal, IUowDal uowDal)
        {
            _contactUsDal = contactUsDal;
            _uowDal = uowDal;
        }

        public void TAdd(ContactUs entity)
        {
           _contactUsDal.Add(entity);
            _uowDal.Save();
        }

        public void TDelete(ContactUs entity)
        {
            _contactUsDal.Delete(entity);
            _uowDal.Save();
        }

        public ContactUs TGetByID(int id)
        {
            return _contactUsDal.GetByID(id);

        }

        public List<ContactUs> TGetList()
        {
           return _contactUsDal.GetList();
        }

        public void TMultiUpdate(List<ContactUs> entities)
        {
            _contactUsDal.MultiUpdate(entities);
            _uowDal.Save();
        }

        public void TUpdate(ContactUs entity)
        {
           _contactUsDal.Update(entity);
            _uowDal.Save();
        }
    }
}
