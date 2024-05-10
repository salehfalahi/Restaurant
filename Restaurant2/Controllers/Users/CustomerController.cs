using BE;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Restaurant2.Controllers.Users
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public AppUser? appUser;
        public CustomerController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var task = _userManager.GetUserAsync(User);
            task.Wait();
            appUser = task.Result;
            if (appUser != null)
            {
                return View(appUser);
            }
            else
            {
                return NotFound(); 
            }
        }

    }
}
