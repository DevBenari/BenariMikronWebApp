using BenariMikronWebApp.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace BenariMikronWebApp.Controllers
{
    public class RoleController : Controller
    {
        [Authorize(Policy = "EmployeeOnly")]
        public IActionResult Index()
        {
            return View();
        }

        //[Authorize(Policy = Constants.Policies.RequireAdmin)]
        //[Authorize(Roles = $"{Constants.Roles.Administrator}, {Constants.Roles.Manager}")]
        //[Authorize(Roles = $"{Constants.Roles.SuperAdmin}")]
        public IActionResult Manager()
        {
            return View();
        }

        //[Authorize(Policy = "RequireAdmin")]
        //[Authorize(Roles = $"{Constants.Roles.Administrator}")]        
        public IActionResult Admin()
        {
            return View();
        }

        //[Authorize(Policy = "RequireAdmin")]
        //[Authorize(Roles = $"{Constants.Roles.User}")]
        public IActionResult User()
        {
            return View();
        }

        //[Authorize(Roles = $"{Constants.Roles.PendaftaranPasien}")]
        //public IActionResult PendaftaranPasien()
        //{
        //    return View();
        //}
    }
}
