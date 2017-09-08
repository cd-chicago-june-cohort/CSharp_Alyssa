using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers
{
    public class PasscodeController : Controller
    {
        public string GetPasscode(){
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            Random rand = new Random();
            char[] passcodeArr = new char[14];
            for (int i=0; i<passcodeArr.Length; i++){
                passcodeArr[i] = characters[rand.Next(characters.Length)];
            }
            string passcode = new String(passcodeArr);
            return passcode;
        }

        [HttpGet]
        [Route("")]
        public IActionResult index()
        {
            int? counter = HttpContext.Session.GetInt32("Counter");
            if (counter == null){
                counter = 1;
            } else {
                counter +=1;
            }
            HttpContext.Session.SetInt32("Counter", (int)counter);
            ViewBag.counter = counter;
            ViewBag.passcode = GetPasscode();
            return View();
        }

        [HttpGet]
        [Route("reload")]
        public IActionResult reload()
        {
            return RedirectToAction("index");
        }
    }
}