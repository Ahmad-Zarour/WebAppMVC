using LexiconWebApp.Data;
using LexiconWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LexiconWebApp.Controllers
{
    public class LanguageController : Controller
{
        private readonly ApplicationDbContext _applicationDbContext;

        public LanguageController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IActionResult Language()
    {
            var result = _applicationDbContext.Languages.Include(x => x.Person_Language).ThenInclude(y => y.Person)
                .ToList();

          return View(result);
    }

        [HttpPost]
        public IActionResult AddLanguage(string languageName)
        {
            _applicationDbContext.Languages.Add(new LanguageModel()
            {
                LanguageName = languageName
            });
            _applicationDbContext.SaveChanges();
            return RedirectToAction("Language");
        }

        [HttpPost]
        public IActionResult EditLanguage(string languageId, string languageName)
        {
            var language = _applicationDbContext.Languages.First(c => c.LanguageId == int.Parse(languageId));
            language.LanguageName = languageName;

            _applicationDbContext.SaveChanges();
            return RedirectToAction("Language");
        }

        [HttpPost]
        public IActionResult DeleteLanguage(string languageId)
        {
            if (!_applicationDbContext.Person_Language.Any(li => li.LanguageId == int.Parse(languageId)))
            {
                _applicationDbContext.Languages.RemoveRange(_applicationDbContext.Languages.Where(li => li.LanguageId == int.Parse(languageId)));
                _applicationDbContext.SaveChanges();
            }
            return RedirectToAction("Language");
        }
    }
}

