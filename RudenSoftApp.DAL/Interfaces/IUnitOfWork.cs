using RudenSoftApp.DAL.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudenSoftApp.DAL.Entities;

namespace RudenSoftApp.DAL.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        void Save();

        IRepository<City> Cities { get; }
        IRepository<District> District { get; }
        IRepository<Office> Offices { get; }
        IRepository<Order> Orders { get; }
        IRepository<OrderItem> OrderItems { get; }
        IRepository<Product> Products { get; }

        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }

        IClientManager<UserProfile> UserProfiles { get; }
        IClientManager<Customer> Customers { get; }
        IClientManager<MainAdmin> MainAdmins { get; }
        IClientManager<Manager> Managers { get; }
        IClientManager<Seller> Sellers { get; }

        Task SaveAsync();
    }
}
