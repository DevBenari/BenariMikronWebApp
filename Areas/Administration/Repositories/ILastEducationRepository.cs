using BenariMikronWebApp.Areas.Administration.Models;
using BenariMikronWebApp.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace BenariMikronWebApp.Areas.Administration.Repositories
{
    public class ILastEducationRepository
    {
        private readonly ApplicationDbContext _context;

        public ILastEducationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public LastEducation Tambah(LastEducation type)
        {
            _context.LastEducations.Add(type);
            _context.SaveChanges();
            return type;
        }

        public async Task<LastEducation> GetLastEducationById(Guid Id)
        {
            var education = await _context.LastEducations.FindAsync(Id);

            if (education == null)
            {
                var educationDetail = new LastEducation()
                {
                    LastEducationId = education.LastEducationId,
                    KodePendidikanTerakhir = education.KodePendidikanTerakhir,
                    NamaPendidikanTerakhir = education.NamaPendidikanTerakhir
                };
                return educationDetail;
            }
            return null;
        }

        public async Task<LastEducation> GetLastEducationByIdNoTracking(Guid Id)
        {
            return await _context.LastEducations.AsNoTracking().FirstOrDefaultAsync(a => a.LastEducationId == Id);
        }

        public async Task<List<LastEducation>> GetLastEducations()
        {
            return await _context.LastEducations.OrderBy(p => p.NamaPendidikanTerakhir).Select(education => new LastEducation()
            {
                LastEducationId = education.LastEducationId,
                KodePendidikanTerakhir = education.KodePendidikanTerakhir,
                NamaPendidikanTerakhir = education.NamaPendidikanTerakhir
            }).ToListAsync();
        }

        public IEnumerable<LastEducation> GetAllLastEducation()
        {
            return _context.LastEducations.AsNoTracking();
        }

        public LastEducation Update(LastEducation update)
        {
            var education = _context.LastEducations.Attach(update);
            education.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return update;
        }

        public LastEducation Delete(Guid Id)
        {
            var education = _context.LastEducations.Find(Id);
            if (education != null)
            {
                _context.LastEducations.Remove(education);
                _context.SaveChanges();
            }
            return education;
        }
    }
}
