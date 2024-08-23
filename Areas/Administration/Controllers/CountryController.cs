using BenariMikronWebApp.Areas.Administration.Models;
using BenariMikronWebApp.Areas.Administration.Repositories;
using BenariMikronWebApp.Areas.Administration.ViewModels;
using BenariMikronWebApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BenariMikronWebApp.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Route("Administration/[Controller]/[Action]")]
    public class CountryController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ICountryRepository _countryRepository;
        private readonly IProvinceRepository _provinceRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly ISubDistrictRepository _subDistrictRepository;
        public CountryController(
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
            var tampilkanData = _countryRepository.GetAllCountry();
            return View(tampilkanData);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult CreateCountry()
        {
            var country = new CreateCountryViewModel();
            var dateNow = DateTimeOffset.Now;
            var lastCodeNgr = _countryRepository.GetAllCountry().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeNegara).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            if (lastCodeNgr == null)
            {
                country.KodeNegara = "NGR" + setDateNow + "0001";
            }
            else
            {
                var lastDateEdu = lastCodeNgr.KodeNegara.Substring(3, 6);

                if (lastDateEdu != setDateNow)
                {
                    country.KodeNegara = "NGR" + setDateNow + "0001";
                }
                else
                {
                    country.KodeNegara = "NGR" + setDateNow + (Convert.ToInt32(lastCodeNgr.KodeNegara.Substring(9, lastCodeNgr.KodeNegara.Length - 9)) + 1).ToString("D4");
                }
            }
            return View(country);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateCountry(CreateCountryViewModel model)
        {
            var dateNow = DateTimeOffset.Now;
            var lastNgr = _countryRepository.GetAllCountry().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeNegara).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            if (lastNgr == null)
            {
                model.KodeNegara = "NGR" + setDateNow + "0001";
            }
            else
            {
                var lastDateNgr = lastNgr.KodeNegara.Substring(3, 6);

                if (lastDateNgr != setDateNow)
                {
                    model.KodeNegara = "NGR" + setDateNow + "0001";
                }
                else
                {
                    model.KodeNegara = "NGR" + setDateNow + (Convert.ToInt32(lastNgr.KodeNegara.Substring(9, lastNgr.KodeNegara.Length - 9)) + 1).ToString("D4");
                }
            }

            if (ModelState.IsValid)
            {
                Country newCountry = new Country
                {
                    CountryId = model.CountryId,
                    KodeNegara = model.KodeNegara,
                    NamaNegara = model.NamaNegara
                };

                var result = _countryRepository.GetAllCountry().Where(c => c.NamaNegara == model.NamaNegara).FirstOrDefault();
                if (result == null)
                {
                    _countryRepository.Add(newCountry);
                    TempData["SuccessMessage"] = "Negara " + model.NamaNegara + " Berhasil Disimpan";
                    return RedirectToAction("Index", "Country");
                }
                else
                {
                    ModelState.AddModelError("", "Maaf, nama negara sudah ada !!!");
                    return View(model);
                }
            }
            return View();
        }
    }
}
