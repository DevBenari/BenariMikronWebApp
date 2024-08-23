using BenariMikronWebApp.Areas.Identity.Data;
using BenariMikronWebApp.Areas.PatientRegistration.Models;
using BenariMikronWebApp.Areas.PatientRegistration.Repositories;
using BenariMikronWebApp.Areas.PatientRegistration.ViewModels;
using BenariMikronWebApp.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using ZXing.QrCode;
using ZXing;
using FastReport.Data;
using FastReport.Export.PdfSimple;
using FastReport.Web;
using FastReport;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Mvc.Rendering;
using BenariMikronWebApp.Areas.Administration.Repositories;

namespace BenariMikronWebApp.Areas.PatientRegistration.Controllers
{
    [Area("PatientRegistration")]
    [Route("PatientRegistration/[Controller]/[Action]")]
    public class ExternalPatientController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;        
        private readonly IInsuranceRepository _insuranceRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IProvinceRepository _provinceRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly ISubDistrictRepository _subDistrictRepository;
        private readonly IPromoRepository _promoRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;
        private readonly INewPatientExternalLaboratoriumRepository _newPatientExternalLaboratoriumRepository;
        private readonly INewPatientExternalRadiologiRepository _newPatientExternalRadiologiRepository;
        private readonly INewPatientExternalRehabilitasiMedikRepository _newPatientExternalRehabilitasiMedikRepository;
        private readonly INewPatientExternalMedicalCheckUpRepository _newPatientExternalMedicalCheckUpRepository;
        private readonly INewPatientExternalFasilitasRepository _newPatientExternalFasilitasRepository;
        private readonly INewPatientExternalAmbulanceRepository _newPatientExternalAmbulanceRepository;
        private readonly INewPatientExternalOptikRepository _newPatientExternalOptikRepository;
        public ExternalPatientController(
            ApplicationDbContext applicationDbContext,            
            IInsuranceRepository insuranceRepository,
            ICountryRepository countryRepository,
            IProvinceRepository provinceRepository,
            ICityRepository cityRepository,
            IDistrictRepository districtRepository,
            ISubDistrictRepository subDistrictRepository,
            IPromoRepository promoRepository,
            IWebHostEnvironment webHostEnvironment,
            IConfiguration configuration,
            INewPatientExternalLaboratoriumRepository newPatientExternalLaboratoriumRepository,
            INewPatientExternalRadiologiRepository newPatientExternalRadiologiRepository,
            INewPatientExternalRehabilitasiMedikRepository newPatientExternalRehabilitasiMedikRepository,
            INewPatientExternalMedicalCheckUpRepository newPatientExternalMedicalCheckUpRepository,
            INewPatientExternalFasilitasRepository newPatientExternalFasilitasRepository,
            INewPatientExternalAmbulanceRepository newPatientExternalAmbulanceRepository,
            INewPatientExternalOptikRepository newPatientExternalOptikRepository
        )
        {
            _applicationDbContext = applicationDbContext;            
            _insuranceRepository = insuranceRepository;
            _countryRepository = countryRepository;
            _provinceRepository = provinceRepository;
            _cityRepository = cityRepository;
            _districtRepository = districtRepository;
            _subDistrictRepository = subDistrictRepository;
            _promoRepository = promoRepository;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
            _newPatientExternalLaboratoriumRepository = newPatientExternalLaboratoriumRepository;
            _newPatientExternalRadiologiRepository = newPatientExternalRadiologiRepository;
            _newPatientExternalRehabilitasiMedikRepository = newPatientExternalRehabilitasiMedikRepository;
            _newPatientExternalMedicalCheckUpRepository = newPatientExternalMedicalCheckUpRepository;
            _newPatientExternalFasilitasRepository = newPatientExternalFasilitasRepository;
            _newPatientExternalAmbulanceRepository = newPatientExternalAmbulanceRepository;
            _newPatientExternalOptikRepository = newPatientExternalOptikRepository;
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

        #region Pasien Laboratorium
        public IActionResult Index()
        {
            var externalPatientLaboratorium = _newPatientExternalLaboratoriumRepository.GetAllExternalPatientLaboratorium();
            return View(externalPatientLaboratorium);
        }
        
        public IActionResult PatientLaboratorium()
        {
            ViewBag.Title = "List Pasien Laboratorium";

            var tampilkanListExternalPatient = _newPatientExternalLaboratoriumRepository.GetAllExternalPatientLaboratorium();
            return View(tampilkanListExternalPatient);            
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ViewResult> CreateExternalPatientLaboratorium()
        {
            var externalPatient = new CreateExternalPatientLaboratoriumViewModel();
            var dateNow = DateTimeOffset.Now;
            var setDateKodePasien = DateTimeOffset.Now.ToString("yyMMdd");

            ViewBag.Insurance = new SelectList(await _insuranceRepository.GetInsurances(), "InsuranceId", "NamaPerusahaan", SortOrder.Ascending);
            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
            ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
            ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
            ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);
            ViewBag.Promo = new SelectList(await _promoRepository.GetPromos(), "PromoId", "NamaPromo", SortOrder.Ascending);

            var lastCodeNewPatient = _newPatientExternalLaboratoriumRepository.GetAllExternalPatientLaboratorium().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(k => k.KodePasien).FirstOrDefault();
            if (lastCodeNewPatient == null)
            {
                externalPatient.KodePasien = "EPLAB" + setDateKodePasien + "0001";
            }
            else
            {
                var lastKodeDate = lastCodeNewPatient.KodePasien.Substring(5, 6);

                if (lastKodeDate != setDateKodePasien)
                {
                    externalPatient.KodePasien = "EPLAB" + setDateKodePasien + "0001";
                }
                else
                {
                    externalPatient.KodePasien = "EPLAB" + setDateKodePasien + (Convert.ToInt32(lastCodeNewPatient.KodePasien.Substring(11, lastCodeNewPatient.KodePasien.Length - 11)) + 1).ToString("D4");
                }
            }

            //Penomoran Rekam Medis = 00-00-00-00 (Kode Unik RS - Tahun Dibuat - Bulan Dibuat - Nomor Urut Asc)            

            var kodeTahun = DateTimeOffset.Now.ToString("yy");
            var kodeHari = DateTimeOffset.Now.ToString("dd");
            var tipePasien = 20; //Kode untuk Pasien Luar Laboratorium

            var noRekamMedisBaru = _newPatientExternalLaboratoriumRepository.GetAllExternalPatientLaboratorium().OrderByDescending(p => p.NomorRekamMedisBaru).FirstOrDefault();
            if (lastCodeNewPatient == null)
            {
                externalPatient.NomorRekamMedisBaru = kodeTahun + "-" + kodeHari + "-" + tipePasien + "-" + "01";
            }
            else
            {
                externalPatient.NomorRekamMedisBaru = kodeTahun + "-" + kodeHari + "-" + tipePasien + "-" + (Convert.ToInt32(noRekamMedisBaru.NomorRekamMedisBaru.Substring(9, noRekamMedisBaru.NomorRekamMedisBaru.Length - 9)) + 1).ToString("D2");
            }

            return View(externalPatient);
        }        

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateExternalPatientLaboratorium(CreateExternalPatientLaboratoriumViewModel model)
        {
            var dateNow = DateTimeOffset.Now;
            var setDateKodePasien = DateTimeOffset.Now.ToString("yyMMdd");

            ViewBag.Insurance = new SelectList(await _insuranceRepository.GetInsurances(), "InsuranceId", "NamaPerusahaan", SortOrder.Ascending);
            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
            ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
            ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
            ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);
            ViewBag.Promo = new SelectList(await _promoRepository.GetPromos(), "PromoId", "NamaPromo", SortOrder.Ascending);

            var lastCodeExternalPatient = _newPatientExternalLaboratoriumRepository.GetAllExternalPatientLaboratorium().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(k => k.KodePasien).FirstOrDefault();
            if (lastCodeExternalPatient == null)
            {
                model.KodePasien = "EPLAB" + setDateKodePasien + "0001";
            }
            else
            {
                var lastKodeDate = lastCodeExternalPatient.KodePasien.Substring(5, 6);

                if (lastKodeDate != setDateKodePasien)
                {
                    model.KodePasien = "EPLAB" + setDateKodePasien + "0001";
                }
                else
                {
                    model.KodePasien = "EPLAB" + setDateKodePasien + (Convert.ToInt32(lastCodeExternalPatient.KodePasien.Substring(11, lastCodeExternalPatient.KodePasien.Length - 11)) + 1).ToString("D4");
                }
            }
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                var writer = new QRCodeWriter();
                var resultBit = writer.encode(model.NomorRekamMedisBaru, BarcodeFormat.QR_CODE, 200, 200);
                var matrix = resultBit;
                int scale = 2;
                Bitmap result = new Bitmap(matrix.Width * scale, matrix.Height * scale);
                for (int x = 0; x < matrix.Height; x++)
                {
                    for (int y = 0; y < matrix.Width; y++)
                    {
                        Color pixel = matrix[x, y] ? Color.Black : Color.White;
                        for (int i = 0; i < scale; i++)
                            for (int j = 0; j < scale; j++)
                                result.SetPixel(x * scale + i, y * scale + j, pixel);
                    }
                }

                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "QRCodePasienLuarLaboratorium");
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.NomorRekamMedisBaru + "_" + model.NamaPasien + ".png";
                string filePath = Path.Combine(uploadFolder, uniqueFileName);

