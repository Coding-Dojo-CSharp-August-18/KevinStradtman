using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LostWoods.Factory;
using LostWoods.Models;
using System.ComponentModel.DataAnnotations;


namespace LostWoods.Controllers
{
    public class HomeController : Controller
    {
        private readonly TrailFactory trailFactory;
        public HomeController(TrailFactory trailFact)
        {
            trailFactory = trailFact;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.trails = trailFactory.AllTrails();
            return View();
        }
        [HttpGet("NewTrail")]
        public IActionResult NewTrail()
        {
            return View();
        }

        [HttpGet("trail/{id}")]
        public IActionResult Trail(int id)
        {
            ViewBag.trail = trailFactory.GetTrailById(id);
            return View();
        }
        [HttpPost("process_trail")]
        public IActionResult ProcessTrail(Trails trail)
        {
            if(ModelState.IsValid)
            {
                trailFactory.AddTrail(trail);
                return RedirectToAction("Index");
            }
            return View("NewTrail");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
