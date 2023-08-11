using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.DtoLayer.DTOs.AboutUs
{
    public class UpdateAboutUsDto
    {
        public int AboutUsID { get; set; }
        public string AboutUsTitle { get; set; }
        public string AboutUsDescription { get; set; }
        public string AboutUsImage { get; set; }
    }
}
