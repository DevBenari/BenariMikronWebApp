using BenariMikronWebApp.Areas.Identity.Data;
using BenariMikronWebApp.Areas.PatientRegistration.Models;
using Microsoft.EntityFrameworkCore;

namespace BenariMikronWebApp.Areas.PatientRegistration.Repositories
{
    public class INewPatientExternalRehabilitasiMedikRepository
    {
        private readonly ApplicationDbContext _context;

        public INewPatientExternalRehabilitasiMedikRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ExternalPatientRehabilitasiMedik Add(ExternalPatientRehabilitasiMedik newPatientRehabilitasiMedik)
        {
            _context.ExternalPatientRehabilitasiMediks.Add(newPatientRehabilitasiMedik);
            _context.SaveChanges();
            return newPatientRehabilitasiMedik;
        }

        public async Task<ExternalPatientRehabilitasiMedik> GetExternalPatientRehabilitasiMedikById(Guid id)
        {
            var externalPatient = await _context.ExternalPatientRehabilitasiMediks.FindAsync(id);

            if (externalPatient != null)
            {
                var pasienExternalDetails = new ExternalPatientRehabilitasiMedik()
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
                    TipeRujukan = externalPatient.TipeRujukan,
                    DeskripsiRujukan = externalPatient.DeskripsiRujukan,
                    SuratRujukan = externalPatient.SuratRujukan,
                    DiagnosaAwal = externalPatient.DiagnosaAwal,
                    DaftarTindakan = externalPatient.DaftarTindakan,
                    DokterPemeriksa = externalPatient.DokterPemeriksa,                   
                    GenerateQrCode = externalPatient.GenerateQrCode,
                };
                return pasienExternalDetails;
            }
            return null;
        }

        public async Task<ExternalPatientRehabilitasiMedik> GetExternalPatientRehabilitasiMedikByIdNoTracking(Guid id)
        {
            return await _context.ExternalPatientRehabilitasiMediks.AsNoTracking().FirstOrDefaultAsync(p => p.ExternalPatientId == id);
        }

        public async Task<List<ExternalPatientRehabilitasiMedik>> GetExternalPatientRehabilitasiMediks()
        {
            return await _context.ExternalPatientRehabilitasiMediks.Select(externalPatient => new ExternalPatientRehabilitasiMedik()
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
                TipeRujukan = externalPatient.TipeRujukan,
                DeskripsiRujukan = externalPatient.DeskripsiRujukan,               
                SuratRujukan = externalPatient.SuratRujukan,
                DiagnosaAwal = externalPatient.DiagnosaAwal,
                DaftarTindakan = externalPatient.DaftarTindakan,
                DokterPemeriksa = externalPatient.DokterPemeriksa,                
                GenerateQrCode = externalPatient.GenerateQrCode,
            }).ToListAsync();
        }

        public IEnumerable<ExternalPatientRehabilitasiMedik> GetAllExternalPatientRehabilitasiMedik()
        {
            return _context.ExternalPatientRehabilitasiMediks.AsNoTracking()
                .Include(asuransi => asuransi.Insurance).OrderByDescending(c => c.CreateDateTime);
        }

        public ExternalPatientRehabilitasiMedik Update(ExternalPatientRehabilitasiMedik externalPatientChanges)
        {
            var externalPatient = _context.ExternalPatientRehabilitasiMediks.Attach(externalPatientChanges);
            externalPatient.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return externalPatientChanges;
        }

        public ExternalPatientRehabilitasiMedik Delete(Guid Id)
        {
            var pasien = _context.ExternalPatientRehabilitasiMediks.Find(Id);
            if (pasien != null)
            {
                _context.ExternalPatientRehabilitasiMediks.Remove(pasien);
                _context.SaveChanges();
            }
            return pasien;
        }
    }
}
