using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudenSoftApp.BLL.DTO
{
    public class ManagerDTO: UserDTO
    {
        public string AboutMe { get; set; }
        public int DistrcitId { get; set; }

    }
}
