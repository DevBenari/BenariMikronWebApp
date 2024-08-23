using BenariMikronWebApp.Areas.HealthManagement.Models;
using BenariMikronWebApp.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace BenariMikronWebApp.Areas.HealthManagement.Repositories
{
    public class IDayRepository
    {
        private readonly ApplicationDbContext _context;

        public IDayRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Day Tambah(Day type)
        {
            _context.Days.Add(type);
            _context.SaveChanges();
            return type;
        }

        public async Task<Day> GetDayById(Guid Id)
        {
            var shcedule = await _context.Days.FindAsync(Id);

            if (shcedule == null)
            {
                var shceduleDetail = new Day()
                {
                    DayId = shcedule.DayId,
                    KodeHari = shcedule.KodeHari,
                    NamaHari = shcedule.NamaHari
                };
                return shceduleDetail;
            }
            return null;
        }

        public async Task<Day> GetDayByIdNoTracking(Guid Id)
        {
            return await _context.Days.AsNoTracking().FirstOrDefaultAsync(a => a.DayId == Id);
        }

        public async Task<List<Day>> GetDays()
        {
            return await _context.Days.OrderBy(p => p.DayId).Select(shcedule => new Day()
            {
                DayId = shcedule.DayId,
                KodeHari = shcedule.KodeHari,
                NamaHari = shcedule.NamaHari
            }).ToListAsync();
        }

        public IEnumerable<Day> GetAllDay()
        {
            return _context.Days.AsNoTracking();
        }

        public Day Update(Day update)
        {
            var shcedule = _context.Days.Attach(update);
            shcedule.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return update;
        }

        public Day Delete(Guid Id)
        {
            var shcedule = _context.Days.Find(Id);
            if (shcedule != null)
            {
                _context.Days.Remove(shcedule);
                _context.SaveChanges();
            }
            return shcedule;
        }
    }
}
