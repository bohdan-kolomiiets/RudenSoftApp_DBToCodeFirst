using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudenSoftApp.DAL.Entities;
using RudenSoftApp.DAL.Identity;
using RudenSoftApp.DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RudenSoftApp.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private AppContext db;

        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;

        private IClientManager<UserProfile> userProfileRepository;
        private ClientManager<Seller> sellerRepository;
        private ClientManager<Customer> customerRepository;
        private ClientManager<MainAdmin> mainAdminRepository;
        private ClientManager<Manager> managerRepository;

        private Repository<City> cityRepository;
        private Repository<District> districtRepository;
        private Repository<Office> officeRepository;
        private Repository<Order> orderRepository;
        private Repository<OrderItem> orderItemRepository;
        private Repository<Product> productRepository;
        
        public EFUnitOfWork(string connectionString)
        {
            db = new AppContext(connectionString);
        }

        public IRepository<City> Cities
        {
            get
            {
                if (cityRepository == null)
                    cityRepository = new Repository<City>(db);
                return cityRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public IClientManager<Customer> Customers
        {
            get
            {
                if (customerRepository == null)
                    customerRepository = new ClientManager<Customer>(db);
                return customerRepository;
            }
        }
        public IRepository<District> District
        {
            get
            {
                if (districtRepository == null)
                    districtRepository = new Repository<District>(db);
                return districtRepository;
            }
        }
        public IClientManager<MainAdmin> MainAdmins
        {
            get
            {
                if (mainAdminRepository == null)
                    mainAdminRepository = new ClientManager<MainAdmin>(db);
                return mainAdminRepository;
            }
        }
        public IClientManager<Manager> Managers
        {
            get
            {
                if (managerRepository == null)
                    managerRepository = new ClientManager<Manager>(db);
                return managerRepository;
            }
        }
        public IRepository<Office> Offices
        {
            get
            {
                if (officeRepository == null)
                    officeRepository = new Repository<Office>(db);
                return officeRepository;
            }
        }
        public IRepository<OrderItem> OrderItems
        {
            get
            {
                if (orderItemRepository == null)
                    orderItemRepository = new Repository<OrderItem>(db);
                return orderItemRepository;
            }
        }
        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new Repository<Order>(db);
                return orderRepository;
            }
        }
        public IRepository<Product> Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new Repository<Product>(db);
                return productRepository;
            }
        }
        public ApplicationRoleManager RoleManager
        {
            get
            {
                if(roleManager == null)
                    roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
                return roleManager;
            }
        }
        public IClientManager<Seller> Sellers
        {
            get
            {
                if (sellerRepository == null)
                    sellerRepository = new ClientManager<Seller>(db);
                return sellerRepository;
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                if(userManager == null)
                    userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
                return userManager;
            }
        }

        public IClientManager<UserProfile> UserProfiles
        {
            get
            {
                if (userProfileRepository == null)
                    userProfileRepository = new ClientManager<UserProfile>(db);
                return userProfileRepository;
            }
        }
    }
}
