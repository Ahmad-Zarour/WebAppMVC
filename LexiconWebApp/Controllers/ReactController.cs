using LexiconWebApp.Data;
using LexiconWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconWebApp.Controllers
{
    public class ReactController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ReactController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
           
        }
        public IActionResult Index()
        {
            return View();
        }


        // Get list of person from db
        [HttpGet]
        public JsonResult GetListPerson()
        {
            return Json(JsonConvert.SerializeObject(_applicationDbContext.People.ToList()));
        }


        // create person
        [HttpPost]
        public IActionResult CreatePerson(string fullName, string phoneNumber, string city)
        {
           
                var personModel = new PersonModel()
                {
                    FullName = fullName,
                    PhoneNumber = phoneNumber,
                    CityId = int.Parse(city)
                };
                _applicationDbContext.People.Add(personModel);
                _applicationDbContext.SaveChanges();
                return Json(personModel);
           
        }

        [HttpPost]
        public IActionResult DeletePerson (string personId)
        {
            var personModel = new PersonModel() { PersonId = int.Parse(personId) };
            if ((_applicationDbContext.People.Any(p => p.PersonId == int.Parse(personId))))
            {
                _applicationDbContext.Person_Language.RemoveRange
                    (_applicationDbContext.Person_Language.Where
                    (x => x.PersonId == int.Parse(personId)));
                _applicationDbContext.People.Attach(personModel);
                _applicationDbContext.People.Remove(personModel);
                _applicationDbContext.SaveChanges();
                return StatusCode(200);
            }
                return StatusCode(404);
            


        }

        // Get all countries from db
        [HttpGet]
        public JsonResult GetListCountries()
        {
            return Json(JsonConvert.SerializeObject(_applicationDbContext.Countries.ToList()));
        }

        // Get all cities from db
        [HttpGet]
        public JsonResult GetListCities()
        {
            return Json(JsonConvert.SerializeObject(_applicationDbContext.Cities.ToList()));
        }

        // Get all Languages from db
        [HttpGet]
        public JsonResult GetListLanguages()
        {
            return Json(JsonConvert.SerializeObject(_applicationDbContext.Languages.ToList()));
        }

        // Get Data from person_language db
        public JsonResult GetListPersonLanguage()
        {
            return Json(JsonConvert.SerializeObject(_applicationDbContext.Person_Language.ToList()));
        }


    }
}
