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


        public IActionResult Index()
        {
            var citiesWithPeople = (from data in _context.Cities.Include("PeopleList") select data).ToList();
            return View(citiesWithPeople);
        }
    }
}
