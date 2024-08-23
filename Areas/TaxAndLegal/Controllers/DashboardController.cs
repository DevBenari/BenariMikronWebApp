using Microsoft.AspNetCore.Mvc;

namespace BenariMikronWebApp.Areas.TaxAndLegal.Controllers
{
    [Area("TaxAndLegal")]
    [Route("TaxAndLegal/[Controller]/[Action]")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
