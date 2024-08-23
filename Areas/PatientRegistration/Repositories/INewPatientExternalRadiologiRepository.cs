using BenariMikronWebApp.Areas.Identity.Data;
using BenariMikronWebApp.Areas.PatientRegistration.Models;
using Microsoft.EntityFrameworkCore;

namespace BenariMikronWebApp.Areas.PatientRegistration.Repositories
{
    public class INewPatientExternalRadiologiRepository
    {
        private readonly ApplicationDbContext _context;

        public INewPatientExternalRadiologiRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ExternalPatientRadiologi Add(ExternalPatientRadiologi newPatientRadiologi)
        {
            _context.ExternalPatientRadiologis.Add(newPatientRadiologi);
            _context.SaveChanges();
            return newPatientRadiologi;
        }

        public async Task<ExternalPatientRadiologi> GetExternalPatientRadiologiById(Guid id)
        {
            var externalPatient = await _context.ExternalPatientRadiologis.FindAsync(id);

            if (externalPatient != null)
            {
                var pasienExternalDetails = new ExternalPatientRadiologi()
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
                    Promo = externalPatient.Promo,                   
                    SuratRujukan = externalPatient.SuratRujukan,
                    DiagnosaAwal = externalPatient.DiagnosaAwal,                    
                    DetailTindakan = externalPatient.DetailTindakan,
                    DokterPemeriksa = externalPatient.DokterPemeriksa,
                    Pemeriksaan = externalPatient.Pemeriksaan,
                    GenerateQrCode = externalPatient.GenerateQrCode,
                };
                return pasienExternalDetails;
            }
            return null;
        }

        public async Task<ExternalPatientRadiologi> GetExternalPatientRadiologiByIdNoTracking(Guid id)
        {
            return await _context.ExternalPatientRadiologis.AsNoTracking().FirstOrDefaultAsync(p => p.ExternalPatientId == id);
        }

        public async Task<List<ExternalPatientRadiologi>> GetExternalPatientRadiologis()
        {
            return await _context.ExternalPatientRadiologis.Select(externalPatient => new ExternalPatientRadiologi()
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
                Promo = externalPatient.Promo,
                SuratRujukan = externalPatient.SuratRujukan,
                DiagnosaAwal = externalPatient.DiagnosaAwal,
                DetailTindakan = externalPatient.DetailTindakan,
                DokterPemeriksa = externalPatient.DokterPemeriksa,
                Pemeriksaan = externalPatient.Pemeriksaan,
                GenerateQrCode = externalPatient.GenerateQrCode,
            }).ToListAsync();
        }

        public IEnumerable<ExternalPatientRadiologi> GetAllExternalPatientRadiologi()
        {
            return _context.ExternalPatientRadiologis.AsNoTracking()
                .Include(asuransi => asuransi.Insurance).OrderByDescending(c => c.CreateDateTime);
        }

        public ExternalPatientRadiologi Update(ExternalPatientRadiologi externalPatientChanges)
        {
            var externalPatient = _context.ExternalPatientRadiologis.Attach(externalPatientChanges);
            externalPatient.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return externalPatientChanges;
        }

        public ExternalPatientRadiologi Delete(Guid Id)
        {
            var pasien = _context.ExternalPatientRadiologis.Find(Id);
            if (pasien != null)
            {
                _context.ExternalPatientRadiologis.Remove(pasien);
                _context.SaveChanges();
            }
            return pasien;
        }
    }
}
