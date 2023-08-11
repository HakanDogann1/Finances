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
    public class HeaderManager : IHeaderService
    {
        private readonly IHeaderDal _headerDal;
        private readonly IUowDal _uowDal;

        public HeaderManager(IHeaderDal headerDal, IUowDal uowDal)
        {
            _headerDal = headerDal;
            _uowDal = uowDal;
        }

        public void TAdd(Header entity)
        {
            _headerDal.Add(entity);
            _uowDal.Save();
        }

        public void TDelete(Header entity)
        {
            _headerDal.Delete(entity);
            _uowDal.Save();
        }

        public Header TGetByID(int id)
        {
            return _headerDal.GetByID(id);
        }

        public List<Header> TGetList()
        {
            return _headerDal.GetList();
        }

        public void TMultiUpdate(List<Header> entities)
        {
            _headerDal.MultiUpdate(entities);
            _uowDal.Save();
        }

        public void TUpdate(Header entity)
        {
            _headerDal.Update(entity);
            _uowDal.Save();
        }
    }
}
