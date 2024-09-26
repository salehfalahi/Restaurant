using BE;
using Microsoft.AspNetCore.Mvc;
using Restaurant2.Models;
using System.Diagnostics;
using BLL;
using Newtonsoft.Json;

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
            var orderCount = GetTemporaryOrderCount(); // دریافت تعداد سفارشات موقت

            ViewBag.OrderCount = orderCount;
            return View();
        }
        private BE.Basket LoadBasketFromSession()
        {
            var basketJson = HttpContext.Session.GetString("Basket");
            if (basketJson == null)
            {
                // اگر سبد در Session وجود نداشت، یک سبد جدید ایجاد کنید
                return new BE.Basket(); // برگرداندن یک سبد خالی
            }
            return JsonConvert.DeserializeObject<BE.Basket>(basketJson);
        }

        public int GetTemporaryOrderCount()
        {
            var basket = LoadBasketFromSession();
            return basket.Orders.Count; // تعداد سفارشات در سبد موقت
        }
        [HttpPost]
        public async Task<IActionResult> GetFoodsByMenuId(int menuId)
        {
            var foods = await _blf.GetFoodsByMenuId(menuId);
            return Json(foods);
        }

      
    }

}   
