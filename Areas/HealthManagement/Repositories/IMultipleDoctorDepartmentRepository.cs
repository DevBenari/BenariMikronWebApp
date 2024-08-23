using BenariMikronWebApp.Areas.HealthManagement.Models;
using BenariMikronWebApp.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace BenariMikronWebApp.Areas.HealthManagement.Repositories
{
    public class IMultipleDoctorDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public IMultipleDoctorDepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public MultipleDoctorDepartment Tambah(MultipleDoctorDepartment multiple)
        {
            _context.MultipleDoctorDepartments.Add(multiple);
            _context.SaveChanges();
            return multiple;
        }

        public async Task<MultipleDoctorDepartment> GetMultipleDoctorDepartmentById(Guid Id)
        {
            var multiple = await _context.MultipleDoctorDepartments.FindAsync(Id);

            if (multiple == null)
            {
                var multipleDetail = new MultipleDoctorDepartment()
                {
                    MultipleDoctorDepartmentId = multiple.MultipleDoctorDepartmentId,
                    DoctorId = multiple.DoctorId,
                    DoctorDepartmentId = multiple.DoctorDepartmentId
                };
                return multipleDetail;
            }
            return null;
        }

        public async Task<MultipleDoctorDepartment> GetMultipleDoctorDepartmentByIdNoTracking(Guid Id)
        {
            return await _context.MultipleDoctorDepartments.AsNoTracking().FirstOrDefaultAsync(a => a.MultipleDoctorDepartmentId == Id);
        }

        public async Task<List<MultipleDoctorDepartment>> GetMultipleDoctorDepartments()
        {
            return await _context.MultipleDoctorDepartments.OrderBy(p => p.MultipleDoctorDepartmentId).Select(multiple => new MultipleDoctorDepartment()
            {
                MultipleDoctorDepartmentId = multiple.MultipleDoctorDepartmentId,
                DoctorId = multiple.DoctorId,
                DoctorDepartmentId = multiple.DoctorDepartmentId
            }).ToListAsync();
        }

        public IEnumerable<MultipleDoctorDepartment> GetAllMultipleDoctorDepartment()
        {
            return _context.MultipleDoctorDepartments.AsNoTracking();
        }

        public MultipleDoctorDepartment Update(MultipleDoctorDepartment update)
        {
            var multiple = _context.MultipleDoctorDepartments.Attach(update);
            multiple.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return update;
        }

        public MultipleDoctorDepartment Delete(Guid Id)
        {
            var multiple = _context.MultipleDoctorDepartments.Find(Id);
            if (multiple != null)
            {
                _context.MultipleDoctorDepartments.Remove(multiple);
                _context.SaveChanges();
            }
            return multiple;
        }
    }
}
