using BenariMikronWebApp.Areas.Identity.Data;
using BenariMikronWebApp.Core.ViewModels.Login;
using BenariMikronWebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Principal;

namespace BenariMikronWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private ILogger<AccountController> logger;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<AccountController> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
        }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
            //return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true

                var user = await signInManager.UserManager.FindByNameAsync(model.Email);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt. ");
                    return View(model);
                }

                var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                if (result.Succeeded)
                {
                    var claims = new List<Claim>
                    {
                        new Claim("amr", "pwd"),
                    };

                    var roles = await signInManager.UserManager.GetRolesAsync(user);

                    if (roles.Any())
                    {
                        var roleClaim = string.Join(",", roles);
                        claims.Add(new Claim("Roles", roleClaim));
                    }

                    await signInManager.SignInWithClaimsAsync(user, model.RememberMe, claims);

                    logger.LogInformation("User logged in.");
                    //return LocalRedirect(returnUrl);
                    return RedirectToAction("Index", "Home");
                }
                if (result.Succeeded)
                {
                    logger.LogInformation("User Loggin in.");
                    return RedirectToAction("Index", "Home");
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);

            //if (!ModelState.IsValid) return View(model);

            //var user = await userManager.FindByEmailAsync(model.Email);

            //if (user != null)
            //{
            //    var passwordCheck = await userManager.CheckPasswordAsync(user, model.Password);
            //    if (passwordCheck)
            //    {
            //        var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
            //        if (result.Succeeded)
            //        {
            //            return RedirectToAction("Index", "Home");
            //        }
            //    }
            //    TempData["Error"] = "Ada Kesalahan Password !";
            //    return View(model);
            //}
            //TempData["Error"] = "Ada Kesalahan Password !";
            //return View(model);
        }
    }
}
