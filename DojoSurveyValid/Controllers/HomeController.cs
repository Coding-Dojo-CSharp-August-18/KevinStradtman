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
        public IActionResult Index()
        {
            ViewData["Message"] = "Send Some Info Through This Form";
            return View();
        }
        [HttpPost("result")]
        public IActionResult ResultData(FormData data)
        {
            ViewData["Message"] = "Data From The Form";
            if(ModelState.IsValid)
            {
                return View("ResultData", data);
            }
            return View("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
