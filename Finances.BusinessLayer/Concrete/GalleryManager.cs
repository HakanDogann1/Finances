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
    public class GalleryManager : IGalleryService
    {
        private readonly IGalleryDal _galleryDal;
        private readonly IUowDal _uowDal;

        public GalleryManager(IGalleryDal galleryDal, IUowDal uowDal)
        {
            _galleryDal = galleryDal;
            _uowDal = uowDal;
        }

        public void TAdd(Gallery entity)
        {
            _galleryDal.Add(entity);
            _uowDal.Save();
        }

        public void TDelete(Gallery entity)
        {
            _galleryDal.Delete(entity);
            _uowDal.Save();
        }

        public Gallery TGetByID(int id)
        {
            return _galleryDal.GetByID(id);
        }

        public List<Gallery> TGetList()
        {
            return _galleryDal.GetList();
        }

        public void TMultiUpdate(List<Gallery> entities)
        {
            _galleryDal.MultiUpdate(entities);
            _uowDal.Save();
        }

        public void TUpdate(Gallery entity)
        {
            _galleryDal.Update(entity);
            _uowDal.Save();
        }
    }
}
