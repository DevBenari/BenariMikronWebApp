using Microsoft.AspNetCore.Mvc;

namespace BenariMikronWebApp.Areas.WarehouseManagement.Controllers
{
    [Area("WarehouseManagement")]
    [Route("WarehouseManagement/[Controller]/[Action]")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
