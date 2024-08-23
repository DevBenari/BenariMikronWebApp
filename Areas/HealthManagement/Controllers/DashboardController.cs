using Microsoft.AspNetCore.Mvc;

namespace BenariMikronWebApp.Areas.HealtManagement.Controllers
{
    [Area("HealthManagement")]
    [Route("HealthManagement/[Controller]/[Action]")]
    public class DashboardController : Controller
    {        
        public IActionResult Index()
        {
            return View();
        }
    }
}
