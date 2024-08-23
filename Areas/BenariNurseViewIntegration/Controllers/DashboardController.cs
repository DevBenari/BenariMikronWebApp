using Microsoft.AspNetCore.Mvc;

namespace BenariMikronWebApp.Areas.BenariNurseViewIntegration.Controllers
{
    [Area("BenariNurseViewIntegration")]
    [Route("BenariNurseViewIntegration/[Controller]/[Action]")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
