using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using RudenSoftApp.DAL.Interfaces;
using RudenSoftApp.DAL.Entities;
using RudenSoftApp.WEB.Controllers;
using System.Collections.Generic;

namespace RudenSoftApp.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexReturnValueIsNotNull()
        {
            //Arrange
            /*
            var uof = new Mock<IUnitOfWork>();
            var iRepo = new Mock<IRepository<City>>();
            
            iRepo.Setup(m => m.iRepo.GetAll()).Returns(new List<City>());
            HomeController home = new HomeController(iRepo.Object);
             */

        }
    }
}
