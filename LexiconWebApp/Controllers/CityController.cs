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
    public class CityController : Controller
{
        private readonly ApplicationDbContext _context;

        public CityController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult City()
        {
            var citiesWithPeople = (from data in _context.Cities.Include("PeopleList") select data).ToList();
            return View(citiesWithPeople);
        }

        [HttpPost]
        public IActionResult DeleteCity(string cityId)
        {

            if (_context.People.Any(ci => ci.CityId == int.Parse(cityId)))
            {
                ViewBag.Error = "unable to delete the city , city added for existing people";
            }
            else
            {
                _context.Cities.RemoveRange(_context.Cities.Where(cr => cr.CityId == int.Parse(cityId)));
                _context.SaveChanges();
            }
            return RedirectToAction("City");
        }
    }
}
