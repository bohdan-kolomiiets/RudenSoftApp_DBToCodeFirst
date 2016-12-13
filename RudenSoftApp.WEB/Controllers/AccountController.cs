using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RudenSoftApp.BLL.Interfaces;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using RudenSoftApp.WEB.ViewModels;
using RudenSoftApp.BLL.DTO;
using RudenSoftApp.BLL.Infrastructure;
using System.Security.Claims;

namespace RudenSoftApp.WEB.Controllers
{
    public class AccountController : Controller
    {
        private IUserService UserService
        {
            get
            {
                //Поскольку ранее мы зарегитрировали сервис пользователей через контекст OWIN, то теперь мы можем получить этот сервис с помощью метода
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                UserDTO userDTO = new UserDTO { Email = model.Email, Password = model.Password };
                ClaimsIdentity claims = await UserService.Authenticate(userDTO);
                if(claims == null)
                {
                    ModelState.AddModelError("", "Невірний логін або пароль.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, claims);
                    return RedirectToAction(returnUrl);
                }
            }
            return View(model);
        }
        
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult CustomerRegister()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> CustomerRegister(CustomerRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                CustomerDTO customerDTO = new CustomerDTO
                {
                    Name = model.FirstName + " " + model.LastName,
                    Age = model.Age,
                    Email = model.Email,
                    Password = model.Password,
                    AboutMe = model.AboutMe,
                    Roles = new List<string> { "customer" },
                    DistrcitId = model.DistrictId
                };
                OperationDetails operationDetails = await UserService.CreateCustomer(customerDTO);
                if (operationDetails.Succeeded)
                    return View("SuccessRegister");
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }
    }
}