using BenariMikronWebApp.Areas.Identity.Data;
using BenariMikronWebApp.Areas.PatientRegistration.Models;
using Microsoft.EntityFrameworkCore;

namespace BenariMikronWebApp.Areas.PatientRegistration.Repositories
{
    public class IReferenceRepository
    {
        private readonly ApplicationDbContext _context;

        public IReferenceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Reference Tambah(Reference rujukan)
        {
            _context.References.Add(rujukan);
            _context.SaveChanges();
            return rujukan;
        }

        public async Task<Reference> GetReferenceById(Guid Id)
        {
            var rujukan = await _context.References.FindAsync(Id);

            if (rujukan == null)
            {
                var rujukanDetail = new Reference()
                {
                    ReferenceId = rujukan.ReferenceId,
                    KodeRujukan = rujukan.KodeRujukan,
                    NamaRujukan = rujukan.NamaRujukan
                };
                return rujukanDetail;
            }
            return null;
        }

        public async Task<Reference> GetReferenceByIdNoTracking(Guid Id)
        {
            return await _context.References.AsNoTracking().FirstOrDefaultAsync(a => a.ReferenceId == Id);
        }

        public async Task<List<Reference>> GetReferences()
        {
            return await _context.References.OrderBy(p => p.NamaRujukan).Select(rujukan => new Reference()
            {
                ReferenceId = rujukan.ReferenceId,
                KodeRujukan = rujukan.KodeRujukan,
                NamaRujukan = rujukan.NamaRujukan
            }).ToListAsync();
        }

        public IEnumerable<Reference> GetAllReference()
        {
            return _context.References.AsNoTracking();
        }

        public Reference Update(Reference update)
        {
            var rujukan = _context.References.Attach(update);
            rujukan.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return update;
        }

        public Reference Delete(Guid Id)
        {
            var rujukan = _context.References.Find(Id);
            if (rujukan != null)
            {
                _context.References.Remove(rujukan);
                _context.SaveChanges();
            }
            return rujukan;
        }
    }
}
