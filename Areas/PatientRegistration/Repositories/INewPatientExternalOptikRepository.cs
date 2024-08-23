using BenariMikronWebApp.Areas.Identity.Data;
using BenariMikronWebApp.Areas.PatientRegistration.Models;
using Microsoft.EntityFrameworkCore;

namespace BenariMikronWebApp.Areas.PatientRegistration.Repositories
{
    public class INewPatientExternalOptikRepository
    {
        private readonly ApplicationDbContext _context;

        public INewPatientExternalOptikRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ExternalPatientOptik Add(ExternalPatientOptik newPatientOptik)
        {
            _context.ExternalPatientOptiks.Add(newPatientOptik);
            _context.SaveChanges();
            return newPatientOptik;
        }

        public async Task<ExternalPatientOptik> GetExternalPatientOptikById(Guid id)
        {
            var externalPatient = await _context.ExternalPatientOptiks.FindAsync(id);

            if (externalPatient != null)
            {
                var pasienExternalDetails = new ExternalPatientOptik()
                {
                    ExternalPatientId = externalPatient.ExternalPatientId,
                    KodePasien = externalPatient.KodePasien,
                    NomorRekamMedisBaru = externalPatient.NomorRekamMedisBaru,
                    NomorRekamMedisLama = externalPatient.NomorRekamMedisLama,
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
                    DetailTindakan = externalPatient.DetailTindakan,
                    DokterPemeriksa = externalPatient.DokterPemeriksa,                    
                    GenerateQrCode = externalPatient.GenerateQrCode,
                };
                return pasienExternalDetails;
            }
            return null;
        }

        public async Task<ExternalPatientOptik> GetExternalPatientOptikByIdNoTracking(Guid id)
        {
            return await _context.ExternalPatientOptiks.AsNoTracking().FirstOrDefaultAsync(p => p.ExternalPatientId == id);
        }

        public async Task<List<ExternalPatientOptik>> GetExternalPatientOptik()
        {
            return await _context.ExternalPatientOptiks.Select(externalPatient => new ExternalPatientOptik()
            {
                ExternalPatientId = externalPatient.ExternalPatientId,
                KodePasien = externalPatient.KodePasien,
                NomorRekamMedisBaru = externalPatient.NomorRekamMedisBaru,
                NomorRekamMedisLama = externalPatient.NomorRekamMedisLama,
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
                DetailTindakan = externalPatient.DetailTindakan,
                DokterPemeriksa = externalPatient.DokterPemeriksa,
                GenerateQrCode = externalPatient.GenerateQrCode,
            }).ToListAsync();
        }

        public IEnumerable<ExternalPatientOptik> GetAllExternalPatientOptik()
        {
            return _context.ExternalPatientOptiks.AsNoTracking()
                .OrderByDescending(c => c.CreateDateTime);
        }

        public ExternalPatientOptik Update(ExternalPatientOptik externalPatientChanges)
        {
            var externalPatient = _context.ExternalPatientOptiks.Attach(externalPatientChanges);
            externalPatient.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return externalPatientChanges;
        }

        public ExternalPatientOptik Delete(Guid Id)
        {
            var pasien = _context.ExternalPatientOptiks.Find(Id);
            if (pasien != null)
            {
                _context.ExternalPatientOptiks.Remove(pasien);
                _context.SaveChanges();
            }
            return pasien;
        }
    }
}
