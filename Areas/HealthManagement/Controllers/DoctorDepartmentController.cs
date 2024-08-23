using BenariMikronWebApp.Areas.Administration.Repositories;
using BenariMikronWebApp.Areas.HealthManagement.Models;
using BenariMikronWebApp.Areas.HealthManagement.Repositories;
using BenariMikronWebApp.Areas.HealthManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;

namespace BenariMikronWebApp.Areas.HealthManagement.Controllers
{
    [Area("HealthManagement")]
    [Route("HealthManagement/[Controller]/[Action]")]
    public class DoctorDepartmentController : Controller
    {
        private readonly IDoctorDepartmentRepository _doctorDepartmentRepository;
        private readonly IDoctorDepartmentLocationRepository _doctorDepartmentLocationRepository;

        public DoctorDepartmentController(
            IDoctorDepartmentRepository doctorDepartmentRepository, 
            IDoctorDepartmentLocationRepository doctorDepartmentLocationRepository)
        {
            _doctorDepartmentRepository = doctorDepartmentRepository;
            _doctorDepartmentLocationRepository = doctorDepartmentLocationRepository;
        }

        public IActionResult Index()
        {
            var tampilkanData = _doctorDepartmentRepository.GetAllDoctorDepartment();
            return View(tampilkanData);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ViewResult> CreateDoctorDepartment()
        {
            var depart = new CreateDoctorDepartmentViewModel();
            var dateNow = DateTimeOffset.Now;
            var lastCodeDepart = _doctorDepartmentRepository.GetAllDoctorDepartment().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeDepartemen).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            ViewBag.Lokasi = new SelectList(await _doctorDepartmentLocationRepository.GetDepartmentLocations(), "LocationId", "NamaLokasi", SortOrder.Ascending);

            if (lastCodeDepart == null)
            {
                depart.KodeDepartemen = "DPT" + setDateNow + "0001";
            }
            else
            {
                var lastDateDepart = lastCodeDepart.KodeDepartemen.Substring(3, 6);

                if (lastDateDepart != setDateNow)
                {
                    depart.KodeDepartemen = "DPT" + setDateNow + "0001";
                }
                else
                {
                    depart.KodeDepartemen = "DPT" + setDateNow + (Convert.ToInt32(lastCodeDepart.KodeDepartemen.Substring(9, lastCodeDepart.KodeDepartemen.Length - 9)) + 1).ToString("D4");
                }
            }
            return View(depart);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateDoctorDepartment(CreateDoctorDepartmentViewModel model)
        {
            var dateNow = DateTimeOffset.Now;
            var lastDepart = _doctorDepartmentRepository.GetAllDoctorDepartment().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeDepartemen).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            ViewBag.Lokasi = new SelectList(await _doctorDepartmentLocationRepository.GetDepartmentLocations(), "LocationId", "NamaLokasi", SortOrder.Ascending);

            if (lastDepart == null)
            {
                model.KodeDepartemen = "DPT" + setDateNow + "0001";
            }
            else
            {
                var lastDateDepart = lastDepart.KodeDepartemen.Substring(3, 6);

                if (lastDateDepart != setDateNow)
                {
                    model.KodeDepartemen = "DPT" + setDateNow + "0001";
                }
                else
                {
                    model.KodeDepartemen = "DPT" + setDateNow + (Convert.ToInt32(lastDepart.KodeDepartemen.Substring(9, lastDepart.KodeDepartemen.Length - 9)) + 1).ToString("D4");
                }
            }

            if (ModelState.IsValid)
            {
                //string uniqueFileName = ProcessUploadFile(model);
                var newDoctorDepartment = new DoctorDepartment
                {
                    CreateDateTime = DateTimeOffset.Now,
                    DepartmentId = model.DepartmentId,
                    KodeDepartemen = model.KodeDepartemen,
                    NamaDepartemen = model.NamaDepartemen,
                    LocationId = model.LocationId,
                    Telepon = model.Telepon,
                    MulaiJamKerja = model.MulaiJamKerja,
                    SelesaiJamKerja = model.SelesaiJamKerja,
                    Keterangan = model.Keterangan
                };

                var result = _doctorDepartmentRepository.GetAllDoctorDepartment().Where(c => c.NamaDepartemen == model.NamaDepartemen).FirstOrDefault();

                if (result == null)
                {
                    _doctorDepartmentRepository.Tambah(newDoctorDepartment);
                    TempData["SuccessMessage"] = "Department " + model.NamaDepartemen + " Berhasil Disimpan";
                    return RedirectToAction("Index", "DoctorDepartment");
                }
                else
                {
                    ModelState.AddModelError("", "Maaf, nama Department sudah ada !!!");
                    ViewBag.Lokasi = new SelectList(await _doctorDepartmentLocationRepository.GetDepartmentLocations(), "LocationId", "NamaLokasi", SortOrder.Ascending);
                    return View(model);
                }
            }
            ViewBag.Lokasi = new SelectList(await _doctorDepartmentLocationRepository.GetDepartmentLocations(), "LocationId", "NamaLokasi", SortOrder.Ascending);
            return View();
        }
    }
}
