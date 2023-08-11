using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.EntityLayer.Concrete
{
    public class Header
    {
        public int HeaderID { get; set; }
        public string HeaderTitle1 { get; set; }
        public string HeaderTitle2 { get; set; }
        public string HeaderImage { get; set; }
    }
}
