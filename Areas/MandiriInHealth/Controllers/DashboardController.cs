using Microsoft.AspNetCore.Mvc;

namespace BenariMikronWebApp.Areas.MandiriInHealt.Controllers
{
    [Area("MandiriInHealth")]
    [Route("MandiriInHealth/[Controller]/[Action]")]
    public class DashboardController : Controller
    {        
        public IActionResult Index()
        {
            return View();
        }
    }
}
