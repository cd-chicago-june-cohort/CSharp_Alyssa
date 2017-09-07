using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace YourNamespace.Controllers
{
    public class HelloController : Controller
    {

        // A GET method
        [HttpGet]
        [Route("index")]
        public string Index()
        {
            return "Hello World!";
        }
        
        // // A POST method
        // [HttpPost]
        // [Route("")]
        // public IActionResult Other()
        // {
        //     // Return a view (We'll learn how soon!)
        // }

        // // A route with a parameter
        // [HttpGet]
        // [Route("template/{Name}")]
        // public IActionResult Method(string Name)
        // {
        //     // Method body
        // }

        // A GET method that returns a JSON response
        [HttpGet]
        [Route("displayint")]
        public JsonResult DisplayInt()
        {
            var AnonObject = new {
                                FirstName = "Raz",
                                LastName = "Aquato",
                                Age = 10
                            };
            return Json(AnonObject);
        }

    }
}