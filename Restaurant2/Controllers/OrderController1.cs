using Microsoft.AspNetCore.Mvc;

namespace Restaurant2.Controllers
{
    public class OrderController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
