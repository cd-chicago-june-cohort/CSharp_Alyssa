using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using bankAccounts.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace bankAccounts.Controllers
{
    public class UserController : Controller
    {
        private Context _context;

        public UserController(Context context)
        {
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        [Route("reg")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        [Route("log")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("processregister")]
        public IActionResult ProcessRegister(RegisterViewModel model){
            if(ModelState.IsValid){
                User currUser = _context.Users.SingleOrDefault(user => user.email == model.email);
                if(currUser != null){
                    ModelState.AddModelError("email", "There is already a registered user with that email.");
                    return View("Register", model);
                }
                User newUser = new User
                {
                    first_name = model.first_name,
                    last_name = model.last_name,
                    email = model.email,
                    password = model.password,    
                };
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.password = Hasher.HashPassword(newUser, newUser.password);
                _context.Users.Add(newUser);
                _context.SaveChanges();
                currUser = _context.Users.SingleOrDefault(user => user.email == newUser.email);
                HttpContext.Session.SetInt32("CurrUser", currUser.id);
                return RedirectToAction("Account", new { id = currUser.id });
            }
            return View("Register", model);

        }

        [HttpPost]
        [Route("processlogin")]
        public IActionResult ProcessLogin(LoginViewModel model){
            User currUser = _context.Users.SingleOrDefault(user => user.email == model.email);
            if(currUser != null && model.password != null)
            {
                var Hasher = new PasswordHasher<User>();
                if(0 != Hasher.VerifyHashedPassword(currUser, currUser.password, model.password)){
                    HttpContext.Session.SetInt32("CurrUser", currUser.id);
                    return RedirectToAction("Account", new { id = currUser.id });
                }
                else {
                    ModelState.AddModelError("password", "Incorrect Password");
                }
            } else if (currUser == null){
                ModelState.AddModelError("email", "User Not Found");
            }
            return View("Login", model);
        }

        [HttpGet]
        [Route("account/{id}")]
        public IActionResult Account(long id){
            int? loggedInId = HttpContext.Session.GetInt32("CurrUser");
            if (loggedInId == null){
                return RedirectToAction("Register");
            }
            User currUser = new User();
            currUser =  _context.Users.SingleOrDefault(user => user.id == id);
            if (currUser.id != loggedInId){
                return RedirectToAction("Account", new { id  = loggedInId });
            }
            
            if(TempData["InsuffFunds"] != null){
                ViewBag.Error = TempData["InsuffFunds"];
            } else {
                ViewBag.Error = "";
            }
            int balance = 0;
            List<Transaction> transactions = _context.Transactions.Where(transaction => transaction.UserId == id).OrderByDescending(transaction => transaction.date).ToList();
            foreach (var transaction in transactions){
                balance += transaction.amount;
            }
            HttpContext.Session.SetInt32("Balance", balance);
            ViewBag.Balance = balance;
            ViewBag.UserTransactions = transactions;
            ViewBag.Transaction = new TransactionViewModel();
            return View(currUser);
        }

        [HttpPost]
        [Route("processtransaction")]
        public IActionResult ProcessTransaction(TransactionViewModel model)
        {
            int? loggedInId = HttpContext.Session.GetInt32("CurrUser");
            int? balance = HttpContext.Session.GetInt32("Balance");
            if ((balance + model.amount) < 0){
                TempData["InsuffFunds"] = "Insufficient Funds";
            } else if (model.amount == 0) {
                TempData["InsuffFunds"] = "";
            } else {
                Transaction newTransaction = new Transaction
                {
                    UserId = (int)loggedInId,
                    date = DateTime.Now,
                    amount = model.amount   
                };
                _context.Transactions.Add(newTransaction);
                _context.SaveChanges();
            }
            return RedirectToAction("Account", new { id = loggedInId });
        }
    }
}
