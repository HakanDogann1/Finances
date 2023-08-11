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
    public class HowItWorksManager : IHowItWorksService
    {
        private readonly IHowItWorksDal _howItWorksDal;
        private readonly IUowDal _uowDal;

        public HowItWorksManager(IHowItWorksDal howItWorksDal, IUowDal uowDal)
        {
            _howItWorksDal = howItWorksDal;
            _uowDal = uowDal;
        }

        public void TAdd(HowItWorks entity)
        {
            _howItWorksDal.Add(entity);
            _uowDal.Save();
        }

        public void TDelete(HowItWorks entity)
        {
            _howItWorksDal.Delete(entity);
            _uowDal.Save();
        }

        public HowItWorks TGetByID(int id)
        {
            return _howItWorksDal.GetByID(id);
        }

        public List<HowItWorks> TGetList()
        {
           return _howItWorksDal.GetList();
        }

        public void TMultiUpdate(List<HowItWorks> entities)
        {
            _howItWorksDal.MultiUpdate(entities);
            _uowDal.Save();
        }

        public void TUpdate(HowItWorks entity)
        {
            _howItWorksDal.Update(entity);
            _uowDal.Save();
        }
    }
}
