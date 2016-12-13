using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudenSoftApp.BLL.Interfaces
{
    public interface IUserDTO
    {
        string Id { get; }
        string Email { get; }
        string Password { get; }
        string Name { get; }
        int? Age { get; }
        IEnumerable<string> Roles { get; }
    }
}
