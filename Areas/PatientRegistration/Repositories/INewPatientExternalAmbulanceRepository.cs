using BenariMikronWebApp.Areas.Identity.Data;
using BenariMikronWebApp.Areas.PatientRegistration.Models;
using Microsoft.EntityFrameworkCore;

namespace BenariMikronWebApp.Areas.PatientRegistration.Repositories
{
    public class INewPatientExternalAmbulanceRepository
    {
        private readonly ApplicationDbContext _context;

        public INewPatientExternalAmbulanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ExternalPatientAmbulance Add(ExternalPatientAmbulance newPatientAmbulance)
        {
            _context.ExternalPatientAmbulances.Add(newPatientAmbulance);
            _context.SaveChanges();
            return newPatientAmbulance;
        }

        public async Task<ExternalPatientAmbulance> GetExternalPatientAmbulanceById(Guid id)
        {
            var externalPatient = await _context.ExternalPatientAmbulances.FindAsync(id);

            if (externalPatient != null)
            {
                var pasienExternalDetails = new ExternalPatientAmbulance()
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
                    Department = externalPatient.Department,
                    Komponen = externalPatient.Komponen,
                    DaerahTujuan = externalPatient.DaerahTujuan,
                    KelebihanJarak = externalPatient.KelebihanJarak,
                    KelebihanWaktu = externalPatient.KelebihanWaktu,
                    Paramedis = externalPatient.Paramedis,
                    AntarJemput = externalPatient.AntarJemput,
                    Catatan = externalPatient.Catatan,
                    GenerateQrCode = externalPatient.GenerateQrCode,
                };
                return pasienExternalDetails;
            }
            return null;
        }

        public async Task<ExternalPatientAmbulance> GetExternalPatientAmbulanceByIdNoTracking(Guid id)
        {
            return await _context.ExternalPatientAmbulances.AsNoTracking().FirstOrDefaultAsync(p => p.ExternalPatientId == id);
        }

        public async Task<List<ExternalPatientAmbulance>> GetExternalPatientAmbulance()
        {
            return await _context.ExternalPatientAmbulances.Select(externalPatient => new ExternalPatientAmbulance()
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
                Department = externalPatient.Department,
                Komponen = externalPatient.Komponen,
                DaerahTujuan = externalPatient.DaerahTujuan,
                KelebihanJarak = externalPatient.KelebihanJarak,
                KelebihanWaktu = externalPatient.KelebihanWaktu,
                Paramedis = externalPatient.Paramedis,
                AntarJemput = externalPatient.AntarJemput,
                Catatan = externalPatient.Catatan,
                GenerateQrCode = externalPatient.GenerateQrCode,
            }).ToListAsync();
        }

        public IEnumerable<ExternalPatientAmbulance> GetAllExternalPatientAmbulance()
        {
            return _context.ExternalPatientAmbulances.AsNoTracking()
                .OrderByDescending(c => c.CreateDateTime);
        }

        public ExternalPatientAmbulance Update(ExternalPatientAmbulance externalPatientChanges)
        {
            var externalPatient = _context.ExternalPatientAmbulances.Attach(externalPatientChanges);
            externalPatient.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return externalPatientChanges;
        }

        public ExternalPatientAmbulance Delete(Guid Id)
        {
            var pasien = _context.ExternalPatientAmbulances.Find(Id);
            if (pasien != null)
            {
                _context.ExternalPatientAmbulances.Remove(pasien);
                _context.SaveChanges();
            }
            return pasien;
        }
    }
}
