using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace YourNamespace.Controllers
{
    public class PortfolioController : Controller
    {
        [HttpGet]
        [Route("")]
        [Route("home")]
        public IActionResult home()
        {
            return View();
        }

        [HttpGet]
        [Route("contact")]
        public IActionResult contact()
        {
            return View();
        }

        [HttpGet]
        [Route("projects")]
        public IActionResult projects()
        {
            return View();
        }

        [HttpPost]
        [Route("contact_form")]
        public IActionResult form(){
            return RedirectToAction("home");
        }
    }
}