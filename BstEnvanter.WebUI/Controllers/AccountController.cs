using BstEnvanter.WebUI.Identity;
using BstEnvanter.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BstEnvanter.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private RoleManager<ApplicationRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        [Authorize(Roles = "admin")]
        public IActionResult Register()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }
            var user = new ApplicationUser()
            {
                UserName = registerViewModel.Email,
                name = registerViewModel.name,
                surname = registerViewModel.surname,
                age = registerViewModel.age,
                gender = registerViewModel.gender,
                Email = registerViewModel.Email,
                department = registerViewModel.department,
                roomNo = registerViewModel.roomNo,
                title = registerViewModel.title,
            };
            var result = _userManager.CreateAsync(user, registerViewModel.password).Result;
            if (result.Succeeded)
            {

                if (!_roleManager.RoleExistsAsync(registerViewModel.role).Result)
                {
                    ApplicationRole role = new ApplicationRole()
                    {
                        Name = registerViewModel.role
                    };
                    IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
                }
                _userManager.AddToRoleAsync(user, registerViewModel.role).Wait();

                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(new LoginViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {

            var user = await _userManager.FindByEmailAsync(loginViewModel.EMail);
            if (user == null)
            {
                TempData.Add("Alert", "Başarısız giriş! E-mail veya parolayı kontrol edin!");
                return View(loginViewModel);
            }
            var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);

            if (result.Succeeded)
            {
                TempData.Add("Success", $"Welcome {user.name}");
                return RedirectToAction("Index", "Home");
            }

            TempData.Add("Alert", "E-Mail or Password is wrong");
            return View(loginViewModel);
        }
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "Home");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }


    }
}
