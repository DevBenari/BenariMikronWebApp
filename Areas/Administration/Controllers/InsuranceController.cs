using BenariMikronWebApp.Areas.Administration.Models;
using BenariMikronWebApp.Areas.Administration.Repositories;
using BenariMikronWebApp.Areas.Administration.ViewModels;
using BenariMikronWebApp.Areas.Identity.Data;
using BenariMikronWebApp.Core.Repositories;
using BenariMikronWebApp.Core.ViewModels;
using BenariMikronWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BenariMikronWebApp.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Route("Administration/[Controller]/[Action]")]
    public class InsuranceController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IInsuranceRepository _insuranceRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IProvinceRepository _provinceRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly ISubDistrictRepository _subDistrictRepository;

        public InsuranceController(
            ApplicationDbContext applicationDbContext,
            SignInManager<ApplicationUser> signInManager,
            IInsuranceRepository insuranceRepository,
            ICountryRepository countryRepository,
            IProvinceRepository provinceRepository,
            ICityRepository cityRepository,
            IDistrictRepository districtRepository,
            ISubDistrictRepository subDistrictRepository)
        {
            _applicationDbContext = applicationDbContext;
            _signInManager = signInManager;
            _insuranceRepository = insuranceRepository;
            _countryRepository = countryRepository;
            _provinceRepository = provinceRepository;
            _cityRepository = cityRepository;
            _districtRepository = districtRepository;
            _subDistrictRepository = subDistrictRepository;
        }
        public IActionResult Index()
        {            
            var tampilkanDataAsuransi = _insuranceRepository.GetAllInsurance();
            return View(tampilkanDataAsuransi);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ViewResult> CreateInsurance()
        {
            var asuransi = new CreateInsuranceViewModel();
            var dateNow = DateTimeOffset.Now;
            var lastCodeInsurance = _insuranceRepository.GetAllInsurance().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeAsuransi).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "Name");
            ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "Name");
            ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "Name");
            ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "Name");

            if (lastCodeInsurance == null)
            {
                asuransi.KodeAsuransi = "ASR" + setDateNow + "0001";
            }
            else
            {
                var lastDateInsurance = lastCodeInsurance.KodeAsuransi.Substring(3, 6);

                if (lastDateInsurance != setDateNow)
                {
                    asuransi.KodeAsuransi = "ASR" + setDateNow + "0001";
                }
                else
                {
                    asuransi.KodeAsuransi = "ASR" + setDateNow + (Convert.ToInt32(lastCodeInsurance.KodeAsuransi.Substring(9, lastCodeInsurance.KodeAsuransi.Length - 9)) + 1).ToString("D4");
                }
            }
            return View(asuransi);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInsurance(CreateInsuranceViewModel model)
        {
            var dateNow = DateTimeOffset.Now;
            var lastInsurance = _insuranceRepository.GetAllInsurance().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeAsuransi).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            if (lastInsurance == null)
            {
                model.KodeAsuransi = "ASR" + setDateNow + "0001";
            }
            else
            {
                var lastDateInsurance = lastInsurance.KodeAsuransi.Substring(3, 6);

                if (lastDateInsurance != setDateNow)
                {
                    model.KodeAsuransi = "ASR" + setDateNow + "0001";
                }
                else
                {
                    model.KodeAsuransi = "ASR" + setDateNow + (Convert.ToInt32(lastInsurance.KodeAsuransi.Substring(9, lastInsurance.KodeAsuransi.Length - 9)) + 1).ToString("D4");
                }
            }

            if (ModelState.IsValid)
            {
                //string uniqueFileName = ProcessUploadFile(model);
                var newInsurance = new Insurance
                {
                    CreateDateTime = DateTimeOffset.Now,
                    InsuranceId = model.InsuranceId,
                    KodeAsuransi = model.KodeAsuransi,
                    MulaiKerjasama = model.MulaiKerjasama,
                    AkhirKerjasama = model.AkhirKerjasama,
                    KodePerusahaan = model.KodePerusahaan,
                    TipePerusahaan = model.TipePerusahaan,
                    NamaPerusahaan = model.NamaPerusahaan,
                    TarifGroupPerusahaan = model.TarifGroupPerusahaan,
                    Email = model.Email,
                    AkunBankKartuKredit = model.AkunBankKartuKredit,                    
                    KomisiKartuKredit = model.KomisiKartuKredit,
                    Diskon = model.Diskon,
                    TermasukAsuransi = model.TermasukAsuransi,
                    TermasukKaryawanRS = model.TermasukKaryawanRS,
                    //PerusahaanAsuransi = model.PerusahaanAsuransi,
                    Direktur = model.Direktur,
                    NamaKontak = model.NamaKontak,
                    Jabatan = model.Jabatan,
                    Bagian = model.Bagian,
                    Alamat = model.Alamat,
                    AlamatTagihan = model.AlamatTagihan,
                    CountryId = model.CountryId,
                    ProvinceId = model.ProvinceId,
                    CityId = model.CityId,
                    DistrictId = model.DistrictId,
                    SubDistrictId = model.SubDistrictId,
                    KodePos = model.KodePos,
                    NomorTelepon = model.NomorTelepon,
                    NomorFax = model.NomorFax,
                    Status = model.Status,
                    JenisKerjasama = model.JenisKerjasama,
                    JenisKontrak = model.JenisKontrak,
                    JatuhTempo = model.JatuhTempo,
                    KriteriaPembayaran = model.KriteriaPembayaran,
                    MenjaminPasienOTC = model.MenjaminPasienOTC,
                    AkunBankAtasNama = model.AkunBankAtasNama,
                    NamaBank = model.NamaBank,
                    NamaCabang = model.NamaCabang,
                    NomorRekeningBank = model.NomorRekeningBank,
                    Pinalti = model.Pinalti,
                    Keterangan = model.Keterangan
                };

                var result = _insuranceRepository.GetAllInsurance().Where(c => c.NamaPerusahaan == model.NamaPerusahaan).FirstOrDefault();

                if (result == null)
                {
                    _insuranceRepository.Tambah(newInsurance);
                    TempData["SuccessMessage"] = "Perusahaan Asuransi " + model.NamaPerusahaan + " Berhasil Disimpan";
                    return RedirectToAction("Index", "Insurance");
                }
                else
                {
                    ModelState.AddModelError("", "Maaf, nama perusahaan sudah ada !!!");
                    return View(model);
                }
            }
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
