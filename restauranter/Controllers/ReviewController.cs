using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using restauranter.Models;
using System.Linq;

namespace restauranter.Controllers
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
    }
}
