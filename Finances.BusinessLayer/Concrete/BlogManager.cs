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
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogDal;
        private readonly IUowDal _uowDal;

        public BlogManager(IBlogDal blogDal, IUowDal uowDal)
        {
            _blogDal = blogDal;
            _uowDal = uowDal;
        }

        public void TAdd(Blog entity)
        {
            _blogDal.Add(entity);
            _uowDal.Save();
        }

        public void TDelete(Blog entity)
        {
            _blogDal.Delete(entity);
            _uowDal.Save();
        }

        public Blog TGetByID(int id)
        {
            return _blogDal.GetByID(id);
        }

        public List<Blog> TGetList()
        {
            return _blogDal.GetList();
        }

        public void TMultiUpdate(List<Blog> entities)
        {
           _blogDal.MultiUpdate(entities);
            _uowDal.Save();
        }

        public void TUpdate(Blog entity)
        {
            _blogDal.Update(entity);
            _uowDal.Save();
        }
    }
}
