using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;
using DbConnection;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            ViewData["Message"] = "Add Your Quote";
            return View();
        }
        [HttpPost("quotes")]
        public IActionResult PostQuote(Quote quote)
        {
             if(ModelState.IsValid)
            {
                string insertString = $"INSERT INTO quotes (name, quote_body, created_at, updated_at) VALUES ('{quote.name}','{quote.quote_body}', now(), now())";
                DbConnector.Execute(insertString);
                return RedirectToAction("Quotes");
            }
            return View("Index");
        }
        [HttpGet("quotes")]
        public IActionResult Quotes()
        {
            ViewData["Message"] = "Here are some awesome quotes";
            List<Dictionary<string, object>> AllQuotes = DbConnector.Query("SELECT * FROM quotes;");
            ViewBag.Quotes = AllQuotes;
            return View("Quotes");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
