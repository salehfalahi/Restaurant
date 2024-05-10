using BE;
using Microsoft.AspNetCore.Mvc;
using Restaurant2.Models;
using System.Diagnostics;
using BLL;
namespace Restaurant2.Controllers
{
    public class HomeController : Controller
    {

        private readonly blFood _blf = new blFood();

        [HttpGet]
        public async Task<IActionResult> Index(int menuId)
        {
            if (menuId > 1)
            {
                ViewBag.Firstfoods = await _blf.GetFoodsByMenuId(menuId);
            }
            else
            {
                menuId = 2;
                ViewBag.Firstfoods = await _blf.GetFoodsByMenuId(menuId);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetFoodsByMenuId(int menuId)
        {
            var foods = await _blf.GetFoodsByMenuId(menuId);
            return Json(foods);
        }
    }

}   
