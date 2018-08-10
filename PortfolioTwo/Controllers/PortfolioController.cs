using Microsoft.AspNetCore.Mvc;


namespace PortfolioTwo
{
    public class PortfolioController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("projects")]
        public IActionResult Projects()
        {
            return View();
        }
        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}