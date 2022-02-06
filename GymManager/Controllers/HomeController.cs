using GymManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace GymManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private UserManager<AppUser> userManager;
        public HomeController(UserManager<AppUser> userMgr)
        {
            userManager = userMgr;
        }

        /*  public HomeController(ILogger<HomeController> logger)
          {
              _logger = logger;
          }*/
        [Authorize(Roles = "Manager,Admin,User")]

        public async Task<IActionResult> Index()
        {
            AppUser user = await userManager.GetUserAsync(HttpContext.User);
            string message = "Hello " + user.UserName;
            return View((object)message);

        }

        [HttpPost]
        public async Task<IActionResult> Index(int id = 0)
        {
            AppUser user = await userManager.GetUserAsync(HttpContext.User);
            string message = "Hello " + user.UserName;
            ViewBag.Layout = "~/Views/Shared/_Layout2.cshtml";
            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
