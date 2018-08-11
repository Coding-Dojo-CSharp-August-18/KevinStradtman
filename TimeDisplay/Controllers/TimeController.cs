using System;
using Microsoft.AspNetCore.Mvc;

namespace TimeDisplay
{
    public class TimeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            DateTime thisDay = DateTime.Now;
            ViewBag.today = thisDay;
            return View(ViewBag.today);
        }
    }
}