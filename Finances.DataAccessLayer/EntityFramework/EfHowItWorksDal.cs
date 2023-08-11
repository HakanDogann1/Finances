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
    public class EfHowItWorksDal : GenericRepository<HowItWorks>, IHowItWorksDal
    {
        public EfHowItWorksDal(Context context) : base(context)
        {
        }
    }
}
