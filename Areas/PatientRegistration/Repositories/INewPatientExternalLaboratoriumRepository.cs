using BenariMikronWebApp.Areas.Identity.Data;
using BenariMikronWebApp.Areas.PatientRegistration.Models;
using Microsoft.EntityFrameworkCore;

namespace BenariMikronWebApp.Areas.PatientRegistration.Repositories
{
    public class INewPatientExternalLaboratoriumRepository
    {
        private readonly ApplicationDbContext _context;

        public INewPatientExternalLaboratoriumRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ExternalPatientLaboratorium Add(ExternalPatientLaboratorium newPatientLaboratorium)
        {
            _context.ExternalPatientLaboratoriums.Add(newPatientLaboratorium);
            _context.SaveChanges();
            return newPatientLaboratorium;
        }

        public async Task<ExternalPatientLaboratorium> GetExternalPatientLaboratoriumById(Guid id)
        {
            var externalPatient = await _context.ExternalPatientLaboratoriums.FindAsync(id);

            if (externalPatient != null)
            {
                var pasienExternalDetails = new ExternalPatientLaboratorium()
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
                    PromoId = externalPatient.PromoId,
                    TipePemeriksaan = externalPatient.TipePemeriksaan,
                    SuratRujukan = externalPatient.SuratRujukan,
                    DiagnosaAwal = externalPatient.DiagnosaAwal,
                    TanggalSampling = externalPatient.TanggalSampling,
                    DetailTindakan = externalPatient.DetailTindakan,
                    DokterPemeriksa = externalPatient.DokterPemeriksa,
                    Pemeriksaan = externalPatient.Pemeriksaan,
                    GenerateQrCode = externalPatient.GenerateQrCode,                    
                };
                return pasienExternalDetails;
            }
            return null;
        }

        public async Task<ExternalPatientLaboratorium> GetExternalPatientLaboratoriumByIdNoTracking(Guid id)
        {
            return await _context.ExternalPatientLaboratoriums.AsNoTracking().FirstOrDefaultAsync(p => p.ExternalPatientId == id);
        }

        public async Task<List<ExternalPatientLaboratorium>> GetExternalPatientLaboratoriums()
        {
            return await _context.ExternalPatientLaboratoriums.Select(externalPatient => new ExternalPatientLaboratorium()
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
                PromoId = externalPatient.PromoId,
                TipePemeriksaan = externalPatient.TipePemeriksaan,
                SuratRujukan = externalPatient.SuratRujukan,
                DiagnosaAwal = externalPatient.DiagnosaAwal,
                TanggalSampling = externalPatient.TanggalSampling,
                DetailTindakan = externalPatient.DetailTindakan,
                DokterPemeriksa = externalPatient.DokterPemeriksa,
                Pemeriksaan = externalPatient.Pemeriksaan,
                GenerateQrCode = externalPatient.GenerateQrCode,
            }).ToListAsync();
        }

        public IEnumerable<ExternalPatientLaboratorium> GetAllExternalPatientLaboratorium()
        {
            return _context.ExternalPatientLaboratoriums.AsNoTracking()
                .Include(asuransi => asuransi.Insurance).OrderByDescending(c => c.CreateDateTime);
        }

        public ExternalPatientLaboratorium Update(ExternalPatientLaboratorium externalPatientChanges)
        {
            var externalPatient = _context.ExternalPatientLaboratoriums.Attach(externalPatientChanges);
            externalPatient.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return externalPatientChanges;
        }

        public ExternalPatientLaboratorium Delete(Guid Id)
        {
            var pasienLab = _context.ExternalPatientLaboratoriums.Find(Id);
            if (pasienLab != null)
            {
                _context.ExternalPatientLaboratoriums.Remove(pasienLab);
                _context.SaveChanges();
            }
            return pasienLab;
        }
    }
}