                result.Save(filePath);

                ExternalPatientLaboratorium externalPasien = new ExternalPatientLaboratorium
                {
                    CreateDateTime = DateTimeOffset.Now,
                    ExternalPatientId = model.ExternalPatientId,
                    KodePasien = model.KodePasien,
                    NomorRekamMedisBaru = model.NomorRekamMedisBaru,
                    NomorRekamMedisLama = model.NomorRekamMedisLama,
                    TipePasien = model.TipePasien,
                    InsuranceId = model.InsuranceId,
                    NomorPolis = model.NomorPolis,
                    Title = model.Title,
                    NamaPasien = model.NamaPasien,
                    NomorIdentitasPasien = model.NomorIdentitasPasien,
                    TempatLahir = model.TempatLahir,
                    TanggalLahir = model.TanggalLahir,
                    JenisKelamin = model.JenisKelamin,
                    AlamatLengkap = model.AlamatLengkap,
                    CountryId = model.CountryId,
                    ProvinceId = model.ProvinceId,
                    CityId = model.CityId,
                    DistrictId = model.DistrictId,
                    SubDistrictId = model.SubDistrictId,
                    KodePos = model.KodePos,
                    NomorTelepon = model.NomorTelepon,
                    EmailAktif = model.EmailAktif,
                    TipeRujukan = model.TipeRujukan,
                    DeskripsiRujukan = model.DeskripsiRujukan,
                    PromoId = model.PromoId,
                    TipePemeriksaan = model.TipePemeriksaan,
                    SuratRujukan = model.SuratRujukan,
                    DiagnosaAwal = model.DiagnosaAwal,
                    TanggalSampling = model.TanggalSampling,
                    DetailTindakan = model.DetailTindakan,
                    DokterPemeriksa = model.DokterPemeriksa,
                    Pemeriksaan = model.Pemeriksaan,
                    GenerateQrCode = uniqueFileName
                };

                var resultData = _newPatientExternalLaboratoriumRepository.GetAllExternalPatientLaboratorium().Where(c => c.NomorIdentitasPasien == model.NomorIdentitasPasien).FirstOrDefault();

