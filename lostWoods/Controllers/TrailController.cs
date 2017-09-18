using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using lostWoods.Factory;
using lostWoods.Models;

namespace lostWoods.Controllers
{
    
    public class TrailController : Controller
    {
        private readonly TrailFactory trailFactory;
        public TrailController()
        {
        trailFactory = new TrailFactory();
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Trails = trailFactory.FindAll();
            return View();
        }

        [HttpGet]
        [Route("addForm")]
        public IActionResult AddForm()
        {
            return View();
        }

        [HttpPost]
        [Route("addTrail")]
        public IActionResult AddTrail(TrailViewModel model)
        {
            if(ModelState.IsValid){
                var Trail = new Trail{
                    name = model.name,
                    length = model.length,
                    elev_change = model.elev_change,
                    longitude = model.longitude,
                    latitude = model.latitude,
                    description = model.description,
                };
                trailFactory.Add(Trail);
                return RedirectToAction("Index");
            }
            return View("AddForm", model);
        }

        [HttpGet]
        [Route("showTrail/{id}")]
        public IActionResult ShowTrail(int id){
            Trail DisplayTrail = new Trail();
            DisplayTrail = trailFactory.FindByID(id);
            return View(DisplayTrail);
        }
    }

}
