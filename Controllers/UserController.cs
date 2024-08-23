using BenariMikronWebApp.Areas.Identity.Data;
using BenariMikronWebApp.Core;
using BenariMikronWebApp.Core.Repositories;
using BenariMikronWebApp.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static BenariMikronWebApp.Core.Constants;

namespace BenariMikronWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork2 _unitOfWork;
        private readonly SignInManager<ApplicationUser> signInManager;

        public UserController(IUnitOfWork2 unitOfWork, SignInManager<ApplicationUser> signInManager)
        { 
            _unitOfWork = unitOfWork;
            this.signInManager = signInManager;
        }

        [Authorize(Roles = $"{Constants.Roles.Administrator}, {Constants.Roles.TambahPasienBaru}")]
        public IActionResult Index()
        {
            var users = _unitOfWork.User.GetUsers();
            return View(users);
        }

        [Authorize(Roles = $"{Constants.Roles.Administrator}, {Constants.Roles.TambahPasienBaru}")]
        public async Task<IActionResult> UbahPengguna(string id)
        {
            var user = _unitOfWork.User.GetUser(id);
            var role = _unitOfWork.Role.GetRoles();

            var userRoles = await signInManager.UserManager.GetRolesAsync(user);

            var roleItems = role.Select(roles => new SelectListItem(
                    roles.Name,
                    roles.Id,
                    userRoles.Any(ur => ur.Contains(roles.Name)))).ToList();

            var vm = new UbahPenggunaViewModel 
            { 
                User = user,
                Roles = roleItems
            };

            return View(vm);
        }

        [Authorize(Roles = $"{Constants.Roles.Administrator}, {Constants.Roles.TambahPasienBaru}")]
        [HttpPost]
        public async Task<IActionResult> OnPostAsync(UbahPenggunaViewModel data)
        {
            var user = _unitOfWork.User.GetUser(data.User.Id);

            if (user == null)
            {
                return NotFound();
            }

            var userRoles = await signInManager.UserManager.GetRolesAsync(user);

            //Lakukan perulangan pada roles di ViewModel
            //Cek pada Database apakah role yang sedang digunakan
            //Jika digunakan -> tidak perlu melakukan perubahan
            //Jika tidak digunakan -> tambahkan role baru

            var rolesToAdd = new List<string>();
            var rolesToDelete = new List<string>();

            foreach (var role in data.Roles)
            {
                var roleCheked = userRoles.FirstOrDefault(ur => ur == role.Text);

                if (role.Selected)
                {
                    if (roleCheked == null)
                    {
                        //Tambahkan Checked Role Baru
                        rolesToAdd.Add(role.Text);
                        //await signInManager.UserManager.AddToRoleAsync(user, role.Text);
                    }
                }
                else
                {
                    if (roleCheked != null)
                    {
                        //Hapus Checked Role
                        rolesToDelete.Add(role.Text);
                        //await signInManager.UserManager.RemoveFromRoleAsync(user, role.Text);
                    }
                }
            }

            if (rolesToAdd.Any())
            { 
                await signInManager.UserManager.AddToRolesAsync(user, rolesToAdd);
            }

            if (rolesToDelete.Any())
            { 
                await signInManager.UserManager.RemoveFromRolesAsync(user, rolesToDelete);
            }

            user.NamaDepan = data.User.NamaDepan;
            user.NamaBelakang = data.User.NamaBelakang;
            user.Email = data.User.Email;

            _unitOfWork.User.UpdateUser(user);

            return RedirectToAction("Index", new { id = user.Id});
        }
    }    
}
