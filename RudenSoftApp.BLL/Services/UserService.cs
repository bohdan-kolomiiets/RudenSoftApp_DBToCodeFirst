using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudenSoftApp.DAL.Interfaces;
using RudenSoftApp.BLL.Interfaces;
using RudenSoftApp.BLL.DTO;
using RudenSoftApp.BLL.Infrastructure;
using System.Security.Claims;
using RudenSoftApp.DAL.Entities;
using Microsoft.AspNet.Identity;

namespace RudenSoftApp.BLL.Services
{
    public class UserService: IUserService
    {
        public IUnitOfWork UOW { get; set; }

        public UserService(IUnitOfWork uow)
        {
            UOW = uow;
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDTO)
        {
            ClaimsIdentity claims = null;
            //find user
            ApplicationUser user = await UOW.UserManager.FindAsync(userDTO.Email, userDTO.Password);
            //authenticate user and return ClaimsIdentity object
            if (user != null)
                claims = await UOW.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            return claims;
        }

        public async Task<OperationDetails> CreateBaseUser(UserDTO userDTO)
        {
            ApplicationUser user = await UOW.UserManager.FindByEmailAsync(userDTO.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDTO.Email, UserName = userDTO.Email };
                var result = await UOW.UserManager.CreateAsync(user, userDTO.Password);
                if (result.Errors.Count() > 0)
                {
                    string totalErrors = "";
                    foreach (string error in result.Errors)
                    {
                        totalErrors += "[" + error + "]" + ", ";
                    }
                    return new OperationDetails(false, totalErrors, "");
                }
                //add role
                foreach (string role in userDTO.Roles)
                    await UOW.UserManager.AddToRoleAsync(user.Id, role);
                //add client's profile
                UserProfile userProfile = new UserProfile { ApplicationUserId = user.Id, Name = userDTO.Name, Age = userDTO.Age };
                UOW.UserProfiles.Create(userProfile);
                return new OperationDetails(true, "Первинна реєстрація виконана.", user.Id);
            }
            else
            {
                return new OperationDetails(false, "Користувач з такою поштою вже зареєстрований.", "Email");
            }
        }

        public async Task<OperationDetails> CreateCustomer(CustomerDTO customerDTO)
        {
            OperationDetails details = await CreateBaseUser(customerDTO as UserDTO);
            if(details.Succeeded == true)
            {
                string userId = details.Message;
                Customer customer = new Customer { UserProfileId = userId, AboutMe = customerDTO.AboutMe, DisctrictId = customerDTO.DistrcitId };
                UOW.Customers.Create(customer);
            }
            await UOW.SaveAsync();
            return new OperationDetails(true, "Реєстрація клієнта успішно завершена", "");
        }
        public async Task<OperationDetails> CreateSeller(SellerDTO sellerDTO)
        {
            OperationDetails details = await CreateBaseUser(sellerDTO as UserDTO);
            if (details.Succeeded == true)
            {
                string userId = details.Message;
                Seller seller = new Seller { /*Specific implementation*/  };
                UOW.Sellers.Create(seller);
            }
            await UOW.SaveAsync();
            return new OperationDetails(true, "Реєстрація продавця успішно завершена", "");
        }
        public async Task<OperationDetails> CreateManager(ManagerDTO managerDTO)
        {
            OperationDetails details = await CreateBaseUser(managerDTO as UserDTO);
            if (details.Succeeded == true)
            {
                string userId = details.Message;
                Manager manager = new Manager { /*Specific implementation*/  };
                UOW.Managers.Create(manager);
            }
            await UOW.SaveAsync();
            return new OperationDetails(true, "Реєстрація менеджера успішно завершена", "");
        }
        public async Task<OperationDetails> CreateMainAdmin(MainAdminDTO mainAdminDTO)
        {
            OperationDetails details = await CreateBaseUser(mainAdminDTO as UserDTO);
            if (details.Succeeded == true)
            {
                string userId = details.Message;
                MainAdmin mainAdmin = new MainAdmin { /*Specific implementation*/  };
                UOW.MainAdmins.Create(mainAdmin);
            }
            await UOW.SaveAsync();
            return new OperationDetails(true, "Реєстрація адміністратора успішно завершена", "");
        }

        public void Dispose()
        {
            UOW.Dispose();
        }
    }
}
