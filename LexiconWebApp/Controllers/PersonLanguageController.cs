using LexiconWebApp.Data;
using LexiconWebApp.Models;
using LexiconWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace LexiconWebApp.Controllers
{
    public class PersonLanguageController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PersonLanguageController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IActionResult PersonLanguage()
        {
            PersonLanguageViewModel personLanguage = new PersonLanguageViewModel
            {
                People = _applicationDbContext.People.ToList(),
                Languages = _applicationDbContext.Languages.ToList(),
                PeopleLanguages = _applicationDbContext.Person_Language.ToList()
            };
            return View(personLanguage);
        }

        public IActionResult AddLanguageToPerson(string personId, string languageId)
        {
            if (!_applicationDbContext.Person_Language.Any
                (x => x.PersonId == int.Parse(personId) &&
                x.LanguageId == int.Parse(languageId)))
           
            {
                _applicationDbContext.Person_Language.Add(new PersonLanguageModel()
                {
                    PersonId = int.Parse(personId),
                    LanguageId = int.Parse(languageId)
                });
                _applicationDbContext.SaveChanges(); 
            }
            return RedirectToAction("PersonLanguage");
        }

        public IActionResult DeleteLanguageToPerson(string personId, string languageId)
        {
            if (_applicationDbContext.Person_Language.Any
                (x => x.PersonId == int.Parse(personId) ||
                x.LanguageId == int.Parse(languageId)))

            {
                _applicationDbContext.Person_Language.RemoveRange(_applicationDbContext.Person_Language.Where(cr => cr.LanguageId == int.Parse(languageId)));
                _applicationDbContext.SaveChanges();
            }
            return RedirectToAction("PersonLanguage");
        }
    }
}
