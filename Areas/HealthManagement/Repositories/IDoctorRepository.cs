using BenariMikronWebApp.Areas.HealthManagement.Models;
using BenariMikronWebApp.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace BenariMikronWebApp.Areas.HealthManagement.Repositories
{
    public class IDoctorRepository
    {
        private readonly ApplicationDbContext _context;

        public IDoctorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Doctor Tambah(Doctor lokasi)
        {
            _context.Doctors.Add(lokasi);
            _context.SaveChanges();
            return lokasi;
        }

        public async Task<Doctor> GetDoctorById(Guid Id)
        {
            var dokter = await _context.Doctors
                .Include(l => l.DoctorType)
                .Include(e => e.LastEducation)
                .Include(r => r.Religion)
                .Include(w => w.Working)
                .Include(q => q.DoctorQueueType)
                .Include(b => b.Bank)
                .Include(c => c.BankCabang)
                .Include(n => n.Country)
                .Include(p => p.Province)
                .Include(t => t.City)
                .Include(d => d.District)
                .Include(s => s.SubDistrict)
                .Include(g => g.DoctorTitle)
                .Include(dpt => dpt.MultipleDoctorDepartments)
                .SingleOrDefaultAsync(p => p.DoctorId == Id);

            if (dokter != null)
            {
                var dokterDetail = new Doctor()
                {
                    DoctorId = dokter.DoctorId,
                    KodeDokter = dokter.KodeDokter,
                    DoctorTypeId = dokter.DoctorTypeId,
                    DoctorType = dokter.DoctorType,
                    NamaLengkap = dokter.NamaLengkap,
                    NamaMarga = dokter.NamaMarga,
                    NomorKtpDokter = dokter.NomorKtpDokter,
                    TempatLahir = dokter.TempatLahir,
                    TanggalLahir = dokter.TanggalLahir,
                    JenisKelamin = dokter.JenisKelamin,
                    Kewarganegaraan = dokter.Kewarganegaraan,
                    LastEducationId = dokter.LastEducationId,
                    LastEducation = dokter.LastEducation,
                    ReligionId = dokter.ReligionId,
                    Religion = dokter.Religion,
                    WorkingId = dokter.WorkingId,
                    Working = dokter.Working,
                    DoctorQueueTypeId = dokter.DoctorQueueTypeId,
                    DoctorQueueType = dokter.DoctorQueueType,
                    BankId = dokter.BankId,
                    Bank = dokter.Bank,
                    BankCabangId = dokter.BankCabangId,
                    BankCabang = dokter.BankCabang,
                    BankAtasNama = dokter.BankAtasNama,
                    BankNomorRekening = dokter.BankNomorRekening,
                    Npwp = dokter.Npwp,
                    AlamatRumahLengkap = dokter.AlamatRumahLengkap,
                    CountryId = dokter.CountryId,
                    Country = dokter.Country,
                    ProvinceId = dokter.ProvinceId,
                    Province = dokter.Province,
                    CityId = dokter.CityId,
                    City = dokter.City,
                    DistrictId = dokter.DistrictId,
                    District = dokter.District,
                    SubDistrictId = dokter.SubDistrictId,
                    SubDistrict = dokter.SubDistrict,
                    KodePos = dokter.KodePos,
                    NomorTelepon = dokter.NomorTelepon,
                    NomorHandphone = dokter.NomorHandphone,
                    AlamatKantorLengkap = dokter.AlamatKantorLengkap,
                    NomorTeleponKantor = dokter.NomorTeleponKantor,
                    NomorIdDokter = dokter.NomorIdDokter,
                    DoctorTitleId = dokter.DoctorTitleId,
                    DoctorTitle = dokter.DoctorTitle,
                    JenisKontrak = dokter.JenisKontrak,
                    TanggalAwalKontrak = dokter.TanggalAwalKontrak,
                    TanggalAkhirKontrak = dokter.TanggalAkhirKontrak,
                    TanggalKeluar = dokter.TanggalKeluar,
                    GuaranteeFee = dokter.GuaranteeFee,
                    DokterMitra = dokter.DokterMitra,
                    DokterSpesialis = dokter.DokterSpesialis,
                    Foto = dokter.Foto
                };
                return dokterDetail;
            }
            return null;
        }

        public async Task<Doctor> GetDoctorByIdNoTracking(Guid Id)
        {
            return await _context.Doctors.AsNoTracking()
                .Where(d => d.DoctorId == Id)
                .Include(m => m.MultipleDoctorDepartments)
                .FirstOrDefaultAsync(a => a.DoctorId == Id);
        }

        public async Task<List<Doctor>> GetDoctors()
        {
            return await _context.Doctors.OrderBy(p => p.NamaLengkap).Select(dokter => new Doctor()
            {
                DoctorId = dokter.DoctorId,
                KodeDokter = dokter.KodeDokter,
                DoctorTypeId = dokter.DoctorTypeId,
                NamaLengkap = dokter.NamaLengkap,
                NamaMarga = dokter.NamaMarga,
                NomorKtpDokter = dokter.NomorKtpDokter,
                TempatLahir = dokter.TempatLahir,
                TanggalLahir = dokter.TanggalLahir,
                JenisKelamin = dokter.JenisKelamin,
                Kewarganegaraan = dokter.Kewarganegaraan,
                LastEducationId = dokter.LastEducationId,
                ReligionId = dokter.ReligionId,
                WorkingId = dokter.WorkingId,
                DoctorQueueTypeId = dokter.DoctorQueueTypeId,
                BankId = dokter.BankId,
                BankCabangId = dokter.BankCabangId,
                BankAtasNama = dokter.BankAtasNama,
                BankNomorRekening = dokter.BankNomorRekening,
                Npwp = dokter.Npwp,
                AlamatRumahLengkap = dokter.AlamatRumahLengkap,
                CountryId = dokter.CountryId,
                ProvinceId = dokter.ProvinceId,
                CityId = dokter.CityId,
                DistrictId = dokter.DistrictId,
                SubDistrictId = dokter.SubDistrictId,
                KodePos = dokter.KodePos,
                NomorTelepon = dokter.NomorTelepon,
                NomorHandphone = dokter.NomorHandphone,
                AlamatKantorLengkap = dokter.AlamatKantorLengkap,
                NomorTeleponKantor = dokter.NomorTeleponKantor,
                NomorIdDokter = dokter.NomorIdDokter,
                DoctorTitleId = dokter.DoctorTitleId,
                JenisKontrak = dokter.JenisKontrak,
                TanggalAwalKontrak = dokter.TanggalAwalKontrak,
                TanggalAkhirKontrak = dokter.TanggalAkhirKontrak,
                TanggalKeluar = dokter.TanggalKeluar,
                GuaranteeFee = dokter.GuaranteeFee,
                DokterMitra = dokter.DokterMitra,
                DokterSpesialis = dokter.DokterSpesialis,
                Foto = dokter.Foto
            }).ToListAsync();
        }

        public IEnumerable<Doctor> GetAllDoctor()
        {
            return _context.Doctors
                .Include(l => l.DoctorType)
                .Include(e => e.LastEducation)
                .Include(r => r.Religion)
                .Include(w => w.Working)
                .Include(q => q.DoctorQueueType)
                .Include(b => b.Bank)
                .Include(c => c.BankCabang)
                .Include(n => n.Country)
                .Include(p => p.Province)
                .Include(t => t.City)
                .Include(d => d.District)
                .Include(s => s.SubDistrict)
                .Include(g => g.DoctorTitle)
                .Include(dpt => dpt.MultipleDoctorDepartments)
                .AsNoTracking();
        }

        public async Task<Doctor> Update(Doctor update)
        {
            //List<MultipleDoctorDepartment> multipleDoctorDepartments = _context.MultipleDoctorDepartments.Where(d => d.DoctorId == update.DoctorId).ToList();
            //_context.MultipleDoctorDepartments.RemoveRange(multipleDoctorDepartments);
            //_context.SaveChanges();

            var dokter = _context.Doctors.Attach(update);
            dokter.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //_context.MultipleDoctorDepartments.AddRangeAsync(update.MultipleDoctorDepartment);
            _context.SaveChanges();
            return update;
        }

        public Doctor Delete(Guid Id)
        {
            var dokter = _context.Doctors.Find(Id);
            if (dokter != null)
            {
                _context.Doctors.Remove(dokter);
                _context.SaveChanges();
            }
            return dokter;
        }
    }
}
