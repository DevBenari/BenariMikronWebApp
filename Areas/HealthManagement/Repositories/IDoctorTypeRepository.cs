using BenariMikronWebApp.Areas.HealthManagement.Models;
using BenariMikronWebApp.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace BenariMikronWebApp.Areas.HealthManagement.Repositories
{
    public class IDoctorTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public IDoctorTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DoctorType Tambah(DoctorType type)
        {
            _context.DoctorTypes.Add(type);
            _context.SaveChanges();
            return type;
        }

        public async Task<DoctorType> GetDoctorTypeById(Guid Id)
        {
            var tipeDokter = await _context.DoctorTypes.FindAsync(Id);

            if (tipeDokter == null)
            {
                var tipeDokterDetail = new DoctorType()
                {
                    DoctorTypeId = tipeDokter.DoctorTypeId,
                    KodeTipeDokter = tipeDokter.KodeTipeDokter,
                    TipeDokter = tipeDokter.TipeDokter,
                    Persentase = tipeDokter.Persentase,
                    Status = tipeDokter.Status
                };
                return tipeDokterDetail;
            }
            return null;
        }

        public async Task<DoctorType> GetDoctorTypeByIdNoTracking(Guid Id)
        {
            return await _context.DoctorTypes.AsNoTracking().FirstOrDefaultAsync(a => a.DoctorTypeId == Id);
        }

        public async Task<List<DoctorType>> GetDoctorTypes()
        {
            return await _context.DoctorTypes.OrderBy(p => p.TipeDokter).Select(tipeDokter => new DoctorType()
            {
                DoctorTypeId = tipeDokter.DoctorTypeId,
                KodeTipeDokter = tipeDokter.KodeTipeDokter,
                TipeDokter = tipeDokter.TipeDokter,
                Persentase = tipeDokter.Persentase,
                Status = tipeDokter.Status
            }).ToListAsync();
        }

        public IEnumerable<DoctorType> GetAllDoctorType()
        {
            return _context.DoctorTypes.AsNoTracking();
        }

        public DoctorType Update(DoctorType update)
        {
            var tipeDokter = _context.DoctorTypes.Attach(update);
            tipeDokter.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return update;
        }

        public DoctorType Delete(Guid Id)
        {
            var tipeDokter = _context.DoctorTypes.Find(Id);
            if (tipeDokter != null)
            {
                _context.DoctorTypes.Remove(tipeDokter);
                _context.SaveChanges();
            }
            return tipeDokter;
        }
    }
}