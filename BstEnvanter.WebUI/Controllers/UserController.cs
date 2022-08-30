using BstEnvanter.WebUI.Identity;
using BstEnvanter.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BstEnvanter.WebUI.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private RoleManager<ApplicationRole> _roleManager;

        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteAccount(string id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            await _userManager.DeleteAsync(user);
            return RedirectToAction("index", "home");
        }
        [Authorize(Roles = "admin")]
        public IActionResult ListOfUsers()
        {
            var model = new ListOfUserViewModel()
            {
                users = _userManager.Users,
            };
            return View(model);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DetailUser(string id)
        {
            var getUser = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var model = new DetailUserViewModel()
            {
                user = getUser,
                role = await _userManager.GetRolesAsync(getUser)
            };
            return View(model);
        }
        public async Task<IActionResult> Profile()
        {
            var model = new ProfileViewModel()
            {
                user = await _userManager.GetUserAsync(User),
            };
            model.role = await _userManager.GetRolesAsync(model.user);
            return View(model);
        }
        public async Task<IActionResult> UpdateUser(string id)
        {
            if (id == null)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                var model = new UpdateUserViewModel()
                {
                    user = user
                };
                return View(model);

            }
            else
            {
                var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
                var model = new UpdateUserViewModel()
                {
                    user = user
                };
                return View(model);
            }

        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateUserViewModel updateUserViewModel)
        {
            var getUser = await _userManager.FindByIdAsync(updateUserViewModel.user.Id);

            if (ModelState.IsValid)
            {
                getUser.UserName = updateUserViewModel.user.UserName;
                getUser.name = updateUserViewModel.user.name;
                getUser.surname = updateUserViewModel.user.surname;
                getUser.age = updateUserViewModel.user.age;
                getUser.gender = updateUserViewModel.user.gender;
                getUser.department = updateUserViewModel.user.department;
                getUser.roomNo = updateUserViewModel.user.roomNo;
                getUser.Email = updateUserViewModel.user.Email;
                await _userManager.UpdateAsync(getUser);
            }
            return RedirectToAction("index", "home");
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
                return RedirectToAction("index", "home");
            }

            return View();
        }
    }
    


}
