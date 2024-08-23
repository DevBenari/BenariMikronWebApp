using BenariMikronWebApp.Areas.Administration.Models;
using BenariMikronWebApp.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace BenariMikronWebApp.Areas.Administration.Repositories
{
    public class ICityRepository
    {
        private readonly ApplicationDbContext _context;

        public ICityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public City Add(City city)
        {
            _context.Cities.Add(city);
            _context.SaveChanges();
            return city;
        }

        public City Update(City cityChanges)
        {
            var City = _context.Cities.Attach(cityChanges);
            City.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return cityChanges;
        }

        public City Delete(Guid Id)
        {
            var city = _context.Cities.Find(Id);
            if (city != null)
            {
                _context.Cities.Remove(city);
                _context.SaveChanges();
            }
            return city;
        }

        public IEnumerable<City> GetAllCity()
        {
            return _context.Cities
                .Include(c => c.Country)
                .Include(p => p.Province)
                .AsNoTracking();
        }

        public async Task<List<City>> GetCities()
        {
            return await _context.Cities.OrderBy(p => p.NamaKota).Select(x => new City()
            {
                CityId = x.CityId,
                KodeKota = x.KodeKota,
                NamaKota = x.NamaKota,
                CountryId = x.CountryId,
                ProvinceId = x.ProvinceId
            }).ToListAsync();
        }
    }
}
