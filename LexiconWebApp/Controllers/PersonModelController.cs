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
    public class PersonModelController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IPersonModelRepo _personModelRepo;
        public PersonModelController(ApplicationDbContext applicationDbContext , IPersonModelRepo personModelRepo)
        {
            _applicationDbContext = applicationDbContext;
            _personModelRepo = personModelRepo;
        }
        public IActionResult Index()
        {
            IEnumerable<PersonModel> PersonsList;
            PersonsList = _personModelRepo.GetAllPerson.OrderBy(p => p.PersonId);
            return View(PersonsList);
        }

        [HttpGet]
        public IActionResult GetListPerson()
        {
            List<PersonModel> people = _applicationDbContext.People.Include(person => person.City)
                .Where(person => person.CityId == person.City.CityId).ToList();
           // return PartialView("_partialPeopleList", people);
            return View(people);
        }


        [HttpPost]
        public IActionResult FindById(int id)
        {
            List<PersonModel> personById =
                 _applicationDbContext.People.Include(person => person.City).Where(person => person.PersonId == id)
                 .Where(person => person.CityId == person.City.CityId).ToList();
            return PartialView("_partialPersonList", personById);
        }

        [HttpPost]
        public IActionResult DeletePerson(string id)
        {

            _applicationDbContext.People.RemoveRange(_applicationDbContext.People.Where(x => x.PersonId == int.Parse(id)));
            _applicationDbContext.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult AddPerson(string FullName,
            string PhoneNumber) 
        {
         

            _applicationDbContext.Add(new PersonModel
            {
                FullName = FullName,
                PhoneNumber = PhoneNumber,
                CityId = 2
            });
            _applicationDbContext.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult EditPerson(string personId, string fullName, string phNumber, string cityId)
        {

            var person = _applicationDbContext.People.First(x => x.PersonId == int.Parse(personId));
            person.FullName = fullName;
            person.PhoneNumber = phNumber;
            person.CityId = int.Parse(cityId);
            _applicationDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
