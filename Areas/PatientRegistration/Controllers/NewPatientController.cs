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
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing.Imaging;
using FastReport.Web;
using FastReport.Data;
using FastReport;
using FastReport.Export.PdfSimple;
using BenariMikronWebApp.Areas.Administration.Repositories;
using BenariMikronWebApp.Areas.HealthManagement.Repositories;

namespace BenariMikronWebApp.Areas.PatientRegistration.Controllers
{
    [Area("PatientRegistration")]
    [Route("PatientRegistration/[Controller]/[Action]")]
    public class NewPatientController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly INewPatientRepository _newPatientRepository;
        private readonly IInsuranceRepository _insuranceRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IProvinceRepository _provinceRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly ISubDistrictRepository _subDistrictRepository;
        private readonly IBloodTypeRepository _bloodTypeRepository;
        private readonly ILastEducationRepository _lastEducationRepository;
        private readonly IReligionRepository _religionRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;
        public NewPatientController(
            ApplicationDbContext applicationDbContext,
            INewPatientRepository newPatientRepository,
            IInsuranceRepository insuranceRepository,
            ICountryRepository countryRepository,
            IProvinceRepository provinceRepository,
            ICityRepository cityRepository,
            IDistrictRepository districtRepository,
            ISubDistrictRepository subDistrictRepository,
            IBloodTypeRepository bloodTypeRepository,
            ILastEducationRepository lastEducationRepository,
            IReligionRepository religionRepository,
            IWebHostEnvironment webHostEnvironment,
            IConfiguration configuration
        )
        {
            _applicationDbContext = applicationDbContext;
            _newPatientRepository = newPatientRepository;
            _insuranceRepository = insuranceRepository;
            _countryRepository = countryRepository;
            _provinceRepository = provinceRepository;
            _cityRepository = cityRepository;
            _districtRepository = districtRepository;
            _subDistrictRepository = subDistrictRepository;
            _bloodTypeRepository = bloodTypeRepository;
            _lastEducationRepository = lastEducationRepository;
            _religionRepository = religionRepository;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
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

        public IActionResult Index()
        {
            var tampilkanDataNewPatient = _newPatientRepository.GetAllNewPatient();
            return View(tampilkanDataNewPatient);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ViewResult> CreateNewPatient()
        {
            var newPatient = new CreateNewPatientViewModel();
            var dateNow = DateTimeOffset.Now;
            var setDateKodePasien = DateTimeOffset.Now.ToString("yyMMdd");

            ViewBag.Insurance = new SelectList(await _insuranceRepository.GetInsurances(), "InsuranceId", "NamaPerusahaan", SortOrder.Ascending);
            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
            ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
            ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota");
            ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);
            ViewBag.BloodType = new SelectList(await _bloodTypeRepository.GetBloodTypes(), "BloodTypeId", "NamaGolonganDarah", SortOrder.Ascending);
            ViewBag.LastEducation = new SelectList(await _lastEducationRepository.GetLastEducations(), "LastEducationId", "NamaPendidikanTerakhir", SortOrder.Ascending);
            ViewBag.Religion = new SelectList(await _religionRepository.GetReligions(), "ReligionId", "NamaAgama", SortOrder.Ascending);

            var lastCodeNewPatient = _newPatientRepository.GetAllNewPatient().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(k => k.KodePasien).FirstOrDefault();
            if (lastCodeNewPatient == null)
            {
                newPatient.KodePasien = "PSN" + setDateKodePasien + "0001";
            }
            else
            {
                var lastKodeDate = lastCodeNewPatient.KodePasien.Substring(3, 6);

                if (lastKodeDate != setDateKodePasien)
                {
                    newPatient.KodePasien = "PSN" + setDateKodePasien + "0001";
                }
                else
                {
                    newPatient.KodePasien = "PSN" + setDateKodePasien + (Convert.ToInt32(lastCodeNewPatient.KodePasien.Substring(9, lastCodeNewPatient.KodePasien.Length - 9)) + 1).ToString("D4");
                }
            }            

            //Penomoran Rekam Medis = 00-00-00-00 (Kode Unik RS - Tahun Dibuat - Bulan Dibuat - Nomor Urut Asc)            

            var kodeTahun = DateTimeOffset.Now.ToString("yy");
            var kodeHari = DateTimeOffset.Now.ToString("dd");
            var tipePasien = 10; //Kode untuk Pasien Baru

            var noRekamMedisBaru = _newPatientRepository.GetAllNewPatient().OrderByDescending(p => p.NomorRekamMedisBaru).FirstOrDefault();
            if (lastCodeNewPatient == null)
            {
                newPatient.NomorRekamMedisBaru = kodeTahun + "-" + kodeHari + "-" + tipePasien + "-" + "01";
            }
            else
            {
                newPatient.NomorRekamMedisBaru = kodeTahun + "-" + kodeHari + "-" + tipePasien + "-" + (Convert.ToInt32(noRekamMedisBaru.NomorRekamMedisBaru.Substring(9, noRekamMedisBaru.NomorRekamMedisBaru.Length - 9)) + 1).ToString("D2");
            }
            return View(newPatient);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateNewPatient(CreateNewPatientViewModel model)
        {
            var dateNow = DateTimeOffset.Now;
            var setDateKodePasien = DateTimeOffset.Now.ToString("yyMMdd");

            ViewBag.Insurance = new SelectList(await _insuranceRepository.GetInsurances(), "InsuranceId", "NamaPerusahaan", SortOrder.Ascending);
            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
            ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
            ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
            ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);
            ViewBag.BloodType = new SelectList(await _bloodTypeRepository.GetBloodTypes(), "BloodTypeId", "NamaGolonganDarah", SortOrder.Ascending);
            ViewBag.LastEducation = new SelectList(await _lastEducationRepository.GetLastEducations(), "LastEducationId", "NamaPendidikanTerakhir", SortOrder.Ascending);
            ViewBag.Religion = new SelectList(await _religionRepository.GetReligions(), "ReligionId", "NamaAgama", SortOrder.Ascending);

            var lastCodeNewPatient = _newPatientRepository.GetAllNewPatient().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(k => k.KodePasien).FirstOrDefault();
            if (lastCodeNewPatient == null)
            {
                model.KodePasien = "PSN" + setDateKodePasien + "0001";
            }
            else
            {
                var lastKodeDate = lastCodeNewPatient.KodePasien.Substring(3, 6);

                if (lastKodeDate != setDateKodePasien)
                {
                    model.KodePasien = "PSN" + setDateKodePasien + "0001";
                }
                else
                {
                    model.KodePasien = "PSN" + setDateKodePasien + (Convert.ToInt32(lastCodeNewPatient.KodePasien.Substring(9, lastCodeNewPatient.KodePasien.Length - 9)) + 1).ToString("D4");
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

                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "NewQRCodePasien");
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.NomorRekamMedisBaru + "_" + model.NamaLengkapPasien + ".png";
                string filePath = Path.Combine(uploadFolder, uniqueFileName);

                result.Save(filePath);

                NewPatient newPasien = new NewPatient
                {
                    CreateDateTime = DateTimeOffset.Now,
                    PatientRegistrationId = model.PatientRegistrationId,
                    KodePasien = model.KodePasien,
                    NomorRekamMedisBaru = model.NomorRekamMedisBaru,
                    NomorRekamMedisLama = model.NomorRekamMedisLama,    
                    TipePasien = model.TipePasien,
                    InsuranceId = model.InsuranceId,
                    NomorPolis = model.NomorPolis,
                    NamaLengkapPasien = model.NamaLengkapPasien,
                    Title = model.Title,
                    NomorIdentitasPasien = model.NomorIdentitasPasien,
                    TempatLahir = model.TempatLahir,
                    TanggalLahir = model.TanggalLahir,
                    JenisKelamin = model.JenisKelamin,
                    PasienPrioritas = model.PasienPrioritas,
                    StatusPasien = model.StatusPasien,
                    ReligionId = model.ReligionId,
                    Kewarganegaraan = model.Kewarganegaraan,
                    LastEducationId = model.LastEducationId,
                    AlamatLengkap = model.AlamatLengkap,
                    CountryId = model.CountryId,
                    ProvinceId = model.ProvinceId,
                    CityId = model.CityId,
                    DistrictId = model.DistrictId,
                    SubDistrictId = model.SubDistrictId,
                    KodePos = model.KodePos,
                    NomorTelepon1 = model.NomorTelepon1,
                    NomorTelepon2 = model.NomorTelepon2,
                    Email = model.Email,
                    Pekerjaan = model.Pekerjaan,
                    NamaKantor = model.NamaKantor,
                    AlamatKantor = model.AlamatKantor,
                    NomorTeleponKantor = model.NomorTeleponKantor,
                    BloodTypeId = model.BloodTypeId,
                    Alergi = model.Alergi,
                    NamaKeluargaTerdekat = model.NamaKeluargaTerdekat,
                    HubunganKeluarga = model.HubunganKeluarga,
                    KaryawanRumahSakit = model.KaryawanRumahSakit,
                    AlamatKeluargaPasien = model.AlamatKeluargaPasien,
                    NomorTeleponKeluargaPasien = model.NomorTeleponKeluargaPasien,
                    NamaAyahPasien = model.NamaAyahPasien,
                    PekerjaanAyahPasien = model.PekerjaanAyahPasien,
                    NamaIbuPasien = model.NamaIbuPasien,
                    PekerjaanIbuPasien = model.PekerjaanIbuPasien,
                    NamaSutriPasien = model.NamaSutriPasien,
                    PekerjaanSutriPasien = model.PekerjaanSutriPasien,
                    NomorIdentitasSutriPasien = model.NomorIdentitasSutriPasien,
                    GenerateQrCode = uniqueFileName
                };

                var resultData = _newPatientRepository.GetAllNewPatient().Where(c => c.NomorIdentitasPasien == model.NomorIdentitasPasien).FirstOrDefault();

                if (resultData == null)
                {
                    _newPatientRepository.Add(newPasien);
                    TempData["SuccessMessage"] = "Pasien No. Rekam Medis " + model.NomorRekamMedisBaru + " Berhasil Disimpan";
                    return RedirectToAction("Index", "NewPatient");
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
                    ViewBag.BloodType = new SelectList(await _bloodTypeRepository.GetBloodTypes(), "BloodTypeId", "NamaGolonganDarah", SortOrder.Ascending);
                    ViewBag.LastEducation = new SelectList(await _lastEducationRepository.GetLastEducations(), "LastEducationId", "NamaPendidikanTerakhir", SortOrder.Ascending);
                    ViewBag.Religion = new SelectList(await _religionRepository.GetReligions(), "ReligionId", "NamaAgama", SortOrder.Ascending);
                    return View(model);
                }
            }
            ViewBag.Insurance = new SelectList(await _insuranceRepository.GetInsurances(), "InsuranceId", "NamaPerusahaan", SortOrder.Ascending);
            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
            ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
            ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
            ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);
            ViewBag.BloodType = new SelectList(await _bloodTypeRepository.GetBloodTypes(), "BloodTypeId", "NamaGolonganDarah", SortOrder.Ascending);
            ViewBag.LastEducation = new SelectList(await _lastEducationRepository.GetLastEducations(), "LastEducationId", "NamaPendidikanTerakhir", SortOrder.Ascending);
            ViewBag.Religion = new SelectList(await _religionRepository.GetReligions(), "ReligionId", "NamaAgama", SortOrder.Ascending);
            return View();
        }        

