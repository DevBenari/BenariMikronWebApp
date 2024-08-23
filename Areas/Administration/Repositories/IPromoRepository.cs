using BenariMikronWebApp.Areas.Administration.Models;
using BenariMikronWebApp.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace BenariMikronWebApp.Areas.Administration.Repositories
{
    public class IPromoRepository
    {
        private readonly ApplicationDbContext _context;

        public IPromoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Promo Tambah(Promo promo)
        {
            _context.Promos.Add(promo);
            _context.SaveChanges();
            return promo;
        }

        public async Task<Promo> GetPromoById(Guid Id)
        {
            var promo = await _context.Promos.FindAsync(Id);

            if (promo == null)
            {
                var promoDetail = new Promo()
                {
                    PromoId = promo.PromoId,
                    KodePromo = promo.KodePromo,
                    NamaPromo = promo.NamaPromo,
                    Keterangan = promo.Keterangan
                };
                return promoDetail;
            }
            return null;
        }

        public async Task<Promo> GetPromoByIdNoTracking(Guid Id)
        {
            return await _context.Promos.AsNoTracking().FirstOrDefaultAsync(a => a.PromoId == Id);
        }

        public async Task<List<Promo>> GetPromos()
        {
            return await _context.Promos.OrderBy(p => p.NamaPromo).Select(promo => new Promo()
            {
                PromoId = promo.PromoId,
                KodePromo = promo.KodePromo,
                NamaPromo = promo.NamaPromo,
                Keterangan = promo.Keterangan
            }).ToListAsync();
        }

        public IEnumerable<Promo> GetAllPromo()
        {
            return _context.Promos.AsNoTracking();
        }

        public Promo Update(Promo update)
        {
            var Promo = _context.Promos.Attach(update);
            Promo.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return update;
        }

        public Promo Delete(Guid Id)
        {
            var promo = _context.Promos.Find(Id);
            if (promo != null)
            {
                _context.Promos.Remove(promo);
                _context.SaveChanges();
            }
            return promo;
        }
    }
}
