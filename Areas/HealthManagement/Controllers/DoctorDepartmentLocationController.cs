using BenariMikronWebApp.Areas.HealthManagement.Models;
using BenariMikronWebApp.Areas.HealthManagement.Repositories;
using BenariMikronWebApp.Areas.HealthManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BenariMikronWebApp.Areas.HealthManagement.Controllers
{
    [Area("HealthManagement")]
    [Route("HealthManagement/[Controller]/[Action]")]
    public class DoctorDepartmentLocationController : Controller
    {
        private readonly IDoctorDepartmentLocationRepository _departmentLocationRepository;

        public DoctorDepartmentLocationController(
            IDoctorDepartmentLocationRepository departmentLocation)
        {
            _departmentLocationRepository = departmentLocation;
        }
        public IActionResult Index()
        {
            var tampilkanData = _departmentLocationRepository.GetAllDepartmentLocation();
            return View(tampilkanData);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ViewResult> CreateDoctorDepartmentLocation()
        {
            var lokasi = new CreateDoctorDepartmentLocationViewModel();
            var dateNow = DateTimeOffset.Now;
            var lastCodeLocation = _departmentLocationRepository.GetAllDepartmentLocation().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeLokasi).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            if (lastCodeLocation == null)
            {
                lokasi.KodeLokasi = "LKS" + setDateNow + "0001";
            }
            else
            {
                var lastDatelokasi = lastCodeLocation.KodeLokasi.Substring(3, 6);

                if (lastDatelokasi != setDateNow)
                {
                    lokasi.KodeLokasi = "LKS" + setDateNow + "0001";
                }
                else
                {
                    lokasi.KodeLokasi = "LKS" + setDateNow + (Convert.ToInt32(lastCodeLocation.KodeLokasi.Substring(9, lastCodeLocation.KodeLokasi.Length - 9)) + 1).ToString("D4");
                }
            }
            return View(lokasi);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateDoctorDepartmentLocation(CreateDoctorDepartmentLocationViewModel model)
        {
            var dateNow = DateTimeOffset.Now;
            var lastLokasi = _departmentLocationRepository.GetAllDepartmentLocation().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeLokasi).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            if (lastLokasi == null)
            {
                model.KodeLokasi = "LKS" + setDateNow + "0001";
            }
            else
            {
                var lastDatelokasi = lastLokasi.KodeLokasi.Substring(3, 6);

                if (lastDatelokasi != setDateNow)
                {
                    model.KodeLokasi = "LKS" + setDateNow + "0001";
                }
                else
                {
                    model.KodeLokasi = "LKS" + setDateNow + (Convert.ToInt32(lastLokasi.KodeLokasi.Substring(9, lastLokasi.KodeLokasi.Length - 9)) + 1).ToString("D4");
                }
            }

            if (ModelState.IsValid)
            {
                //string uniqueFileName = ProcessUploadFile(model);
                var newDepartmentLocation = new DoctorDepartmentLocation
                {
                    CreateDateTime = DateTimeOffset.Now,
                    LocationId = model.LocationId,
                    KodeLokasi = model.KodeLokasi,
                    NamaLokasi = model.NamaLokasi,
                    Keterangan = model.Keterangan
                };

                var result = _departmentLocationRepository.GetAllDepartmentLocation().Where(c => c.NamaLokasi == model.NamaLokasi).FirstOrDefault();

                if (result == null)
                {
                    _departmentLocationRepository.Tambah(newDepartmentLocation);
                    TempData["SuccessMessage"] = "Lokasi " + model.NamaLokasi + " Berhasil Disimpan";
                    return RedirectToAction("Index", "DoctorDepartmentLocation");
                }
                else
                {
                    ModelState.AddModelError("", "Maaf, nama lokasi sudah ada !!!");
                    return View(model);
                }
            }
            return View();
        }
    }
}
