using BenariMikronWebApp.Areas.Administration.Models;
using BenariMikronWebApp.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace BenariMikronWebApp.Areas.Administration.Repositories
{
    public class IReligionRepository
    {
        private readonly ApplicationDbContext _context;

        public IReligionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Religion Tambah(Religion type)
        {
            _context.Religions.Add(type);
            _context.SaveChanges();
            return type;
        }

        public async Task<Religion> GetReligionById(Guid Id)
        {
            var education = await _context.Religions.FindAsync(Id);

            if (education == null)
            {
                var educationDetail = new Religion()
                {
                    ReligionId = education.ReligionId,
                    KodeAgama = education.KodeAgama,
                    NamaAgama = education.NamaAgama
                };
                return educationDetail;
            }
            return null;
        }

        public async Task<Religion> GetReligionByIdNoTracking(Guid Id)
        {
            return await _context.Religions.AsNoTracking().FirstOrDefaultAsync(a => a.ReligionId == Id);
        }

        public async Task<List<Religion>> GetReligions()
        {
            return await _context.Religions.OrderBy(p => p.NamaAgama).Select(education => new Religion()
            {
                ReligionId = education.ReligionId,
                KodeAgama = education.KodeAgama,
                NamaAgama = education.NamaAgama
            }).ToListAsync();
        }

        public IEnumerable<Religion> GetAllReligion()
        {
            return _context.Religions.AsNoTracking();
        }

        public Religion Update(Religion update)
        {
            var education = _context.Religions.Attach(update);
            education.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return update;
        }

        public Religion Delete(Guid Id)
        {
            var education = _context.Religions.Find(Id);
            if (education != null)
            {
                _context.Religions.Remove(education);
                _context.SaveChanges();
            }
            return education;
        }
    }
}
