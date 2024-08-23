using BenariMikronWebApp.Areas.Administration.Models;
using BenariMikronWebApp.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace BenariMikronWebApp.Areas.Administration.Repositories
{
    public class IDistrictRepository
    {
        private readonly ApplicationDbContext _context;

        public IDistrictRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public District Add(District district)
        {
            _context.Districts.Add(district);
            _context.SaveChanges();
            return district;
        }

        public District Update(District districtChanges)
        {
            var District = _context.Districts.Attach(districtChanges);
            District.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return districtChanges;
        }

        public District Delete(Guid Id)
        {
            var district = _context.Districts.Find(Id);
            if (district != null)
            {
                _context.Districts.Remove(district);
                _context.SaveChanges();
            }
            return district;
        }

        public IEnumerable<District> GetAllDistrict()
        {
            return _context.Districts
                .Include(c => c.Country)
                .Include(p => p.Province)
                .Include(p => p.City)
                .AsNoTracking();
        }

        public async Task<List<District>> GetDistricts()
        {
            return await _context.Districts.OrderBy(p => p.NamaKecamatan).Select(x => new District()
            {
                DistrictId = x.DistrictId,
                KodeKecamatan = x.KodeKecamatan,
                NamaKecamatan = x.NamaKecamatan,
                CityId = x.CityId,
                ProvinceId = x.ProvinceId,
                CountryId = x.CountryId
            }).ToListAsync();
        }
    }
}
