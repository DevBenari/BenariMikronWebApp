using BenariMikronWebApp.Areas.Identity.Data;
using BenariMikronWebApp.Areas.PatientRegistration.Models;
using BenariMikronWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BenariMikronWebApp.Areas.PatientRegistration.Repositories
{
    public class INewPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public INewPatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public NewPatient Add(NewPatient newPatient)
        {
            _context.NewPatients.Add(newPatient);
            _context.SaveChanges();
            return newPatient;
        }

        public async Task<NewPatient> GetNewPatientById(Guid id)
        {
            var newPatient = await _context.NewPatients.FindAsync(id);

            if (newPatient != null)
            {
                var pasienDetails = new NewPatient()
                {
                    PatientRegistrationId = newPatient.PatientRegistrationId,
                    KodePasien = newPatient.KodePasien,
                    NomorRekamMedisBaru = newPatient.NomorRekamMedisBaru,
                    NomorRekamMedisLama = newPatient.NomorRekamMedisLama,
                    TipePasien = newPatient.TipePasien,
                    InsuranceId = newPatient.InsuranceId,
                    NomorPolis = newPatient.NomorPolis,
                    NamaLengkapPasien = newPatient.NamaLengkapPasien,
                    Title = newPatient.Title,
                    NomorIdentitasPasien = newPatient.NomorIdentitasPasien,
                    TempatLahir = newPatient.TempatLahir,
                    TanggalLahir = newPatient.TanggalLahir,
                    JenisKelamin = newPatient.JenisKelamin,
                    PasienPrioritas = newPatient.PasienPrioritas,
                    StatusPasien = newPatient.StatusPasien,
                    ReligionId = newPatient.ReligionId,
                    Kewarganegaraan = newPatient.Kewarganegaraan,
                    LastEducationId = newPatient.LastEducationId,
                    AlamatLengkap = newPatient.AlamatLengkap,
                    CountryId = newPatient.CountryId,
                    ProvinceId = newPatient.ProvinceId,
                    CityId = newPatient.CityId,
                    DistrictId = newPatient.DistrictId,
                    SubDistrictId = newPatient.SubDistrictId,
                    KodePos = newPatient.KodePos,
                    NomorTelepon1 = newPatient.NomorTelepon1,
                    NomorTelepon2 = newPatient.NomorTelepon2,
                    Email = newPatient.Email,
                    Pekerjaan = newPatient.Pekerjaan,
                    NamaKantor = newPatient.NamaKantor,
                    AlamatKantor = newPatient.AlamatKantor,
                    NomorTeleponKantor = newPatient.NomorTeleponKantor,
                    BloodTypeId = newPatient.BloodTypeId,
                    Alergi = newPatient.Alergi,
                    NamaKeluargaTerdekat = newPatient.NamaKeluargaTerdekat,
                    HubunganKeluarga = newPatient.HubunganKeluarga,
                    KaryawanRumahSakit = newPatient.KaryawanRumahSakit,
                    AlamatKeluargaPasien = newPatient.AlamatKeluargaPasien,
                    NomorTeleponKeluargaPasien = newPatient.NomorTeleponKeluargaPasien,
                    NamaAyahPasien = newPatient.NamaAyahPasien,
                    PekerjaanAyahPasien = newPatient.PekerjaanAyahPasien,
                    NamaIbuPasien = newPatient.NamaIbuPasien,
                    PekerjaanIbuPasien = newPatient.PekerjaanIbuPasien,
                    NamaSutriPasien = newPatient.NamaSutriPasien,
                    PekerjaanSutriPasien = newPatient.PekerjaanSutriPasien,
                    NomorIdentitasSutriPasien = newPatient.NomorIdentitasSutriPasien,                                        
                    GenerateQrCode = newPatient.GenerateQrCode
                };
                return pasienDetails;
            }
            return null;
        }

        public async Task<NewPatient> GetNewPatientByIdNoTracking(Guid id)
        {
            return await _context.NewPatients.AsNoTracking().FirstOrDefaultAsync(p => p.PatientRegistrationId == id);
        }

        public async Task<List<NewPatient>> GetNewPatients()
        {
            return await _context.NewPatients.Select(newPatient => new NewPatient()
            {
                PatientRegistrationId = newPatient.PatientRegistrationId,
                KodePasien = newPatient.KodePasien,
                NomorRekamMedisBaru = newPatient.NomorRekamMedisBaru,
                NomorRekamMedisLama = newPatient.NomorRekamMedisLama,
                TipePasien = newPatient.TipePasien,
                InsuranceId = newPatient.InsuranceId,
                NomorPolis = newPatient.NomorPolis,
                NamaLengkapPasien = newPatient.NamaLengkapPasien,
                Title = newPatient.Title,
                NomorIdentitasPasien = newPatient.NomorIdentitasPasien,
                TempatLahir = newPatient.TempatLahir,
                TanggalLahir = newPatient.TanggalLahir,
                JenisKelamin = newPatient.JenisKelamin,
                PasienPrioritas = newPatient.PasienPrioritas,
                StatusPasien = newPatient.StatusPasien,
                ReligionId = newPatient.ReligionId,
                Kewarganegaraan = newPatient.Kewarganegaraan,
                LastEducationId = newPatient.LastEducationId,
                AlamatLengkap = newPatient.AlamatLengkap,
                CountryId = newPatient.CountryId,
                ProvinceId = newPatient.ProvinceId,
                CityId = newPatient.CityId,
                DistrictId = newPatient.DistrictId,
                SubDistrictId = newPatient.SubDistrictId,
                KodePos = newPatient.KodePos,
                NomorTelepon1 = newPatient.NomorTelepon1,
                NomorTelepon2 = newPatient.NomorTelepon2,
                Email = newPatient.Email,
                Pekerjaan = newPatient.Pekerjaan,
                NamaKantor = newPatient.NamaKantor,
                AlamatKantor = newPatient.AlamatKantor,
                NomorTeleponKantor = newPatient.NomorTeleponKantor,
                BloodTypeId = newPatient.BloodTypeId,
                Alergi = newPatient.Alergi,
                NamaKeluargaTerdekat = newPatient.NamaKeluargaTerdekat,
                HubunganKeluarga = newPatient.HubunganKeluarga,
                KaryawanRumahSakit = newPatient.KaryawanRumahSakit,
                AlamatKeluargaPasien = newPatient.AlamatKeluargaPasien,
                NomorTeleponKeluargaPasien = newPatient.NomorTeleponKeluargaPasien,
                NamaAyahPasien = newPatient.NamaAyahPasien,
                PekerjaanAyahPasien = newPatient.PekerjaanAyahPasien,
                NamaIbuPasien = newPatient.NamaIbuPasien,
                PekerjaanIbuPasien = newPatient.PekerjaanIbuPasien,
                NamaSutriPasien = newPatient.NamaSutriPasien,
                PekerjaanSutriPasien = newPatient.PekerjaanSutriPasien,
                NomorIdentitasSutriPasien = newPatient.NomorIdentitasSutriPasien,
                GenerateQrCode = newPatient.GenerateQrCode
            }).ToListAsync();
        }

        public IEnumerable<NewPatient> GetAllNewPatient()
        {
            return _context.NewPatients.AsNoTracking()
                .Include(penjamin => penjamin.Insurance).OrderByDescending(c => c.CreateDateTime);
        }

        public NewPatient Update(NewPatient NewPatientChanges)
        {
            var NewPatient = _context.NewPatients.Attach(NewPatientChanges);
            NewPatient.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return NewPatientChanges;
        }

        public NewPatient Delete(Guid Id)
        {
            var pasien = _context.NewPatients.Find(Id);
            if (pasien != null)
            {
                _context.NewPatients.Remove(pasien);
                _context.SaveChanges();
            }
            return pasien;
        }
    }
}
