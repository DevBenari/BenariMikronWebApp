using BenariMikronWebApp.Areas.Administration.Models;
using BenariMikronWebApp.Areas.Administration.Repositories;
using BenariMikronWebApp.Areas.Administration.ViewModels;
using BenariMikronWebApp.Areas.HealthManagement.Models;
using BenariMikronWebApp.Areas.HealthManagement.Repositories;
using BenariMikronWebApp.Areas.HealthManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BenariMikronWebApp.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Route("Administration/[Controller]/[Action]")]
    public class PromoController : Controller
    {
        private readonly IPromoRepository _promoRepository;

        public PromoController(
            IPromoRepository promoRepository)
        {
            _promoRepository = promoRepository;
        }
        public IActionResult Index()
        {
            var tampilkanData = _promoRepository.GetAllPromo();
            return View(tampilkanData);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ViewResult> CreatePromo()
        {
            var promo = new CreatePromoViewModel();
            var dateNow = DateTimeOffset.Now;
            var lastCodePromo = _promoRepository.GetAllPromo().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodePromo).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            if (lastCodePromo == null)
            {
                promo.KodePromo = "PRM" + setDateNow + "0001";
            }
            else
            {
                var lastDatepromo = lastCodePromo.KodePromo.Substring(3, 6);

                if (lastDatepromo != setDateNow)
                {
                    promo.KodePromo = "PRM" + setDateNow + "0001";
                }
                else
                {
                    promo.KodePromo = "PRM" + setDateNow + (Convert.ToInt32(lastCodePromo.KodePromo.Substring(9, lastCodePromo.KodePromo.Length - 9)) + 1).ToString("D4");
                }
            }
            return View(promo);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreatePromo(CreatePromoViewModel model)
        {
            var dateNow = DateTimeOffset.Now;
            var lastpromo = _promoRepository.GetAllPromo().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodePromo).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            if (lastpromo == null)
            {
                model.KodePromo = "PRM" + setDateNow + "0001";
            }
            else
            {
                var lastDatepromo = lastpromo.KodePromo.Substring(3, 6);

                if (lastDatepromo != setDateNow)
                {
                    model.KodePromo = "PRM" + setDateNow + "0001";
                }
                else
                {
                    model.KodePromo = "PRM" + setDateNow + (Convert.ToInt32(lastpromo.KodePromo.Substring(9, lastpromo.KodePromo.Length - 9)) + 1).ToString("D4");
                }
            }

            if (ModelState.IsValid)
            {
                //string uniqueFileName = ProcessUploadFile(model);
                var newPromo = new Promo
                {
                    CreateDateTime = DateTimeOffset.Now,
                    PromoId = model.PromoId,
                    KodePromo = model.KodePromo,
                    NamaPromo = model.NamaPromo,
                    Keterangan = model.Keterangan
                };

                var result = _promoRepository.GetAllPromo().Where(c => c.NamaPromo == model.NamaPromo).FirstOrDefault();

                if (result == null)
                {
                    _promoRepository.Tambah(newPromo);
                    TempData["SuccessMessage"] = "Promo " + model.NamaPromo + " Berhasil Disimpan";
                    return RedirectToAction("Index", "Promo");
                }
                else
                {
                    ModelState.AddModelError("", "Maaf, nama promo sudah ada !!!");
                    return View(model);
                }
            }
            return View();
        }
    }
}
