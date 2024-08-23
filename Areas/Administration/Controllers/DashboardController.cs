using Microsoft.AspNetCore.Mvc;

namespace BenariMikronWebApp.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Route("Administration/[Controller]/[Action]")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
