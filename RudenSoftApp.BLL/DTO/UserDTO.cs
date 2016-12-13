using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudenSoftApp.BLL.Interfaces;

namespace RudenSoftApp.BLL.DTO
{
    public class UserDTO: IUserDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public IEnumerable<string> Roles { get; set; } = new List<string>();
    }
}
