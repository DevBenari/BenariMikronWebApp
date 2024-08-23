using BenariMikronWebApp.Areas.Identity.Data;
using BenariMikronWebApp.Areas.PatientRegistration.Models;
using Microsoft.EntityFrameworkCore;

namespace BenariMikronWebApp.Areas.PatientRegistration.Repositories
{
    public class INewPatientExternalFasilitasRepository
    {
        private readonly ApplicationDbContext _context;

        public INewPatientExternalFasilitasRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ExternalPatientFasilitas Add(ExternalPatientFasilitas newPatientFasilitas)
        {
            _context.ExternalPatientFasilitas.Add(newPatientFasilitas);
            _context.SaveChanges();
            return newPatientFasilitas;
        }

        public async Task<ExternalPatientFasilitas> GetExternalPatientFasilitasById(Guid id)
        {
            var externalPatient = await _context.ExternalPatientFasilitas.FindAsync(id);

            if (externalPatient != null)
            {
                var pasienExternalDetails = new ExternalPatientFasilitas()
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

        public async Task<ExternalPatientFasilitas> GetExternalPatientFasilitasByIdNoTracking(Guid id)
        {
            return await _context.ExternalPatientFasilitas.AsNoTracking().FirstOrDefaultAsync(p => p.ExternalPatientId == id);
        }

        public async Task<List<ExternalPatientFasilitas>> GetExternalPatientFasilitas()
        {
            return await _context.ExternalPatientFasilitas.Select(externalPatient => new ExternalPatientFasilitas()
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
                GenerateQrCode = externalPatient.GenerateQrCode
            }).ToListAsync();
        }

        public IEnumerable<ExternalPatientFasilitas> GetAllExternalPatientFasilitas()
        {
            return _context.ExternalPatientFasilitas.AsNoTracking()
                .OrderByDescending(c => c.CreateDateTime);
        }

        public ExternalPatientFasilitas Update(ExternalPatientFasilitas externalPatientChanges)
        {
            var externalPatient = _context.ExternalPatientFasilitas.Attach(externalPatientChanges);
            externalPatient.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return externalPatientChanges;
        }

        public ExternalPatientFasilitas Delete(Guid Id)
        {
            var pasien = _context.ExternalPatientFasilitas.Find(Id);
            if (pasien != null)
            {
                _context.ExternalPatientFasilitas.Remove(pasien);
                _context.SaveChanges();
            }
            return pasien;
        }
    }
}
