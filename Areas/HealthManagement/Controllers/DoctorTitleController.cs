using BenariMikronWebApp.Areas.HealthManagement.Models;
using BenariMikronWebApp.Areas.HealthManagement.Repositories;
using BenariMikronWebApp.Areas.HealthManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BenariMikronWebApp.Areas.HealthManagement.Controllers
{
    [Area("HealthManagement")]
    [Route("HealthManagement/[Controller]/[Action]")]
    public class DoctorTitleController : Controller
    {
        private readonly IDoctorTitleRepository _doctorTitleRepository;

        public DoctorTitleController(
            IDoctorTitleRepository doctorTitleRepository)
        {
            _doctorTitleRepository = doctorTitleRepository;
        }

        //Doctor Title
        public IActionResult Index()
        {
            var tampilkanData = _doctorTitleRepository.GetAllDoctorTitle();
            return View(tampilkanData);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ViewResult> CreateDoctorTitle()
        {
            var title = new CreateDoctorTitleViewModel();
            var dateNow = DateTimeOffset.Now;
            var lastCodeTitle = _doctorTitleRepository.GetAllDoctorTitle().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.NamaGelar).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            if (lastCodeTitle == null)
            {
                title.KodeGelar = "GLR" + setDateNow + "0001";
            }
            else
            {
                var lastDateTipe = lastCodeTitle.KodeGelar.Substring(3, 6);

                if (lastDateTipe != setDateNow)
                {
                    title.KodeGelar = "GLR" + setDateNow + "0001";
                }
                else
                {
                    title.KodeGelar = "GLR" + setDateNow + (Convert.ToInt32(lastCodeTitle.KodeGelar.Substring(9, lastCodeTitle.KodeGelar.Length - 9)) + 1).ToString("D4");
                }
            }
            return View(title);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateDoctorTitle(CreateDoctorTitleViewModel model)
        {
            var dateNow = DateTimeOffset.Now;
            var lastTitle = _doctorTitleRepository.GetAllDoctorTitle().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeGelar).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            if (lastTitle == null)
            {
                model.KodeGelar = "GLR" + setDateNow + "0001";
            }
            else
            {
                var lastDateTitle = lastTitle.KodeGelar.Substring(3, 6);

                if (lastDateTitle != setDateNow)
                {
                    model.KodeGelar = "GLR" + setDateNow + "0001";
                }
                else
                {
                    model.KodeGelar = "GLR" + setDateNow + (Convert.ToInt32(lastTitle.KodeGelar.Substring(9, lastTitle.KodeGelar.Length - 9)) + 1).ToString("D4");
                }
            }

            if (ModelState.IsValid)
            {
                var newTitle = new DoctorTitle
                {
                    CreateDateTime = DateTimeOffset.Now,
                    DoctorTitleId = model.DoctorTitleId,
                    KodeGelar = model.KodeGelar,
                    NamaGelar = model.NamaGelar,
                    Deskripsi = model.Deskripsi,
                    LapRL1 = model.LapRL1,
                    LapRL2 = model.LapRL2,
                    Status = model.Status
                };

                var result = _doctorTitleRepository.GetAllDoctorTitle().Where(c => c.NamaGelar == model.NamaGelar).FirstOrDefault();

                if (result == null)
                {
                    _doctorTitleRepository.Tambah(newTitle);
                    TempData["SuccessMessage"] = "Title " + model.NamaGelar + " Berhasil Disimpan";
                    return RedirectToAction("Index", "DoctorTitle");
                }
                else
                {
                    ModelState.AddModelError("", "Maaf, title sudah ada !!!");
                    return View(model);
                }
            }
            return View();
        }
    }
}
