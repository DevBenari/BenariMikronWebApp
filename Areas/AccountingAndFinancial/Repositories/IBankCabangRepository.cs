using BenariMikronWebApp.Areas.AccountingAndFinancial.Models;
using BenariMikronWebApp.Areas.Administration.Models;
using BenariMikronWebApp.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace BenariMikronWebApp.Areas.AccountingAndFinancial.Repositories
{
    public class IBankCabangRepository
    {
        private readonly ApplicationDbContext _context;

        public IBankCabangRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public BankCabang Add(BankCabang bank)
        {
            _context.BankCabangs.Add(bank);
            _context.SaveChanges();
            return bank;
        }

        public BankCabang Update(BankCabang bankChanges)
        {
            var bank = _context.BankCabangs.Attach(bankChanges);
            bank.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return bankChanges;
        }

        public BankCabang Delete(Guid Id)
        {
            var bankCabang = _context.BankCabangs.Find(Id);
            if (bankCabang != null)
            {
                _context.BankCabangs.Remove(bankCabang);
                _context.SaveChanges();
            }
            return bankCabang;
        }

        public IEnumerable<BankCabang> GetAllBankCabang()
        {
            return _context.BankCabangs
                .Include(b => b.Bank)
                .AsNoTracking();
        }

        public async Task<List<BankCabang>> GetBankCabangs()
        {
            return await _context.BankCabangs.OrderBy(p => p.NamaCabang).Select(x => new BankCabang()
            {
                BankCabangId = x.BankCabangId,
                KodeBankCabang = x.KodeBankCabang,
                NamaCabang = x.NamaCabang
            }).ToListAsync();
        }
    }
}
