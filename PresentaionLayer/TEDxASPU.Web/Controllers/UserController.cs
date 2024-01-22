using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using TEDxASPU.Provider;

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
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        } 
        [HttpPost]
        public IActionResult SignUp(Entities.Account acc)
        {
            var result = new TEDxASPUProvider().SignUpNewUser(acc);
            return View();
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(Entities.Account acc)
        {
            var data = new TEDxASPUProvider().SignInNewUser(acc);
            
            if (data != null)
            {
                return RedirectToAction("AudienceDashboard", "Audience", data);
            }
            else
                return View("login", acc);
        }
        

        public IActionResult Schedual()
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