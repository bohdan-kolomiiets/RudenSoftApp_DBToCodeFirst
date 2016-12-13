using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RudenSoftApp.DAL.Interfaces;
using RudenSoftApp.DAL.Entities;

namespace RudenSoftApp.WEB.Controllers
{
    public class HomeController : Controller
    {
        IUnitOfWork UOF;
        public HomeController(IUnitOfWork uof)
        {
            UOF = uof;
        }
        public ActionResult Index()
        {
            List<City> cities = UOF.Cities.GetAll().ToList();
            City city = new City { Name = "Kiev" };
            UOF.Cities.Create(city);
            UOF.Save();
            return View(UOF.Cities.GetAll());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}