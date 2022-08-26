using BstEnvanter.WebUI.Identity;
using BstEnvanter.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BstEnvanter.WebUI.Controllers
{
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
        public async Task<IActionResult> DeleteAccount()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            await _signInManager.SignOutAsync();
            await _userManager.DeleteAsync(user);
            return RedirectToAction("index", "home");
        }
        public IActionResult ListOfUsers()
        {
            var model = new ListOfUserViewModel()
            {
                users = _userManager.Users,
            };
            return View(model);
        }
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
    }

}
