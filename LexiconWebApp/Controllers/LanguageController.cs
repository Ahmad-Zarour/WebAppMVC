using LexiconWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LexiconWebApp.Controllers
{
    public class LanguageController : Controller
{
        private readonly ApplicationDbContext _context;

        public LanguageController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
    {
            var result = _context.Languages.Include(x => x.Person_Language).ThenInclude(y => y.Person)
                .ToList();

          return View(result);
    }
}
}

