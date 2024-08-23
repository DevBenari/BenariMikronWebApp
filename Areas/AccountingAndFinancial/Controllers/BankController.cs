using BenariMikronWebApp.Areas.AccountingAndFinancial.Models;
using BenariMikronWebApp.Areas.AccountingAndFinancial.Repositories;
using BenariMikronWebApp.Areas.AccountingAndFinancial.ViewModels;
using BenariMikronWebApp.Areas.Administration.Models;
using BenariMikronWebApp.Areas.Administration.Repositories;
using BenariMikronWebApp.Areas.Administration.ViewModels;
using BenariMikronWebApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;

namespace BenariMikronWebApp.Areas.AccountingAndFinancial.Controllers
{
    [Area("AccountingAndFinancial")]
    [Route("AccountingAndFinancial/[Controller]/[Action]")]
    public class BankController : Controller
    {
        private readonly IBankRepository _bankRepository;

        public BankController(
            IBankRepository bankRepository
        )
        {
            _bankRepository = bankRepository;
        }
        
        public IActionResult Index()
        {
            var tampilkanData = _bankRepository.GetAllBank();
            return View(tampilkanData);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ViewResult> CreateBank()
        {
            var bank = new CreateBankViewModel();
            var dateNow = DateTimeOffset.Now;
            var lastCodebank = _bankRepository.GetAllBank().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeBank).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            if (lastCodebank == null)
            {
                bank.KodeBank = "BNK" + setDateNow + "0001";
            }
            else
            {
                var lastDateEdu = lastCodebank.KodeBank.Substring(3, 6);

                if (lastDateEdu != setDateNow)
                {
                    bank.KodeBank = "BNK" + setDateNow + "0001";
                }
                else
                {
                    bank.KodeBank = "BNK" + setDateNow + (Convert.ToInt32(lastCodebank.KodeBank.Substring(9, lastCodebank.KodeBank.Length - 9)) + 1).ToString("D4");
                }
            }
            return View(bank);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateBank(CreateBankViewModel model)
        {
            var dateNow = DateTimeOffset.Now;
            var lastBank = _bankRepository.GetAllBank().Where(d => d.CreateDateTime.ToString("yyMMdd") == dateNow.ToString("yyMMdd")).OrderByDescending(c => c.KodeBank).FirstOrDefault();
            var setDateNow = DateTimeOffset.Now.ToString("yyMMdd");

            if (lastBank == null)
            {
                model.KodeBank = "BNK" + setDateNow + "0001";
            }
            else
            {
                var lastDateBank = lastBank.KodeBank.Substring(3, 6);

                if (lastDateBank != setDateNow)
                {
                    model.KodeBank = "BNK" + setDateNow + "0001";
                }
                else
                {
                    model.KodeBank = "BNK" + setDateNow + (Convert.ToInt32(lastBank.KodeBank.Substring(9, lastBank.KodeBank.Length - 9)) + 1).ToString("D4");
                }
            }

            if (ModelState.IsValid)
            {
                var newBank = new Bank
                {
                    CreateDateTime = DateTimeOffset.Now,
                    BankId = model.BankId,
                    KodeBank = model.KodeBank,
                    NamaBank = model.NamaBank
                };

                var result = _bankRepository.GetAllBank().Where(c => c.NamaBank == model.NamaBank).FirstOrDefault();

                if (result == null)
                {
                    _bankRepository.Add(newBank);
                    TempData["SuccessMessage"] = "Bank " + model.NamaBank + " Berhasil Disimpan";
                    return RedirectToAction("Index", "Bank");
                }
                else
                {
                    ModelState.AddModelError("", "Maaf, Nama Bank sudah ada !!!");
                    return View(model);
                }
            }
            return View();
        }        
    }
}
