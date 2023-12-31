﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.EntityLayer.Concrete
{
    public class Account
    {
        public int AccountID { get; set; }
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        public AppUser AppUser { get; set; }
        public double AccountAmount { get; set; }
    }
}
