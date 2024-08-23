using Microsoft.AspNetCore.Mvc;

namespace BenariMikronWebApp.Areas.UserManagement.Controllers
{
    [Area("UserManagement")]
    [Route("UserManagement/[Controller]/[Action]")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
