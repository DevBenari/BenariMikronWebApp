using BenariMikronWebApp.Areas.Administration.Models;
using BenariMikronWebApp.Areas.Administration.Repositories;
using BenariMikronWebApp.Areas.Administration.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BenariMikronWebApp.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Route("Administration/[Controller]/[Action]")]
    public class ReligionController : Controller
    {
        private readonly IReligionRepository _religionRepository;
        public ReligionController(
            IReligionRepository religionRepository)
        {
            _religionRepository = religionRepository;
        }

        public IActionResult Index()
        {
            var tampilkanData = _religionRepository.GetAllReligion();
            return View(tampilkanData);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ViewResult> CreateReligion()
        {
            var tipe = new CreateReligionViewModel();
            var dateNow = DateTimeOffset.Now;
            var lastCodeEdu = _religionRepository.GetAllReligion().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeAgama).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            if (lastCodeEdu == null)
            {
                tipe.KodeAgama = "RLG" + setDateNow + "0001";
            }
            else
            {
                var lastDateEdu = lastCodeEdu.KodeAgama.Substring(3, 6);

                if (lastDateEdu != setDateNow)
                {
                    tipe.KodeAgama = "RLG" + setDateNow + "0001";
                }
                else
                {
                    tipe.KodeAgama = "RLG" + setDateNow + (Convert.ToInt32(lastCodeEdu.KodeAgama.Substring(9, lastCodeEdu.KodeAgama.Length - 9)) + 1).ToString("D4");
                }
            }
            return View(tipe);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateReligion(CreateReligionViewModel model)
        {
            var dateNow = DateTimeOffset.Now;
            var lastReligi = _religionRepository.GetAllReligion().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeAgama).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            if (lastReligi == null)
            {
                model.KodeAgama = "RLG" + setDateNow + "0001";
            }
            else
            {
                var lastDateReligi = lastReligi.KodeAgama.Substring(3, 6);

                if (lastDateReligi != setDateNow)
                {
                    model.KodeAgama = "RLG" + setDateNow + "0001";
                }
                else
                {
                    model.KodeAgama = "RLG" + setDateNow + (Convert.ToInt32(lastReligi.KodeAgama.Substring(9, lastReligi.KodeAgama.Length - 9)) + 1).ToString("D4");
                }
            }

            if (ModelState.IsValid)
            {
                var newReligion = new Religion
                {
                    CreateDateTime = DateTimeOffset.Now,
                    ReligionId = model.ReligionId,
                    KodeAgama = model.KodeAgama,
                    NamaAgama = model.NamaAgama
                };

                var result = _religionRepository.GetAllReligion().Where(c => c.NamaAgama == model.NamaAgama).FirstOrDefault();

                if (result == null)
                {
                    _religionRepository.Tambah(newReligion);
                    TempData["SuccessMessage"] = "Agama " + model.NamaAgama + " Berhasil Disimpan";
                    return RedirectToAction("Index", "Religion");
                }
                else
                {
                    ModelState.AddModelError("", "Maaf, Agama sudah ada !!!");
                    return View(model);
                }
            }
            return View();
        }
    }
}
