using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using restReviews.Models;
using System.Linq;

namespace restReviews.Controllers
{
    public class ReviewController : Controller
    {
        private Context _context;

        public ReviewController(Context context)
        {
            _context = context;
        }
        
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("addReview")]
        public IActionResult AddReview(Review newReview)
        {
            if(ModelState.IsValid){
                if (newReview.date > DateTime.Today)
                {
                    ModelState.AddModelError("date", "Date cannot be set to future date!");
                    return View("Index", newReview);
                } 
                _context.Add(newReview);
                _context.SaveChanges();
                return RedirectToAction("Reviews");
            }
            return View("Index", newReview);
        }

        [HttpGet]
        [Route("reviews")]
        public IActionResult Reviews()
        {
            List<Review> AllReviews = _context.Reviews.ToList();
            return View(AllReviews);
        }
    }
}