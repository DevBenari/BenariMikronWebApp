using BenariMikronWebApp.Areas.Administration.Models;
using BenariMikronWebApp.Areas.Identity.Data;
using BenariMikronWebApp.Areas.PatientRegistration.Models;
using Microsoft.EntityFrameworkCore;

namespace BenariMikronWebApp.Areas.Administration.Repositories
{
    public class ICountryRepository
    {
        private readonly ApplicationDbContext _context;

        public ICountryRepository(ApplicationDbContext context)
        { 
            _context = context;
        }

        public Country Add(Country country) 
        { 
            _context.Countries.Add(country);
            _context.SaveChanges();
            return country;
        }

        public Country Update(Country CountryChanges)
        {
            var Country = _context.Countries.Attach(CountryChanges);
            Country.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return CountryChanges;
        }

        public Country Delete(Guid Id)
        {
            var country = _context.Countries.Find(Id);
            if (country != null)
            {
                _context.Countries.Remove(country);
                _context.SaveChanges();
            }
            return country;
        }

        public IEnumerable<Country> GetAllCountry()
        {
            return _context.Countries
                .Include(prov => prov.Province)                
                .AsNoTracking();
        }       

        public async Task<List<Country>> GetCountries()
        {
            return await _context.Countries.OrderBy(p => p.NamaNegara).Select(x => new Country()
            {
                CountryId = x.CountryId,
                KodeNegara = x.KodeNegara,
                NamaNegara = x.NamaNegara
            }).ToListAsync();
        }        
    }
}
