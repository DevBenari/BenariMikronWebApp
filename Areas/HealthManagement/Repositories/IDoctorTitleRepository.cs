using BenariMikronWebApp.Areas.HealthManagement.Models;
using BenariMikronWebApp.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace BenariMikronWebApp.Areas.HealthManagement.Repositories
{
    public class IDoctorTitleRepository
    {
        private readonly ApplicationDbContext _context;

        public IDoctorTitleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DoctorTitle Tambah(DoctorTitle type)
        {
            _context.DoctorTitles.Add(type);
            _context.SaveChanges();
            return type;
        }

        public async Task<DoctorTitle> GetDoctorTitleById(Guid Id)
        {
            var dokter = await _context.DoctorTitles.FindAsync(Id);

            if (dokter == null)
            {
                var dokterDetail = new DoctorTitle()
                {
                    DoctorTitleId = dokter.DoctorTitleId,
                    KodeGelar = dokter.KodeGelar,
                    NamaGelar = dokter.NamaGelar,
                    Deskripsi = dokter.Deskripsi,
                    LapRL1 = dokter.LapRL1,
                    LapRL2 = dokter.LapRL2,
                    Status = dokter.Status
                };
                return dokterDetail;
            }
            return null;
        }

        public async Task<DoctorTitle> GetDoctorTitleByIdNoTracking(Guid Id)
        {
            return await _context.DoctorTitles.AsNoTracking().FirstOrDefaultAsync(a => a.DoctorTitleId == Id);
        }

        public async Task<List<DoctorTitle>> GetDoctorTitles()
        {
            return await _context.DoctorTitles.OrderBy(p => p.NamaGelar).Select(dokter => new DoctorTitle()
            {
                DoctorTitleId = dokter.DoctorTitleId,
                KodeGelar = dokter.KodeGelar,
                NamaGelar = dokter.NamaGelar,
                Deskripsi = dokter.Deskripsi,
                LapRL1 = dokter.LapRL1,
                LapRL2 = dokter.LapRL2,                
                Status = dokter.Status
            }).ToListAsync();
        }

        public IEnumerable<DoctorTitle> GetAllDoctorTitle()
        {
            return _context.DoctorTitles.AsNoTracking();
        }

        public DoctorTitle Update(DoctorTitle update)
        {
            var dokter = _context.DoctorTitles.Attach(update);
            dokter.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return update;
        }

        public DoctorTitle Delete(Guid Id)
        {
            var dokter = _context.DoctorTitles.Find(Id);
            if (dokter != null)
            {
                _context.DoctorTitles.Remove(dokter);
                _context.SaveChanges();
            }
            return dokter;
        }
    }
}
