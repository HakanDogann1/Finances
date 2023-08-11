using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.DtoLayer.DTOs.Blog
{
    public class ResultBlogDto
    {
        public int BlogID { get; set; }
        public string BlogTitle { get; set; }
        public string BlogDescription { get; set; }
        public DateTime BlogDate { get; set; }
        public string BlogWriter { get; set; }
        public string BlogImage { get; set; }
    }
}
