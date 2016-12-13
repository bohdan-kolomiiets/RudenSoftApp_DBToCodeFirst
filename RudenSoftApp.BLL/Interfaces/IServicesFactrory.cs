using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudenSoftApp.BLL.DTO;

namespace RudenSoftApp.BLL.Interfaces
{
    public interface IServicesFactrory
    {
        IUserService CreateUserService();
    }
}
