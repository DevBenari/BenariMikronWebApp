using BenariMikronWebApp.Areas.HealthManagement.Models;
using BenariMikronWebApp.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace BenariMikronWebApp.Areas.HealthManagement.Repositories
{
    public class IScheduleTodayRepository
    {
        private readonly ApplicationDbContext _context;

        public IScheduleTodayRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ScheduleToday Tambah(ScheduleToday type)
        {
            _context.ScheduleTodays.Add(type);
            _context.SaveChanges();
            return type;
        }

        public async Task<ScheduleToday> GetScheduleTodayById(Guid Id)
        {
            var shcedule = await _context.ScheduleTodays.FindAsync(Id);

            if (shcedule == null)
            {
                var shceduleDetail = new ScheduleToday()
                {
                    ScheduleTodayId = shcedule.ScheduleTodayId,
                    KodeJadwal = shcedule.KodeJadwal,
                    DoctorId = shcedule.DoctorId,
                    Doctor = shcedule.Doctor,
                    DepartmentId = shcedule.DepartmentId,
                    DoctorDepartment = shcedule.DoctorDepartment,
                    DayId = shcedule.DayId,
                    Day = shcedule.Day,
                    TanggalPraktek = shcedule.TanggalPraktek,
                    JamMulai = shcedule.JamMulai,
                    JamSelesai = shcedule.JamSelesai,
                    LamaPeriksaPerPasien = shcedule.LamaPeriksaPerPasien,
                    PagiSore = shcedule.PagiSore,
                    Ruangan = shcedule.Ruangan,
                };
                return shceduleDetail;
            }
            return null;
        }

        public async Task<ScheduleToday> GetScheduleTodayByIdNoTracking(Guid Id)
        {
            return await _context.ScheduleTodays.AsNoTracking().FirstOrDefaultAsync(a => a.ScheduleTodayId == Id);
        }

        public async Task<List<ScheduleToday>> GetScheduleTodays()
        {
            return await _context.ScheduleTodays.OrderBy(p => p.ScheduleTodayId).Select(shcedule => new ScheduleToday()
            {
                ScheduleTodayId = shcedule.ScheduleTodayId,
                KodeJadwal = shcedule.KodeJadwal,
                DoctorId = shcedule.DoctorId,
                Doctor = shcedule.Doctor,
                DepartmentId = shcedule.DepartmentId,
                DoctorDepartment = shcedule.DoctorDepartment,
                DayId = shcedule.DayId,
                Day = shcedule.Day,
                TanggalPraktek = shcedule.TanggalPraktek,
                JamMulai = shcedule.JamMulai,
                JamSelesai = shcedule.JamSelesai,
                LamaPeriksaPerPasien = shcedule.LamaPeriksaPerPasien,
                PagiSore = shcedule.PagiSore,
                Ruangan = shcedule.Ruangan,
            }).ToListAsync();
        }

        public IEnumerable<ScheduleToday> GetAllScheduleToday()
        {
            return _context.ScheduleTodays
                .Include(d => d.Doctor)
                .Include(y => y.Day)
                .Include(p => p.DoctorDepartment)
                .AsNoTracking();
        }

        public ScheduleToday Update(ScheduleToday update)
        {
            var shcedule = _context.ScheduleTodays.Attach(update);
            shcedule.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return update;
        }

        public ScheduleToday Delete(Guid Id)
        {
            var shcedule = _context.ScheduleTodays.Find(Id);
            if (shcedule != null)
            {
                _context.ScheduleTodays.Remove(shcedule);
                _context.SaveChanges();
            }
            return shcedule;
        }
    }
}
