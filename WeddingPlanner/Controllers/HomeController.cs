using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private WeddingContext _wContext;

        public HomeController(WeddingContext context)
        {
            _wContext = context;    
        }
        private User ActiveUser 
        {
            get 
            {
                return _wContext.users.Where(u => u.user_id == HttpContext.Session.GetInt32("user_id")).FirstOrDefault();
            }
        }
        [HttpGet("")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("registeruser")]
        public IActionResult RegisterUser(RegisterUser newuser)
        {
            User CheckEmail = _wContext.users
                .Where(u => u.email == newuser.email)
                .SingleOrDefault();

            if(CheckEmail != null)
            {
                ViewBag.errors = "That email already exists";
                return RedirectToAction("Register");
            }
            if(ModelState.IsValid)
            {
                PasswordHasher<RegisterUser> Hasher = new PasswordHasher<RegisterUser>();
                User newUser = new User
                {
                    user_id = newuser.user_id,
                    first_name = newuser.first_name,
                    last_name = newuser.last_name,
                    email = newuser.email,
                    password = Hasher.HashPassword(newuser, newuser.password)
                  };
                _wContext.Add(newUser);
                _wContext.SaveChanges();
                ViewBag.success = "Successfully registered";
                return RedirectToAction("Login");
            }
            else
            {
                return View("Register");
            }
        }

        [HttpPost("loginuser")]
        public IActionResult LoginUser(LoginUser loginUser) 
        {
            User CheckEmail = _wContext.users
                .SingleOrDefault(u => u.email == loginUser.email);
            if(CheckEmail != null)
            {
                var Hasher = new PasswordHasher<User>();
                if(0 != Hasher.VerifyHashedPassword(CheckEmail, CheckEmail.password, loginUser.password))
                {
                    HttpContext.Session.SetInt32("user_id", CheckEmail.user_id);
                    HttpContext.Session.SetString("first_name", CheckEmail.first_name);
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    ViewBag.errors = "Incorrect Password";
                    return View("Register");
                }
            }
            else
            {
                ViewBag.errors = "Email not registered";
                return View("Register");
            }
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        // **************************************************** WEDDING ****************************************************** //

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            if(ActiveUser == null)
            {
                return RedirectToAction("Login");
            }
            User thisUser = _wContext.users
                .Where(u => u.user_id == HttpContext.Session.GetInt32("user_id"))
                .FirstOrDefault();
            User thisUserName = _wContext.users 
                .Where(u => u.first_name == HttpContext.Session.GetString("first_name"))
                .FirstOrDefault();
            ViewBag.Weddings = _wContext.weddings
                .Where(w => w.event_date > System.DateTime.Now)
                .OrderBy(d => d.event_date)
                .Include(h => h.Host)
                .ToList();
            ViewBag.id = thisUser;
            ViewBag.name = thisUserName;
            return View();
        }
        
        [HttpGet("AddEvent")]
        public IActionResult AddEvent()
        {
            if(ActiveUser == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpPost("AddEvent/new")]
        public IActionResult AddEventData(AddEventData events)
        {
            if(ActiveUser == null)
            {
                return RedirectToAction("Login");
            }
            if(ModelState.IsValid)
            {
                Wedding Wedding = events.TheWedding();
                Wedding.Host = ActiveUser;
                _wContext.Add(Wedding);
                _wContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View("AddEvent");
        }

        [HttpPost("RSVP")]
        public IActionResult RSVP(int id)
        {
            return RedirectToAction("Dashboard");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}