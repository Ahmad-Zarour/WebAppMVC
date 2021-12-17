using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }
        public IActionResult About()
        {
            ViewBag.Title = "About me";
            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Title = "Contact me";
            return View();
        }

        public IActionResult Projects()
        {
            ViewBag.Title = "Some Projects";
            return View();
        }
    }
}
