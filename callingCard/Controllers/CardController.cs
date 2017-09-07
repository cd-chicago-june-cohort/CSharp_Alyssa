using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace YourNamespace.Controllers
{
    public class HelloController : Controller
    {

        // A route with a parameter
        [HttpGet]
        [Route("{firstName}/{lastName}/{age}/{color}")]
        public JsonResult CallingCard(string firstName, string lastName, int age, string color)
        {
            var AnonObject = new {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                FavoriteColor = color
            };
            return Json(AnonObject);
        }
    }
}