using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.AspNet.Identity;
using RudenSoftApp.BLL.Interfaces;
using RudenSoftApp.BLL.Services;
using RudenSoftApp.BLL.DTO;
using RudenSoftApp.DAL.Interfaces;

[assembly: OwinStartup(typeof(RudenSoftApp.App_Start.Startup))]

namespace RudenSoftApp.App_Start
{
    public class Startup
    {
        IServicesFactrory serviceFactory = new ServicesFactory("AppContext");
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(serviceFactory.CreateUserService);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }
    }
}