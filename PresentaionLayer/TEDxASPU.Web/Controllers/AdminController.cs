using Microsoft.AspNetCore.Mvc;
namespace Presentation.Controllers
{
    public class AdminController : Controller
    {
        [HttpPost]
        public IActionResult Index()
        {
            return View();
        }
    }
}
