using BenariMikronWebApp.Areas.HealthManagement.Models;
using BenariMikronWebApp.Areas.HealthManagement.Repositories;
using BenariMikronWebApp.Areas.HealthManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BenariMikronWebApp.Areas.HealthManagement.Controllers
{
    [Area("HealthManagement")]
    [Route("HealthManagement/[Controller]/[Action]")]
    public class BloodTypeController : Controller
    {
        private readonly IBloodTypeRepository _bloodTypeRepository1;

        public BloodTypeController(
            IBloodTypeRepository bloodTypeRepository)
        {
            _bloodTypeRepository1 = bloodTypeRepository;
        }
        public IActionResult Index()
        {
            var tampilkanData = _bloodTypeRepository1.GetAllBloodType();
            return View(tampilkanData);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ViewResult> CreateBloodType()
        {
            var goldar = new CreateBloodTypeViewModel();
            var dateNow = DateTimeOffset.Now;
            var lastGoldar = _bloodTypeRepository1.GetAllBloodType().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeGolonganDarah).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            if (lastGoldar == null)
            {
                goldar.KodeGolonganDarah = "GDR" + setDateNow + "0001";
            }
            else
            {
                var lastDatelokasi = lastGoldar.KodeGolonganDarah.Substring(3, 6);

                if (lastDatelokasi != setDateNow)
                {
                    goldar.KodeGolonganDarah = "GDR" + setDateNow + "0001";
                }
                else
                {
                    goldar.KodeGolonganDarah = "GDR" + setDateNow + (Convert.ToInt32(lastGoldar.KodeGolonganDarah.Substring(9, lastGoldar.KodeGolonganDarah.Length - 9)) + 1).ToString("D4");
                }
            }
            return View(goldar);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateBloodType(CreateBloodTypeViewModel model)
        {
            var dateNow = DateTimeOffset.Now;
            var lastGoldar = _bloodTypeRepository1.GetAllBloodType().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeGolonganDarah).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            if (lastGoldar == null)
            {
                model.KodeGolonganDarah = "GDR" + setDateNow + "0001";
            }
            else
            {
                var lastDateGoldar = lastGoldar.KodeGolonganDarah.Substring(3, 6);

                if (lastDateGoldar != setDateNow)
                {
                    model.KodeGolonganDarah = "GDR" + setDateNow + "0001";
                }
                else
                {
                    model.KodeGolonganDarah = "GDR" + setDateNow + (Convert.ToInt32(lastGoldar.KodeGolonganDarah.Substring(9, lastGoldar.KodeGolonganDarah.Length - 9)) + 1).ToString("D4");
                }
            }

            if (ModelState.IsValid)
            {
                //string uniqueFileName = ProcessUploadFile(model);
                var newGoldar = new BloodType
                {
                    CreateDateTime = DateTimeOffset.Now,
                    BloodTypeId = model.BloodTypeId,
                    KodeGolonganDarah = model.KodeGolonganDarah,
                    NamaGolonganDarah = model.NamaGolonganDarah,
                    Keterangan = model.Keterangan
                };

                var result = _bloodTypeRepository1.GetAllBloodType().Where(c => c.NamaGolonganDarah == model.NamaGolonganDarah).FirstOrDefault();

                if (result == null)
                {
                    _bloodTypeRepository1.Tambah(newGoldar);
                    TempData["SuccessMessage"] = "Golongan Darah " + model.NamaGolonganDarah + " Berhasil Disimpan";
                    return RedirectToAction("Index", "BloodType");
                }
                else
                {
                    ModelState.AddModelError("", "Maaf, Golongan Darah sudah ada !!!");
                    return View(model);
                }
            }
            return View();
        }
    }
}
