﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.DtoLayer.DTOs.HowItWorks
{
    public class UpdateHowItWorksDto
    {
        public int HowItWorksID { get; set; }
        public string HowItWorksTitle { get; set; }
        public string HowItWorksDescription { get; set; }
    }
}
