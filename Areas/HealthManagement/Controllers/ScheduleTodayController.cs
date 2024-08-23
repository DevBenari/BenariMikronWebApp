using BenariMikronWebApp.Areas.HealthManagement.Models;
using BenariMikronWebApp.Areas.HealthManagement.Repositories;
using BenariMikronWebApp.Areas.HealthManagement.ViewModels;
using BenariMikronWebApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using ZXing;

namespace BenariMikronWebApp.Areas.HealthManagement.Controllers
{
    [Area("HealthManagement")]
    [Route("HealthManagement/[Controller]/[Action]")]
    public class ScheduleTodayController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IScheduleTodayRepository _scheduleTodayRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IDayRepository _dayRepository;
        private readonly IDoctorDepartmentRepository _doctorDepartmentRepository;

        public ScheduleTodayController( 
            ApplicationDbContext applicationDbContext,
            IScheduleTodayRepository scheduleTodayRepository, 
            IDoctorRepository doctorRepository,
            IDayRepository dayRepository,
            IDoctorDepartmentRepository doctorDepartmentRepository)
        {
            _applicationDbContext = applicationDbContext;
            _scheduleTodayRepository = scheduleTodayRepository;
            _doctorRepository = doctorRepository;
            _dayRepository = dayRepository;
            _doctorDepartmentRepository = doctorDepartmentRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index(string department)
        {            
            ViewBag.Department = new SelectList(await _doctorDepartmentRepository.GetDoctorDepartments(), "DepartmentId", "NamaDepartemen", SortOrder.Ascending);
            var tampilkanData = _scheduleTodayRepository.GetAllScheduleToday().Where(x => x.TanggalPraktek == DateTime.Now);
            return View(tampilkanData);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(string department, DateTime tanggalawalpencarian, DateTime tanggalakhirpencarian)
        {
            if (string.IsNullOrEmpty(department))
            {
                var tampilkanData = _scheduleTodayRepository.GetAllScheduleToday().Where(x => x.TanggalPraktek == DateTime.Now && x.DepartmentId.ToString() == department);
                ViewBag.Department = new SelectList(await _doctorDepartmentRepository.GetDoctorDepartments(), "DepartmentId", "NamaDepartemen", SortOrder.Ascending);
                return View(tampilkanData);
            }
            else {                
                var tampilkanData = _scheduleTodayRepository.GetAllScheduleToday().Where(r => r.DepartmentId.ToString().Contains(department) && r.TanggalPraktek >= tanggalawalpencarian && r.TanggalPraktek <= tanggalakhirpencarian).ToList();                                  
                ViewBag.Department = new SelectList(await _doctorDepartmentRepository.GetDoctorDepartments(), "DepartmentId", "NamaDepartemen", SortOrder.Ascending);                    
                return View(tampilkanData);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ViewResult> CreateScheduleToday()
        {
            var schedule = new CreateScheduleTodayViewModel();
            var dateNow = DateTimeOffset.Now;
            var lastSchedule = _scheduleTodayRepository.GetAllScheduleToday().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeJadwal).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            ViewBag.Doctor = new SelectList(await _doctorRepository.GetDoctors(), "DoctorId", "NamaLengkap", SortOrder.Ascending);
            ViewBag.Day = new SelectList(await _dayRepository.GetDays(), "DayId", "NamaHari", SortOrder.Ascending);
            ViewBag.Department = new SelectList(await _doctorDepartmentRepository.GetDoctorDepartments(), "DepartmentId", "NamaDepartemen", SortOrder.Ascending);

            if (lastSchedule == null)
            {
                schedule.KodeJadwal = "SCH" + setDateNow + "0001";
            }
            else
            {
                var lastDateSchedule = lastSchedule.KodeJadwal.Substring(3, 6);

                if (lastDateSchedule != setDateNow)
                {
                    schedule.KodeJadwal = "SCH" + setDateNow + "0001";
                }
                else
                {
                    schedule.KodeJadwal = "SCH" + setDateNow + (Convert.ToInt32(lastSchedule.KodeJadwal.Substring(9, lastSchedule.KodeJadwal.Length - 9)) + 1).ToString("D4");
                }
            }
            return View(schedule);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateScheduleToday(CreateScheduleTodayViewModel model)
        {
            var dateNow = DateTimeOffset.Now;
            var lastSchedule = _scheduleTodayRepository.GetAllScheduleToday().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeJadwal).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            ViewBag.Doctor = new SelectList(await _doctorRepository.GetDoctors(), "DoctorId", "NamaLengkap", SortOrder.Ascending);
            ViewBag.Day = new SelectList(await _dayRepository.GetDays(), "DayId", "NamaHari", SortOrder.Ascending);
            ViewBag.Department = new SelectList(await _doctorDepartmentRepository.GetDoctorDepartments(), "DepartmentId", "NamaDepartemen", SortOrder.Ascending);

            if (lastSchedule == null)
            {
                model.KodeJadwal = "SCH" + setDateNow + "0001";
            }
            else
            {
                var lastDateTitle = lastSchedule.KodeJadwal.Substring(3, 6);

                if (lastDateTitle != setDateNow)
                {
                    model.KodeJadwal = "SCH" + setDateNow + "0001";
                }
                else
                {
                    model.KodeJadwal = "SCH" + setDateNow + (Convert.ToInt32(lastSchedule.KodeJadwal.Substring(9, lastSchedule.KodeJadwal.Length - 9)) + 1).ToString("D4");
                }
            }

            if (ModelState.IsValid)
            {
                var newTitle = new ScheduleToday
                {
                    CreateDateTime = DateTimeOffset.Now,
                    ScheduleTodayId = model.ScheduleTodayId,
                    KodeJadwal = model.KodeJadwal,
                    DoctorId = model.DoctorId,
                    DepartmentId = model.DepartmentId,
                    DayId = model.DayId,
                    TanggalPraktek = model.TanggalPraktek,
                    JamMulai = model.JamMulai,
                    JamSelesai = model.JamSelesai,
                    LamaPeriksaPerPasien = model.LamaPeriksaPerPasien,
                    PagiSore = model.PagiSore,
                    Ruangan = model.Ruangan,
                };

                var result = _scheduleTodayRepository.GetAllScheduleToday().Where(c => c.DoctorId == model.DoctorId && c.DayId == model.DayId && c.JamMulai == model.JamMulai).FirstOrDefault();

                if (result == null)
                {
                    _scheduleTodayRepository.Tambah(newTitle);
                    TempData["SuccessMessage"] = "Jadwal Dokter " + model.DoctorId + " Berhasil Disimpan";
                    return RedirectToAction("Index", "ScheduleToday");
                }
                else
                {
                    ModelState.AddModelError("", "Maaf, Jadwal Dokter sudah ada !!!");
                    ViewBag.Doctor = new SelectList(await _doctorRepository.GetDoctors(), "DoctorId", "NamaLengkap", SortOrder.Ascending);
                    ViewBag.Day = new SelectList(await _dayRepository.GetDays(), "DayId", "NamaHari", SortOrder.Ascending);
                    ViewBag.Department = new SelectList(await _doctorDepartmentRepository.GetDoctorDepartments(), "DepartmentId", "NamaDepartemen", SortOrder.Ascending);
                    return View(model);
                }
            }
            ViewBag.Doctor = new SelectList(await _doctorRepository.GetDoctors(), "DoctorId", "NamaLengkap", SortOrder.Ascending);
            ViewBag.Day = new SelectList(await _dayRepository.GetDays(), "DayId", "NamaHari", SortOrder.Ascending);
            ViewBag.Department = new SelectList(await _doctorDepartmentRepository.GetDoctorDepartments(), "DepartmentId", "NamaDepartemen", SortOrder.Ascending);
            return View();
        }
    }
}
