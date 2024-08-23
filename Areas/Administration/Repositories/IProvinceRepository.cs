using BenariMikronWebApp.Areas.Administration.Models;
using BenariMikronWebApp.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace BenariMikronWebApp.Areas.Administration.Repositories
{
    public class IProvinceRepository
    {
        private readonly ApplicationDbContext _context;

        public IProvinceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Province Add(Province province)
        {
            _context.Provinces.Add(province);
            _context.SaveChanges();
            return province;
        }

        public Province Update(Province provinceChanges)
        {
            var Province = _context.Provinces.Attach(provinceChanges);
            Province.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return provinceChanges;
        }

        public Province Delete(Guid Id)
        {
            var province = _context.Provinces.Find(Id);
            if (province != null)
            {
                _context.Provinces.Remove(province);
                _context.SaveChanges();
            }
            return province;
        }

        public IEnumerable<Province> GetAllProvince()
        {
            return _context.Provinces
                .Include(country => country.Country)
                .AsNoTracking();
        }

        public async Task<List<Province>> GetProvinces()
        {
            return await _context.Provinces.OrderBy(p => p.NamaProvinsi).Select(x => new Province()
            {
                ProvinceId = x.ProvinceId,
                KodeProvinsi = x.KodeProvinsi,
                NamaProvinsi = x.NamaProvinsi,
                CountryId = x.CountryId,
            }).ToListAsync();
        }        
    }
}
