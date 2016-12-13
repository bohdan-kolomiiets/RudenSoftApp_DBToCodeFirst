using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudenSoftApp.BLL.Infrastructure;
using RudenSoftApp.BLL.DTO;
using System.Security.Claims;

namespace RudenSoftApp.BLL.Interfaces
{
    public interface IUserService: IDisposable
    {
        Task<OperationDetails> CreateBaseUser(UserDTO userDTO);
        Task<OperationDetails> CreateCustomer(CustomerDTO customerDTO);
        Task<OperationDetails> CreateSeller(SellerDTO sellerDTO);
        Task<OperationDetails> CreateManager(ManagerDTO managerDTO);
        Task<OperationDetails> CreateMainAdmin(MainAdminDTO adminDTO);
        Task<ClaimsIdentity> Authenticate(UserDTO userDTO);
    }
}
