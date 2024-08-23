using Microsoft.AspNetCore.Mvc;

namespace BenariMikronWebApp.Areas.HumanResourceDevelopment.Controllers
{
    [Area("HumanResourceDevelopment")]
    [Route("HumanResourceDevelopment/[Controller]/[Action]")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
