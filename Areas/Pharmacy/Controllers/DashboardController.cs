using Microsoft.AspNetCore.Mvc;

namespace BenariMikronWebApp.Areas.Pharmacy.Controllers
{
    [Area("Pharmacy")]
    [Route("Pharmacy/[Controller]/[Action]")]
    public class DashboardController : Controller
    {        
        public IActionResult Index()
        {
            return View();
        }
    }
}
