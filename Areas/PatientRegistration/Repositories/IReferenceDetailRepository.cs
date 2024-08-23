using BenariMikronWebApp.Areas.Identity.Data;
using BenariMikronWebApp.Areas.PatientRegistration.Models;
using Microsoft.EntityFrameworkCore;

namespace BenariMikronWebApp.Areas.PatientRegistration.Repositories
{
    public class IReferenceDetailRepository
    {
        private readonly ApplicationDbContext _context;

        public IReferenceDetailRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ReferenceDetail Tambah(ReferenceDetail rujukan)
        {
            _context.ReferenceDetails.Add(rujukan);
            _context.SaveChanges();
            return rujukan;
        }

        public async Task<ReferenceDetail> GetReferenceDetailById(Guid Id)
        {
            var rujukan = await _context.ReferenceDetails.FindAsync(Id);

            if (rujukan == null)
            {
                var rujukanDetail = new ReferenceDetail()
                {
                    ReferenceDetailId = rujukan.ReferenceDetailId,
                    KodeDetailRujukan = rujukan.KodeDetailRujukan,
                    NamaDetailRujukan = rujukan.NamaDetailRujukan,
                    NomorTelepon = rujukan.NomorTelepon,
                    Alamat = rujukan.Alamat,
                    ReferenceTypeId = rujukan.ReferenceTypeId
                };
                return rujukanDetail;
            }
            return null;
        }

        public async Task<ReferenceDetail> GetReferenceDetailByIdNoTracking(Guid Id)
        {
            return await _context.ReferenceDetails.AsNoTracking().FirstOrDefaultAsync(a => a.ReferenceDetailId == Id);
        }

        public async Task<List<ReferenceDetail>> GetReferenceDetails()
        {
            return await _context.ReferenceDetails.OrderBy(p => p.NamaDetailRujukan).Select(rujukan => new ReferenceDetail()
            {
                ReferenceDetailId = rujukan.ReferenceDetailId,
                KodeDetailRujukan = rujukan.KodeDetailRujukan,
                NamaDetailRujukan = rujukan.NamaDetailRujukan,
                NomorTelepon = rujukan.NomorTelepon,
                Alamat = rujukan.Alamat,
                ReferenceTypeId = rujukan.ReferenceTypeId
            }).ToListAsync();
        }

        public IEnumerable<ReferenceDetail> GetAllReferenceDetail()
        {
            return _context.ReferenceDetails
                .Include(a => a.ReferenceType)
                .AsNoTracking();
        }

        public ReferenceDetail Update(ReferenceDetail update)
        {
            var rujukan = _context.ReferenceDetails.Attach(update);
            rujukan.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return update;
        }

        public ReferenceDetail Delete(Guid Id)
        {
            var rujukan = _context.ReferenceDetails.Find(Id);
            if (rujukan != null)
            {
                _context.ReferenceDetails.Remove(rujukan);
                _context.SaveChanges();
            }
            return rujukan;
        }
    }
}
