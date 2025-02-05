using embezzlement.Models;
using embezzlement.ViewModels;
using Entites.Models;
using IdentityApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace embezzlement.Controllers
{
    public class AccountController : Controller
    {

        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;
        private SignInManager<AppUser> _signinManager;
        public AccountController(
            UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager,
            SignInManager<AppUser> signinManager
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signinManager = signinManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    await _signinManager.SignOutAsync();

                    var result = await _signinManager.PasswordSignInAsync(user, model.Password, model.RememberMe, true);
                    if (result.Succeeded)
                    {
                        await _userManager.ResetAccessFailedCountAsync(user);
                        await _userManager.SetLockoutEndDateAsync(user, null);

                        return RedirectToAction(nameof(Index), "Home");
                    }
                    else if (result.IsLockedOut)
                    {
                        var logoutDate = await _userManager.GetLockoutEndDateAsync(user);
                        var timeLeft = DateTime.Now - logoutDate;

                        ModelState.AddModelError("", $"Your account has been locked for {timeLeft}");
                    }

                    else
                    {
                        ModelState.AddModelError("", "Incorrect Password");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Can't find an account registired to e-mail");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _userManager.FindByEmailAsync(model.Email) != null)
                {
                    ModelState.AddModelError("", "Email address is already in use.");
                    return View(model);
                }

                var user = new AppUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    FullName = model.FullName
                };

                IdentityResult result = await _userManager.CreateAsync(user, model.Password);


                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> ConfirmEmail(string Id, string token)
        {
            if (Id == null || token == null)
            {
                TempData["message"] = "Invalid Token";
                return View();
            }

            var user = await _userManager.FindByIdAsync(Id);

            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);

                if (result.Succeeded)
                {
                    TempData["message"] = "Your account has been confirmed";
                    return RedirectToAction("Login", "Account");
                }
            }

            TempData["message"] = "User Can't Found";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();

            return RedirectToAction("Login");
        }
    }

}
