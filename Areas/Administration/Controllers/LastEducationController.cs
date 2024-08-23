using BenariMikronWebApp.Areas.Administration.Models;
using BenariMikronWebApp.Areas.Administration.Repositories;
using BenariMikronWebApp.Areas.Administration.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BenariMikronWebApp.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Route("Administration/[Controller]/[Action]")]
    public class LastEducationController : Controller
    {
        private readonly ILastEducationRepository _lastEducationRepository;

        public LastEducationController(
            ILastEducationRepository lastEducationRepository)
        {
            _lastEducationRepository = lastEducationRepository;
        }
        
        public IActionResult Index()
        {
            var tampilkanData = _lastEducationRepository.GetAllLastEducation();
            return View(tampilkanData);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ViewResult> CreateLastEducation()
        {
            var tipe = new CreateLastEducationViewModel();
            var dateNow = DateTimeOffset.Now;
            var lastCodeEdu = _lastEducationRepository.GetAllLastEducation().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodePendidikanTerakhir).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            if (lastCodeEdu == null)
            {
                tipe.KodePendidikanTerakhir = "EDU" + setDateNow + "0001";
            }
            else
            {
                var lastDateEdu = lastCodeEdu.KodePendidikanTerakhir.Substring(3, 6);

                if (lastDateEdu != setDateNow)
                {
                    tipe.KodePendidikanTerakhir = "EDU" + setDateNow + "0001";
                }
                else
                {
                    tipe.KodePendidikanTerakhir = "EDU" + setDateNow + (Convert.ToInt32(lastCodeEdu.KodePendidikanTerakhir.Substring(9, lastCodeEdu.KodePendidikanTerakhir.Length - 9)) + 1).ToString("D4");
                }
            }
            return View(tipe);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateLastEducation(CreateLastEducationViewModel model)
        {
            var dateNow = DateTimeOffset.Now;
            var lastTipe = _lastEducationRepository.GetAllLastEducation().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodePendidikanTerakhir).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            if (lastTipe == null)
            {
                model.KodePendidikanTerakhir = "EDU" + setDateNow + "0001";
            }
            else
            {
                var lastDateTipe = lastTipe.KodePendidikanTerakhir.Substring(3, 6);

                if (lastDateTipe != setDateNow)
                {
                    model.KodePendidikanTerakhir = "EDU" + setDateNow + "0001";
                }
                else
                {
                    model.KodePendidikanTerakhir = "EDU" + setDateNow + (Convert.ToInt32(lastTipe.KodePendidikanTerakhir.Substring(9, lastTipe.KodePendidikanTerakhir.Length - 9)) + 1).ToString("D4");
                }
            }

            if (ModelState.IsValid)
            {
                var newLastEducation = new LastEducation
                {
                    CreateDateTime = DateTimeOffset.Now,
                    LastEducationId = model.LastEducationId,
                    KodePendidikanTerakhir = model.KodePendidikanTerakhir,
                    NamaPendidikanTerakhir = model.NamaPendidikanTerakhir
                };

                var result = _lastEducationRepository.GetAllLastEducation().Where(c => c.NamaPendidikanTerakhir == model.NamaPendidikanTerakhir).FirstOrDefault();

                if (result == null)
                {
                    _lastEducationRepository.Tambah(newLastEducation);
                    TempData["SuccessMessage"] = "Pendidikan Terakhir " + model.NamaPendidikanTerakhir + " Berhasil Disimpan";
                    return RedirectToAction("Index", "LastEducation");
                }
                else
                {
                    ModelState.AddModelError("", "Maaf, Pendidikan Terakhir sudah ada !!!");
                    return View(model);
                }
            }
            return View();
        }
    }
}
