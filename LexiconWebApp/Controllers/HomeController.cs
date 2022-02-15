using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using LexiconWebApp.Models;
using System.Security.Claims;
using System.Net;

namespace LexiconWebApp.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Home Page";
         
            return View();
        }
        public IActionResult About()
        {
            ViewBag.Title = "About me";
            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Title = "Contact me";
            return View();
        }

        public IActionResult Projects()
        {
            ViewBag.Title = "Some Projects";
            return View();
        }

    
        [HttpPost]
        public async Task<IActionResult> ChangeRoles()
        {
          
            var currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await _userManager.FindByIdAsync(currentUserId);

             if (await _userManager.IsInRoleAsync(user, "Admin"))
            {
                var deletionResult = await _userManager.RemoveFromRoleAsync(user, "Admin");
                var addResult = await _userManager.AddToRoleAsync(user, "User");
            }
            else if(await _userManager.IsInRoleAsync(user, "User"))
                    {
                    var deletionResult = await _userManager.RemoveFromRoleAsync(user, "User");
                var addResult = await _userManager.AddToRoleAsync(user, "Admin");
                }


            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {

               


            }
            ViewBag.Message = "The role has changed successfully, Please logout and log in again to apply the change.";
            
            return View("Index");
        }
        
    }
}
