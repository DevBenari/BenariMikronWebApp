using BenariMikronWebApp.Areas.HealthManagement.Models;
using BenariMikronWebApp.Areas.HealthManagement.Repositories;
using BenariMikronWebApp.Areas.HealthManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BenariMikronWebApp.Areas.HealthManagement.Controllers
{
    [Area("HealthManagement")]
    [Route("HealthManagement/[Controller]/[Action]")]
    public class DoctorTypeController : Controller
    {
        private readonly IDoctorTypeRepository _doctorTypeRepository;

        public DoctorTypeController(
            IDoctorTypeRepository doctorTypeRepository)
        {
            _doctorTypeRepository = doctorTypeRepository;
        }

        //Doctor Type
        public IActionResult Index()
        {
            var tampilkanData = _doctorTypeRepository.GetAllDoctorType();
            return View(tampilkanData);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ViewResult> CreateDoctorType()
        {
            var tipe = new CreateDoctorTypeViewModel();
            var dateNow = DateTimeOffset.Now;
            var lastCodeTipe = _doctorTypeRepository.GetAllDoctorType().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeTipeDokter).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            if (lastCodeTipe == null)
            {
                tipe.KodeTipeDokter = "TPE" + setDateNow + "0001";
            }
            else
            {
                var lastDateTipe = lastCodeTipe.KodeTipeDokter.Substring(3, 6);

                if (lastDateTipe != setDateNow)
                {
                    tipe.KodeTipeDokter = "TPE" + setDateNow + "0001";
                }
                else
                {
                    tipe.KodeTipeDokter = "TPE" + setDateNow + (Convert.ToInt32(lastCodeTipe.KodeTipeDokter.Substring(9, lastCodeTipe.KodeTipeDokter.Length - 9)) + 1).ToString("D4");
                }
            }
            return View(tipe);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateDoctorType(CreateDoctorTypeViewModel model)
        {
            var dateNow = DateTimeOffset.Now;
            var lastTipe = _doctorTypeRepository.GetAllDoctorType().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeTipeDokter).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            if (lastTipe == null)
            {
                model.KodeTipeDokter = "TPE" + setDateNow + "0001";
            }
            else
            {
                var lastDateTipe = lastTipe.KodeTipeDokter.Substring(3, 6);

                if (lastDateTipe != setDateNow)
                {
                    model.KodeTipeDokter = "TPE" + setDateNow + "0001";
                }
                else
                {
                    model.KodeTipeDokter = "TPE" + setDateNow + (Convert.ToInt32(lastTipe.KodeTipeDokter.Substring(9, lastTipe.KodeTipeDokter.Length - 9)) + 1).ToString("D4");
                }
            }

            if (ModelState.IsValid)
            {
                var newDoctorType = new DoctorType
                {
                    CreateDateTime = DateTimeOffset.Now,
                    DoctorTypeId = model.DoctorTypeId,
                    KodeTipeDokter = model.KodeTipeDokter,
                    TipeDokter = model.TipeDokter,
                    Persentase = model.Persentase,
                    Status = model.Status
                };

                var result = _doctorTypeRepository.GetAllDoctorType().Where(c => c.TipeDokter == model.TipeDokter).FirstOrDefault();

                if (result == null)
                {
                    _doctorTypeRepository.Tambah(newDoctorType);
                    TempData["SuccessMessage"] = "Tipe " + model.TipeDokter + " Berhasil Disimpan";
                    return RedirectToAction("Index", "DoctorType");
                }
                else
                {
                    ModelState.AddModelError("", "Maaf, Tipe sudah ada !!!");
                    return View(model);
                }
            }
            return View();
        }
    }
}
