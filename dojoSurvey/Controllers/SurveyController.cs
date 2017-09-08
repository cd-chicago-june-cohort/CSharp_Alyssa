using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace YourNamespace.Controllers
{
    public class SurveyController : Controller
    {
        [HttpGet]
        [Route("")]
        [Route("index")]
        public IActionResult index()
        {
            return View();
        }

        [HttpPost]
        [Route("process")]
        public IActionResult result(string name, string location, string language, string comment)
        {
            ViewBag.name = name;
            ViewBag.location = location;
            ViewBag.language = language;
            ViewBag.comment = comment;
            return View();
        }
    }
}