﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.EntityLayer.Concrete
{
    public class Service
    {
        public int ServiceID { get; set; }
        public string ServiceTitle { get; set; }
        public string ServiceDescription { get; set; }
        public string ServiceImage { get; set; }
    }
}
