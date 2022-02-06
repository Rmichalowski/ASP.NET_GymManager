using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using GymManager.Models;

namespace GymManager.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View(Repository.AllClients);
        }

        public IActionResult Hello()
        {
            ViewBag.Message = "Hello World";
            return View();
        }

        public IActionResult Info()
        {
            Client client = new Client();
            client.Name = "Anthon";
            client.Age = 58;
            client.Phone = "591123123";
            return View(client);
        }

        //HTTP GET 
        public IActionResult Create()
        {
            return View();
        }

        //HTTP POST
        [HttpPost]
        public IActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
                Repository.Create(client);
                return View("Thanks", client);
            }
            else
                return View();
        }

        //GET
        public IActionResult Update(string cname)
        {
            Client client = Repository.AllClients.Where(e => e.Name == cname).FirstOrDefault(); // <-- LINQ Search at Repository.AllClients.Where
            return View(client);
        }

        //POST
        [HttpPost]
        public IActionResult Update(Client client, string cname)
        {
            if (ModelState.IsValid)
            {
                Repository.AllClients.Where(c => c.Name == cname).FirstOrDefault().Name = client.Name;
                Repository.AllClients.Where(c => c.Name == cname).FirstOrDefault().Age = client.Age;
                Repository.AllClients.Where(c => c.Name == cname).FirstOrDefault().Phone = client.Phone;
                return RedirectToAction("Index");
            }
            else
                return View();


        }

        [HttpPost]
        public IActionResult Delete(string cname)
        {
            Client client = Repository.AllClients.Where(client => client.Name == cname).FirstOrDefault();
            Repository.Delete(client);

            return RedirectToAction("Index");
        }

    }
}
