using BenariMikronWebApp.Areas.HealthManagement.Models;
using BenariMikronWebApp.Areas.HealthManagement.Repositories;
using BenariMikronWebApp.Areas.HealthManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BenariMikronWebApp.Areas.HealthManagement.Controllers
{
    [Area("HealthManagement")]
    [Route("HealthManagement/[Controller]/[Action]")]
    public class DayController : Controller
    {
        private readonly IDayRepository _dayRepository;        

        public DayController(
            IDayRepository dayRepository)
        {
            _dayRepository = dayRepository;
        }
        public IActionResult Index()
        {
            var tampilkanData = _dayRepository.GetAllDay();
            return View(tampilkanData);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ViewResult> CreateDay()
        {
            var days = new CreateDayViewModel();
            var dateNow = DateTimeOffset.Now;
            var lastDay = _dayRepository.GetAllDay().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeHari).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");            

            if (lastDay == null)
            {
                days.KodeHari = "DAY" + setDateNow + "0001";
            }
            else
            {
                var lastDateDay = lastDay.KodeHari.Substring(3, 6);

                if (lastDateDay != setDateNow)
                {
                    days.KodeHari = "DAY" + setDateNow + "0001";
                }
                else
                {
                    days.KodeHari = "DAY" + setDateNow + (Convert.ToInt32(lastDay.KodeHari.Substring(9, lastDay.KodeHari.Length - 9)) + 1).ToString("D4");
                }
            }
            return View(days);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateDay(CreateDayViewModel model)
        {
            var dateNow = DateTimeOffset.Now;
            var lastDay = _dayRepository.GetAllDay().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeHari).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            if (lastDay == null)
            {
                model.KodeHari = "DAY" + setDateNow + "0001";
            }
            else
            {
                var lastDateDay = lastDay.KodeHari.Substring(3, 6);

                if (lastDateDay != setDateNow)
                {
                    model.KodeHari = "DAY" + setDateNow + "0001";
                }
                else
                {
                    model.KodeHari = "DAY" + setDateNow + (Convert.ToInt32(lastDay.KodeHari.Substring(9, lastDay.KodeHari.Length - 9)) + 1).ToString("D4");
                }
            }

            if (ModelState.IsValid)
            {
                var newdays = new Day
                {
                    CreateDateTime = DateTimeOffset.Now,
                    DayId = model.DayId,
                    KodeHari = model.KodeHari,
                    NamaHari = model.NamaHari
                };

                var result = _dayRepository.GetAllDay().Where(c => c.NamaHari == model.NamaHari).FirstOrDefault();

                if (result == null)
                {
                    _dayRepository.Tambah(newdays);
                    TempData["SuccessMessage"] = "Hari " + model.NamaHari + " Berhasil Disimpan";
                    return RedirectToAction("Index", "Day");
                }
                else
                {
                    ModelState.AddModelError("", "Maaf, Nama hari sudah ada !!!");
                    return View(model);
                }
            }
            return View();
        }
    }
}
