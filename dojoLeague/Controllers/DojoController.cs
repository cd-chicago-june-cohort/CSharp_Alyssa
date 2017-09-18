using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using dojoLeague.Models;
using dojoLeague.Factory;

namespace dojoLeague.Controllers
{
    public class DojoController : Controller
    {
        private readonly DojoFactory dojoFactory;
        public DojoController()
        {
            dojoFactory = new DojoFactory();
        }
        // GET: /Home/
        [HttpGet]
        [Route("Dojos")]
        public IActionResult Index()
        {
            ViewBag.Dojos = dojoFactory.FindAll();
            return View();
        }

        [HttpPost]
        [Route("addDojo")]
        public IActionResult AddDojo(Dojo dojo){
            if(ModelState.IsValid){
                dojoFactory.Add(dojo);
                return RedirectToAction("Index");
            };
            return View("Index", dojo);
        }

        [HttpGet]
        [Route("Dojo/{id}")]
        public IActionResult ShowDojo(int id){
            Dojo DisplayDojo = new Dojo();
            DisplayDojo = dojoFactory.FindByID(id);
            Dojo RogueNinjas = new Dojo();
            RogueNinjas = dojoFactory.FindByID(1);
            ViewBag.Rogue = RogueNinjas;
            return View(DisplayDojo);
        }
    }
}