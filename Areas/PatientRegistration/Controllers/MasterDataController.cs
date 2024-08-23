using Microsoft.AspNetCore.Mvc;

namespace BenariMikronWebApp.Areas.PatientRegistration.Controllers
{
    [Area("HealthManagement")]
    [Route("HealthManagement/[Controller]/[Action]")]
    public class MasterDataController : Controller
    {
        public IActionResult OutOfHospitalReferral()
        {
            return View();
        }
    }
}
