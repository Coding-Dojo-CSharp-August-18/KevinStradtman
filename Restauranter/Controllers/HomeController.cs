using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restauranter.Models;

namespace Restauranter.Controllers
{
    public class HomeController : Controller
    {
        private RestContext _context;
        public HomeController(RestContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("AddReview")]
        public IActionResult AddReview(Review rev)
        {
            if(ModelState.IsValid)
            {
                if(rev.visit > DateTime.Now)
                {
                    ModelState.AddModelError("visit", "Your date cannot be in the future");
                    return RedirectToAction("Index");
                }
                else
                {
                    Review newReview = new Review
                    {
                        review_id = rev.review_id,
                        name = rev.name,
                        rest_name = rev.rest_name,
                        rating = rev.rating,
                        review = rev.review,
                        visit = rev.visit
                    };
                    _context.Add(newReview);
                    _context.SaveChanges();
                    return RedirectToAction("Reviews");
                }
            }
            return View("Index");
        }

        [HttpGet("Reviews")]
        public IActionResult Reviews()
        {
            List<Review> reviews = _context.reviews.OrderByDescending(d => d.visit).ToList();
            ViewBag.reviews = reviews;
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
