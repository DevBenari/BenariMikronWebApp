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
    public class SubDistrictController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ICountryRepository _countryRepository;
        private readonly IProvinceRepository _provinceRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly ISubDistrictRepository _subDistrictRepository;
        public SubDistrictController(
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
            var tampilkanData = _subDistrictRepository.GetAllSubDistrict();
            return View(tampilkanData);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ViewResult> CreateSubDistrict()
        {
            var subDistrict = new CreateSubDistrictViewModel();
            var dateNow = DateTimeOffset.Now;
            var lastCodeSubDistrict = _subDistrictRepository.GetAllSubDistrict().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeKelurahan).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
            ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
            ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
            ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);

            if (lastCodeSubDistrict == null)
            {
                subDistrict.KodeKelurahan = "SDS" + setDateNow + "0001";
            }
            else
            {
                var lastDateSubDistrict = lastCodeSubDistrict.KodeKelurahan.Substring(3, 6);

                if (lastDateSubDistrict != setDateNow)
                {
                    subDistrict.KodeKelurahan = "SDS" + setDateNow + "0001";
                }
                else
                {
                    subDistrict.KodeKelurahan = "SDS" + setDateNow + (Convert.ToInt32(lastCodeSubDistrict.KodeKelurahan.Substring(9, lastCodeSubDistrict.KodeKelurahan.Length - 9)) + 1).ToString("D4");
                }
            }
            return View(subDistrict);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateSubDistrict(CreateSubDistrictViewModel model)
        {
            var dateNow = DateTimeOffset.Now;
            var lastSubDistrict = _subDistrictRepository.GetAllSubDistrict().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeKelurahan).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            if (lastSubDistrict == null)
            {
                model.KodeKelurahan = "SDS" + setDateNow + "0001";
            }
            else
            {
                var lastDateSubDistrict = lastSubDistrict.KodeKelurahan.Substring(3, 6);

                if (lastDateSubDistrict != setDateNow)
                {
                    model.KodeKelurahan = "SDS" + setDateNow + "0001";
                }
                else
                {
                    model.KodeKelurahan = "SDS" + setDateNow + (Convert.ToInt32(lastSubDistrict.KodeKelurahan.Substring(9, lastSubDistrict.KodeKelurahan.Length - 9)) + 1).ToString("D4");
                }
            }
            if (ModelState.IsValid)
            {
                SubDistrict newSubDistrict = new SubDistrict
                {
                    SubDistrictId = model.SubDistrictId,
                    KodeKelurahan = model.KodeKelurahan,
                    NamaKelurahan = model.NamaKelurahan,
                    DistrictId = model.DistrictId,
                    CityId = model.CityId,
                    ProvinceId = model.ProvinceId,
                    CountryId = model.CountryId,
                };

                var result = _subDistrictRepository.GetAllSubDistrict().Where(c => c.NamaKelurahan == model.NamaKelurahan).FirstOrDefault();
                if (result == null)
                {
                    _subDistrictRepository.Add(newSubDistrict);
                    TempData["SuccessMessage"] = "Kelurahan " + model.NamaKelurahan + " Berhasil Disimpan";
                    return RedirectToAction("Index", "SubDistrict");
                }
                else
                {
                    ModelState.AddModelError("", "Maaf, nama kelurahan sudah ada !!!");
                    ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
                    ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
                    ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
                    ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);
                    return View(model);
                }
            }
            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
            ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
            ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
            ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);
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
