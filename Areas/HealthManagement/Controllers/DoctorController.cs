using BenariMikronWebApp.Areas.AccountingAndFinancial.Models;
using BenariMikronWebApp.Areas.AccountingAndFinancial.Repositories;
using BenariMikronWebApp.Areas.Administration.Models;
using BenariMikronWebApp.Areas.Administration.Repositories;
using BenariMikronWebApp.Areas.Administration.ViewModels;
using BenariMikronWebApp.Areas.HealthManagement.Models;
using BenariMikronWebApp.Areas.HealthManagement.Repositories;
using BenariMikronWebApp.Areas.HealthManagement.ViewModels;
using BenariMikronWebApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace BenariMikronWebApp.Areas.HealthManagement.Controllers
{
    [Area("HealthManagement")]
    [Route("HealthManagement/[Controller]/[Action]")]
    public class DoctorController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IDoctorTypeRepository _doctorTypeRepository;
        private readonly ILastEducationRepository _lastEducationRepository;
        private readonly IReligionRepository _religionRepository;
        private readonly IWorkingRepository _workingRepository;
        private readonly IDoctorQueueTypeRepository _doctorQueueTypeRepository;
        private readonly IBankRepository _bankRepository;
        private readonly IBankCabangRepository _bankCabangRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IProvinceRepository _provinceRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly ISubDistrictRepository _subDistrictRepository;
        private readonly IDoctorTitleRepository _doctorTitleRepository;
        private readonly IDoctorDepartmentRepository _doctorDepartmentRepository;
        private readonly IMultipleDoctorDepartmentRepository _multipleDoctorDepartmentRepository;

        public DoctorController(
            IHostingEnvironment hostingEnvironment,
            ApplicationDbContext applicationDbContext,
            IDoctorRepository doctorRepository,
            IDoctorTypeRepository doctorTypeRepository,
            ILastEducationRepository lastEducationRepository,
            IReligionRepository religionRepository,
            IWorkingRepository workingRepository,
            IDoctorQueueTypeRepository doctorQueueTypeRepository,
            IBankRepository bankRepository,
            IBankCabangRepository bankCabangRepository,
            ICountryRepository countryRepository,
            IProvinceRepository provinceRepository,
            ICityRepository cityRepository,
            IDistrictRepository districtRepository,
            ISubDistrictRepository subDistrictRepository,
            IDoctorTitleRepository doctorTitleRepository,
            IDoctorDepartmentRepository doctorDepartmentRepository,
            IMultipleDoctorDepartmentRepository multipleDoctorDepartmentRepository)
        {
            _hostingEnvironment = hostingEnvironment;
            _applicationDbContext = applicationDbContext;
            _doctorRepository = doctorRepository;
            _doctorTypeRepository = doctorTypeRepository;
            _lastEducationRepository = lastEducationRepository;
            _religionRepository = religionRepository;
            _workingRepository = workingRepository;
            _doctorQueueTypeRepository = doctorQueueTypeRepository;
            _bankRepository = bankRepository;
            _bankCabangRepository = bankCabangRepository;
            _countryRepository = countryRepository;
            _provinceRepository = provinceRepository;
            _cityRepository = cityRepository;
            _districtRepository = districtRepository;
            _subDistrictRepository = subDistrictRepository;
            _doctorTitleRepository = doctorTitleRepository;
            _doctorDepartmentRepository = doctorDepartmentRepository;
            _multipleDoctorDepartmentRepository = multipleDoctorDepartmentRepository;
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

        public JsonResult LoadBankCabang(Guid Id)
        {
            var bankCabang = _applicationDbContext.BankCabangs.Where(p => p.BankId == Id).ToList();
            return Json(new SelectList(bankCabang, "BankCabangId", "NamaCabang"));
        }

        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult Index()
        {            
            var tampilkanData = (from doctor in _applicationDbContext.Doctors.Include(l => l.DoctorType)
                                 join deptdoctor in _applicationDbContext.MultipleDoctorDepartments on doctor.DoctorId equals deptdoctor.DoctorId
                                 group new { doctor, deptdoctor } by new { doctor.DoctorId, doctor.CreateDateTime, doctor.KodeDokter, doctor.NamaLengkap, doctor.DoctorType.TipeDokter, doctor.Foto } into multi
                                 select new MultipleDepartmentViewModel
                                 {
                                     DoctorId = multi.Key.DoctorId,
                                     CreateDateTime = multi.Key.CreateDateTime,
                                     KodeDokter = multi.Key.KodeDokter,
                                     NamaDokter = multi.Key.NamaLengkap,
                                     TipeDokter = multi.Key.TipeDokter,
                                     DepartemenDokter = string.Join(", ", multi.Select(x => x.deptdoctor.DoctorDepartment.NamaDepartemen)),
                                     Foto = multi.Key.Foto
                                 }).ToList().OrderByDescending(d => d.CreateDateTime);
            return View(tampilkanData);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ViewResult> CreateDoctor()
        {            
            CreateDoctorViewModel doctor = new CreateDoctorViewModel();
            var dateNow = DateTimeOffset.Now;
            var lastCodeDoc = _doctorRepository.GetAllDoctor().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeDokter).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");           

            ViewBag.DoctorType = new SelectList(await _doctorTypeRepository.GetDoctorTypes(), "DoctorTypeId", "TipeDokter", SortOrder.Ascending);
            ViewBag.LastEducation = new SelectList(await _lastEducationRepository.GetLastEducations(), "LastEducationId", "NamaPendidikanTerakhir", SortOrder.Ascending);
            ViewBag.Religion = new SelectList(await _religionRepository.GetReligions(), "ReligionId", "NamaAgama", SortOrder.Ascending);
            ViewBag.Working = new SelectList(await _workingRepository.GetWorkings(), "WorkingId", "NamaPekerjaan", SortOrder.Ascending);
            ViewBag.DoctorQueueType = new SelectList(await _doctorQueueTypeRepository.GetDoctorQueueTypes(), "DoctorQueueTypeId", "NamaTipeAntrian", SortOrder.Ascending);
            ViewBag.Bank = new SelectList(await _bankRepository.GetBanks(), "BankId", "NamaBank", SortOrder.Ascending);
            ViewBag.BankCabang = new SelectList(await _bankCabangRepository.GetBankCabangs(), "BankCabangId", "NamaCabang", SortOrder.Ascending);
            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
            ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
            ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
            ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);
            ViewBag.SubDistrict = new SelectList(await _subDistrictRepository.GetSubDistricts(), "SubDistrictId", "NamaKelurahan", SortOrder.Ascending);
            ViewBag.DoctorTitle = new SelectList(await _doctorTitleRepository.GetDoctorTitles(), "DoctorTitleId", "NamaGelar", SortOrder.Ascending);            

            doctor.DepartmentList = _applicationDbContext.DoctorDepartments.Select(c => new SelectListItem
            { 
                Value = c.DepartmentId.ToString(),
                Text = c.NamaDepartemen
            
            }).ToList();

            if (lastCodeDoc == null)
            {
                doctor.KodeDokter = "DCT" + setDateNow + "0001";
            }
            else
            {
                var lastDateDoc = lastCodeDoc.KodeDokter.Substring(3, 6);

                if (lastDateDoc != setDateNow)
                {
                    doctor.KodeDokter = "DCT" + setDateNow + "0001";
                }
                else
                {
                    doctor.KodeDokter = "DCT" + setDateNow + (Convert.ToInt32(lastCodeDoc.KodeDokter.Substring(9, lastCodeDoc.KodeDokter.Length - 9)) + 1).ToString("D4");
                }
            }           

            return View(doctor);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateDoctor(CreateDoctorViewModel model)
        {
            var dateNow = DateTimeOffset.Now;
            var lastDoc = _doctorRepository.GetAllDoctor().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeDokter).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            ViewBag.DoctorType = new SelectList(await _doctorTypeRepository.GetDoctorTypes(), "DoctorTypeId", "TipeDokter", SortOrder.Ascending);
            ViewBag.LastEducation = new SelectList(await _lastEducationRepository.GetLastEducations(), "LastEducationId", "NamaPendidikanTerakhir", SortOrder.Ascending);
            ViewBag.Religion = new SelectList(await _religionRepository.GetReligions(), "ReligionId", "NamaAgama", SortOrder.Ascending);
            ViewBag.Working = new SelectList(await _workingRepository.GetWorkings(), "WorkingId", "NamaPekerjaan", SortOrder.Ascending);
            ViewBag.DoctorQueueType = new SelectList(await _doctorQueueTypeRepository.GetDoctorQueueTypes(), "DoctorQueueTypeId", "NamaTipeAntrian", SortOrder.Ascending);
            ViewBag.Bank = new SelectList(await _bankRepository.GetBanks(), "BankId", "NamaBank", SortOrder.Ascending);
            ViewBag.BankCabang = new SelectList(await _bankCabangRepository.GetBankCabangs(), "BankCabangId", "NamaCabang", SortOrder.Ascending);
            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
            ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
            ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
            ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);
            ViewBag.SubDistrict = new SelectList(await _subDistrictRepository.GetSubDistricts(), "SubDistrictId", "NamaKelurahan", SortOrder.Ascending);
            ViewBag.DoctorTitle = new SelectList(await _doctorTitleRepository.GetDoctorTitles(), "DoctorTitleId", "NamaGelar", SortOrder.Ascending);
            ViewBag.DoctorDepartment = new SelectList(await _doctorDepartmentRepository.GetDoctorDepartments(), "DepartmentId", "NamaDepartemen", SortOrder.Ascending);

            if (lastDoc == null)
            {
                model.KodeDokter = "DCT" + setDateNow + "0001";
            }
            else
            {
                var lastDateDepart = lastDoc.KodeDokter.Substring(3, 6);

                if (lastDateDepart != setDateNow)
                {
                    model.KodeDokter = "DCT" + setDateNow + "0001";
                }
                else
                {
                    model.KodeDokter = "DCT" + setDateNow + (Convert.ToInt32(lastDoc.KodeDokter.Substring(9, lastDoc.KodeDokter.Length - 9)) + 1).ToString("D4");
                }
            }
            string uniqueFileName = ProcessUploadFile(model);
            var newDoctor = new Doctor
            {
                CreateDateTime = DateTimeOffset.Now,
                DoctorId = model.DoctorId,
                KodeDokter = model.KodeDokter,
                DoctorTypeId = model.DoctorTypeId,
                NamaLengkap = model.NamaLengkap,
                NamaMarga = model.NamaMarga,
                NomorKtpDokter = model.NomorKtpDokter,
                TempatLahir = model.TempatLahir,
                TanggalLahir = model.TanggalLahir,
                JenisKelamin = model.JenisKelamin,
                Kewarganegaraan = model.Kewarganegaraan,
                LastEducationId = model.LastEducationId,
                ReligionId = model.ReligionId,
                WorkingId = model.WorkingId,
                DoctorQueueTypeId = model.DoctorQueueTypeId,
                BankId = model.BankId,
                BankCabangId = model.BankCabangId,
                BankAtasNama = model.BankAtasNama,
                BankNomorRekening = model.BankNomorRekening,
                Npwp = model.Npwp,
                AlamatRumahLengkap = model.AlamatRumahLengkap,
                CountryId = model.CountryId,
                ProvinceId = model.ProvinceId,
                CityId = model.CityId,
                DistrictId = model.DistrictId,
                SubDistrictId = model.SubDistrictId,
                KodePos = model.KodePos,
                NomorTelepon = model.NomorTelepon,
                NomorHandphone = model.NomorHandphone,
                AlamatKantorLengkap = model.AlamatKantorLengkap,
                NomorTeleponKantor = model.NomorTeleponKantor,
                NomorIdDokter = model.NomorIdDokter,
                DoctorTitleId = model.DoctorTitleId,
                JenisKontrak = model.JenisKontrak,
                TanggalAwalKontrak = model.TanggalAwalKontrak,
                TanggalAkhirKontrak = model.TanggalAkhirKontrak,
                TanggalKeluar = model.TanggalKeluar,
                GuaranteeFee = model.GuaranteeFee,
                DokterMitra = model.DokterMitra,
                DokterSpesialis = model.DokterSpesialis,
                Foto = uniqueFileName
            };

            var result = _doctorRepository.GetAllDoctor().Where(c => c.NomorKtpDokter == model.NomorKtpDokter).FirstOrDefault();

            if (result == null)
            {
                _doctorRepository.Tambah(newDoctor);
                _applicationDbContext.SaveChanges();

                foreach (var selectedId in model.DepartmentId)
                {
                    var newMultipleDepartment = new MultipleDoctorDepartment
                    {
                        DoctorId = newDoctor.DoctorId,
                        DoctorDepartmentId = selectedId
                    };
                    _multipleDoctorDepartmentRepository.Tambah(newMultipleDepartment);
                    _applicationDbContext.SaveChanges();
                }
                TempData["SuccessMessage"] = "Dokter " + model.NamaLengkap + " Berhasil Disimpan";
                return RedirectToAction("Index", "Doctor");
            }
            else
            {
                ModelState.AddModelError("", "Maaf, nama dokter sudah ada !!!");
                ViewBag.DoctorType = new SelectList(await _doctorTypeRepository.GetDoctorTypes(), "DoctorTypeId", "TipeDokter", SortOrder.Ascending);
                ViewBag.LastEducation = new SelectList(await _lastEducationRepository.GetLastEducations(), "LastEducationId", "NamaPendidikanTerakhir", SortOrder.Ascending);
                ViewBag.Religion = new SelectList(await _religionRepository.GetReligions(), "ReligionId", "NamaAgama", SortOrder.Ascending);
                ViewBag.Working = new SelectList(await _workingRepository.GetWorkings(), "WorkingId", "NamaPekerjaan", SortOrder.Ascending);
                ViewBag.DoctorQueueType = new SelectList(await _doctorQueueTypeRepository.GetDoctorQueueTypes(), "DoctorQueueTypeId", "NamaTipeAntrian", SortOrder.Ascending);
                ViewBag.Bank = new SelectList(await _bankRepository.GetBanks(), "BankId", "NamaBank", SortOrder.Ascending);
                ViewBag.BankCabang = new SelectList(await _bankCabangRepository.GetBankCabangs(), "BankCabangId", "NamaCabang", SortOrder.Ascending);
                ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
                ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
                ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
                ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);
                ViewBag.SubDistrict = new SelectList(await _subDistrictRepository.GetSubDistricts(), "SubDistrictId", "NamaKelurahan", SortOrder.Ascending);
                ViewBag.DoctorTitle = new SelectList(await _doctorTitleRepository.GetDoctorTitles(), "DoctorTitleId", "NamaGelar", SortOrder.Ascending);
                ViewBag.DoctorDepartment = new SelectList(await _doctorDepartmentRepository.GetDoctorDepartments(), "NamaDepartemen", "NamaDepartemen", SortOrder.Ascending);
                return View(model);
            }
        }

        [AllowAnonymous]
        public async Task<IActionResult> DetailDoctor(Guid Id)
        { 
            var doctor = await _doctorRepository.GetDoctorById(Id);

            ViewBag.DoctorType = new SelectList(await _doctorTypeRepository.GetDoctorTypes(), "DoctorTypeId", "TipeDokter", SortOrder.Ascending);
            ViewBag.LastEducation = new SelectList(await _lastEducationRepository.GetLastEducations(), "LastEducationId", "NamaPendidikanTerakhir", SortOrder.Ascending);
            ViewBag.Religion = new SelectList(await _religionRepository.GetReligions(), "ReligionId", "NamaAgama", SortOrder.Ascending);
            ViewBag.Working = new SelectList(await _workingRepository.GetWorkings(), "WorkingId", "NamaPekerjaan", SortOrder.Ascending);
            ViewBag.DoctorQueueType = new SelectList(await _doctorQueueTypeRepository.GetDoctorQueueTypes(), "DoctorQueueTypeId", "NamaTipeAntrian", SortOrder.Ascending);
            ViewBag.Bank = new SelectList(await _bankRepository.GetBanks(), "BankId", "NamaBank", SortOrder.Ascending);
            ViewBag.BankCabang = new SelectList(await _bankCabangRepository.GetBankCabangs(), "BankCabangId", "NamaCabang", SortOrder.Ascending);
            ViewBag.Country = new SelectList(await _countryRepository.GetCountries(), "CountryId", "NamaNegara", SortOrder.Ascending);
            ViewBag.Province = new SelectList(await _provinceRepository.GetProvinces(), "ProvinceId", "NamaProvinsi", SortOrder.Ascending);
            ViewBag.City = new SelectList(await _cityRepository.GetCities(), "CityId", "NamaKota", SortOrder.Ascending);
            ViewBag.District = new SelectList(await _districtRepository.GetDistricts(), "DistrictId", "NamaKecamatan", SortOrder.Ascending);
            ViewBag.SubDistrict = new SelectList(await _subDistrictRepository.GetSubDistricts(), "SubDistrictId", "NamaKelurahan", SortOrder.Ascending);
            ViewBag.DoctorTitle = new SelectList(await _doctorTitleRepository.GetDoctorTitles(), "DoctorTitleId", "NamaGelar", SortOrder.Ascending);
            ViewBag.DoctorDepartment = new SelectList(await _doctorDepartmentRepository.GetDoctorDepartments(), "NamaDepartemen", "NamaDepartemen", SortOrder.Ascending);            

            if (doctor == null)
            {
                Response.StatusCode = 404;
                return View("DoctorNotFound", Id);
            }

            DetailDoctorViewModel viewModel = new DetailDoctorViewModel
            {
                DoctorId = doctor.DoctorId,
                KodeDokter = doctor.KodeDokter,
                DoctorTypeId = doctor.DoctorTypeId,
                NamaLengkap = doctor.NamaLengkap,
                NamaMarga = doctor.NamaMarga,
                NomorKtpDokter = doctor.NomorKtpDokter,
                TempatLahir = doctor.TempatLahir,
                TanggalLahir = doctor.TanggalLahir,
                JenisKelamin = doctor.JenisKelamin,
                Kewarganegaraan = doctor.Kewarganegaraan,
                LastEducationId = doctor.LastEducationId,
                ReligionId = doctor.ReligionId,
                WorkingId = doctor.WorkingId,
                DoctorQueueTypeId = doctor.DoctorQueueTypeId,
                BankId = doctor.BankId,
                BankCabangId = doctor.BankCabangId,
                BankAtasNama = doctor.BankAtasNama,
                BankNomorRekening = doctor.BankNomorRekening,
                Npwp = doctor.Npwp,
                AlamatRumahLengkap = doctor.AlamatRumahLengkap,
                CountryId = doctor.CountryId,
                ProvinceId = doctor.ProvinceId,
                CityId = doctor.CityId,
                DistrictId = doctor.DistrictId,
                SubDistrictId = doctor.SubDistrictId,
                KodePos = doctor.KodePos,
                NomorTelepon = doctor.NomorTelepon,
                NomorHandphone = doctor.NomorHandphone,
                AlamatKantorLengkap = doctor.AlamatKantorLengkap,
                NomorTeleponKantor = doctor.NomorTeleponKantor,
                NomorIdDokter = doctor.NomorIdDokter,
                DoctorTitleId = doctor.DoctorTitleId,
                JenisKontrak = doctor.JenisKontrak,
                TanggalAwalKontrak = doctor.TanggalAwalKontrak,
                TanggalAkhirKontrak = doctor.TanggalAkhirKontrak,
                TanggalKeluar = doctor.TanggalKeluar,
                GuaranteeFee = doctor.GuaranteeFee,
                DokterMitra = doctor.DokterMitra,
                DokterSpesialis = doctor.DokterSpesialis,
                DoctorPhotoPath = doctor.Foto
            };
            viewModel.DepartmentList = _applicationDbContext.DoctorDepartments.Select(c => new SelectListItem
            {
                Value = c.DepartmentId.ToString(),
                Text = c.NamaDepartemen

            }).ToList();

            List<Guid> departmentIds = new List<Guid>();

            var doctors = _applicationDbContext.Doctors.Include(dept => dept.MultipleDoctorDepartments).FirstOrDefault(x => x.DoctorId == Id);
            doctors.MultipleDoctorDepartments.ToList().ForEach(d => departmentIds.Add((Guid)d.DoctorDepartmentId));            

            viewModel.DepartmentId = departmentIds;
            return View(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> DetailDoctor(DetailDoctorViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Doctor doctor = await _doctorRepository.GetDoctorByIdNoTracking(viewModel.DoctorId);

                if (doctor.NamaLengkap != viewModel.NamaLengkap)
                {
                    var check = _doctorRepository.GetAllDoctor().Where(d => d.NamaLengkap == viewModel.NamaLengkap).FirstOrDefault();

                    if (check == null)
                    {
                        doctor.UpdateDateTime = DateTime.Now;
                        doctor.KodeDokter = viewModel.KodeDokter;
                        doctor.DoctorTypeId = viewModel.DoctorTypeId;
                        doctor.NamaLengkap = viewModel.NamaLengkap;
                        doctor.NamaMarga = viewModel.NamaMarga;
                        doctor.NomorKtpDokter = viewModel.NomorKtpDokter;
                        doctor.TempatLahir = viewModel.TempatLahir;
                        doctor.TanggalLahir = viewModel.TanggalLahir;
                        doctor.JenisKelamin = viewModel.JenisKelamin;
                        doctor.Kewarganegaraan = viewModel.Kewarganegaraan;
                        doctor.LastEducationId = viewModel.LastEducationId;
                        doctor.ReligionId = viewModel.ReligionId;
                        doctor.WorkingId = viewModel.WorkingId;
                        doctor.DoctorQueueTypeId = viewModel.DoctorQueueTypeId;
                        doctor.BankId = viewModel.BankId;
                        doctor.BankCabangId = viewModel.BankCabangId;
                        doctor.BankAtasNama = viewModel.BankAtasNama;
                        doctor.BankNomorRekening = viewModel.BankNomorRekening;
                        doctor.Npwp = viewModel.Npwp;
                        doctor.AlamatRumahLengkap = viewModel.AlamatRumahLengkap;
                        doctor.CountryId = viewModel.CountryId;
                        doctor.ProvinceId = viewModel.ProvinceId;
                        doctor.CityId = viewModel.CityId;
                        doctor.DistrictId = viewModel.DistrictId;
                        doctor.SubDistrictId = viewModel.SubDistrictId;
                        doctor.KodePos = viewModel.KodePos;
                        doctor.NomorTelepon = viewModel.NomorTelepon;
                        doctor.NomorHandphone = viewModel.NomorHandphone;
                        doctor.AlamatKantorLengkap = viewModel.AlamatKantorLengkap;
                        doctor.NomorTeleponKantor = viewModel.NomorTeleponKantor;
                        doctor.NomorIdDokter = viewModel.NomorIdDokter;
                        doctor.DoctorTitleId = viewModel.DoctorTitleId;
                        doctor.JenisKontrak = viewModel.JenisKontrak;
                        doctor.TanggalAwalKontrak = viewModel.TanggalAwalKontrak;
                        doctor.TanggalAkhirKontrak = viewModel.TanggalAkhirKontrak;
                        doctor.TanggalKeluar = viewModel.TanggalKeluar;
                        doctor.GuaranteeFee = viewModel.GuaranteeFee;
                        doctor.DokterMitra = viewModel.DokterMitra;
                        doctor.DokterSpesialis = viewModel.DokterSpesialis;
                        if (viewModel.Foto != null)
                        {
                            if (viewModel.DoctorPhotoPath != null)
                            {
                                string filePath = Path.Combine(_hostingEnvironment.WebRootPath,
                                    "FotoDokter", viewModel.DoctorPhotoPath);
                                System.IO.File.Delete(filePath);
                            }
                            doctor.Foto = ProcessUploadFile(viewModel);
                        }

                        _doctorRepository.Update(doctor);
                        _applicationDbContext.SaveChanges();

                        List<MultipleDoctorDepartment> multipleDoctorDepartments = new List<MultipleDoctorDepartment>();

                        var doctors = _applicationDbContext.Doctors.Include(dept => dept.MultipleDoctorDepartments).FirstOrDefault(x => x.DoctorId == viewModel.DoctorId);
                        doctors.MultipleDoctorDepartments.ToList().ForEach(d => multipleDoctorDepartments.Add(d));
                        _applicationDbContext.MultipleDoctorDepartments.RemoveRange(multipleDoctorDepartments);
                        _applicationDbContext.SaveChanges();

                        multipleDoctorDepartments = new List<MultipleDoctorDepartment>();

                        foreach (var selectedId in viewModel.DepartmentId)
                        {
                            var newMultipleDepartment = new MultipleDoctorDepartment
                            {
                                DoctorId = doctor.DoctorId,
                                DoctorDepartmentId = selectedId
                            };
                            _multipleDoctorDepartmentRepository.Tambah(newMultipleDepartment);
                            _applicationDbContext.SaveChanges();
                        }

                        doctor.MultipleDoctorDepartments = multipleDoctorDepartments;

                        TempData["SuccessMessage"] = "Dokter " + viewModel.NamaLengkap + " Berhasil Diubah";
                        return RedirectToAction("Index", "Doctor");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Maaf, nama dokter sudah ada !!!");
                        return View(viewModel);
                    }
                }
                else
                {
                    doctor.UpdateDateTime = DateTime.Now;
                    doctor.KodeDokter = viewModel.KodeDokter;
                    doctor.DoctorTypeId = viewModel.DoctorTypeId;
                    doctor.NamaLengkap = viewModel.NamaLengkap;
                    doctor.NamaMarga = viewModel.NamaMarga;
                    doctor.NomorKtpDokter = viewModel.NomorKtpDokter;
                    doctor.TempatLahir = viewModel.TempatLahir;
                    doctor.TanggalLahir = viewModel.TanggalLahir;
                    doctor.JenisKelamin = viewModel.JenisKelamin;
                    doctor.Kewarganegaraan = viewModel.Kewarganegaraan;
                    doctor.LastEducationId = viewModel.LastEducationId;
                    doctor.ReligionId = viewModel.ReligionId;
                    doctor.WorkingId = viewModel.WorkingId;
                    doctor.DoctorQueueTypeId = viewModel.DoctorQueueTypeId;
                    doctor.BankId = viewModel.BankId;
                    doctor.BankCabangId = viewModel.BankCabangId;
                    doctor.BankAtasNama = viewModel.BankAtasNama;
                    doctor.BankNomorRekening = viewModel.BankNomorRekening;
                    doctor.Npwp = viewModel.Npwp;
                    doctor.AlamatRumahLengkap = viewModel.AlamatRumahLengkap;
                    doctor.CountryId = viewModel.CountryId;
                    doctor.ProvinceId = viewModel.ProvinceId;
                    doctor.CityId = viewModel.CityId;
                    doctor.DistrictId = viewModel.DistrictId;
                    doctor.SubDistrictId = viewModel.SubDistrictId;
                    doctor.KodePos = viewModel.KodePos;
                    doctor.NomorTelepon = viewModel.NomorTelepon;
                    doctor.NomorHandphone = viewModel.NomorHandphone;
                    doctor.AlamatKantorLengkap = viewModel.AlamatKantorLengkap;
                    doctor.NomorTeleponKantor = viewModel.NomorTeleponKantor;
                    doctor.NomorIdDokter = viewModel.NomorIdDokter;
                    doctor.DoctorTitleId = viewModel.DoctorTitleId;
                    doctor.JenisKontrak = viewModel.JenisKontrak;
                    doctor.TanggalAwalKontrak = viewModel.TanggalAwalKontrak;
                    doctor.TanggalAkhirKontrak = viewModel.TanggalAkhirKontrak;
                    doctor.TanggalKeluar = viewModel.TanggalKeluar;
                    doctor.GuaranteeFee = viewModel.GuaranteeFee;
                    doctor.DokterMitra = viewModel.DokterMitra;
                    doctor.DokterSpesialis = viewModel.DokterSpesialis;
                    if (viewModel.Foto != null)
                    {
                        if (viewModel.DoctorPhotoPath != null)
                        {
                            string filePath = Path.Combine(_hostingEnvironment.WebRootPath,
                                "FotoDokter", viewModel.DoctorPhotoPath);
                            System.IO.File.Delete(filePath);
                        }
                        doctor.Foto = ProcessUploadFile(viewModel);
                    }

                    _doctorRepository.Update(doctor);
                    _applicationDbContext.SaveChanges();

                    List<MultipleDoctorDepartment> multipleDoctorDepartments = new List<MultipleDoctorDepartment>();

                    var doctors = _applicationDbContext.Doctors.Include(dept => dept.MultipleDoctorDepartments).FirstOrDefault(x => x.DoctorId == viewModel.DoctorId);
                    doctors.MultipleDoctorDepartments.ToList().ForEach(d => multipleDoctorDepartments.Add(d));
                    _applicationDbContext.MultipleDoctorDepartments.RemoveRange(multipleDoctorDepartments);
                    _applicationDbContext.SaveChanges();

                    multipleDoctorDepartments = new List<MultipleDoctorDepartment>();

                    foreach (var selectedId in viewModel.DepartmentId)
                    {
                        var newMultipleDepartment = new MultipleDoctorDepartment
                        {
                            DoctorId = doctor.DoctorId,
                            DoctorDepartmentId = selectedId
                        };
                        _multipleDoctorDepartmentRepository.Tambah(newMultipleDepartment);
                        _applicationDbContext.SaveChanges();
                    }

                    doctor.MultipleDoctorDepartments = multipleDoctorDepartments;
                    
                    TempData["SuccessMessage"] = "Dokter " + viewModel.NamaLengkap + " Berhasil Diubah";
                    return RedirectToAction("Index", "Doctor");
                }
            }
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        //[Authorize]
        public async Task<IActionResult> DeleteDoctor(Guid Id)
        {            
            var doctor = await _doctorRepository.GetDoctorById(Id);
            if (doctor == null)
            {
                Response.StatusCode = 404;
                return View("DoctorNotFound", Id);
            }

            DetailDoctorViewModel vm = new DetailDoctorViewModel
            {
                DoctorId = doctor.DoctorId,
                KodeDokter = doctor.KodeDokter,
                NamaLengkap = doctor.NamaLengkap,
                DoctorPhotoPath = doctor.Foto,                
            };
            vm.DepartmentList = _applicationDbContext.DoctorDepartments.Select(c => new SelectListItem
            {
                Value = c.DepartmentId.ToString(),
                Text = c.NamaDepartemen

            }).ToList();            
            return View(vm);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteDoctor(Doctor model)
        {
            //Hapus MultipleDepartment dulu
            List<MultipleDoctorDepartment> multipleDoctorDepartments = new List<MultipleDoctorDepartment>();

            var doctors = _applicationDbContext.Doctors.Include(dept => dept.MultipleDoctorDepartments).FirstOrDefault(x => x.DoctorId == model.DoctorId);
            doctors.MultipleDoctorDepartments.ToList().ForEach(d => multipleDoctorDepartments.Add(d));
            _applicationDbContext.MultipleDoctorDepartments.RemoveRange(multipleDoctorDepartments);
            _applicationDbContext.SaveChanges();

            //Baru Hapus Doctor
            _applicationDbContext.Attach(doctors);
            _applicationDbContext.Entry(doctors).State = EntityState.Deleted;
            _applicationDbContext.SaveChanges();

            TempData["SuccessMessage"] = "Dokter " + model.NamaLengkap + " Berhasil Dihapus";

            return RedirectToAction("Index", "Doctor");
        }

        private string ProcessUploadFile(CreateDoctorViewModel model)
        {
            string uniqueFileName = null;
            if (model.Foto != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "FotoDokter");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Foto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Foto.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
