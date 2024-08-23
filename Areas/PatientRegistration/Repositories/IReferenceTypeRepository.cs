using BenariMikronWebApp.Areas.Identity.Data;
using BenariMikronWebApp.Areas.PatientRegistration.Models;
using Microsoft.EntityFrameworkCore;

namespace BenariMikronWebApp.Areas.PatientRegistration.Repositories
{
    public class IReferenceTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public IReferenceTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ReferenceType Tambah(ReferenceType rujukan)
        {
            _context.ReferenceTypes.Add(rujukan);
            _context.SaveChanges();
            return rujukan;
        }

        public async Task<ReferenceType> GetReferenceTypeById(Guid Id)
        {
            var rujukan = await _context.ReferenceTypes.FindAsync(Id);

            if (rujukan == null)
            {
                var rujukanDetail = new ReferenceType()
                {
                    ReferenceTypeId = rujukan.ReferenceTypeId,
                    KodeTipeRujukan = rujukan.KodeTipeRujukan,
                    NamaTipeRujukan = rujukan.NamaTipeRujukan,
                    ReferenceId = rujukan.ReferenceId
                };
                return rujukanDetail;
            }
            return null;
        }

        public async Task<ReferenceType> GetReferenceTypeByIdNoTracking(Guid Id)
        {
            return await _context.ReferenceTypes.AsNoTracking().FirstOrDefaultAsync(a => a.ReferenceTypeId == Id);
        }

        public async Task<List<ReferenceType>> GetReferenceTypes()
        {
            return await _context.ReferenceTypes.OrderBy(p => p.NamaTipeRujukan).Select(rujukan => new ReferenceType()
            {
                ReferenceTypeId = rujukan.ReferenceTypeId,
                KodeTipeRujukan = rujukan.KodeTipeRujukan,
                NamaTipeRujukan = rujukan.NamaTipeRujukan,
                ReferenceId = rujukan.ReferenceId
            }).ToListAsync();
        }

        public IEnumerable<ReferenceType> GetAllReferenceType()
        {
            return _context.ReferenceTypes
                .Include(a => a.Reference)
                .AsNoTracking();
        }

        public ReferenceType Update(ReferenceType update)
        {
            var rujukan = _context.ReferenceTypes.Attach(update);
            rujukan.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return update;
        }

        public ReferenceType Delete(Guid Id)
        {
            var rujukan = _context.ReferenceTypes.Find(Id);
            if (rujukan != null)
            {
                _context.ReferenceTypes.Remove(rujukan);
                _context.SaveChanges();
            }
            return rujukan;
        }
    }
}
