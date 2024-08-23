using BenariMikronWebApp.Areas.Administration.Models;
using BenariMikronWebApp.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace BenariMikronWebApp.Areas.Administration.Repositories
{
    public class IWorkingRepository
    {
        private readonly ApplicationDbContext _context;

        public IWorkingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Working Tambah(Working type)
        {
            _context.Workings.Add(type);
            _context.SaveChanges();
            return type;
        }

        public async Task<Working> GetWorkingById(Guid Id)
        {
            var work = await _context.Workings.FindAsync(Id);

            if (work == null)
            {
                var workDetail = new Working()
                {
                    WorkingId = work.WorkingId,
                    KodePekerjaan = work.KodePekerjaan,
                    NamaPekerjaan = work.NamaPekerjaan
                };
                return workDetail;
            }
            return null;
        }

        public async Task<Working> GetWorkingByIdNoTracking(Guid Id)
        {
            return await _context.Workings.AsNoTracking().FirstOrDefaultAsync(a => a.WorkingId == Id);
        }

        public async Task<List<Working>> GetWorkings()
        {
            return await _context.Workings.OrderBy(p => p.NamaPekerjaan).Select(work => new Working()
            {
                WorkingId = work.WorkingId,
                KodePekerjaan = work.KodePekerjaan,
                NamaPekerjaan = work.NamaPekerjaan
            }).ToListAsync();
        }

        public IEnumerable<Working> GetAllWorking()
        {
            return _context.Workings.AsNoTracking();
        }

        public Working Update(Working update)
        {
            var work = _context.Workings.Attach(update);
            work.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return update;
        }

        public Working Delete(Guid Id)
        {
            var work = _context.Workings.Find(Id);
            if (work != null)
            {
                _context.Workings.Remove(work);
                _context.SaveChanges();
            }
            return work;
        }
    }
}
