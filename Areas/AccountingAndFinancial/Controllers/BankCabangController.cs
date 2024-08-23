using BenariMikronWebApp.Areas.AccountingAndFinancial.Models;
using BenariMikronWebApp.Areas.AccountingAndFinancial.Repositories;
using BenariMikronWebApp.Areas.AccountingAndFinancial.ViewModels;
using BenariMikronWebApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;

namespace BenariMikronWebApp.Areas.AccountingAndFinancial.Controllers
{
    [Area("AccountingAndFinancial")]
    [Route("AccountingAndFinancial/[Controller]/[Action]")]
    public class BankCabangController : Controller
    {
        private readonly IBankRepository _bankRepository;
        private readonly IBankCabangRepository _bankCabangRepository;
        public BankCabangController(
            IBankCabangRepository bankCabangRepository,
            IBankRepository bankRepository
        )
        {
            _bankCabangRepository = bankCabangRepository;
            _bankRepository = bankRepository;
        }
        public IActionResult Index()
        {
            var tampilkanData = _bankCabangRepository.GetAllBankCabang();
            return View(tampilkanData);
        }

        [HttpGet]
        public async Task<ViewResult> CreateBankCabang()
        {            
            var bank = new CreateBankCabangViewModel();
            var dateNow = DateTimeOffset.Now;
            var lastCodeBankCabang = _bankCabangRepository.GetAllBankCabang().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeBankCabang).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            ViewBag.Bank = new SelectList(await _bankRepository.GetBanks(), "BankId", "NamaBank", SortOrder.Ascending);

            if (lastCodeBankCabang == null)
            {
                bank.KodeBankCabang = "BCB" + setDateNow + "0001";
            }
            else
            {
                var lastDateEdu = lastCodeBankCabang.KodeBankCabang.Substring(3, 6);

                if (lastDateEdu != setDateNow)
                {
                    bank.KodeBankCabang = "BCB" + setDateNow + "0001";
                }
                else
                {
                    bank.KodeBankCabang = "BCB" + setDateNow + (Convert.ToInt32(lastCodeBankCabang.KodeBankCabang.Substring(9, lastCodeBankCabang.KodeBankCabang.Length - 9)) + 1).ToString("D4");
                }
            }
            return View(bank);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateBankCabang(CreateBankCabangViewModel model)
        {
            var dateNow = DateTimeOffset.Now;
            var lastBank = _bankCabangRepository.GetAllBankCabang().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeBankCabang).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            ViewBag.Bank = new SelectList(await _bankRepository.GetBanks(), "BankId", "NamaBank", SortOrder.Ascending);

            if (lastBank == null)
            {
                model.KodeBankCabang = "BNK" + setDateNow + "0001";
            }
            else
            {
                var lastDateBank = lastBank.KodeBankCabang.Substring(3, 6);

                if (lastDateBank != setDateNow)
                {
                    model.KodeBankCabang = "BNK" + setDateNow + "0001";
                }
                else
                {
                    model.KodeBankCabang = "BNK" + setDateNow + (Convert.ToInt32(lastBank.KodeBankCabang.Substring(9, lastBank.KodeBankCabang.Length - 9)) + 1).ToString("D4");
                }
            }

            if (ModelState.IsValid)
            {
                var newBankCabang = new BankCabang
                {
                    CreateDateTime = DateTimeOffset.Now,
                    BankCabangId = model.BankCabangId,
                    KodeBankCabang = model.KodeBankCabang,
                    NamaCabang = model.NamaCabang,
                    BankId = model.BankId
                };

                var result = _bankCabangRepository.GetAllBankCabang().Where(c => c.NamaCabang == model.NamaCabang).FirstOrDefault();

                if (result == null)
                {
                    _bankCabangRepository.Add(newBankCabang);
                    TempData["SuccessMessage"] = "Bank Cabang " + model.NamaCabang + " Berhasil Disimpan";
                    return RedirectToAction("Index", "BankCabang");
                }
                else
                {
                    ModelState.AddModelError("", "Maaf, Nama Bank Cabang sudah ada !!!");
                    ViewBag.Bank = new SelectList(await _bankRepository.GetBanks(), "BankId", "NamaBank", SortOrder.Ascending);
                    return View(model);
                }
            }
            ViewBag.Bank = new SelectList(await _bankRepository.GetBanks(), "BankId", "NamaBank", SortOrder.Ascending);
            return View();
        }
    }
}
