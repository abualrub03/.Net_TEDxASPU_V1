using Microsoft.AspNetCore.Mvc;
namespace TEDxASPU.Web.Controllers
{
    public class Audience : Controller
    {
        public IActionResult AudienceDashboard(Entities.Account acc)
        {

            return View();
        }

    }
}