                if (resultData == null)
                {
                    _newPatientExternalLaboratoriumRepository.Add(externalPasien);
                    TempData["SuccessMessage"] = "Pasien No. Rekam Medis " + model.NomorRekamMedisBaru + " Berhasil Disimpan";
                    return RedirectToAction("PatientLaboratorium", "ExternalPatient");
                    //return RedirectToAction("NewPatient", "PatientList", new { id = newPasien.PatientRegistrationId });
                }
                else
                {
                    ModelState.AddModelError("", "Maaf, nama pasien sudah ada !!!");
                    ViewBag.Insurance = new SelectList(await _insuranceRepository.GetInsurances(), "InsuranceId", "NamaPerusahaan", SortOrder.Ascending);
                    ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
                    ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
                    ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
                    ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);
                    ViewBag.Promo = new SelectList(await _promoRepository.GetPromos(), "PromoId", "NamaPromo", SortOrder.Ascending);
                    return View(model);
                }
            }
            ViewBag.Insurance = new SelectList(await _insuranceRepository.GetInsurances(), "InsuranceId", "NamaPerusahaan", SortOrder.Ascending);
            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
            ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
            ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
            ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);
            ViewBag.Promo = new SelectList(await _promoRepository.GetPromos(), "PromoId", "NamaPromo", SortOrder.Ascending);
            return View();
        }        

        public async Task<IActionResult> PrintQrPatientLaboratorium(Guid Id)
        {
            var pasienId = await _newPatientExternalLaboratoriumRepository.GetExternalPatientLaboratoriumById(Id);

            //var ambilFileNameGambar = _pasienBaruRepository.GetAllPasienBaru().Where(idGambar => idGambar.Id == Id).FirstOrDefault();
            //var tangkapGambar = ambilFileNameGambar.GenerateQrCode;

            string imageParam = "";
            string pathFolder = _webHostEnvironment.WebRootPath + "\\QRCodePasienLuarLaboratorium\\" + pasienId.GenerateQrCode;

            using (var b = new Bitmap(pathFolder))
            {
                using (var ms = new MemoryStream())
                {
                    b.Save(ms, ImageFormat.Bmp);
                    imageParam = Convert.ToBase64String(ms.ToArray());
                }
            }

            pasienId.GenerateQrCode = pathFolder;                
            var getNomorRekamMedisBaru = pasienId.NomorRekamMedisBaru;
            WebReport web = new WebReport();
            var path = $"{_webHostEnvironment.WebRootPath}\\DesainKartuPasienLuar\\NewCetakKartuPasienLuarLaboratorium.frx";
            web.Report.Load(path);

            var msSqlDataConnection = new MsSqlDataConnection();
            msSqlDataConnection.ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            var Conn = msSqlDataConnection.ConnectionString;

            web.Report.SetParameterValue("Conn", Conn);
            web.Report.SetParameterValue("IdExternalPatientLaboratorium", Id.ToString());

            PictureObject pic = web.Report.FindObject("Picture1") as PictureObject;
            pic.Image = new Bitmap(pathFolder);

            web.Report.Prepare();
            Stream stream = new MemoryStream();
            web.Report.Export(new PDFSimpleExport(), stream);
            stream.Position = 0;

            return File(stream, "application/zip", (getNomorRekamMedisBaru + ".pdf"));
        }

        #endregion Pasien Laboratorium

        #region Pasien Radiologi
        public IActionResult PatientRadiologi()
        {
            var externalPatientRadiologi = _newPatientExternalRadiologiRepository.GetAllExternalPatientRadiologi();
            return View(externalPatientRadiologi);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ViewResult> CreateExternalPatientRadiologi()
        {           
            var externalPatient = new CreateExternalPatientRadiologiViewModel();
            var dateNow = DateTimeOffset.Now;
            var setDateKodePasien = DateTimeOffset.Now.ToString("yyMMdd");

            ViewBag.Insurance = new SelectList(await _insuranceRepository.GetInsurances(), "InsuranceId", "NamaPerusahaan", SortOrder.Ascending);
            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
            ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
            ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
            ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);

            var lastCodeNewPatient = _newPatientExternalRadiologiRepository.GetAllExternalPatientRadiologi().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(k => k.KodePasien).FirstOrDefault();

            if (lastCodeNewPatient == null)
            {
                externalPatient.KodePasien = "EPRAD" + setDateKodePasien + "0001";
            }
            else
            {
                var lastKodeDate = lastCodeNewPatient.KodePasien.Substring(5, 6);

                if (lastKodeDate != setDateKodePasien)
                {
                    externalPatient.KodePasien = "EPRAD" + setDateKodePasien + "0001";
                }
                else
                {
                    externalPatient.KodePasien = "EPRAD" + setDateKodePasien + (Convert.ToInt32(lastCodeNewPatient.KodePasien.Substring(11, lastCodeNewPatient.KodePasien.Length - 11)) + 1).ToString("D4");
                }
            }

            //Penomoran Rekam Medis = 00-00-00-00 (Kode Unik RS - Tahun Dibuat - Bulan Dibuat - Nomor Urut Asc)            

            var kodeTahun = DateTimeOffset.Now.ToString("yy");
            var kodeHari = DateTimeOffset.Now.ToString("dd");
            var tipePasien = 30; //Kode untuk Pasien Luar Radiologi

            var noRekamMedisBaru = _newPatientExternalRadiologiRepository.GetAllExternalPatientRadiologi().OrderByDescending(p => p.NomorRekamMedisBaru).FirstOrDefault();
            if (lastCodeNewPatient == null)
            {
                externalPatient.NomorRekamMedisBaru = kodeTahun + "-" + kodeHari + "-" + tipePasien + "-" + "01";
            }
            else
            {
                externalPatient.NomorRekamMedisBaru = kodeTahun + "-" + kodeHari + "-" + tipePasien + "-" + (Convert.ToInt32(noRekamMedisBaru.NomorRekamMedisBaru.Substring(9, noRekamMedisBaru.NomorRekamMedisBaru.Length - 9)) + 1).ToString("D2");
            }

            return View(externalPatient);
        }        

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateExternalPatientRadiologi(CreateExternalPatientRadiologiViewModel model)
        {
            var dateNow = DateTimeOffset.Now;
            var setDateKodePasien = DateTimeOffset.Now.ToString("yyMMdd");

            ViewBag.Insurance = new SelectList(await _insuranceRepository.GetInsurances(), "InsuranceId", "NamaPerusahaan", SortOrder.Ascending);
            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
            ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
            ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
            ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);

            var lastCodeExternalPatient = _newPatientExternalRadiologiRepository.GetAllExternalPatientRadiologi().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(k => k.KodePasien).FirstOrDefault();

            if (lastCodeExternalPatient == null)
            {
                model.KodePasien = "EPRAD" + setDateKodePasien + "0001";
            }
            else
            {
                var lastKodeDate = lastCodeExternalPatient.KodePasien.Substring(5, 6);

                if (lastKodeDate != setDateKodePasien)
                {
                    model.KodePasien = "EPRAD" + setDateKodePasien + "0001";
                }
                else
                {
                    model.KodePasien = "EPRAD" + setDateKodePasien + (Convert.ToInt32(lastCodeExternalPatient.KodePasien.Substring(11, lastCodeExternalPatient.KodePasien.Length - 11)) + 1).ToString("D4");
                }
            }
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                var writer = new QRCodeWriter();
                var resultBit = writer.encode(model.NomorRekamMedisBaru, BarcodeFormat.QR_CODE, 200, 200);
                var matrix = resultBit;
                int scale = 2;
                Bitmap result = new Bitmap(matrix.Width * scale, matrix.Height * scale);
                for (int x = 0; x < matrix.Height; x++)
                {
                    for (int y = 0; y < matrix.Width; y++)
                    {
                        Color pixel = matrix[x, y] ? Color.Black : Color.White;
                        for (int i = 0; i < scale; i++)
                            for (int j = 0; j < scale; j++)
                                result.SetPixel(x * scale + i, y * scale + j, pixel);
                    }
                }

                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "QRCodePasienLuarRadiologi");
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.NomorRekamMedisBaru + "_" + model.NamaPasien + ".png";
                string filePath = Path.Combine(uploadFolder, uniqueFileName);

                result.Save(filePath);

                ExternalPatientRadiologi externalPasien = new ExternalPatientRadiologi
                {
                    CreateDateTime = DateTimeOffset.Now,
                    ExternalPatientId = model.ExternalPatientId,
                    KodePasien = model.KodePasien,
                    NomorRekamMedisBaru = model.NomorRekamMedisBaru,
                    NomorRekamMedisLama = model.NomorRekamMedisLama,
                    TipePasien = model.TipePasien,
                    InsuranceId = model.InsuranceId,
                    NomorPolis = model.NomorPolis,
                    Title = model.Title,
                    NamaPasien = model.NamaPasien,
                    NomorIdentitasPasien = model.NomorIdentitasPasien,
                    TempatLahir = model.TempatLahir,
                    TanggalLahir = model.TanggalLahir,
                    JenisKelamin = model.JenisKelamin,
                    AlamatLengkap = model.AlamatLengkap,
                    CountryId = model.CountryId,
                    ProvinceId = model.ProvinceId,
                    CityId = model.CityId,
                    DistrictId = model.DistrictId,
                    SubDistrictId = model.SubDistrictId,
                    KodePos = model.KodePos,
                    NomorTelepon = model.NomorTelepon,
                    EmailAktif = model.EmailAktif,
                    TipeRujukan = model.TipeRujukan,
                    DeskripsiRujukan = model.DeskripsiRujukan,
                    Promo = model.Promo,                    
                    SuratRujukan = model.SuratRujukan,
                    DiagnosaAwal = model.DiagnosaAwal,                    
                    DetailTindakan = model.DetailTindakan,
                    DokterPemeriksa = model.DokterPemeriksa,
                    Pemeriksaan = model.Pemeriksaan,
                    GenerateQrCode = uniqueFileName
                };

                var resultData = _newPatientExternalRadiologiRepository.GetAllExternalPatientRadiologi().Where(c => c.NomorIdentitasPasien == model.NomorIdentitasPasien).FirstOrDefault();

                if (resultData == null)
                {
                    _newPatientExternalRadiologiRepository.Add(externalPasien);
                    TempData["SuccessMessage"] = "Pasien No. Rekam Medis " + model.NomorRekamMedisBaru + " Berhasil Disimpan";
                    return RedirectToAction("PatientRadiologi", "ExternalPatient");
                    //return RedirectToAction("NewPatient", "PatientList", new { id = newPasien.PatientRegistrationId });
                }
                else
                {
                    ModelState.AddModelError("", "Maaf, nama pasien sudah ada !!!");
                    ViewBag.Insurance = new SelectList(await _insuranceRepository.GetInsurances(), "InsuranceId", "NamaPerusahaan", SortOrder.Ascending);
                    ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
                    ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
                    ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
                    ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);
                    return View(model);
                }
            }
            ViewBag.Insurance = new SelectList(await _insuranceRepository.GetInsurances(), "InsuranceId", "NamaPerusahaan", SortOrder.Ascending);
            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
            ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
            ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
            ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);
            return View();
        }

        public async Task<IActionResult> PrintQrPatientRadiologi(Guid Id)
        {
            var pasienId = await _newPatientExternalRadiologiRepository.GetExternalPatientRadiologiById(Id);

            //var ambilFileNameGambar = _pasienBaruRepository.GetAllPasienBaru().Where(idGambar => idGambar.Id == Id).FirstOrDefault();
            //var tangkapGambar = ambilFileNameGambar.GenerateQrCode;

            string imageParam = "";
            string pathFolder = _webHostEnvironment.WebRootPath + "\\QRCodePasienLuarRadiologi\\" + pasienId.GenerateQrCode;

            using (var b = new Bitmap(pathFolder))
            {
                using (var ms = new MemoryStream())
                {
                    b.Save(ms, ImageFormat.Bmp);
                    imageParam = Convert.ToBase64String(ms.ToArray());
                }
            }

            pasienId.GenerateQrCode = pathFolder;
            var getNomorRekamMedisBaru = pasienId.NomorRekamMedisBaru;
            WebReport web = new WebReport();
            var path = $"{_webHostEnvironment.WebRootPath}\\DesainKartuPasienLuar\\NewCetakKartuPasienLuarRadiologi.frx";
            web.Report.Load(path);

            var msSqlDataConnection = new MsSqlDataConnection();
            msSqlDataConnection.ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            var Conn = msSqlDataConnection.ConnectionString;

            web.Report.SetParameterValue("Conn", Conn);
            web.Report.SetParameterValue("IdExternalPatientRadiologi", Id.ToString());

            PictureObject pic = web.Report.FindObject("Picture1") as PictureObject;
            pic.Image = new Bitmap(pathFolder);

            web.Report.Prepare();
            Stream stream = new MemoryStream();
            web.Report.Export(new PDFSimpleExport(), stream);
            stream.Position = 0;

            return File(stream, "application/zip", (getNomorRekamMedisBaru + ".pdf"));
        }

        #endregion Pasien Radiologi

        #region Pasien Rehabilitasi Medik
        public IActionResult PatientRehabilitasiMedik()
        {
            var externalPatient = _newPatientExternalRehabilitasiMedikRepository.GetAllExternalPatientRehabilitasiMedik();
            return View(externalPatient);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ViewResult> CreateExternalPatientRehabilitasiMedik()
        {
            var externalPatient = new CreateExternalPatientRehabilitasiMedikViewModel();
            var dateNow = DateTimeOffset.Now;
            var setDateKodePasien = DateTimeOffset.Now.ToString("yyMMdd");

            ViewBag.Insurance = new SelectList(await _insuranceRepository.GetInsurances(), "InsuranceId", "NamaPerusahaan", SortOrder.Ascending);
            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
            ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
            ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
            ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);

            var lastCodeNewPatient = _newPatientExternalRehabilitasiMedikRepository.GetAllExternalPatientRehabilitasiMedik().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(k => k.KodePasien).FirstOrDefault();

            if (lastCodeNewPatient == null)
            {
                externalPatient.KodePasien = "EPRHB" + setDateKodePasien + "0001";
            }
            else
            {
                var lastKodeDate = lastCodeNewPatient.KodePasien.Substring(5, 6);

                if (lastKodeDate != setDateKodePasien)
                {
                    externalPatient.KodePasien = "EPRHB" + setDateKodePasien + "0001";
                }
                else
                {
                    externalPatient.KodePasien = "EPRHB" + setDateKodePasien + (Convert.ToInt32(lastCodeNewPatient.KodePasien.Substring(11, lastCodeNewPatient.KodePasien.Length - 11)) + 1).ToString("D4");
                }
            }

            //Penomoran Rekam Medis = 00-00-00-00 (Kode Unik RS - Tahun Dibuat - Bulan Dibuat - Nomor Urut Asc)            

            var kodeTahun = DateTimeOffset.Now.ToString("yy");
            var kodeHari = DateTimeOffset.Now.ToString("dd");
            var tipePasien = 40; //Kode untuk Pasien Luar Rehabilitasi Medik

            var noRekamMedisBaru = _newPatientExternalRehabilitasiMedikRepository.GetAllExternalPatientRehabilitasiMedik().OrderByDescending(p => p.NomorRekamMedisBaru).FirstOrDefault();
            if (lastCodeNewPatient == null)
            {
                externalPatient.NomorRekamMedisBaru = kodeTahun + "-" + kodeHari + "-" + tipePasien + "-" + "01";
            }
            else
            {
                externalPatient.NomorRekamMedisBaru = kodeTahun + "-" + kodeHari + "-" + tipePasien + "-" + (Convert.ToInt32(noRekamMedisBaru.NomorRekamMedisBaru.Substring(9, noRekamMedisBaru.NomorRekamMedisBaru.Length - 9)) + 1).ToString("D2");
            }

            return View(externalPatient);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateExternalPatientRehabilitasiMedik(CreateExternalPatientRehabilitasiMedikViewModel model)
        {
            var dateNow = DateTimeOffset.Now;
            var setDateKodePasien = DateTimeOffset.Now.ToString("yyMMdd");

            ViewBag.Insurance = new SelectList(await _insuranceRepository.GetInsurances(), "InsuranceId", "NamaPerusahaan", SortOrder.Ascending);
            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
            ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
            ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
            ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);

            var lastCodeExternalPatient = _newPatientExternalRehabilitasiMedikRepository.GetAllExternalPatientRehabilitasiMedik().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(k => k.KodePasien).FirstOrDefault();

            if (lastCodeExternalPatient == null)
            {
                model.KodePasien = "EPRHB" + setDateKodePasien + "0001";
            }
            else
            {
                var lastKodeDate = lastCodeExternalPatient.KodePasien.Substring(5, 6);

                if (lastKodeDate != setDateKodePasien)
                {
                    model.KodePasien = "EPRHB" + setDateKodePasien + "0001";
                }
                else
                {
                    model.KodePasien = "EPRHB" + setDateKodePasien + (Convert.ToInt32(lastCodeExternalPatient.KodePasien.Substring(11, lastCodeExternalPatient.KodePasien.Length - 11)) + 1).ToString("D4");
                }
            }
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                var writer = new QRCodeWriter();
                var resultBit = writer.encode(model.NomorRekamMedisBaru, BarcodeFormat.QR_CODE, 200, 200);
                var matrix = resultBit;
                int scale = 2;
                Bitmap result = new Bitmap(matrix.Width * scale, matrix.Height * scale);
                for (int x = 0; x < matrix.Height; x++)
                {
                    for (int y = 0; y < matrix.Width; y++)
                    {
                        Color pixel = matrix[x, y] ? Color.Black : Color.White;
                        for (int i = 0; i < scale; i++)
                            for (int j = 0; j < scale; j++)
                                result.SetPixel(x * scale + i, y * scale + j, pixel);
                    }
                }

                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "QRCodePasienLuarRehabilitasiMedik");
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.NomorRekamMedisBaru + "_" + model.NamaPasien + ".png";
                string filePath = Path.Combine(uploadFolder, uniqueFileName);

                result.Save(filePath);

                ExternalPatientRehabilitasiMedik externalPasien = new ExternalPatientRehabilitasiMedik
                {
                    CreateDateTime = DateTimeOffset.Now,
                    ExternalPatientId = model.ExternalPatientId,
                    KodePasien = model.KodePasien,
                    NomorRekamMedisBaru = model.NomorRekamMedisBaru,
                    NomorRekamMedisLama = model.NomorRekamMedisLama,
                    TipePasien = model.TipePasien,
                    InsuranceId = model.InsuranceId,
                    NomorPolis = model.NomorPolis,
                    Title = model.Title,
                    NamaPasien = model.NamaPasien,
                    NomorIdentitasPasien = model.NomorIdentitasPasien,
                    TempatLahir = model.TempatLahir,
                    TanggalLahir = model.TanggalLahir,
                    JenisKelamin = model.JenisKelamin,
                    AlamatLengkap = model.AlamatLengkap,
                    CountryId = model.CountryId,
                    ProvinceId = model.ProvinceId,
                    CityId = model.CityId,
                    DistrictId = model.DistrictId,
                    SubDistrictId = model.SubDistrictId,
                    KodePos = model.KodePos,
                    NomorTelepon = model.NomorTelepon,
                    EmailAktif = model.EmailAktif,
                    TipeRujukan = model.TipeRujukan,
                    DeskripsiRujukan = model.DeskripsiRujukan,                    
                    SuratRujukan = model.SuratRujukan,
                    DiagnosaAwal = model.DiagnosaAwal,
                    DaftarTindakan = model.DaftarTindakan,
                    DokterPemeriksa = model.DokterPemeriksa,                   
                    GenerateQrCode = uniqueFileName
                };

                var resultData = _newPatientExternalRehabilitasiMedikRepository.GetAllExternalPatientRehabilitasiMedik().Where(c => c.NomorIdentitasPasien == model.NomorIdentitasPasien).FirstOrDefault();

                if (resultData == null)
                {
                    _newPatientExternalRehabilitasiMedikRepository.Add(externalPasien);
                    TempData["SuccessMessage"] = "Pasien No. Rekam Medis " + model.NomorRekamMedisBaru + " Berhasil Disimpan";
                    return RedirectToAction("PatientRehabilitasiMedik", "ExternalPatient");
                    //return RedirectToAction("NewPatient", "PatientList", new { id = newPasien.PatientRegistrationId });
                }
                else
                {
                    ModelState.AddModelError("", "Maaf, nama pasien sudah ada !!!");
                    ViewBag.Insurance = new SelectList(await _insuranceRepository.GetInsurances(), "InsuranceId", "NamaPerusahaan", SortOrder.Ascending);
                    ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
                    ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
                    ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
                    ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);
                    return View(model);
                }
            }
            ViewBag.Insurance = new SelectList(await _insuranceRepository.GetInsurances(), "InsuranceId", "NamaPerusahaan", SortOrder.Ascending);
            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
            ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
            ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
            ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);
            return View();
        }

        public async Task<IActionResult> PrintQrPatientRehabilitasiMedik(Guid Id)
        {
            var pasienId = await _newPatientExternalRehabilitasiMedikRepository.GetExternalPatientRehabilitasiMedikById(Id);

            //var ambilFileNameGambar = _pasienBaruRepository.GetAllPasienBaru().Where(idGambar => idGambar.Id == Id).FirstOrDefault();
            //var tangkapGambar = ambilFileNameGambar.GenerateQrCode;

            string imageParam = "";
            string pathFolder = _webHostEnvironment.WebRootPath + "\\QRCodePasienLuarRehabilitasiMedik\\" + pasienId.GenerateQrCode;

            using (var b = new Bitmap(pathFolder))
            {
                using (var ms = new MemoryStream())
                {
                    b.Save(ms, ImageFormat.Bmp);
                    imageParam = Convert.ToBase64String(ms.ToArray());
                }
            }

            pasienId.GenerateQrCode = pathFolder;
            var getNomorRekamMedisBaru = pasienId.NomorRekamMedisBaru;
            WebReport web = new WebReport();
            var path = $"{_webHostEnvironment.WebRootPath}\\DesainKartuPasienLuar\\NewCetakKartuPasienLuarRehabilitasiMedik.frx";
            web.Report.Load(path);

            var msSqlDataConnection = new MsSqlDataConnection();
            msSqlDataConnection.ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            var Conn = msSqlDataConnection.ConnectionString;

            web.Report.SetParameterValue("Conn", Conn);
            web.Report.SetParameterValue("IdExternalPatientRehabilitasiMedik", Id.ToString());

            PictureObject pic = web.Report.FindObject("Picture1") as PictureObject;
            pic.Image = new Bitmap(pathFolder);

            web.Report.Prepare();
            Stream stream = new MemoryStream();
            web.Report.Export(new PDFSimpleExport(), stream);
            stream.Position = 0;

            return File(stream, "application/zip", (getNomorRekamMedisBaru + ".pdf"));
        }
        #endregion

        #region Pasien Medical Check Up
        public IActionResult PatientMedicalCheckUp()
        {
            var externalPatient = _newPatientExternalMedicalCheckUpRepository.GetAllExternalPatientMedicalCheckUp();
            return View(externalPatient);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ViewResult> CreateExternalPatientMedicalCheckUp()
        {
            var externalPatient = new CreateExternalPatientMedicalCheckUpViewModel();
            var dateNow = DateTimeOffset.Now;
            var setDateKodePasien = DateTimeOffset.Now.ToString("yyMMdd");

            ViewBag.Insurance = new SelectList(await _insuranceRepository.GetInsurances(), "InsuranceId", "NamaPerusahaan", SortOrder.Ascending);
            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
            ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
            ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
            ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);

            var lastCodeNewPatient = _newPatientExternalMedicalCheckUpRepository.GetAllExternalPatientMedicalCheckUp().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(k => k.KodePasien).FirstOrDefault();

            if (lastCodeNewPatient == null)
            {
                externalPatient.KodePasien = "EPMCU" + setDateKodePasien + "0001";
            }
            else
            {
                var lastKodeDate = lastCodeNewPatient.KodePasien.Substring(5, 6);

                if (lastKodeDate != setDateKodePasien)
                {
                    externalPatient.KodePasien = "EPMCU" + setDateKodePasien + "0001";
                }
                else
                {
                    externalPatient.KodePasien = "EPMCU" + setDateKodePasien + (Convert.ToInt32(lastCodeNewPatient.KodePasien.Substring(11, lastCodeNewPatient.KodePasien.Length - 11)) + 1).ToString("D4");
                }
            }

            //Penomoran Rekam Medis = 00-00-00-00 (Kode Unik RS - Tahun Dibuat - Bulan Dibuat - Nomor Urut Asc)            

            var kodeTahun = DateTimeOffset.Now.ToString("yy");
            var kodeHari = DateTimeOffset.Now.ToString("dd");
            var tipePasien = 50; //Kode untuk Pasien Luar Medical Check Up

            var noRekamMedisBaru = _newPatientExternalMedicalCheckUpRepository.GetAllExternalPatientMedicalCheckUp().OrderByDescending(p => p.NomorRekamMedisBaru).FirstOrDefault();
            if (lastCodeNewPatient == null)
            {
                externalPatient.NomorRekamMedisBaru = kodeTahun + "-" + kodeHari + "-" + tipePasien + "-" + "01";
            }
            else
            {
                externalPatient.NomorRekamMedisBaru = kodeTahun + "-" + kodeHari + "-" + tipePasien + "-" + (Convert.ToInt32(noRekamMedisBaru.NomorRekamMedisBaru.Substring(9, noRekamMedisBaru.NomorRekamMedisBaru.Length - 9)) + 1).ToString("D2");
            }

            return View(externalPatient);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateExternalPatientMedicalCheckUp(CreateExternalPatientMedicalCheckUpViewModel model)
        {
            var dateNow = DateTimeOffset.Now;
            var setDateKodePasien = DateTimeOffset.Now.ToString("yyMMdd");

            ViewBag.Insurance = new SelectList(await _insuranceRepository.GetInsurances(), "InsuranceId", "NamaPerusahaan", SortOrder.Ascending);
            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
            ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
            ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
            ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);

            var lastCodeExternalPatient = _newPatientExternalMedicalCheckUpRepository.GetAllExternalPatientMedicalCheckUp().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(k => k.KodePasien).FirstOrDefault();

            if (lastCodeExternalPatient == null)
            {
                model.KodePasien = "EPMCU" + setDateKodePasien + "0001";
            }
            else
            {
                var lastKodeDate = lastCodeExternalPatient.KodePasien.Substring(5, 6);

                if (lastKodeDate != setDateKodePasien)
                {
                    model.KodePasien = "EPMCU" + setDateKodePasien + "0001";
                }
                else
                {
                    model.KodePasien = "EPMCU" + setDateKodePasien + (Convert.ToInt32(lastCodeExternalPatient.KodePasien.Substring(11, lastCodeExternalPatient.KodePasien.Length - 11)) + 1).ToString("D4");
                }
            }
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                var writer = new QRCodeWriter();
                var resultBit = writer.encode(model.NomorRekamMedisBaru, BarcodeFormat.QR_CODE, 200, 200);
                var matrix = resultBit;
                int scale = 2;
                Bitmap result = new Bitmap(matrix.Width * scale, matrix.Height * scale);
                for (int x = 0; x < matrix.Height; x++)
                {
                    for (int y = 0; y < matrix.Width; y++)
                    {
                        Color pixel = matrix[x, y] ? Color.Black : Color.White;
                        for (int i = 0; i < scale; i++)
                            for (int j = 0; j < scale; j++)
                                result.SetPixel(x * scale + i, y * scale + j, pixel);
                    }
                }

                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "QRCodePasienLuarMedicalCheckUp");
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.NomorRekamMedisBaru + "_" + model.NamaPasien + ".png";
                string filePath = Path.Combine(uploadFolder, uniqueFileName);

                result.Save(filePath);

                ExternalPatientMedicalCheckUp externalPasien = new ExternalPatientMedicalCheckUp
                {
                    CreateDateTime = DateTimeOffset.Now,
                    ExternalPatientId = model.ExternalPatientId,
                    KodePasien = model.KodePasien,
                    NomorRekamMedisBaru = model.NomorRekamMedisBaru,
                    NomorRekamMedisLama = model.NomorRekamMedisLama,
                    TipePasien = model.TipePasien,
                    InsuranceId = model.InsuranceId,
                    NomorPolis = model.NomorPolis,
                    Title = model.Title,
                    NamaPasien = model.NamaPasien,
                    NomorIdentitasPasien = model.NomorIdentitasPasien,
                    TempatLahir = model.TempatLahir,
                    TanggalLahir = model.TanggalLahir,
                    JenisKelamin = model.JenisKelamin,
                    AlamatLengkap = model.AlamatLengkap,
                    CountryId = model.CountryId,
                    ProvinceId = model.ProvinceId,
                    CityId = model.CityId,
                    DistrictId = model.DistrictId,
                    SubDistrictId = model.SubDistrictId,
                    KodePos = model.KodePos,
                    NomorTelepon = model.NomorTelepon,
                    EmailAktif = model.EmailAktif,
                    PaketMCU = model.PaketMCU,
                    DokterMCU = model.DokterMCU,
                    TipeRujukan = model.TipeRujukan,
                    DeskripsiRujukan = model.DeskripsiRujukan,
                    Promo = model.Promo,
                    SuratRujukan = model.SuratRujukan,
                    DiagnosaAwal = model.DiagnosaAwal,                    
                    GenerateQrCode = uniqueFileName
                };

                var resultData = _newPatientExternalMedicalCheckUpRepository.GetAllExternalPatientMedicalCheckUp().Where(c => c.NomorIdentitasPasien == model.NomorIdentitasPasien).FirstOrDefault();

                if (resultData == null)
                {
                    _newPatientExternalMedicalCheckUpRepository.Add(externalPasien);
                    TempData["SuccessMessage"] = "Pasien No. Rekam Medis " + model.NomorRekamMedisBaru + " Berhasil Disimpan";
                    return RedirectToAction("PatientMedicalCheckUp", "ExternalPatient");
                    //return RedirectToAction("NewPatient", "PatientList", new { id = newPasien.PatientRegistrationId });
                }
                else
                {
                    ModelState.AddModelError("", "Maaf, nama pasien sudah ada !!!");
                    ViewBag.Insurance = new SelectList(await _insuranceRepository.GetInsurances(), "InsuranceId", "NamaPerusahaan", SortOrder.Ascending);
                    ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
                    ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
                    ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
                    ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);
                    return View(model);
                }
            }
            ViewBag.Insurance = new SelectList(await _insuranceRepository.GetInsurances(), "InsuranceId", "NamaPerusahaan", SortOrder.Ascending);
            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
            ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
            ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
            ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);
            return View();
        }

        public async Task<IActionResult> PrintQrPatientMedicalCheckUp(Guid Id)
        {
            var pasienId = await _newPatientExternalMedicalCheckUpRepository.GetExternalPatientMedicalCheckUpById(Id);

            //var ambilFileNameGambar = _pasienBaruRepository.GetAllPasienBaru().Where(idGambar => idGambar.Id == Id).FirstOrDefault();
            //var tangkapGambar = ambilFileNameGambar.GenerateQrCode;

            string imageParam = "";
            string pathFolder = _webHostEnvironment.WebRootPath + "\\QRCodePasienLuarMedicalCheckUp\\" + pasienId.GenerateQrCode;

            using (var b = new Bitmap(pathFolder))
            {
                using (var ms = new MemoryStream())
                {
                    b.Save(ms, ImageFormat.Bmp);
                    imageParam = Convert.ToBase64String(ms.ToArray());
                }
            }

            pasienId.GenerateQrCode = pathFolder;
            var getNomorRekamMedisBaru = pasienId.NomorRekamMedisBaru;
            WebReport web = new WebReport();
            var path = $"{_webHostEnvironment.WebRootPath}\\DesainKartuPasienLuar\\NewCetakKartuPasienLuarMedicalCheckUp.frx";
            web.Report.Load(path);

            var msSqlDataConnection = new MsSqlDataConnection();
            msSqlDataConnection.ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            var Conn = msSqlDataConnection.ConnectionString;

            web.Report.SetParameterValue("Conn", Conn);
            web.Report.SetParameterValue("IdExternalPatientMedicalCheckUp", Id.ToString());

            PictureObject pic = web.Report.FindObject("Picture1") as PictureObject;
            pic.Image = new Bitmap(pathFolder);

            web.Report.Prepare();
            Stream stream = new MemoryStream();
            web.Report.Export(new PDFSimpleExport(), stream);
            stream.Position = 0;

            return File(stream, "application/zip", (getNomorRekamMedisBaru + ".pdf"));
        }
        #endregion

        #region Pasien Fasilitas
        public IActionResult PatientFasilitas()
        {
            var externalPatient = _newPatientExternalFasilitasRepository.GetAllExternalPatientFasilitas();
            return View(externalPatient);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ViewResult> CreateExternalPatientFasilitas()
        {
            var externalPatient = new CreateExternalPatientFasilitasViewModel();
            var dateNow = DateTimeOffset.Now;
            var setDateKodePasien = DateTimeOffset.Now.ToString("yyMMdd");

            ViewBag.Insurance = new SelectList(await _insuranceRepository.GetInsurances(), "InsuranceId", "NamaPerusahaan", SortOrder.Ascending);
            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
            ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
            ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
            ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);

            var lastCodeNewPatient = _newPatientExternalFasilitasRepository.GetAllExternalPatientFasilitas().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(k => k.KodePasien).FirstOrDefault();

            if (lastCodeNewPatient == null)
            {
                externalPatient.KodePasien = "EPFST" + setDateKodePasien + "0001";
            }
            else
            {
                var lastKodeDate = lastCodeNewPatient.KodePasien.Substring(5, 6);

                if (lastKodeDate != setDateKodePasien)
                {
                    externalPatient.KodePasien = "EPFST" + setDateKodePasien + "0001";
                }
                else
                {
                    externalPatient.KodePasien = "EPFST" + setDateKodePasien + (Convert.ToInt32(lastCodeNewPatient.KodePasien.Substring(11, lastCodeNewPatient.KodePasien.Length - 11)) + 1).ToString("D4");
                }
            }

            //Penomoran Rekam Medis = 00-00-00-00 (Kode Unik RS - Tahun Dibuat - Bulan Dibuat - Nomor Urut Asc)            

            var kodeTahun = DateTimeOffset.Now.ToString("yy");
            var kodeHari = DateTimeOffset.Now.ToString("dd");
            var tipePasien = 60; //Kode untuk Pasien Luar Rehabilitasi Medik

            var noRekamMedisBaru = _newPatientExternalFasilitasRepository.GetAllExternalPatientFasilitas().OrderByDescending(p => p.NomorRekamMedisBaru).FirstOrDefault();
            if (lastCodeNewPatient == null)
            {
                externalPatient.NomorRekamMedisBaru = kodeTahun + "-" + kodeHari + "-" + tipePasien + "-" + "01";
            }
            else
            {
                externalPatient.NomorRekamMedisBaru = kodeTahun + "-" + kodeHari + "-" + tipePasien + "-" + (Convert.ToInt32(noRekamMedisBaru.NomorRekamMedisBaru.Substring(9, noRekamMedisBaru.NomorRekamMedisBaru.Length - 9)) + 1).ToString("D2");
            }

            return View(externalPatient);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateExternalPatientFasilitas(CreateExternalPatientFasilitasViewModel model)
        {
            var dateNow = DateTimeOffset.Now;
            var setDateKodePasien = DateTimeOffset.Now.ToString("yyMMdd");

            ViewBag.Insurance = new SelectList(await _insuranceRepository.GetInsurances(), "InsuranceId", "NamaPerusahaan", SortOrder.Ascending);
            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
            ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
            ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
            ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);

            var lastCodeExternalPatient = _newPatientExternalFasilitasRepository.GetAllExternalPatientFasilitas().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(k => k.KodePasien).FirstOrDefault();

            if (lastCodeExternalPatient == null)
            {
                model.KodePasien = "EPFST" + setDateKodePasien + "0001";
            }
            else
            {
                var lastKodeDate = lastCodeExternalPatient.KodePasien.Substring(5, 6);

                if (lastKodeDate != setDateKodePasien)
                {
                    model.KodePasien = "EPFST" + setDateKodePasien + "0001";
                }
                else
                {
                    model.KodePasien = "EPFST" + setDateKodePasien + (Convert.ToInt32(lastCodeExternalPatient.KodePasien.Substring(11, lastCodeExternalPatient.KodePasien.Length - 11)) + 1).ToString("D4");
                }
            }
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                var writer = new QRCodeWriter();
                var resultBit = writer.encode(model.NomorRekamMedisBaru, BarcodeFormat.QR_CODE, 200, 200);
                var matrix = resultBit;
                int scale = 2;
                Bitmap result = new Bitmap(matrix.Width * scale, matrix.Height * scale);
                for (int x = 0; x < matrix.Height; x++)
                {
                    for (int y = 0; y < matrix.Width; y++)
                    {
                        Color pixel = matrix[x, y] ? Color.Black : Color.White;
                        for (int i = 0; i < scale; i++)
                            for (int j = 0; j < scale; j++)
                                result.SetPixel(x * scale + i, y * scale + j, pixel);
                    }
                }

                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "QRCodePasienLuarFasilitas");
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.NomorRekamMedisBaru + "_" + model.NamaPasien + ".png";
                string filePath = Path.Combine(uploadFolder, uniqueFileName);

                result.Save(filePath);

                ExternalPatientFasilitas externalPasien = new ExternalPatientFasilitas
                {
                    CreateDateTime = DateTimeOffset.Now,
                    ExternalPatientId = model.ExternalPatientId,
                    KodePasien = model.KodePasien,
                    NomorRekamMedisBaru = model.NomorRekamMedisBaru,
                    NomorRekamMedisLama = model.NomorRekamMedisLama,                 
                    Title = model.Title,
                    NamaPasien = model.NamaPasien,
                    NomorIdentitasPasien = model.NomorIdentitasPasien,
                    TempatLahir = model.TempatLahir,
                    TanggalLahir = model.TanggalLahir,
                    JenisKelamin = model.JenisKelamin,
                    AlamatLengkap = model.AlamatLengkap,
                    CountryId = model.CountryId,
                    ProvinceId = model.ProvinceId,
                    CityId = model.CityId,
                    DistrictId = model.DistrictId,
                    SubDistrictId = model.SubDistrictId,
                    KodePos = model.KodePos,
                    NomorTelepon = model.NomorTelepon,
                    EmailAktif = model.EmailAktif,
                    DetailTindakan = model.DetailTindakan,
                    DokterPemeriksa = model.DokterPemeriksa,                    
                    GenerateQrCode = uniqueFileName
                };

                var resultData = _newPatientExternalFasilitasRepository.GetAllExternalPatientFasilitas().Where(c => c.NomorIdentitasPasien == model.NomorIdentitasPasien).FirstOrDefault();

                if (resultData == null)
                {
                    _newPatientExternalFasilitasRepository.Add(externalPasien);
                    TempData["SuccessMessage"] = "Pasien No. Rekam Medis " + model.NomorRekamMedisBaru + " Berhasil Disimpan";
                    return RedirectToAction("PatientFasilitas", "ExternalPatient");
                    //return RedirectToAction("NewPatient", "PatientList", new { id = newPasien.PatientRegistrationId });
                }
                else
                {
                    ModelState.AddModelError("", "Maaf, nama pasien sudah ada !!!");
                    ViewBag.Insurance = new SelectList(await _insuranceRepository.GetInsurances(), "InsuranceId", "NamaPerusahaan", SortOrder.Ascending);
                    ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
                    ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
                    ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
                    ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);
                    return View(model);
                }
            }
            ViewBag.Insurance = new SelectList(await _insuranceRepository.GetInsurances(), "InsuranceId", "NamaPerusahaan", SortOrder.Ascending);
            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
            ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
            ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
            ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);
            return View();
        }

        public async Task<IActionResult> PrintQrPatientFasilitas(Guid Id)
        {
            var pasienId = await _newPatientExternalFasilitasRepository.GetExternalPatientFasilitasById(Id);

            //var ambilFileNameGambar = _pasienBaruRepository.GetAllPasienBaru().Where(idGambar => idGambar.Id == Id).FirstOrDefault();
            //var tangkapGambar = ambilFileNameGambar.GenerateQrCode;

            string imageParam = "";
            string pathFolder = _webHostEnvironment.WebRootPath + "\\QRCodePasienLuarFasilitas\\" + pasienId.GenerateQrCode;

            using (var b = new Bitmap(pathFolder))
            {
                using (var ms = new MemoryStream())
                {
                    b.Save(ms, ImageFormat.Bmp);
                    imageParam = Convert.ToBase64String(ms.ToArray());
                }
            }

            pasienId.GenerateQrCode = pathFolder;
            var getNomorRekamMedisBaru = pasienId.NomorRekamMedisBaru;
            WebReport web = new WebReport();
            var path = $"{_webHostEnvironment.WebRootPath}\\DesainKartuPasienLuar\\NewCetakKartuPasienLuarFasilitas.frx";
            web.Report.Load(path);

            var msSqlDataConnection = new MsSqlDataConnection();
            msSqlDataConnection.ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            var Conn = msSqlDataConnection.ConnectionString;

            web.Report.SetParameterValue("Conn", Conn);
            web.Report.SetParameterValue("IdExternalPatientFasilitas", Id.ToString());

            PictureObject pic = web.Report.FindObject("Picture1") as PictureObject;
            pic.Image = new Bitmap(pathFolder);

            web.Report.Prepare();
            Stream stream = new MemoryStream();
            web.Report.Export(new PDFSimpleExport(), stream);
            stream.Position = 0;

            return File(stream, "application/zip", (getNomorRekamMedisBaru + ".pdf"));
        }
        #endregion

        #region Pasien Ambulance
        public IActionResult PatientAmbulance()
        {
            var externalPatient = _newPatientExternalAmbulanceRepository.GetAllExternalPatientAmbulance();
            return View(externalPatient);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ViewResult> CreateExternalPatientAmbulance()
        {
            var externalPatient = new CreateExternalPatientAmbulanceViewModel();
            var dateNow = DateTimeOffset.Now;
            var setDateKodePasien = DateTimeOffset.Now.ToString("yyMMdd");

            ViewBag.Insurance = new SelectList(await _insuranceRepository.GetInsurances(), "InsuranceId", "NamaPerusahaan", SortOrder.Ascending);
            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
            ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
            ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
            ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);

            var lastCodeNewPatient = _newPatientExternalAmbulanceRepository.GetAllExternalPatientAmbulance().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(k => k.KodePasien).FirstOrDefault();

            if (lastCodeNewPatient == null)
            {
                externalPatient.KodePasien = "EPAMB" + setDateKodePasien + "0001";
            }
            else
            {
                var lastKodeDate = lastCodeNewPatient.KodePasien.Substring(5, 6);

                if (lastKodeDate != setDateKodePasien)
                {
                    externalPatient.KodePasien = "EPAMB" + setDateKodePasien + "0001";
                }
                else
                {
                    externalPatient.KodePasien = "EPAMB" + setDateKodePasien + (Convert.ToInt32(lastCodeNewPatient.KodePasien.Substring(11, lastCodeNewPatient.KodePasien.Length - 11)) + 1).ToString("D4");
                }
            }

            //Penomoran Rekam Medis = 00-00-00-00 (Kode Unik RS - Tahun Dibuat - Bulan Dibuat - Nomor Urut Asc)            

            var kodeTahun = DateTimeOffset.Now.ToString("yy");
            var kodeHari = DateTimeOffset.Now.ToString("dd");
            var tipePasien = 70; //Kode untuk Pasien Luar Rehabilitasi Medik

            var noRekamMedisBaru = _newPatientExternalAmbulanceRepository.GetAllExternalPatientAmbulance().OrderByDescending(p => p.NomorRekamMedisBaru).FirstOrDefault();
            if (lastCodeNewPatient == null)
            {
                externalPatient.NomorRekamMedisBaru = kodeTahun + "-" + kodeHari + "-" + tipePasien + "-" + "01";
            }
            else
            {
                externalPatient.NomorRekamMedisBaru = kodeTahun + "-" + kodeHari + "-" + tipePasien + "-" + (Convert.ToInt32(noRekamMedisBaru.NomorRekamMedisBaru.Substring(9, noRekamMedisBaru.NomorRekamMedisBaru.Length - 9)) + 1).ToString("D2");
            }

            return View(externalPatient);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateExternalPatientAmbulance(CreateExternalPatientAmbulanceViewModel model)
        {
            var dateNow = DateTimeOffset.Now;
            var setDateKodePasien = DateTimeOffset.Now.ToString("yyMMdd");

            ViewBag.Insurance = new SelectList(await _insuranceRepository.GetInsurances(), "InsuranceId", "NamaPerusahaan", SortOrder.Ascending);
            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
            ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
            ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
            ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);

            var lastCodeExternalPatient = _newPatientExternalAmbulanceRepository.GetAllExternalPatientAmbulance().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(k => k.KodePasien).FirstOrDefault();

            if (lastCodeExternalPatient == null)
            {
                model.KodePasien = "EPAMB" + setDateKodePasien + "0001";
            }
            else
            {
                var lastKodeDate = lastCodeExternalPatient.KodePasien.Substring(5, 6);

                if (lastKodeDate != setDateKodePasien)
                {
                    model.KodePasien = "EPAMB" + setDateKodePasien + "0001";
                }
                else
                {
                    model.KodePasien = "EPAMB" + setDateKodePasien + (Convert.ToInt32(lastCodeExternalPatient.KodePasien.Substring(11, lastCodeExternalPatient.KodePasien.Length - 11)) + 1).ToString("D4");
                }
            }
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                var writer = new QRCodeWriter();
                var resultBit = writer.encode(model.NomorRekamMedisBaru, BarcodeFormat.QR_CODE, 200, 200);
                var matrix = resultBit;
                int scale = 2;
                Bitmap result = new Bitmap(matrix.Width * scale, matrix.Height * scale);
                for (int x = 0; x < matrix.Height; x++)
                {
                    for (int y = 0; y < matrix.Width; y++)
                    {
                        Color pixel = matrix[x, y] ? Color.Black : Color.White;
                        for (int i = 0; i < scale; i++)
                            for (int j = 0; j < scale; j++)
                                result.SetPixel(x * scale + i, y * scale + j, pixel);
                    }
                }

                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "QRCodePasienLuarAmbulance");
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.NomorRekamMedisBaru + "_" + model.NamaPasien + ".png";
                string filePath = Path.Combine(uploadFolder, uniqueFileName);

                result.Save(filePath);

                ExternalPatientAmbulance externalPasien = new ExternalPatientAmbulance
                {
                    CreateDateTime = DateTimeOffset.Now,
                    ExternalPatientId = model.ExternalPatientId,
                    KodePasien = model.KodePasien,
                    NomorRekamMedisBaru = model.NomorRekamMedisBaru,
                    NomorRekamMedisLama = model.NomorRekamMedisLama,
                    Title = model.Title,
                    NamaPasien = model.NamaPasien,
                    NomorIdentitasPasien = model.NomorIdentitasPasien,
                    TempatLahir = model.TempatLahir,
                    TanggalLahir = model.TanggalLahir,
                    JenisKelamin = model.JenisKelamin,
                    AlamatLengkap = model.AlamatLengkap,
                    CountryId = model.CountryId,
                    ProvinceId = model.ProvinceId,
                    CityId = model.CityId,
                    DistrictId = model.DistrictId,
                    SubDistrictId = model.SubDistrictId,
                    KodePos = model.KodePos,
                    NomorTelepon = model.NomorTelepon,
                    EmailAktif = model.EmailAktif,
                    Department = model.Department,
                    Komponen = model.Komponen,
                    DaerahTujuan = model.DaerahTujuan,
                    KelebihanJarak = model.KelebihanJarak,
                    KelebihanWaktu = model.KelebihanWaktu,
                    Paramedis = model.Paramedis,
                    AntarJemput = model.AntarJemput,
                    Catatan = model.Catatan,
                    GenerateQrCode = uniqueFileName
                };

                var resultData = _newPatientExternalAmbulanceRepository.GetAllExternalPatientAmbulance().Where(c => c.NomorIdentitasPasien == model.NomorIdentitasPasien).FirstOrDefault();

                if (resultData == null)
                {
                    _newPatientExternalAmbulanceRepository.Add(externalPasien);
                    TempData["SuccessMessage"] = "Pasien No. Rekam Medis " + model.NomorRekamMedisBaru + " Berhasil Disimpan";
                    return RedirectToAction("PatientAmbulance", "ExternalPatient");
                    //return RedirectToAction("NewPatient", "PatientList", new { id = newPasien.PatientRegistrationId });
                }
                else
                {
                    ModelState.AddModelError("", "Maaf, nama pasien sudah ada !!!");
                    ViewBag.Insurance = new SelectList(await _insuranceRepository.GetInsurances(), "InsuranceId", "NamaPerusahaan", SortOrder.Ascending);
                    ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
                    ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
                    ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
                    ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);
                    return View(model);
                }
            }
            ViewBag.Insurance = new SelectList(await _insuranceRepository.GetInsurances(), "InsuranceId", "NamaPerusahaan", SortOrder.Ascending);
            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
            ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
            ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
            ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);
            return View();
        }

        public async Task<IActionResult> PrintQrPatientAmbulance(Guid Id)
        {
            var pasienId = await _newPatientExternalAmbulanceRepository.GetExternalPatientAmbulanceById(Id);

            //var ambilFileNameGambar = _pasienBaruRepository.GetAllPasienBaru().Where(idGambar => idGambar.Id == Id).FirstOrDefault();
            //var tangkapGambar = ambilFileNameGambar.GenerateQrCode;

            string imageParam = "";
            string pathFolder = _webHostEnvironment.WebRootPath + "\\QRCodePasienLuarAmbulance\\" + pasienId.GenerateQrCode;

            using (var b = new Bitmap(pathFolder))
            {
                using (var ms = new MemoryStream())
                {
                    b.Save(ms, ImageFormat.Bmp);
                    imageParam = Convert.ToBase64String(ms.ToArray());
                }
            }

            pasienId.GenerateQrCode = pathFolder;
            var getNomorRekamMedisBaru = pasienId.NomorRekamMedisBaru;
            WebReport web = new WebReport();
            var path = $"{_webHostEnvironment.WebRootPath}\\DesainKartuPasienLuar\\NewCetakKartuPasienLuarAmbulance.frx";
            web.Report.Load(path);

            var msSqlDataConnection = new MsSqlDataConnection();
            msSqlDataConnection.ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            var Conn = msSqlDataConnection.ConnectionString;

            web.Report.SetParameterValue("Conn", Conn);
            web.Report.SetParameterValue("IdExternalPatientAmbulance", Id.ToString());

            PictureObject pic = web.Report.FindObject("Picture1") as PictureObject;
            pic.Image = new Bitmap(pathFolder);

            web.Report.Prepare();
            Stream stream = new MemoryStream();
            web.Report.Export(new PDFSimpleExport(), stream);
            stream.Position = 0;

            return File(stream, "application/zip", (getNomorRekamMedisBaru + ".pdf"));
        }
        #endregion

        #region Pasien Optik
        public IActionResult PatientOptik()
        {
            var externalPatient = _newPatientExternalOptikRepository.GetAllExternalPatientOptik();
            return View(externalPatient);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ViewResult> CreateExternalPatientOptik()
        {
            var externalPatient = new CreateExternalPatientOptikViewModel();
            var dateNow = DateTimeOffset.Now;
            var setDateKodePasien = DateTimeOffset.Now.ToString("yyMMdd");

            ViewBag.Insurance = new SelectList(await _insuranceRepository.GetInsurances(), "InsuranceId", "NamaPerusahaan", SortOrder.Ascending);
            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
            ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
            ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
            ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);

            var lastCodeNewPatient = _newPatientExternalOptikRepository.GetAllExternalPatientOptik().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(k => k.KodePasien).FirstOrDefault();

            if (lastCodeNewPatient == null)
            {
                externalPatient.KodePasien = "EPOPT" + setDateKodePasien + "0001";
            }
            else
            {
                var lastKodeDate = lastCodeNewPatient.KodePasien.Substring(5, 6);

                if (lastKodeDate != setDateKodePasien)
                {
                    externalPatient.KodePasien = "EPOPT" + setDateKodePasien + "0001";
                }
                else
                {
                    externalPatient.KodePasien = "EPOPT" + setDateKodePasien + (Convert.ToInt32(lastCodeNewPatient.KodePasien.Substring(11, lastCodeNewPatient.KodePasien.Length - 11)) + 1).ToString("D4");
                }
            }

            //Penomoran Rekam Medis = 00-00-00-00 (Kode Unik RS - Tahun Dibuat - Bulan Dibuat - Nomor Urut Asc)            

            var kodeTahun = DateTimeOffset.Now.ToString("yy");
            var kodeHari = DateTimeOffset.Now.ToString("dd");
            var tipePasien = 80; //Kode untuk Pasien Luar Rehabilitasi Medik

            var noRekamMedisBaru = _newPatientExternalOptikRepository.GetAllExternalPatientOptik().OrderByDescending(p => p.NomorRekamMedisBaru).FirstOrDefault();
            if (lastCodeNewPatient == null)
            {
                externalPatient.NomorRekamMedisBaru = kodeTahun + "-" + kodeHari + "-" + tipePasien + "-" + "01";
            }
            else
            {
                externalPatient.NomorRekamMedisBaru = kodeTahun + "-" + kodeHari + "-" + tipePasien + "-" + (Convert.ToInt32(noRekamMedisBaru.NomorRekamMedisBaru.Substring(9, noRekamMedisBaru.NomorRekamMedisBaru.Length - 9)) + 1).ToString("D2");
            }

            return View(externalPatient);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateExternalPatientOptik(CreateExternalPatientOptikViewModel model)
        {
            var dateNow = DateTimeOffset.Now;
            var setDateKodePasien = DateTimeOffset.Now.ToString("yyMMdd");

            ViewBag.Insurance = new SelectList(await _insuranceRepository.GetInsurances(), "InsuranceId", "NamaPerusahaan", SortOrder.Ascending);
            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
            ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
            ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
            ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);

            var lastCodeExternalPatient = _newPatientExternalOptikRepository.GetAllExternalPatientOptik().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(k => k.KodePasien).FirstOrDefault();

            if (lastCodeExternalPatient == null)
            {
                model.KodePasien = "EPOPT" + setDateKodePasien + "0001";
            }
            else
            {
                var lastKodeDate = lastCodeExternalPatient.KodePasien.Substring(5, 6);

                if (lastKodeDate != setDateKodePasien)
                {
                    model.KodePasien = "EPOPT" + setDateKodePasien + "0001";
                }
                else
                {
                    model.KodePasien = "EPOPT" + setDateKodePasien + (Convert.ToInt32(lastCodeExternalPatient.KodePasien.Substring(11, lastCodeExternalPatient.KodePasien.Length - 11)) + 1).ToString("D4");
                }
            }
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                var writer = new QRCodeWriter();
                var resultBit = writer.encode(model.NomorRekamMedisBaru, BarcodeFormat.QR_CODE, 200, 200);
                var matrix = resultBit;
                int scale = 2;
                Bitmap result = new Bitmap(matrix.Width * scale, matrix.Height * scale);
                for (int x = 0; x < matrix.Height; x++)
                {
                    for (int y = 0; y < matrix.Width; y++)
                    {
                        Color pixel = matrix[x, y] ? Color.Black : Color.White;
                        for (int i = 0; i < scale; i++)
                            for (int j = 0; j < scale; j++)
                                result.SetPixel(x * scale + i, y * scale + j, pixel);
                    }
                }

                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "QRCodePasienLuarOptik");
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.NomorRekamMedisBaru + "_" + model.NamaPasien + ".png";
                string filePath = Path.Combine(uploadFolder, uniqueFileName);

                result.Save(filePath);

                ExternalPatientOptik externalPasien = new ExternalPatientOptik
                {
                    CreateDateTime = DateTimeOffset.Now,
                    ExternalPatientId = model.ExternalPatientId,
                    KodePasien = model.KodePasien,
                    NomorRekamMedisBaru = model.NomorRekamMedisBaru,
                    NomorRekamMedisLama = model.NomorRekamMedisLama,
                    Title = model.Title,
                    NamaPasien = model.NamaPasien,
                    NomorIdentitasPasien = model.NomorIdentitasPasien,
                    TempatLahir = model.TempatLahir,
                    TanggalLahir = model.TanggalLahir,
                    JenisKelamin = model.JenisKelamin,
                    AlamatLengkap = model.AlamatLengkap,
                    CountryId = model.CountryId,
                    ProvinceId = model.ProvinceId,
                    CityId = model.CityId,
                    DistrictId = model.DistrictId,
                    SubDistrictId = model.SubDistrictId,
                    KodePos = model.KodePos,
                    NomorTelepon = model.NomorTelepon,
                    EmailAktif = model.EmailAktif,
                    DetailTindakan = model.DetailTindakan,
                    DokterPemeriksa = model.DokterPemeriksa,                    
                    GenerateQrCode = uniqueFileName
                };

                var resultData = _newPatientExternalOptikRepository.GetAllExternalPatientOptik().Where(c => c.NomorIdentitasPasien == model.NomorIdentitasPasien).FirstOrDefault();

                if (resultData == null)
                {
                    _newPatientExternalOptikRepository.Add(externalPasien);
                    TempData["SuccessMessage"] = "Pasien No. Rekam Medis " + model.NomorRekamMedisBaru + " Berhasil Disimpan";
                    return RedirectToAction("PatientOptik", "ExternalPatient");
                    //return RedirectToAction("NewPatient", "PatientList", new { id = newPasien.PatientRegistrationId });
                }
                else
                {
                    ModelState.AddModelError("", "Maaf, nama pasien sudah ada !!!");
                    ViewBag.Insurance = new SelectList(await _insuranceRepository.GetInsurances(), "InsuranceId", "NamaPerusahaan", SortOrder.Ascending);
                    ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
                    ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
                    ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
                    ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);
                    return View(model);
                }
            }
            ViewBag.Insurance = new SelectList(await _insuranceRepository.GetInsurances(), "InsuranceId", "NamaPerusahaan", SortOrder.Ascending);
            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
            ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
            ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
            ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);
            return View();
        }

        public async Task<IActionResult> PrintQrPatientOptik(Guid Id)
        {
            var pasienId = await _newPatientExternalOptikRepository.GetExternalPatientOptikById(Id);

            //var ambilFileNameGambar = _pasienBaruRepository.GetAllPasienBaru().Where(idGambar => idGambar.Id == Id).FirstOrDefault();
            //var tangkapGambar = ambilFileNameGambar.GenerateQrCode;

            string imageParam = "";
            string pathFolder = _webHostEnvironment.WebRootPath + "\\QRCodePasienLuarOptik\\" + pasienId.GenerateQrCode;

            using (var b = new Bitmap(pathFolder))
            {
                using (var ms = new MemoryStream())
                {
                    b.Save(ms, ImageFormat.Bmp);
                    imageParam = Convert.ToBase64String(ms.ToArray());
                }
            }

            pasienId.GenerateQrCode = pathFolder;
            var getNomorRekamMedisBaru = pasienId.NomorRekamMedisBaru;
            WebReport web = new WebReport();
            var path = $"{_webHostEnvironment.WebRootPath}\\DesainKartuPasienLuar\\NewCetakKartuPasienLuarOptik.frx";
            web.Report.Load(path);

            var msSqlDataConnection = new MsSqlDataConnection();
            msSqlDataConnection.ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            var Conn = msSqlDataConnection.ConnectionString;

            web.Report.SetParameterValue("Conn", Conn);
            web.Report.SetParameterValue("IdExternalPatientOptik", Id.ToString());

            PictureObject pic = web.Report.FindObject("Picture1") as PictureObject;
            pic.Image = new Bitmap(pathFolder);

            web.Report.Prepare();
            Stream stream = new MemoryStream();
            web.Report.Export(new PDFSimpleExport(), stream);
            stream.Position = 0;

            return File(stream, "application/zip", (getNomorRekamMedisBaru + ".pdf"));
        }
        #endregion
    }
}