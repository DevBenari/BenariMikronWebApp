using BenariMikronWebApp.Areas.HealthManagement.Repositories;
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
    public class ReferenceDetailController : Controller
    {
        private readonly IReferenceDetailRepository _referenceDetailRepository;
        private readonly IReferenceTypeRepository _referenceTypeRepository;
        private readonly IDoctorRepository _doctorRepository;

        public ReferenceDetailController(
            IReferenceDetailRepository referenceDetailRepository,
            IReferenceTypeRepository referenceTypeRepository,
            IDoctorRepository doctorRepository)
        {
            _referenceDetailRepository = referenceDetailRepository;
            _referenceTypeRepository = referenceTypeRepository;
            _doctorRepository = doctorRepository;
        }
        public IActionResult Index()
        {
            var tampilkanData = _referenceDetailRepository.GetAllReferenceDetail();
            return View(tampilkanData);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ViewResult> CreateReferenceDetail()
        {
            var rujukan = new CreateReferenceDetailViewModel();
            var dateNow = DateTimeOffset.Now;
            var lastCodeRujukan = _referenceDetailRepository.GetAllReferenceDetail().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeDetailRujukan).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            ViewBag.ReferenceType = new SelectList(await _referenceTypeRepository.GetReferenceTypes(), "ReferenceTypeId", "NamaTipeRujukan", SortOrder.Ascending);
            ViewBag.Doctor = new SelectList(await _doctorRepository.GetDoctors(), "DoctorId", "NamaLengkap", SortOrder.Ascending);

            if (lastCodeRujukan == null)
            {
                rujukan.KodeDetailRujukan = "RDT" + setDateNow + "0001";
            }
            else
            {
                var lastDaterujukan = lastCodeRujukan.KodeDetailRujukan.Substring(3, 6);

                if (lastDaterujukan != setDateNow)
                {
                    rujukan.KodeDetailRujukan = "RDT" + setDateNow + "0001";
                }
                else
                {
                    rujukan.KodeDetailRujukan = "RDT" + setDateNow + (Convert.ToInt32(lastCodeRujukan.KodeDetailRujukan.Substring(9, lastCodeRujukan.KodeDetailRujukan.Length - 9)) + 1).ToString("D4");
                }
            }
            return View(rujukan);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateReferenceDetail(CreateReferenceDetailViewModel model)
        {
            var dateNow = DateTimeOffset.Now;
            var lastrujukan = _referenceDetailRepository.GetAllReferenceDetail().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeDetailRujukan).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            ViewBag.ReferenceType = new SelectList(await _referenceTypeRepository.GetReferenceTypes(), "ReferenceTypeId", "NamaTipeRujukan", SortOrder.Ascending);

            if (lastrujukan == null)
            {
                model.KodeDetailRujukan = "RDT" + setDateNow + "0001";
            }
            else
            {
                var lastDaterujukan = lastrujukan.KodeDetailRujukan.Substring(3, 6);

                if (lastDaterujukan != setDateNow)
                {
                    model.KodeDetailRujukan = "RDT" + setDateNow + "0001";
                }
                else
                {
                    model.KodeDetailRujukan = "RDT" + setDateNow + (Convert.ToInt32(lastrujukan.KodeDetailRujukan.Substring(9, lastrujukan.KodeDetailRujukan.Length - 9)) + 1).ToString("D4");
                }
            }

            if (ModelState.IsValid)
            {
                //string uniqueFileName = ProcessUploadFile(model);
                var newReferenceDetail = new ReferenceDetail
                {
                    CreateDateTime = DateTimeOffset.Now,
                    ReferenceDetailId = model.ReferenceDetailId,
                    KodeDetailRujukan = model.KodeDetailRujukan,
                    NamaDetailRujukan = model.NamaDetailRujukan,
                    NomorTelepon = model.NomorTelepon,
                    Alamat = model.Alamat,
                    ReferenceTypeId = model.ReferenceTypeId
                };

                var result = _referenceDetailRepository.GetAllReferenceDetail().Where(c => c.NamaDetailRujukan == model.NamaDetailRujukan).FirstOrDefault();

                if (result == null)
                {
                    _referenceDetailRepository.Tambah(newReferenceDetail);
                    TempData["SuccessMessage"] = "Detail Rujukan " + model.NamaDetailRujukan + " Berhasil Disimpan";
                    return RedirectToAction("Index", "ReferenceDetail");
                }
                else
                {
                    ModelState.AddModelError("", "Maaf, nama tipe rujukan sudah ada !!!");
                    ViewBag.ReferenceType = new SelectList(await _referenceTypeRepository.GetReferenceTypes(), "ReferenceTypeId", "NamaTipeRujukan", SortOrder.Ascending);
                    return View(model);
                }
            }
            ViewBag.ReferenceType = new SelectList(await _referenceTypeRepository.GetReferenceTypes(), "ReferenceTypeId", "NamaTipeRujukan", SortOrder.Ascending);
            return View();
        }
    }
}
