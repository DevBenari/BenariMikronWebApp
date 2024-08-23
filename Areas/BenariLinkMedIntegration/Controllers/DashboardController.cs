using Microsoft.AspNetCore.Mvc;

namespace BenariMikronWebApp.Areas.BenariLinkMedIntegration.Controllers
{
    [Area("BenariLinkMedIntegration")]
    [Route("BenariLinkMedIntegration/[Controller]/[Action]")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
