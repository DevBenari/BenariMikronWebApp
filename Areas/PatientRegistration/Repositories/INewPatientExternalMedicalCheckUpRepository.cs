using BenariMikronWebApp.Areas.Identity.Data;
using BenariMikronWebApp.Areas.PatientRegistration.Models;
using Microsoft.EntityFrameworkCore;

namespace BenariMikronWebApp.Areas.PatientRegistration.Repositories
{
    public class INewPatientExternalMedicalCheckUpRepository
    {
        private readonly ApplicationDbContext _context;

        public INewPatientExternalMedicalCheckUpRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ExternalPatientMedicalCheckUp Add(ExternalPatientMedicalCheckUp newPatientMedicalCheckUp)
        {
            _context.ExternalPatientMedicalCheckUps.Add(newPatientMedicalCheckUp);
            _context.SaveChanges();
            return newPatientMedicalCheckUp;
        }

        public async Task<ExternalPatientMedicalCheckUp> GetExternalPatientMedicalCheckUpById(Guid id)
        {
            var externalPatient = await _context.ExternalPatientMedicalCheckUps.FindAsync(id);

            if (externalPatient != null)
            {
                var pasienExternalDetails = new ExternalPatientMedicalCheckUp()
                {
                    ExternalPatientId = externalPatient.ExternalPatientId,
                    KodePasien = externalPatient.KodePasien,
                    NomorRekamMedisBaru = externalPatient.NomorRekamMedisBaru,
                    NomorRekamMedisLama = externalPatient.NomorRekamMedisLama,
                    TipePasien = externalPatient.TipePasien,
                    InsuranceId = externalPatient.InsuranceId,
                    NomorPolis = externalPatient.NomorPolis,
                    Title = externalPatient.Title,
                    NamaPasien = externalPatient.NamaPasien,
                    NomorIdentitasPasien = externalPatient.NomorIdentitasPasien,
                    TempatLahir = externalPatient.TempatLahir,
                    TanggalLahir = externalPatient.TanggalLahir,
                    JenisKelamin = externalPatient.JenisKelamin,
                    AlamatLengkap = externalPatient.AlamatLengkap,
                    CountryId = externalPatient.CountryId,
                    ProvinceId = externalPatient.ProvinceId,
                    CityId = externalPatient.CityId,
                    DistrictId = externalPatient.DistrictId,
                    SubDistrictId = externalPatient.SubDistrictId,
                    KodePos = externalPatient.KodePos,
                    NomorTelepon = externalPatient.NomorTelepon,
                    EmailAktif = externalPatient.EmailAktif,
                    PaketMCU = externalPatient.PaketMCU,
                    DokterMCU = externalPatient.DokterMCU,
                    TipeRujukan = externalPatient.TipeRujukan,
                    DeskripsiRujukan = externalPatient.DeskripsiRujukan,
                    SuratRujukan = externalPatient.SuratRujukan,
                    DiagnosaAwal = externalPatient.DiagnosaAwal,                    
                    GenerateQrCode = externalPatient.GenerateQrCode,
                };
                return pasienExternalDetails;
            }
            return null;
        }

        public async Task<ExternalPatientMedicalCheckUp> GetExternalPatientMedicalCheckUpByIdNoTracking(Guid id)
        {
            return await _context.ExternalPatientMedicalCheckUps.AsNoTracking().FirstOrDefaultAsync(p => p.ExternalPatientId == id);
        }

        public async Task<List<ExternalPatientMedicalCheckUp>> GetExternalPatientMedicalCheckUps()
        {
            return await _context.ExternalPatientMedicalCheckUps.Select(externalPatient => new ExternalPatientMedicalCheckUp()
            {
                ExternalPatientId = externalPatient.ExternalPatientId,
                KodePasien = externalPatient.KodePasien,
                NomorRekamMedisBaru = externalPatient.NomorRekamMedisBaru,
                NomorRekamMedisLama = externalPatient.NomorRekamMedisLama,
                TipePasien = externalPatient.TipePasien,
                InsuranceId = externalPatient.InsuranceId,
                NomorPolis = externalPatient.NomorPolis,
                Title = externalPatient.Title,
                NamaPasien = externalPatient.NamaPasien,
                NomorIdentitasPasien = externalPatient.NomorIdentitasPasien,
                TempatLahir = externalPatient.TempatLahir,
                TanggalLahir = externalPatient.TanggalLahir,
                JenisKelamin = externalPatient.JenisKelamin,
                AlamatLengkap = externalPatient.AlamatLengkap,
                CountryId = externalPatient.CountryId,
                ProvinceId = externalPatient.ProvinceId,
                CityId = externalPatient.CityId,
                DistrictId = externalPatient.DistrictId,
                SubDistrictId = externalPatient.SubDistrictId,
                KodePos = externalPatient.KodePos,
                NomorTelepon = externalPatient.NomorTelepon,
                EmailAktif = externalPatient.EmailAktif,
                PaketMCU = externalPatient.PaketMCU,
                DokterMCU = externalPatient.DokterMCU,
                TipeRujukan = externalPatient.TipeRujukan,
                DeskripsiRujukan = externalPatient.DeskripsiRujukan,
                SuratRujukan = externalPatient.SuratRujukan,
                DiagnosaAwal = externalPatient.DiagnosaAwal,
                GenerateQrCode = externalPatient.GenerateQrCode,
            }).ToListAsync();
        }

        public IEnumerable<ExternalPatientMedicalCheckUp> GetAllExternalPatientMedicalCheckUp()
        {
            return _context.ExternalPatientMedicalCheckUps.AsNoTracking()
                .Include(asuransi => asuransi.Insurance).OrderByDescending(c => c.CreateDateTime);
        }

        public ExternalPatientMedicalCheckUp Update(ExternalPatientMedicalCheckUp externalPatientChanges)
        {
            var externalPatient = _context.ExternalPatientMedicalCheckUps.Attach(externalPatientChanges);
            externalPatient.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return externalPatientChanges;
        }

        public ExternalPatientMedicalCheckUp Delete(Guid Id)
        {
            var pasien = _context.ExternalPatientMedicalCheckUps.Find(Id);
            if (pasien != null)
            {
                _context.ExternalPatientMedicalCheckUps.Remove(pasien);
                _context.SaveChanges();
            }
            return pasien;
        }
    }
}
