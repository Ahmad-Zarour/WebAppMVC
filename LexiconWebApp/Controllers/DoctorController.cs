using LexiconWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconWebApp.Controllers
{
    public class DoctorController : Controller
    {
        [HttpGet("Doctor/FeverCheck")]
        public IActionResult FeverCheck()
        {
            return View();
        }
        
        [HttpPost("Doctor/FeverCheck")]
        public IActionResult FeverCheck(float temperature)
        {
            ViewBag.message = FeverCheckerModel.Fever(temperature);
            return View();
        }
    }
}
