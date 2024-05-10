using Microsoft.AspNetCore.Mvc;

namespace Restaurant2.Controllers.Users
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
