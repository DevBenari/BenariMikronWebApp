using Microsoft.AspNetCore.Mvc;

namespace BenariMikronWebApp.Areas.AccountingAndFinancial.Controllers
{
    [Area("AccountingAndFinancial")]
    [Route("AccountingAndFinancial/[Controller]/[Action]")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
