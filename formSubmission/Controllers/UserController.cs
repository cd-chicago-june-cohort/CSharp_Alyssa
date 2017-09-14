using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using formSubmission.Models;

namespace formSubmission.Controllers
{
    public class UserController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("submit")]
        public IActionResult ProcessForm(string First_Name, string Last_Name, int Age, string Email, string Password){
            User NewUser = new User
            {
                First_Name = First_Name,
                Last_Name = Last_Name,
                Age = Age,
                Email = Email,
                Password = Password
            };
            TryValidateModel(NewUser);
            ViewBag.errors = ModelState.Values;
            return View("Result");
        }

    }
}
