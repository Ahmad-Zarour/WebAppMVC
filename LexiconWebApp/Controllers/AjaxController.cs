using LexiconWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconWebApp.Controllers
{
    public class AjaxController : Controller
{
    public IActionResult Index()
    {
            //CreatePersonViewModel createPersonViewModel = new CreatePersonViewModel();
            //PeopleViewModel peopleViewModel = new PeopleViewModel() { PeopleListViewModel = createPersonViewModel.GetListPerson() };
            //if (peopleViewModel.PeopleListViewModel.Count == 0)
            //    createPersonViewModel.MockPersonRepo();
            //return View(peopleViewModel);     
            return View();     
    }

        [HttpGet]
        public IActionResult GetPerson()
        { 
            CreatePersonViewModel createPersonViewModel = new CreatePersonViewModel();
            
            List<Person> personList = createPersonViewModel.GetListPerson();
            return PartialView("_partialPeopleList", personList);   
        }


        [HttpPost]
        public IActionResult DeletePerson(int personId)
        {
            CreatePersonViewModel createPersonViewModel = new CreatePersonViewModel();
            Person person = createPersonViewModel.GetPersonById(personId);

            if (person != null)
            {
                if (createPersonViewModel.DeletePerson(person))
                    return StatusCode(200); //Status200OK	HTTP status code 200.
            }
            return StatusCode(400); // Status400BadRequest HTTP status code 400.
        }


        [HttpPost]
        public IActionResult FindPersonById(int personId)
        {
            CreatePersonViewModel createPersonViewModel = new CreatePersonViewModel();
            Person person = createPersonViewModel.GetPersonById(personId);
            List<Person> PersonList = new List<Person>();

            if (person != null) PersonList.Add(person);
            return PartialView("_partialPeopleList", PersonList);
        }
    }
}
