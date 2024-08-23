using BenariMikronWebApp.Areas.Administration.Models;
using BenariMikronWebApp.Areas.HealthManagement.Models;
using BenariMikronWebApp.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace BenariMikronWebApp.Areas.HealthManagement.Repositories
{    
    public class IDoctorDepartmentLocationRepository
    {
        private readonly ApplicationDbContext _context;

        public IDoctorDepartmentLocationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DoctorDepartmentLocation Tambah(DoctorDepartmentLocation lokasi)
        {
            _context.DepartmentLocations.Add(lokasi);
            _context.SaveChanges();
            return lokasi;
        }

        public async Task<DoctorDepartmentLocation> GetDepartmentLocationById(Guid Id)
        {
            var lokasi = await _context.DepartmentLocations.FindAsync(Id);

            if (lokasi == null)
            {
                var lokasiDetail = new DoctorDepartmentLocation()
                {
                    LocationId = lokasi.LocationId,
                    KodeLokasi = lokasi.KodeLokasi,
                    NamaLokasi = lokasi.NamaLokasi,
                    Keterangan = lokasi.Keterangan                    
                };
                return lokasiDetail;
            }
            return null;
        }

        public async Task<DoctorDepartmentLocation> GetDepartmentLocationByIdNoTracking(Guid Id)
        {
            return await _context.DepartmentLocations.AsNoTracking().FirstOrDefaultAsync(a => a.LocationId == Id);
        }

        public async Task<List<DoctorDepartmentLocation>> GetDepartmentLocations()
        {
            return await _context.DepartmentLocations.OrderBy(p => p.NamaLokasi).Select(lokasi => new DoctorDepartmentLocation()
            {
                LocationId = lokasi.LocationId,
                KodeLokasi = lokasi.KodeLokasi,
                NamaLokasi = lokasi.NamaLokasi,
                Keterangan = lokasi.Keterangan
            }).ToListAsync();
        }

        public IEnumerable<DoctorDepartmentLocation> GetAllDepartmentLocation()
        {
            return _context.DepartmentLocations.AsNoTracking();
        }

        public DoctorDepartmentLocation Update(DoctorDepartmentLocation update)
        {
            var lokasi = _context.DepartmentLocations.Attach(update);
            lokasi.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return update;
        }

        public DoctorDepartmentLocation Delete(Guid Id)
        {
            var lokasi = _context.DepartmentLocations.Find(Id);
            if (lokasi != null)
            {
                _context.DepartmentLocations.Remove(lokasi);
                _context.SaveChanges();
            }
            return lokasi;
        }
    }
}
