using BenariMikronWebApp.Areas.Administration.Models;
using BenariMikronWebApp.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace BenariMikronWebApp.Areas.Administration.Repositories
{
    public class ISubDistrictRepository
    {
        private readonly ApplicationDbContext _context;

        public ISubDistrictRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public SubDistrict Add(SubDistrict subDistrict)
        {
            _context.SubDistricts.Add(subDistrict);
            _context.SaveChanges();
            return subDistrict;
        }

        public SubDistrict Update(SubDistrict subDistrictChanges)
        {
            var SubDistrict = _context.SubDistricts.Attach(subDistrictChanges);
            SubDistrict.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return subDistrictChanges;
        }

        public SubDistrict Delete(Guid Id)
        {
            var subDistrict = _context.SubDistricts.Find(Id);
            if (subDistrict != null)
            {
                _context.SubDistricts.Remove(subDistrict);
                _context.SaveChanges();
            }
            return subDistrict;
        }

        public async Task<List<SubDistrict>> GetSubDistricts()
        {
            return await _context.SubDistricts.OrderBy(p => p.NamaKelurahan).Select(x => new SubDistrict()
            {
                SubDistrictId = x.SubDistrictId,
                KodeKelurahan = x.KodeKelurahan,
                NamaKelurahan = x.NamaKelurahan,
                DistrictId = x.DistrictId,
                CityId = x.CityId,
                ProvinceId = x.ProvinceId,
                CountryId = x.CountryId
            }).ToListAsync();
        }

        public IEnumerable<SubDistrict> GetAllSubDistrict()
        {
            return _context.SubDistricts.AsNoTracking()
                .Include(c => c.Country)
                .Include(p => p.Province)
                .Include(ct => ct.City)
                .Include(d => d.District);
        }        
    }
}
