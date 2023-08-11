using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.DtoLayer.DTOs.AboutUsService
{
    public class UpdateAboutUsServiceDto
    {
        public int AboutUsServiceID { get; set; }
        public string AboutUsServiceTitle { get; set; }
        public string AboutUsServiceDescription { get; set; }
        public string AboutUsServiceImage { get; set; }
    }
}
