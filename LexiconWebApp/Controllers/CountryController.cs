using LexiconWebApp.Data;
using LexiconWebApp.Models;
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
        private readonly ApplicationDbContext _applicationDbContext;

        public CountryController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IActionResult Country()
        {
            var countryWithCities = (from data in _applicationDbContext.Countries.Include("Cities") select data).ToList();
            return View(countryWithCities);
        }

        [HttpPost]
        public IActionResult DeleteCountry(string countryId)
        {

            if (!_applicationDbContext.Cities.Any(ci => ci.CountryId == int.Parse(countryId)))
            {

                var country = _applicationDbContext.Countries.Where(cr => cr.CountryId == int.Parse(countryId));
                _applicationDbContext.Countries.RemoveRange(country);
                _applicationDbContext.SaveChanges();
            }
            return RedirectToAction("Country");
        }


        [HttpPost]
        public IActionResult AddCountry(string countryName)
        {
            _applicationDbContext.Countries.Add(new CountryModel()
            {
                CountryName = countryName
            });
            _applicationDbContext.SaveChanges();
            return RedirectToAction("Country");
        }

        [HttpPost]
        public IActionResult EditCountry(string countryId, string countryName)
        {
            
            var country = _applicationDbContext.Countries.First(c => c.CountryId == int.Parse(countryId));
            country.CountryName = countryName;

            _applicationDbContext.SaveChanges();
            return RedirectToAction("Country");
        }
    }
}
