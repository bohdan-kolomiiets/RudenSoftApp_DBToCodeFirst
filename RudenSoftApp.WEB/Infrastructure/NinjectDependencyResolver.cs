﻿using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using RudenSoftApp.DAL;
using RudenSoftApp.BLL;

namespace RudenSoftApp.WEB.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            //kernel.Bind<DAL.Interfaces.IUnitOfWork>().To<DAL.Repositories.EFUnitOfWork>().WithConstructorArgument("AppContext");
            //kernel.Bind<BLL.Interfaces.IServicesFactrory>().To<BLL.Services.ServicesFactory>().WithConstructorArgument("AppContext");

        }
    }
}
