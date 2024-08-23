using BenariMikronWebApp.Areas.HealthManagement.Models;
using BenariMikronWebApp.Areas.HealthManagement.Repositories;
using BenariMikronWebApp.Areas.HealthManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BenariMikronWebApp.Areas.HealthManagement.Controllers
{
    [Area("HealthManagement")]
    [Route("HealthManagement/[Controller]/[Action]")]
    public class DoctorQueueTypeController : Controller
    {
        private readonly IDoctorQueueTypeRepository _doctorQueueTypeRepository;

        public DoctorQueueTypeController(
            IDoctorQueueTypeRepository doctorQueueTypeRepository)
        {
            _doctorQueueTypeRepository = doctorQueueTypeRepository;
        }

        //Doctor Queue Type
        public IActionResult Index()
        {
            var tampilkanData = _doctorQueueTypeRepository.GetAllDoctorQueueType();
            return View(tampilkanData);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ViewResult> CreateDoctorQueueType()
        {
            var queueType = new CreateDoctorQueueTypeViewModel();
            var dateNow = DateTimeOffset.Now;
            var lastCodeQueueType = _doctorQueueTypeRepository.GetAllDoctorQueueType().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.NamaTipeAntrian).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            if (lastCodeQueueType == null)
            {
                queueType.KodeTipeAntrian = "DQT" + setDateNow + "0001";
            }
            else
            {
                var lastDateQueueType = lastCodeQueueType.KodeTipeAntrian.Substring(3, 6);

                if (lastDateQueueType != setDateNow)
                {
                    queueType.KodeTipeAntrian = "DQT" + setDateNow + "0001";
                }
                else
                {
                    queueType.KodeTipeAntrian = "DQT" + setDateNow + (Convert.ToInt32(lastCodeQueueType.KodeTipeAntrian.Substring(9, lastCodeQueueType.KodeTipeAntrian.Length - 9)) + 1).ToString("D4");
                }
            }
            return View(queueType);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateDoctorQueueType(CreateDoctorQueueTypeViewModel model)
        {
            var dateNow = DateTimeOffset.Now;
            var lastQueueType = _doctorQueueTypeRepository.GetAllDoctorQueueType().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeTipeAntrian).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            if (lastQueueType == null)
            {
                model.KodeTipeAntrian = "DQT" + setDateNow + "0001";
            }
            else
            {
                var lastDateQueueType = lastQueueType.KodeTipeAntrian.Substring(3, 6);

                if (lastDateQueueType != setDateNow)
                {
                    model.KodeTipeAntrian = "DQT" + setDateNow + "0001";
                }
                else
                {
                    model.KodeTipeAntrian = "DQT" + setDateNow + (Convert.ToInt32(lastQueueType.KodeTipeAntrian.Substring(9, lastQueueType.KodeTipeAntrian.Length - 9)) + 1).ToString("D4");
                }
            }

            if (ModelState.IsValid)
            {
                var newTitle = new DoctorQueueType
                {
                    CreateDateTime = DateTimeOffset.Now,
                    DoctorQueueTypeId = model.DoctorQueueTypeId,
                    KodeTipeAntrian = model.KodeTipeAntrian,
                    NamaTipeAntrian = model.NamaTipeAntrian
                };

                var result = _doctorQueueTypeRepository.GetAllDoctorQueueType().Where(c => c.NamaTipeAntrian == model.NamaTipeAntrian).FirstOrDefault();

                if (result == null)
                {
                    _doctorQueueTypeRepository.Tambah(newTitle);
                    TempData["SuccessMessage"] = "Tipe Antrian " + model.NamaTipeAntrian + " Berhasil Disimpan";
                    return RedirectToAction("Index", "DoctorQueueType");
                }
                else
                {
                    ModelState.AddModelError("", "Maaf, tipe antrian sudah ada !!!");
                    return View(model);
                }
            }
            return View();
        }
    }
}
