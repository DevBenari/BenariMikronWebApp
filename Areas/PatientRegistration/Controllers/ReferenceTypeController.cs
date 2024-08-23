using BenariMikronWebApp.Areas.PatientRegistration.Models;
using BenariMikronWebApp.Areas.PatientRegistration.Repositories;
using BenariMikronWebApp.Areas.PatientRegistration.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;

namespace BenariMikronWebApp.Areas.PatientRegistration.Controllers
{
    [Area("PatientRegistration")]
    [Route("PatientRegistration/[Controller]/[Action]")]
    public class ReferenceTypeController : Controller
    {
        private readonly IReferenceTypeRepository _referenceTypeRepository;
        private readonly IReferenceRepository _referenceRepository;

        public ReferenceTypeController(
            IReferenceTypeRepository referenceType, 
            IReferenceRepository referenceRepository)
        {
            _referenceTypeRepository = referenceType;
            _referenceRepository = referenceRepository;
        }
        public IActionResult Index()
        {
            var tampilkanData = _referenceTypeRepository.GetAllReferenceType();
            return View(tampilkanData);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ViewResult> CreateReferenceType()
        {
            var rujukan = new CreateReferenceTypeViewModel();
            var dateNow = DateTimeOffset.Now;
            var lastCodeRujukan = _referenceTypeRepository.GetAllReferenceType().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeTipeRujukan).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            ViewBag.Reference = new SelectList(await _referenceRepository.GetReferences(), "ReferenceId", "NamaRujukan", SortOrder.Ascending);

            if (lastCodeRujukan == null)
            {
                rujukan.KodeTipeRujukan = "TPR" + setDateNow + "0001";
            }
            else
            {
                var lastDaterujukan = lastCodeRujukan.KodeTipeRujukan.Substring(3, 6);

                if (lastDaterujukan != setDateNow)
                {
                    rujukan.KodeTipeRujukan = "TPR" + setDateNow + "0001";
                }
                else
                {
                    rujukan.KodeTipeRujukan = "TPR" + setDateNow + (Convert.ToInt32(lastCodeRujukan.KodeTipeRujukan.Substring(9, lastCodeRujukan.KodeTipeRujukan.Length - 9)) + 1).ToString("D4");
                }
            }
            return View(rujukan);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateReferenceType(CreateReferenceTypeViewModel model)
        {
            var dateNow = DateTimeOffset.Now;
            var lastrujukan = _referenceTypeRepository.GetAllReferenceType().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeTipeRujukan).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            ViewBag.Reference = new SelectList(await _referenceRepository.GetReferences(), "ReferenceId", "NamaRujukan", SortOrder.Ascending);

            if (lastrujukan == null)
            {
                model.KodeTipeRujukan = "TPR" + setDateNow + "0001";
            }
            else
            {
                var lastDaterujukan = lastrujukan.KodeTipeRujukan.Substring(3, 6);

                if (lastDaterujukan != setDateNow)
                {
                    model.KodeTipeRujukan = "TPR" + setDateNow + "0001";
                }
                else
                {
                    model.KodeTipeRujukan = "TPR" + setDateNow + (Convert.ToInt32(lastrujukan.KodeTipeRujukan.Substring(9, lastrujukan.KodeTipeRujukan.Length - 9)) + 1).ToString("D4");
                }
            }

            if (ModelState.IsValid)
            {
                //string uniqueFileName = ProcessUploadFile(model);
                var newReferenceType = new ReferenceType
                {
                    CreateDateTime = DateTimeOffset.Now,
                    ReferenceTypeId = model.ReferenceTypeId,
                    KodeTipeRujukan = model.KodeTipeRujukan,
                    NamaTipeRujukan = model.NamaTipeRujukan,
                    ReferenceId = model.ReferenceId
                };

                var result = _referenceTypeRepository.GetAllReferenceType().Where(c => c.NamaTipeRujukan == model.NamaTipeRujukan).FirstOrDefault();

                if (result == null)
                {
                    _referenceTypeRepository.Tambah(newReferenceType);
                    TempData["SuccessMessage"] = "Tipe Rujukan " + model.NamaTipeRujukan + " Berhasil Disimpan";
                    return RedirectToAction("Index", "ReferenceType");
                }
                else
                {
                    ModelState.AddModelError("", "Maaf, nama tipe rujukan sudah ada !!!");
                    ViewBag.Reference = new SelectList(await _referenceRepository.GetReferences(), "ReferenceId", "NamaRujukan", SortOrder.Ascending);
                    return View(model);
                }
            }
            ViewBag.Reference = new SelectList(await _referenceRepository.GetReferences(), "ReferenceId", "NamaRujukan", SortOrder.Ascending);
            return View();
        }
    }
}
