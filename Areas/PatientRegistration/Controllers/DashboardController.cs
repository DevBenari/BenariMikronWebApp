using Microsoft.AspNetCore.Mvc;

namespace BenariMikronWebApp.Areas.PatientRegistration.Controllers
{
    [Area("PatientRegistration")]
    [Route("PatientRegistration/[Controller]/[Action]")]
    public class DashboardController : Controller
    {        
        public IActionResult Index()
        {
            ViewBag.Active = "2";
            return View();
        }
    }
}
