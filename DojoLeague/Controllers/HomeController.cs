using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DojoLeague.Models;
using DojoLeague.Factory;

namespace DojoLeague.Controllers
{
    public class HomeController : Controller
    {
        private readonly DojoFactory _dojoFactory;
        public HomeController(DojoFactory dFactory)
        {
            _dojoFactory = dFactory;
        }
        
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("Ninjas")]
        public IActionResult Ninjas()
        {
            ViewBag.ninjas = _dojoFactory.FindAllNinjas();
            ViewBag.dojos = _dojoFactory.FindAllDojos();
            return View();
        }

        [HttpPost("CreateNinja")]
        public IActionResult CreateNinja(Ninjas ninja)
        {
            if(ModelState.IsValid)
            {
                _dojoFactory.CreateNinja(ninja);
                return RedirectToAction("Ninjas");
            }
            return View("Ninjas");
        }

        [HttpGet("Dojos")]
        public IActionResult Dojos()
        {
            ViewBag.dojos = _dojoFactory.FindAllDojos();
            return View();
        }
        [HttpPost("CreateDojo")]
        public IActionResult CreateDojo(Dojos dojo)
        {
            if(ModelState.IsValid)
            {
                _dojoFactory.CreateDojo(dojo);
                return RedirectToAction("Dojos");
            }
            return RedirectToAction("Dojos");
        }

        [HttpGet("SingleDojo/{Id}")]
        public IActionResult SingleDojo(long Id)
        {
            ViewBag.singleDojo = _dojoFactory.FindDojoById(Id);
            return View();
        }
        [HttpGet("SingleNinja/{id}")]
        public IActionResult SingleNinja(int id)
        {
            ViewBag.singleNinja = _dojoFactory.GetNinjaById(id);
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
