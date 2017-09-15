using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using logReg.Models;
using DbConnection;

namespace logReg.Controllers
{
    public class UserController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Register");
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(User user)
        {
            if(ModelState.IsValid){
                DbConnector.Execute($"INSERT INTO users (first_name, last_name, email, password) VALUES ('{user.first_name}', '{user.last_name}', '{user.email}', '{user.password}')");
                return RedirectToAction("Success");
            }
            return View(user);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(User user)
        {
            List<Dictionary<string, object>> found = DbConnector.Query($"SELECT * FROM users WHERE email = '{user.email}'");
            if (found.Count == 0){
                ViewBag.error = "User not found";
                return View("Register");
            } else if ((string)found[0]["password"] != user.password) {
                ViewBag.error = "Incorrect password";
                return View("Register");
            } else {
                return RedirectToAction("Success");
            }
        }

        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
            return View();
        }
    }
}
