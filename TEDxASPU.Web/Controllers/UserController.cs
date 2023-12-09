using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Presentation.Controllers
{
    public class UserController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Speakers()
        {
            return View();
        }public IActionResult Schedual()
        {
            return View();
        }
        public IActionResult Location()
        {
            return View();
        }
        public IActionResult Blog()
        {
            return View();
        }public IActionResult BlogElements()
        {
            return View();
        }public IActionResult BlogDetails()
        {
            return View();
        }public IActionResult Contact()
        {
            return View();
        }
        
    }
}