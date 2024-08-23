using BenariMikronWebApp.Areas.HealthManagement.Models;
using BenariMikronWebApp.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace BenariMikronWebApp.Areas.HealthManagement.Repositories
{
    public class IDoctorDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public IDoctorDepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DoctorDepartment Tambah(DoctorDepartment lokasi)
        {
            _context.DoctorDepartments.Add(lokasi);
            _context.SaveChanges();
            return lokasi;
        }

        public async Task<DoctorDepartment> GetDoctorDepartmentById(Guid Id)
        {
            var dokter = await _context.DoctorDepartments.FindAsync(Id);

            if (dokter == null)
            {
                var dokterDetail = new DoctorDepartment()
                {
                    DepartmentId = dokter.DepartmentId,
                    KodeDepartemen = dokter.KodeDepartemen,
                    NamaDepartemen = dokter.NamaDepartemen,
                    LocationId = dokter.LocationId,
                    Telepon = dokter.Telepon,
                    MulaiJamKerja = dokter.MulaiJamKerja,
                    SelesaiJamKerja = dokter.SelesaiJamKerja,
                    Keterangan = dokter.Keterangan
                };
                return dokterDetail;
            }
            return null;
        }

        public async Task<DoctorDepartment> GetDoctorDepartmentByIdNoTracking(Guid Id)
        {
            return await _context.DoctorDepartments.AsNoTracking().FirstOrDefaultAsync(a => a.DepartmentId == Id);
        }

        public async Task<List<DoctorDepartment>> GetDoctorDepartments()
        {
            return await _context.DoctorDepartments.OrderBy(p => p.NamaDepartemen).Select(dokter => new DoctorDepartment()
            {
                DepartmentId = dokter.DepartmentId,
                KodeDepartemen = dokter.KodeDepartemen,
                NamaDepartemen = dokter.NamaDepartemen,
                LocationId = dokter.LocationId,
                Telepon = dokter.Telepon,
                MulaiJamKerja = dokter.MulaiJamKerja,
                SelesaiJamKerja = dokter.SelesaiJamKerja,
                Keterangan = dokter.Keterangan
            }).ToListAsync();
        }

        public IEnumerable<DoctorDepartment> GetAllDoctorDepartment()
        {
            return _context.DoctorDepartments
                .Include(l => l.DepartmentLocation)
                .AsNoTracking();
        }

        public DoctorDepartment Update(DoctorDepartment update)
        {
            var dokter = _context.DoctorDepartments.Attach(update);
            dokter.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return update;
        }

        public DoctorDepartment Delete(Guid Id)
        {
            var dokter = _context.DoctorDepartments.Find(Id);
            if (dokter != null)
            {
                _context.DoctorDepartments.Remove(dokter);
                _context.SaveChanges();
            }
            return dokter;
        }
    }
}
