using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;
using System.Collections;

namespace movieAPI.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Dictionary<string,object>> AllMovies = DbConnector.Query("SELECT * FROM movies ORDER BY id DESC");
            ViewBag.AllMovies = AllMovies;
            return View();
        }

        [HttpPost]
        [Route("movie")]
        public void PostMovie(string title, double rating, string release)
        {
            Console.WriteLine(title);
            Console.WriteLine(rating);
            Console.WriteLine(release);
            DbConnector.Execute($"INSERT INTO movies (title, rating, release_date) VALUES ('{title}', {rating}, '{release}')");
        }
    }
}
