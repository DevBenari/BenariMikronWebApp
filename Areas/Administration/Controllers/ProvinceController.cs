using BenariMikronWebApp.Areas.Administration.Models;
using BenariMikronWebApp.Areas.Administration.Repositories;
using BenariMikronWebApp.Areas.Administration.ViewModels;
using BenariMikronWebApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;

namespace BenariMikronWebApp.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Route("Administration/[Controller]/[Action]")]
    public class ProvinceController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ICountryRepository _countryRepository;
        private readonly IProvinceRepository _provinceRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly ISubDistrictRepository _subDistrictRepository;
        public ProvinceController(
            ApplicationDbContext applicationDbContext,
            ICountryRepository countryRepository,
            IProvinceRepository provinceRepository,
            ICityRepository cityRepository,
            IDistrictRepository districtRepository,
            ISubDistrictRepository subDistrictRepository
        )
        {
            _applicationDbContext = applicationDbContext;
            _countryRepository = countryRepository;
            _provinceRepository = provinceRepository;
            _cityRepository = cityRepository;
            _districtRepository = districtRepository;
            _subDistrictRepository = subDistrictRepository;
        }
        public IActionResult Index()
        {
            var tampilkanData = _provinceRepository.GetAllProvince();
            return View(tampilkanData);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ViewResult> CreateProvince()
        {
            var prov = new CreateProvinceViewModel();
            var dateNow = DateTimeOffset.Now;
            var lastCodeProv = _provinceRepository.GetAllProvince().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeProvinsi).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);

            if (lastCodeProv == null)
            {
                prov.KodeProvinsi = "PRV" + setDateNow + "0001";
            }
            else
            {
                var lastDateEdu = lastCodeProv.KodeProvinsi.Substring(3, 6);

                if (lastDateEdu != setDateNow)
                {
                    prov.KodeProvinsi = "PRV" + setDateNow + "0001";
                }
                else
                {
                    prov.KodeProvinsi = "PRV" + setDateNow + (Convert.ToInt32(lastCodeProv.KodeProvinsi.Substring(9, lastCodeProv.KodeProvinsi.Length - 9)) + 1).ToString("D4");
                }
            }
            return View(prov);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateProvince(CreateProvinceViewModel model)
        {
            var dateNow = DateTimeOffset.Now;
            var lastProv = _provinceRepository.GetAllProvince().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeProvinsi).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            if (lastProv == null)
            {
                model.KodeProvinsi = "PRV" + setDateNow + "0001";
            }
            else
            {
                var lastDateProv = lastProv.KodeProvinsi.Substring(3, 6);

                if (lastDateProv != setDateNow)
                {
                    model.KodeProvinsi = "PRV" + setDateNow + "0001";
                }
                else
                {
                    model.KodeProvinsi = "PRV" + setDateNow + (Convert.ToInt32(lastProv.KodeProvinsi.Substring(9, lastProv.KodeProvinsi.Length - 9)) + 1).ToString("D4");
                }
            }
            if (ModelState.IsValid)
            {
                Province newProvince = new Province
                {
                    ProvinceId = model.ProvinceId,
                    KodeProvinsi = model.KodeProvinsi,
                    NamaProvinsi = model.NamaProvinsi,
                    CountryId = model.CountryId,
                };

                var result = _provinceRepository.GetAllProvince().Where(c => c.NamaProvinsi == model.NamaProvinsi).FirstOrDefault();
                if (result == null)
                {
                    _provinceRepository.Add(newProvince);
                    TempData["SuccessMessage"] = "Provinsi " + model.NamaProvinsi + " Berhasil Disimpan";
                    return RedirectToAction("Index", "Province");
                }
                else
                {
                    ModelState.AddModelError("", "Maaf, nama provinsi sudah ada !!!");
                    ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
                    return View(model);
                }
            }
            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
            return View();
        }
    }
}
