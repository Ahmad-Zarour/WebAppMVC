using LexiconWebApp.Data;
using LexiconWebApp.Models;
using LexiconWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Threading.Tasks;

namespace LexiconWebApp.Controllers
{

    public class CityController : Controller
{
      
        private readonly ApplicationDbContext _applicationDbContext;

        public CityController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        
        public IActionResult City()

        {
            CityViewModel items = new CityViewModel
            {
                Countries = _applicationDbContext.Countries.ToList(),
                Cities =
              (from data in _applicationDbContext.Cities.Include("PeopleList")
               select data).ToList()
            };
            return View(items);
        }

        [HttpPost]
        public IActionResult DeleteCity(string cityId)
        {

            if (!_applicationDbContext.People.Any(ci => ci.CityId == int.Parse(cityId)))
            {
                _applicationDbContext.Cities.RemoveRange(_applicationDbContext.Cities.Where(cr => cr.CityId == int.Parse(cityId)));
                _applicationDbContext.SaveChanges();
            }
            return RedirectToAction("City");
        }


        [HttpPost]
        public IActionResult EditCity(string cityId, string cityName, string countryId)
        {
            var city = _applicationDbContext.Cities.First(a => a.CityId == int.Parse(cityId));
            city.CityName = cityName;
            city.CountryId = int.Parse(countryId);
            _applicationDbContext.SaveChanges();
            return RedirectToAction("City");
        }


        [HttpPost]
        public IActionResult AddCity(string cityName, string countryId)
        {
            if(cityName  != null && countryId != null)
            _applicationDbContext.Cities.Add(new CityModel()
            {
                CityName = cityName,
                CountryId = int.Parse(countryId)
            });
            _applicationDbContext.SaveChanges();

            return RedirectToAction("City");
        }
    }
}
