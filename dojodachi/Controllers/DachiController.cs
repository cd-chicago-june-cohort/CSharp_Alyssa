using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace YourNamespace.Controllers
{
    public class DachiController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            int? happiness = HttpContext.Session.GetInt32("happiness");
            int? fullness = HttpContext.Session.GetInt32("fullness");
            int? energy = HttpContext.Session.GetInt32("energy");
            int? meals = HttpContext.Session.GetInt32("meals");
            string message = HttpContext.Session.GetString("message");
            if (happiness == null){
                happiness = 20;
                fullness = 20;
                energy = 50;
                meals = 3;
                message = "Please take care of your Dojodachi!  Select a button below to play.";
                HttpContext.Session.SetInt32("happiness", (int)happiness);
                HttpContext.Session.SetInt32("fullness", (int)fullness);
                HttpContext.Session.SetInt32("energy", (int)energy);
                HttpContext.Session.SetInt32("meals", (int)meals);
            }
            if (energy >= 100 && fullness >= 100 && happiness >= 100){
                message = "Congratulations! You won!";
                ViewBag.restart = true;
            }
            if (fullness <= 0 || happiness <= 0){
                message = "Your Dojodachi has passed away.";
                ViewBag.restart = true;
            }
            ViewBag.happiness = happiness;
            ViewBag.fullness = fullness;
            ViewBag.energy = energy;
            ViewBag.meals = meals;
            ViewBag.message = message;
            return View();
        }

        [HttpGet]
        [Route("feed")]
        public IActionResult Feed()
        {
            Random rand = new Random();
            int? fullness = HttpContext.Session.GetInt32("fullness");
            int? meals = HttpContext.Session.GetInt32("meals");
            int like = rand.Next(1,5);
            if (meals == 0){
                HttpContext.Session.SetString("message", "You do not have any meals to feed your Dojodachi!  Consider working first!");
            } else if (like == 1){
                HttpContext.Session.SetString("message", "Your Dojodachi didn't like that meal! Meals -1, Fullness (no change)!");
                HttpContext.Session.SetInt32("meals", (int)(meals-1));
            } else {
                HttpContext.Session.SetInt32("meals", (int)(meals-1));
                int fullnessIncrease = rand.Next(5,11);
                HttpContext.Session.SetInt32("fullness", (int)(fullness) + fullnessIncrease);
                HttpContext.Session.SetString("message", $"You fed your Dojodachi! Meals -1, Fullness +{fullnessIncrease}");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("play")]
        public IActionResult Play()
        {
            Random rand = new Random();
            int? happiness = HttpContext.Session.GetInt32("happiness");
            int? energy = HttpContext.Session.GetInt32("energy");
            int like = rand.Next(1,5);
            if (energy <5){
                HttpContext.Session.SetString("message", "You do not have enough energy to play with your Dojodachi!  Consider sleeping first!");
            } else if(like == 1){
                HttpContext.Session.SetString("message", "Your Dojodachi didn't like that game! Energy -5, Happiness (no change)!");
                HttpContext.Session.SetInt32("energy", (int)(energy-5));
            } else {
                int happinessIncrease = rand.Next(5,11);
                HttpContext.Session.SetInt32("energy", (int)(energy-5));
                HttpContext.Session.SetInt32("happiness", (int)(happiness) + happinessIncrease);
                HttpContext.Session.SetString("message", $"You played with your Dojodachi! Happiness +{happinessIncrease}, Energy -5");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("work")]
        public IActionResult Work()
        {
            Random rand = new Random();
            int? meals = HttpContext.Session.GetInt32("meals");
            int? energy = HttpContext.Session.GetInt32("energy");
            if (energy <5){
                HttpContext.Session.SetString("message", "You do not have enough energy to work!  Consider sleeping first!");
            } else {
                int mealsIncrease = rand.Next(1,4);
                HttpContext.Session.SetInt32("energy", (int)(energy-5));
                HttpContext.Session.SetInt32("meals", (int)(meals) + mealsIncrease);
                HttpContext.Session.SetString("message", $"You worked very hard! Meals +{mealsIncrease}, Energy -5");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("sleep")]
        public IActionResult Sleep()
        {
            int? fullness = HttpContext.Session.GetInt32("fullness");
            int? happiness = HttpContext.Session.GetInt32("happiness");
            int? energy = HttpContext.Session.GetInt32("energy");
            HttpContext.Session.SetInt32("energy", (int)(energy+15));
            HttpContext.Session.SetInt32("fullness", (int)(fullness-5));
            HttpContext.Session.SetInt32("happiness", (int)(happiness-5));
            HttpContext.Session.SetString("message", "You slept soundly! Energy +15, Fullness -5, Happiness -5");
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("restart")]
        public IActionResult Restart()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}