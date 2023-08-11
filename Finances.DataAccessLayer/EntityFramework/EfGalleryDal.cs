using Finances.DataAccessLayer.Abstract;
using Finances.DataAccessLayer.Concrete;
using Finances.DataAccessLayer.Repositories;
using Finances.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.DataAccessLayer.EntityFramework
{
    public class EfGalleryDal : GenericRepository<Gallery>, IGalleryDal
    {
        public EfGalleryDal(Context context) : base(context)
        {
        }
    }
}
