using Microsoft.AspNetCore.Mvc;

namespace BenariMikronWebApp.Areas.HealthManagement.Controllers
{
    [Area("HealthManagement")]
    [Route("HealthManagement/[Controller]/[Action]")]
    public class MasterDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
