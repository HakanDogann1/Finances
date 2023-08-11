﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.EntityLayer.Concrete
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string ContactName { get; set; }
        public string ContactSurname { get; set; }
        public string ContactEmail { get; set; }
        public string ContactSubject { get; set; }
        public string ContactMessage { get; set; }
    }
}
