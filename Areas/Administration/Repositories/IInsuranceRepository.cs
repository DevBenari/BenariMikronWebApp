using BenariMikronWebApp.Areas.Administration.Models;
using BenariMikronWebApp.Areas.Identity.Data;
using BenariMikronWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BenariMikronWebApp.Areas.Administration.Repositories
{
    public class IInsuranceRepository
    {
        private readonly ApplicationDbContext _context;

        public IInsuranceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Insurance Tambah(Insurance asuransi)
        {
            _context.Insurances.Add(asuransi);
            _context.SaveChanges();
            return asuransi;
        }

        public async Task<Insurance> GetInsuranceById(Guid Id)
        {
            var asuransi = await _context.Insurances.FindAsync(Id);

            if (asuransi == null)
            {
                var asuransiDetail = new Insurance()
                {
                    InsuranceId = asuransi.InsuranceId,
                    KodeAsuransi = asuransi.KodeAsuransi,
                    MulaiKerjasama = asuransi.MulaiKerjasama,
                    AkhirKerjasama = asuransi.AkhirKerjasama,
                    KodePerusahaan = asuransi.KodePerusahaan,
                    TipePerusahaan = asuransi.TipePerusahaan,
                    NamaPerusahaan = asuransi.NamaPerusahaan,
                    TarifGroupPerusahaan = asuransi.TarifGroupPerusahaan,
                    Email = asuransi.Email,
                    AkunBankKartuKredit = asuransi.AkunBankKartuKredit,
                    Direktur = asuransi.Direktur,
                    NamaKontak = asuransi.NamaKontak,
                    Jabatan = asuransi.Jabatan,
                    Bagian = asuransi.Bagian,
                    KomisiKartuKredit = asuransi.KomisiKartuKredit,
                    Diskon = asuransi.Diskon,
                    TermasukAsuransi = asuransi.TermasukAsuransi,
                    TermasukKaryawanRS = asuransi.TermasukKaryawanRS,
                    //PerusahaanAsuransi = asuransi.PerusahaanAsuransi,
                    Alamat = asuransi.Alamat,
                    AlamatTagihan = asuransi.AlamatTagihan,
                    CountryId = asuransi.CountryId,
                    ProvinceId = asuransi.ProvinceId,
                    CityId = asuransi.CityId,
                    DistrictId = asuransi.DistrictId,
                    SubDistrictId = asuransi.SubDistrictId,
                    KodePos = asuransi.KodePos,
                    NomorTelepon = asuransi.NomorTelepon,
                    NomorFax = asuransi.NomorFax,
                    Status = asuransi.Status,
                    JenisKerjasama = asuransi.JenisKerjasama,
                    JenisKontrak = asuransi.JenisKontrak,
                    JatuhTempo = asuransi.JatuhTempo,
                    KriteriaPembayaran = asuransi.KriteriaPembayaran,
                    MenjaminPasienOTC = asuransi.MenjaminPasienOTC,
                    AkunBankAtasNama = asuransi.AkunBankAtasNama,
                    NamaBank = asuransi.NamaBank,
                    NamaCabang = asuransi.NamaCabang,
                    NomorRekeningBank = asuransi.NomorRekeningBank,
                    Pinalti = asuransi.Pinalti,
                    Keterangan = asuransi.Keterangan
                };
                return asuransiDetail;
            }
            return null;
        }

        public async Task<Insurance> GetInsuranceByIdNoTracking(Guid Id)
        {
            return await _context.Insurances.AsNoTracking().FirstOrDefaultAsync(a => a.InsuranceId == Id);
        }

        public async Task<List<Insurance>> GetInsurances()
        {
            return await _context.Insurances.OrderBy(p => p.NamaPerusahaan).Select(asuransi => new Insurance()
            {
                InsuranceId = asuransi.InsuranceId,
                KodeAsuransi = asuransi.KodeAsuransi,
                MulaiKerjasama = asuransi.MulaiKerjasama,
                AkhirKerjasama = asuransi.AkhirKerjasama,
                KodePerusahaan = asuransi.KodePerusahaan,
                TipePerusahaan = asuransi.TipePerusahaan,
                NamaPerusahaan = asuransi.NamaPerusahaan,
                TarifGroupPerusahaan = asuransi.TarifGroupPerusahaan,
                Email = asuransi.Email,
                AkunBankKartuKredit = asuransi.AkunBankKartuKredit,
                Direktur = asuransi.Direktur,
                NamaKontak = asuransi.NamaKontak,
                Jabatan = asuransi.Jabatan,
                Bagian = asuransi.Bagian,
                KomisiKartuKredit = asuransi.KomisiKartuKredit,
                Diskon = asuransi.Diskon,
                TermasukAsuransi = asuransi.TermasukAsuransi,
                TermasukKaryawanRS = asuransi.TermasukKaryawanRS,
                //PerusahaanAsuransi = asuransi.PerusahaanAsuransi,
                Alamat = asuransi.Alamat,
                AlamatTagihan = asuransi.AlamatTagihan,
                CountryId = asuransi.CountryId,
                ProvinceId = asuransi.ProvinceId,
                CityId = asuransi.CityId,
                DistrictId = asuransi.DistrictId,
                SubDistrictId = asuransi.SubDistrictId,
                KodePos = asuransi.KodePos,
                NomorTelepon = asuransi.NomorTelepon,
                NomorFax = asuransi.NomorFax,
                Status = asuransi.Status,
                JenisKerjasama = asuransi.JenisKerjasama,
                JenisKontrak = asuransi.JenisKontrak,
                JatuhTempo = asuransi.JatuhTempo,
                KriteriaPembayaran = asuransi.KriteriaPembayaran,
                MenjaminPasienOTC = asuransi.MenjaminPasienOTC,
                AkunBankAtasNama = asuransi.AkunBankAtasNama,
                NamaBank = asuransi.NamaBank,
                NamaCabang = asuransi.NamaCabang,
                NomorRekeningBank = asuransi.NomorRekeningBank,
                Pinalti = asuransi.Pinalti,
                Keterangan = asuransi.Keterangan
            }).ToListAsync();
        }

        public IEnumerable<Insurance> GetAllInsurance()
        {
            return _context.Insurances.AsNoTracking();
        }

        public Insurance Update(Insurance asuransiChanges)
        {
            var asuransi = _context.Insurances.Attach(asuransiChanges);
            asuransi.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return asuransiChanges;
        }

        public Insurance Delete(Guid Id)
        {
            var asuransi = _context.Insurances.Find(Id);
            if (asuransi != null)
            {
                _context.Insurances.Remove(asuransi);
                _context.SaveChanges();
            }
            return asuransi;
        }
    }
}
