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
    public class EfAboutUsServiceDal : GenericRepository<AboutUsService>, IAboutUsServiceDal
    {
        public EfAboutUsServiceDal(Context context) : base(context)
        {
        }
    }
}
