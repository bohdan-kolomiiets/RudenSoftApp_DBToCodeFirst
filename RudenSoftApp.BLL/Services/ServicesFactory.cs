using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudenSoftApp.BLL.DTO;
using RudenSoftApp.BLL.Interfaces;
using RudenSoftApp.DAL.Interfaces;
using RudenSoftApp.DAL.Repositories;

namespace RudenSoftApp.BLL.Services
{
    public class ServicesFactory : IServicesFactrory
    {
        IUnitOfWork UOW;
        public ServicesFactory(string connectionString)
        {
            UOW = new EFUnitOfWork(connectionString);
        }
        public IUserService CreateUserService()
        {
            return new UserService(UOW);
        }

    }
}
