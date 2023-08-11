using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.DtoLayer.DTOs.Account
{
    public class AddAccountDto
    {
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        public double AccountAmount { get; set; }
    }
}
