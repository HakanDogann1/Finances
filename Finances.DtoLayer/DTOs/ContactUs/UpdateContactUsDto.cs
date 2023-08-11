using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.DtoLayer.DTOs.ContactUs
{
    public class UpdateContactUsDto
    {
        public int ContactUsID { get; set; }
        public string ContactUsIcon { get; set; }
        public string ContactUsLocation { get; set; }
    }
}
