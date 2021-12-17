using LexiconWebApp.Data;
using LexiconWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LexiconMVC_Data.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PeopleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult PeopleList()
        {

            List<PersonModel> people = _context.People.ToList();

            return View(people);
        }

       

        [HttpGet]
        public IActionResult GetListPerson()
        {
            List<PersonModel> people = _context.People .Include(person => person.City)
                .Where(person => person.CityId == person.City.CityId).ToList();
            return PartialView("_partialPeopleList",people);
        }


        [HttpPost]
        public IActionResult FindById(int id)
        {
            List<PersonModel> personById =
                 _context.People.Include(person => person.City).Where(person => person.PersonId == id)
                 .Where(person => person.CityId == person.City.CityId).ToList();
            return PartialView("_partialPersonList",personById);
        }


        [HttpPost]
        public IActionResult DeletePerson(int id)
        {
            PersonModel temp =(from person in _context.People.ToList() where person.PersonId == id
                 select person).FirstOrDefault();
            _context.People.Remove(temp);
            return RedirectToAction("PeopleList");
        }

    }
}
