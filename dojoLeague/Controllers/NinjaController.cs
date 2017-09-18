using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using dojoLeague.Models;
using dojoLeague.Factory;

namespace dojoLeague.Controllers
{
    public class NinjaController : Controller
    {
        private readonly NinjaFactory ninjaFactory;
        private readonly DojoFactory dojoFactory;
        public NinjaController()
        {
            ninjaFactory = new NinjaFactory();
            dojoFactory = new DojoFactory();
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        [Route("Ninjas")]
        public IActionResult Index()
        {
            ViewBag.Ninjas = ninjaFactory.FindAll();
            ViewBag.Dojos = dojoFactory.FindAll();
            return View();
        }

        [HttpPost]
        [Route("addNinja")]
        public IActionResult AddNinja(Ninja ninja, int dojo)
        {
            if(ModelState.IsValid){
                ninja.dojo_id = dojo;
                ninjaFactory.Add(ninja);
                return RedirectToAction("Index");
            };
            return View("Index", ninja);
        }

        [HttpGet]
        [Route("Ninja/{id}")]
        public IActionResult ShowNinja(int id)
        {
            Ninja DisplayNinja = new Ninja();
            DisplayNinja = ninjaFactory.FindByID(id);
            DisplayNinja.dojo = dojoFactory.FindByID(DisplayNinja.dojo_id);
            return View(DisplayNinja);
        }

        [HttpGet]
        [Route("Recruit/{id}/{dojo_id}")]
        public IActionResult Recruit(int id, int dojo_id)
        {
            ninjaFactory.UpdateDojo(id, dojo_id);
            return RedirectToAction("ShowDojo", "Dojo", new { id = dojo_id });
        }

        [HttpGet]
        [Route("Banish/{id}/{dojo_id}")]
        public IActionResult Banish(int id, int dojo_id)
        {
            ninjaFactory.UpdateDojo(id, 1);
            return RedirectToAction("ShowDojo", "Dojo", new { id = dojo_id });
        }
    }
}
