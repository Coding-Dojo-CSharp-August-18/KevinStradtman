using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyValid.Models;
using System.ComponentModel.DataAnnotations;

namespace DojoSurveyValid.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index(int id)
        {
            ViewData["Message"] = "Send Some Info Through This Form";
            FormData location1 = new FormData()
            {
                Location = "Washington D.C."
            };
            FormData location2 = new FormData()
            {
                Location = "Redmond W.A."
            };
            FormData location3 = new FormData()
            {
                Location = "Austin Texas"
            };
            FormData location4 = new FormData()
            {
                Location = "Seattle"
            };

            FormData language1 = new FormData()
            {
                Language = "PHP"
            };
            FormData language2 = new FormData()
            {
                Language = "C#"
            };
            FormData language3 = new FormData()
            {
                Language = "C++"
            };
            FormData language4 = new FormData()
            {
                Language = "JavaScript"
            };
            return View();
        }
        [HttpPost("result")]
        public IActionResult ResultData(FormData data)
        {
            ViewData["Message"] = "Data From The Form";
            if(ModelState.IsValid)
            {
                return View("Index", data);
            }
            return View("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
