using BenariMikronWebApp.Areas.Administration.Models;
using BenariMikronWebApp.Areas.Administration.Repositories;
using BenariMikronWebApp.Areas.Administration.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BenariMikronWebApp.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Route("Administration/[Controller]/[Action]")]
    public class WorkingController : Controller
    {
        private readonly IWorkingRepository _workingRepository;

        public WorkingController(
            IWorkingRepository WorkingRepository)
        {
            _workingRepository = WorkingRepository;
        }

        public IActionResult Index()
        {
            var tampilkanData = _workingRepository.GetAllWorking();
            return View(tampilkanData);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ViewResult> CreateWorking()
        {
            var tipe = new CreateWorkingViewModel();
            var dateNow = DateTimeOffset.Now;
            var lastCodeEdu = _workingRepository.GetAllWorking().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodePekerjaan).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            if (lastCodeEdu == null)
            {
                tipe.KodePekerjaan = "WRK" + setDateNow + "0001";
            }
            else
            {
                var lastDateEdu = lastCodeEdu.KodePekerjaan.Substring(3, 6);

                if (lastDateEdu != setDateNow)
                {
                    tipe.KodePekerjaan = "WRK" + setDateNow + "0001";
                }
                else
                {
                    tipe.KodePekerjaan = "WRK" + setDateNow + (Convert.ToInt32(lastCodeEdu.KodePekerjaan.Substring(9, lastCodeEdu.KodePekerjaan.Length - 9)) + 1).ToString("D4");
                }
            }
            return View(tipe);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateWorking(CreateWorkingViewModel model)
        {
            var dateNow = DateTimeOffset.Now;
            var lastTipe = _workingRepository.GetAllWorking().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodePekerjaan).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            if (lastTipe == null)
            {
                model.KodePekerjaan = "WRK" + setDateNow + "0001";
            }
            else
            {
                var lastDateTipe = lastTipe.KodePekerjaan.Substring(3, 6);

                if (lastDateTipe != setDateNow)
                {
                    model.KodePekerjaan = "WRK" + setDateNow + "0001";
                }
                else
                {
                    model.KodePekerjaan = "WRK" + setDateNow + (Convert.ToInt32(lastTipe.KodePekerjaan.Substring(9, lastTipe.KodePekerjaan.Length - 9)) + 1).ToString("D4");
                }
            }

            if (ModelState.IsValid)
            {
                var newWorking = new Working
                {
                    CreateDateTime = DateTimeOffset.Now,
                    WorkingId = model.WorkingId,
                    KodePekerjaan = model.KodePekerjaan,
                    NamaPekerjaan = model.NamaPekerjaan
                };

                var result = _workingRepository.GetAllWorking().Where(c => c.NamaPekerjaan == model.NamaPekerjaan).FirstOrDefault();

                if (result == null)
                {
                    _workingRepository.Tambah(newWorking);
                    TempData["SuccessMessage"] = "Pekerjaan " + model.NamaPekerjaan + " Berhasil Disimpan";
                    return RedirectToAction("Index", "Working");
                }
                else
                {
                    ModelState.AddModelError("", "Maaf, Nama pekerjaan sudah ada !!!");
                    return View(model);
                }
            }
            return View();
        }
    }
}
