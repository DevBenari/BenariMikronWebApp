using Microsoft.AspNetCore.Mvc;

namespace BenariMikronWebApp.Areas.InformationTechnology.Controllers
{
    [Area("InformationTechnology")]
    [Route("InformationTechnology/[Controller]/[Action]")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
