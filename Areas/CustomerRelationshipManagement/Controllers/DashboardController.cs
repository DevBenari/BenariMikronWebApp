using Microsoft.AspNetCore.Mvc;

namespace BenariMikronWebApp.Areas.CustomerRelationshipManagement.Controllers
{
    [Area("CustomerRelationshipManagement")]
    [Route("CustomerRelationshipManagement/[Controller]/[Action]")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
