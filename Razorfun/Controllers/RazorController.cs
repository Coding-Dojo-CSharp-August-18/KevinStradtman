using Microsoft.AspNetCore.Mvc;

namespace Razorfun
{
    public class RazorController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}