        public async Task<IActionResult> CetakQRPasien(Guid Id)
        {
            var pasienId = await _newPatientRepository.GetNewPatientById(Id);

            //var ambilFileNameGambar = _pasienBaruRepository.GetAllPasienBaru().Where(idGambar => idGambar.Id == Id).FirstOrDefault();
            //var tangkapGambar = ambilFileNameGambar.GenerateQrCode;

            string imageParam = "";
            string pathFolder = _webHostEnvironment.WebRootPath + "\\NewQRCodePasien\\" + pasienId.GenerateQrCode;

            using (var b = new Bitmap(pathFolder))
            {
                using (var ms = new MemoryStream())
                {
                    b.Save(ms, ImageFormat.Bmp);
                    imageParam = Convert.ToBase64String(ms.ToArray());
                }
            }

            pasienId.GenerateQrCode = pathFolder;
            //var reader = new BarcodeReaderGeneric();
            //Bitmap image = (Bitmap)Image.FromFile(pathFolder);
            //using (image)
            //{
            //    LuminanceSource source;
            //    source = new ZXing.Windows.Compatibility.BitmapLuminanceSource(image);
            //    Result result = reader.Decode(source);
            //    var getImageQr = result.Text;
            //}            

            var getGambar = pathFolder;
            var getNomorRekamMedisBaru = pasienId.NomorRekamMedisBaru;

            WebReport web = new WebReport();
            var path = $"{_webHostEnvironment.WebRootPath}\\Reports\\NewCetakKartuIdentitasPasien.frx";
            web.Report.Load(path);

            var msSqlDataConnection = new MsSqlDataConnection();
            msSqlDataConnection.ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            var Conn = msSqlDataConnection.ConnectionString;     

            web.Report.SetParameterValue("Conn", Conn);
            web.Report.SetParameterValue("IdNewPatient", Id.ToString());

            PictureObject pic = web.Report.FindObject("Picture1") as PictureObject;
            pic.Image = new Bitmap(pathFolder);

            web.Report.Prepare();
            Stream stream = new MemoryStream();
            web.Report.Export(new PDFSimpleExport(), stream);
            stream.Position = 0;

            return File(stream, "application/zip", (getNomorRekamMedisBaru + ".pdf"));
        }
    }
}
