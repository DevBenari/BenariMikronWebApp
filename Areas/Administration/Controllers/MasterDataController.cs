using BenariMikronWebApp.Areas.Administration.Models;
using BenariMikronWebApp.Areas.Administration.Repositories;
using BenariMikronWebApp.Areas.Administration.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;

namespace BenariMikronWebApp.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Route("Administration/[Controller]/[Action]")]
    public class MasterDataController : Controller
    {
        //private readonly ICountryRepository _countryRepository;
        //private readonly IProvinceRepository _provinceRepository;
        //private readonly ICityRepository _cityRepository;
        //private readonly IDistrictRepository _districtRepository;
        //private readonly ISubDistrictRepository _subDistrictRepository;

        public MasterDataController(
            //ICountryRepository countryRepository, 
            //IProvinceRepository provinceRepository,
            //ICityRepository cityRepository,
            //IDistrictRepository districtRepository,
            //ISubDistrictRepository subDistrictRepository
        )
        {
            //_countryRepository = countryRepository;
            //_provinceRepository = provinceRepository;
            //_cityRepository = cityRepository;
            //_districtRepository = districtRepository;
            //_subDistrictRepository = subDistrictRepository;
        }

        public IActionResult Index()
        {
            return View();
        }        
    }
}
