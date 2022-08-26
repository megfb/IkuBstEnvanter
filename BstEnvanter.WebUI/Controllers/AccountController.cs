using BstEnvanter.WebUI.Identity;
using BstEnvanter.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BstEnvanter.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private RoleManager<ApplicationRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Register()
        {
            return View();
        }
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
                TempData.Add("Alert", "User is not found");
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
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "Home");
        }
        public IActionResult ChangePassword()
        {
            return View(new ChangePasswordViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePasswordViewModel)
        {

            var user = await _userManager.GetUserAsync(HttpContext.User);
            
            await _userManager.ChangePasswordAsync(user, changePasswordViewModel.OldPassword, changePasswordViewModel.NewPassword);
            IdentityResult result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("index","home");
            }

            return View();
        }


    }
}
