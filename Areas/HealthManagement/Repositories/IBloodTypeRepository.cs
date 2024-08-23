using BenariMikronWebApp.Areas.HealthManagement.Models;
using BenariMikronWebApp.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace BenariMikronWebApp.Areas.HealthManagement.Repositories
{
    public class IBloodTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public IBloodTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public BloodType Tambah(BloodType goldar)
        {
            _context.BloodTypes.Add(goldar);
            _context.SaveChanges();
            return goldar;
        }

        public async Task<BloodType> GetBloodTypeById(Guid Id)
        {
            var goldar = await _context.BloodTypes.FindAsync(Id);

            if (goldar == null)
            {
                var goldarDetail = new BloodType()
                {
                    BloodTypeId = goldar.BloodTypeId,
                    KodeGolonganDarah = goldar.KodeGolonganDarah,
                    NamaGolonganDarah = goldar.NamaGolonganDarah,
                    Keterangan = goldar.Keterangan
                };
                return goldarDetail;
            }
            return null;
        }

        public async Task<BloodType> GetBloodTypeByIdNoTracking(Guid Id)
        {
            return await _context.BloodTypes.AsNoTracking().FirstOrDefaultAsync(a => a.BloodTypeId == Id);
        }

        public async Task<List<BloodType>> GetBloodTypes()
        {
            return await _context.BloodTypes.OrderBy(p => p.NamaGolonganDarah).Select(goldar => new BloodType()
            {
                BloodTypeId = goldar.BloodTypeId,
                KodeGolonganDarah = goldar.KodeGolonganDarah,
                NamaGolonganDarah = goldar.NamaGolonganDarah,
                Keterangan = goldar.Keterangan
            }).ToListAsync();
        }

        public IEnumerable<BloodType> GetAllBloodType()
        {
            return _context.BloodTypes.AsNoTracking();
        }

        public BloodType Update(BloodType update)
        {
            var goldar = _context.BloodTypes.Attach(update);
            goldar.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return update;
        }

        public BloodType Delete(Guid Id)
        {
            var goldar = _context.BloodTypes.Find(Id);
            if (goldar != null)
            {
                _context.BloodTypes.Remove(goldar);
                _context.SaveChanges();
            }
            return goldar;
        }
    }
}
