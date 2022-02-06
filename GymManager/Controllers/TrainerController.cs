using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using GymManager.Models;
using System.Threading.Tasks;

namespace GymManager.Controllers
{
    public class TrainerController : Controller
    {
        private readonly MvcTrainerContext _context;

       /* public TrainerController(MvcTrainerContext context)
        {
            _context = context;
        }*/

        public IActionResult Index()
        {
            return View(Repository.AllTrainers);
        }

        public IActionResult Hello()
        {
            ViewBag.Message = "Hello World";
            return View();
        }


        //HTTP GET 
        public IActionResult Create()
        {
            return View();
        }

        //HTTP POST
        [HttpPost]
        public IActionResult Create(Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                Repository.Create(trainer);
                return View("Thanks", trainer);
            }
            else
                return View();
        }

        //GET
        public IActionResult Update(string cname)
        {
            Trainer trainer = Repository.AllTrainers.Where(e => e.Name == cname).FirstOrDefault(); // <-- LINQ Search at Repository.AllClients.Where
            return View(trainer);
        }

        //POST
        [HttpPost]
        public IActionResult Update(Trainer trainer, string cname)
        {
            if (ModelState.IsValid)
            {
                Repository.AllTrainers.Where(c => c.Name == cname).FirstOrDefault().Name = trainer.Name;
                Repository.AllTrainers.Where(c => c.Name == cname).FirstOrDefault().Specialization = trainer.Specialization;
                Repository.AllTrainers.Where(c => c.Name == cname).FirstOrDefault().Phone = trainer.Phone;
                return RedirectToAction("Index");
            }
            else
                return View();


        }

        [HttpPost]
        public IActionResult Delete(string cname)
        {
            Trainer trainer = Repository.AllTrainers.Where(trainer => trainer.Name == cname).FirstOrDefault();
            Repository.Delete(trainer);

            return RedirectToAction("Index");
        }

        // Validation 
        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> VerifySpecialization(string Phone, string Email)
        {
            var phone = await _context.Trainer
                .FirstOrDefaultAsync(m => m.Phone.Equals(Phone) ||
                                            m.Email == Email);
            if (phone == null)
                return Json(true);
            else
                return Json($" {phone} or  {Email} already exists, dont lie.");
        }

    }
}
