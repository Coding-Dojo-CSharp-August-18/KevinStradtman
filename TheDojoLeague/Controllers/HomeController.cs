using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheDojoLeague.Models;
using TheDojoLeague.Factory;

namespace TheDojoLeague.Controllers
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
            ViewBag.ninjasWithDojos = _dojoFactory.NinjasWithDojos();
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
            return RedirectToAction("Ninjas");
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

        [HttpGet("/SingleDojo/{Id}")]
        public IActionResult SingleDojo(int id)
        {
            ViewBag.singleNinja = _dojoFactory.GetNinjaById(id);
            ViewBag.singleDojo = _dojoFactory.FindDojoById(id);
            ViewBag.rogue = _dojoFactory.RogueNinjas();
            return View();
        }
        [HttpGet("/SingleNinja/{Id}")]
        public IActionResult SingleNinja(int id)
        {
            ViewBag.dojo = _dojoFactory.FindDojoById(id);
            ViewBag.ninja = _dojoFactory.GetNinjaById(id);
            return View();
        }

        [Route("SingleDojo/{dojoid}/Banish/{ninjaid}")]
        public IActionResult Banish(int dojoid, int ninjaid)
        {
            _dojoFactory.Banish(ninjaid);
            return RedirectToAction("SingleDojo", new {id = dojoid});
        }
        [Route("SingleDojo/{dojoid}/Recruit/{ninjaid}")]
        public IActionResult Recruit(int dojoid, int ninjaid)
        {
            _dojoFactory.Recruit(dojoid, ninjaid);
            return RedirectToAction("SingleDojo", new {id = dojoid});
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
