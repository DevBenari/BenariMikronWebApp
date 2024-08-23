using BenariMikronWebApp.Areas.Identity.Data;
using BenariMikronWebApp.Areas.UserManagement.Data;
using BenariMikronWebApp.Areas.UserManagement.ViewModels;
using BenariMikronWebApp.Areas.UserManagement.Repositories;
using BenariMikronWebApp.Areas.UserManagement.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BenariMikronWebApp.Areas.UserManagement.Controllers
{
    [Area("UserManagement")]
    [Route("UserManagement/[Controller]/[Action]")]
    public class UserManagementController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SignInManager<ApplicationUser> signInManager;

        public UserManagementController(IUnitOfWork unitOfWork, SignInManager<ApplicationUser> signInManager)
        {
            _unitOfWork = unitOfWork;
            this.signInManager = signInManager;
        }
        
        public IActionResult Index()
        {
            var users = _unitOfWork.User.GetUsers();
            return View(users);
        }
        
        public async Task<IActionResult> ChangeUserManagement(string id)
        {
            var user = _unitOfWork.User.GetUser(id);
            var role = _unitOfWork.Role.GetRoles();

            var userRoles = await signInManager.UserManager.GetRolesAsync(user);

            var roleItems = role.Select(roles => new SelectListItem(
                    roles.Name,
                    roles.Id,
                    userRoles.Any(ur => ur.Contains(roles.Name)))).ToList();

            var vm = new ChangeUserManagementViewModel
            {
                User = user,
                Roles = roleItems
            };

            return View(vm);
        }
        
        [HttpPost]
        public async Task<IActionResult> OnPostAsync(ChangeUserManagementViewModel data)
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

            return RedirectToAction("Index", new { id = user.Id });
        }
    }
}
