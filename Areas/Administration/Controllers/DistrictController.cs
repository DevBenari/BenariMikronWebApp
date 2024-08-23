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
    public class DistrictController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ICountryRepository _countryRepository;
        private readonly IProvinceRepository _provinceRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly ISubDistrictRepository _subDistrictRepository;
        public DistrictController(
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
            var tampilkanData = _districtRepository.GetAllDistrict();
            return View(tampilkanData);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ViewResult> CreateDistrict()
        {
            var district = new CreateDistrictViewModel();
            var dateNow = DateTimeOffset.Now;
            var lastCodeDistrict = _districtRepository.GetAllDistrict().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeKecamatan).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
            ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
            ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);

            if (lastCodeDistrict == null)
            {
                district.KodeKecamatan = "DST" + setDateNow + "0001";
            }
            else
            {
                var lastDateDistrict = lastCodeDistrict.KodeKecamatan.Substring(3, 6);

                if (lastDateDistrict != setDateNow)
                {
                    district.KodeKecamatan = "DST" + setDateNow + "0001";
                }
                else
                {
                    district.KodeKecamatan = "DST" + setDateNow + (Convert.ToInt32(lastCodeDistrict.KodeKecamatan.Substring(9, lastCodeDistrict.KodeKecamatan.Length - 9)) + 1).ToString("D4");
                }
            }
            return View(district);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateDistrict(CreateDistrictViewModel model)
        {
            var dateNow = DateTimeOffset.Now;
            var lastDistrict = _districtRepository.GetAllDistrict().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeKecamatan).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            if (lastDistrict == null)
            {
                model.KodeKecamatan = "DST" + setDateNow + "0001";
            }
            else
            {
                var lastDateDistrict = lastDistrict.KodeKecamatan.Substring(3, 6);

                if (lastDateDistrict != setDateNow)
                {
                    model.KodeKecamatan = "DST" + setDateNow + "0001";
                }
                else
                {
                    model.KodeKecamatan = "DST" + setDateNow + (Convert.ToInt32(lastDistrict.KodeKecamatan.Substring(9, lastDistrict.KodeKecamatan.Length - 9)) + 1).ToString("D4");
                }
            }
            if (ModelState.IsValid)
            {
                District newDistrict = new District
                {
                    DistrictId = model.DistrictId,
                    KodeKecamatan = model.KodeKecamatan,
                    NamaKecamatan = model.NamaKecamatan,
                    CityId = model.CityId,
                    ProvinceId = model.ProvinceId,
                    CountryId = model.CountryId,
                };

                var result = _districtRepository.GetAllDistrict().Where(c => c.NamaKecamatan == model.NamaKecamatan).FirstOrDefault();
                if (result == null)
                {
                    _districtRepository.Add(newDistrict);
                    TempData["SuccessMessage"] = "Kecamatan " + model.NamaKecamatan + " Berhasil Disimpan";
                    return RedirectToAction("Index", "District");
                }
                else
                {
                    ModelState.AddModelError("", "Maaf, nama kecamatan sudah ada !!!");
                    ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
                    ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
                    ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
                    return View(model);
                }
            }
            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
            ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
            ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
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
