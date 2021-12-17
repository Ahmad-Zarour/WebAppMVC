using LexiconWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconWebApp.Controllers
{
    public class CountryController : Controller
{
        private readonly ApplicationDbContext _context;

        public CountryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
    {
            var countryWithCities = (from data in _context.Countries.Include("Cities") select data).ToList();
            return View(countryWithCities);
        }
}
}
