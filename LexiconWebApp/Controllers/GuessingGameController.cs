using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconWebApp.Controllers
{
    public class GuessingGameController : Controller
    {
		[HttpGet("GuessingGame")]
		public IActionResult GuessingGame()
        {
			HttpContext.Session.SetInt32("randNum",new Random().Next(0, 100));
			return View();
        }

		[HttpPost("GuessingGame")]
		public IActionResult GuessingGame(int userInput) 
		{
			ViewBag.ResultMessage = null;
			int randNum = (int)HttpContext.Session.GetInt32("randNum");
			if ((userInput < 0) || (userInput > 100))
				ViewBag.ResultMessage = "Valid numbers are between 0 and 100";
			else if (userInput > randNum)
				ViewBag.ResultMessage = $"{userInput} is Bigger than the guess number";
			else if (userInput < randNum)
				ViewBag.ResultMessage = $"{userInput} is smaller than the guess number";
			else if (userInput == randNum)
				ViewBag.ResultMessage = $"You did it! You found the right guess number :{randNum}.";
			return View();
		}
	}
}