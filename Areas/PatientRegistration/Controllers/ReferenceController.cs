using BenariMikronWebApp.Areas.PatientRegistration.Models;
using BenariMikronWebApp.Areas.PatientRegistration.Repositories;
using BenariMikronWebApp.Areas.PatientRegistration.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BenariMikronWebApp.Areas.PatientRegistration.Controllers
{
    [Area("PatientRegistration")]
    [Route("PatientRegistration/[Controller]/[Action]")]
    public class ReferenceController : Controller
    {
        private readonly IReferenceRepository _referenceRepository;

        public ReferenceController(
            IReferenceRepository reference)
        {
            _referenceRepository = reference;
        }
        public IActionResult Index()
        {
            var tampilkanData = _referenceRepository.GetAllReference();
            return View(tampilkanData);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ViewResult> CreateReference()
        {
            var rujukan = new CreateReferenceViewModel();
            var dateNow = DateTimeOffset.Now;
            var lastCodeRujukan = _referenceRepository.GetAllReference().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeRujukan).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            if (lastCodeRujukan == null)
            {
                rujukan.KodeRujukan = "RJK" + setDateNow + "0001";
            }
            else
            {
                var lastDaterujukan = lastCodeRujukan.KodeRujukan.Substring(3, 6);

                if (lastDaterujukan != setDateNow)
                {
                    rujukan.KodeRujukan = "RJK" + setDateNow + "0001";
                }
                else
                {
                    rujukan.KodeRujukan = "RJK" + setDateNow + (Convert.ToInt32(lastCodeRujukan.KodeRujukan.Substring(9, lastCodeRujukan.KodeRujukan.Length - 9)) + 1).ToString("D4");
                }
            }
            return View(rujukan);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateReference(CreateReferenceViewModel model)
        {
            var dateNow = DateTimeOffset.Now;
            var lastrujukan = _referenceRepository.GetAllReference().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeRujukan).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            if (lastrujukan == null)
            {
                model.KodeRujukan = "RJK" + setDateNow + "0001";
            }
            else
            {
                var lastDaterujukan = lastrujukan.KodeRujukan.Substring(3, 6);

                if (lastDaterujukan != setDateNow)
                {
                    model.KodeRujukan = "RJK" + setDateNow + "0001";
                }
                else
                {
                    model.KodeRujukan = "RJK" + setDateNow + (Convert.ToInt32(lastrujukan.KodeRujukan.Substring(9, lastrujukan.KodeRujukan.Length - 9)) + 1).ToString("D4");
                }
            }

            if (ModelState.IsValid)
            {
                //string uniqueFileName = ProcessUploadFile(model);
                var newreference = new Reference
                {
                    CreateDateTime = DateTimeOffset.Now,
                    ReferenceId = model.ReferenceId,
                    KodeRujukan = model.KodeRujukan,
                    NamaRujukan = model.NamaRujukan                    
                };

                var result = _referenceRepository.GetAllReference().Where(c => c.NamaRujukan == model.NamaRujukan).FirstOrDefault();

                if (result == null)
                {
                    _referenceRepository.Tambah(newreference);
                    TempData["SuccessMessage"] = "Rujukan " + model.NamaRujukan + " Berhasil Disimpan";
                    return RedirectToAction("Index", "Reference");
                }
                else
                {
                    ModelState.AddModelError("", "Maaf, nama rujukan sudah ada !!!");
                    return View(model);
                }
            }
            return View();
        }
    }
}
