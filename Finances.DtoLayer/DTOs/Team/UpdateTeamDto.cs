using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.DtoLayer.DTOs.Team
{
    public class UpdateTeamDto
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public string TeamSurname { get; set; }
        public string TeamDepartment { get; set; }
        public string TeamImage { get; set; }
    }
}
