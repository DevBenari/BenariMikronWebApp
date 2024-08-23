using BenariMikronWebApp.Areas.HealthManagement.Models;
using BenariMikronWebApp.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace BenariMikronWebApp.Areas.HealthManagement.Repositories
{
    public class IDoctorQueueTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public IDoctorQueueTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DoctorQueueType Tambah(DoctorQueueType type)
        {
            _context.DoctorQueueTypes.Add(type);
            _context.SaveChanges();
            return type;
        }

        public async Task<DoctorQueueType> GetDoctorQueueTypeById(Guid Id)
        {
            var dokter = await _context.DoctorQueueTypes.FindAsync(Id);

            if (dokter == null)
            {
                var dokterDetail = new DoctorQueueType()
                {
                    DoctorQueueTypeId = dokter.DoctorQueueTypeId,
                    KodeTipeAntrian = dokter.KodeTipeAntrian,
                    NamaTipeAntrian = dokter.NamaTipeAntrian
                };
                return dokterDetail;
            }
            return null;
        }

        public async Task<DoctorQueueType> GetDoctorQueueTypeByIdNoTracking(Guid Id)
        {
            return await _context.DoctorQueueTypes.AsNoTracking().FirstOrDefaultAsync(a => a.DoctorQueueTypeId == Id);
        }

        public async Task<List<DoctorQueueType>> GetDoctorQueueTypes()
        {
            return await _context.DoctorQueueTypes.OrderBy(p => p.NamaTipeAntrian).Select(dokter => new DoctorQueueType()
            {
                DoctorQueueTypeId = dokter.DoctorQueueTypeId,
                KodeTipeAntrian = dokter.KodeTipeAntrian,
                NamaTipeAntrian = dokter.NamaTipeAntrian
            }).ToListAsync();
        }

        public IEnumerable<DoctorQueueType> GetAllDoctorQueueType()
        {
            return _context.DoctorQueueTypes.AsNoTracking();
        }

        public DoctorQueueType Update(DoctorQueueType update)
        {
            var dokter = _context.DoctorQueueTypes.Attach(update);
            dokter.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return update;
        }

        public DoctorQueueType Delete(Guid Id)
        {
            var dokter = _context.DoctorQueueTypes.Find(Id);
            if (dokter != null)
            {
                _context.DoctorQueueTypes.Remove(dokter);
                _context.SaveChanges();
            }
            return dokter;
        }
    }
}
