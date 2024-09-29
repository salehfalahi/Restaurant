using Microsoft.AspNetCore.Mvc;

namespace Restaurant2.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
