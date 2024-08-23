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
    public class CityController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ICountryRepository _countryRepository;
        private readonly IProvinceRepository _provinceRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly ISubDistrictRepository _subDistrictRepository;
        public CityController(
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
            var tampilkanData = _cityRepository.GetAllCity();
            return View(tampilkanData);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ViewResult> CreateCity()
        {
            var city = new CreateCityViewModel();
            var dateNow = DateTimeOffset.Now;
            var lastCodeCity = _cityRepository.GetAllCity().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeKota).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
            ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);

            if (lastCodeCity == null)
            {
                city.KodeKota = "CTY" + setDateNow + "0001";
            }
            else
            {
                var lastDateCty = lastCodeCity.KodeKota.Substring(3, 6);

                if (lastDateCty != setDateNow)
                {
                    city.KodeKota = "CTY" + setDateNow + "0001";
                }
                else
                {
                    city.KodeKota = "CTY" + setDateNow + (Convert.ToInt32(lastCodeCity.KodeKota.Substring(9, lastCodeCity.KodeKota.Length - 9)) + 1).ToString("D4");
                }
            }
            return View(city);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateCity(CreateCityViewModel model)
        {
            var dateNow = DateTimeOffset.Now;
            var lastCity = _cityRepository.GetAllCity().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeKota).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            if (lastCity == null)
            {
                model.KodeKota = "CTY" + setDateNow + "0001";
            }
            else
            {
                var lastDateCity = lastCity.KodeKota.Substring(3, 6);

                if (lastDateCity != setDateNow)
                {
                    model.KodeKota = "CTY" + setDateNow + "0001";
                }
                else
                {
                    model.KodeKota = "CTY" + setDateNow + (Convert.ToInt32(lastCity.KodeKota.Substring(9, lastCity.KodeKota.Length - 9)) + 1).ToString("D4");
                }
            }
            if (ModelState.IsValid)
            {
                City newCity = new City
                {
                    CityId = model.CityId,
                    KodeKota = model.KodeKota,
                    NamaKota = model.NamaKota,
                    ProvinceId = model.ProvinceId,
                    CountryId = model.CountryId,
                };

                var result = _cityRepository.GetAllCity().Where(c => c.NamaKota == model.NamaKota).FirstOrDefault();
                if (result == null)
                {
                    _cityRepository.Add(newCity);
                    TempData["SuccessMessage"] = "Kota " + model.NamaKota + " Berhasil Disimpan";
                    return RedirectToAction("Index", "City");
                }
                else
                {
                    ModelState.AddModelError("", "Maaf, nama kota sudah ada !!!");
                    ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
                    ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
                    return View(model);
                }
            }
            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
            ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
            return View();
        }

        public JsonResult LoadProvince(Guid Id)
        {
            var province = _applicationDbContext.Provinces.Where(p => p.CountryId == Id).ToList();
            return Json(new SelectList(province, "ProvinceId", "NamaProvinsi"));
        }

        public JsonResult LoadCity(Guid Id)
        {
            var city = _applicationDbContext.Cities.Where(p => p.ProvinceId == Id).ToList();
            return Json(new SelectList(city, "CityId", "NamaKota"));
        }

        public JsonResult LoadDistrict(Guid Id)
        {
            var district = _applicationDbContext.Districts.Where(p => p.CityId == Id).ToList();
            return Json(new SelectList(district, "DistrictId", "NamaKecamatan"));
        }

        public JsonResult LoadSubDistrict(Guid Id)
        {
            var subdistrict = _applicationDbContext.SubDistricts.Where(p => p.DistrictId == Id).ToList();
            return Json(new SelectList(subdistrict, "SubDistrictId", "NamaKelurahan"));
        }
    }
}
