using BE;
using Microsoft.AspNetCore.Mvc;
using Restaurant2.Models;
using System.Diagnostics;
using BLL;
using Newtonsoft.Json;
using DAL;
using System;
using NuGet.ContentModel;

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

            // تغییر این خط به صورت زیر
            if (ViewBag.OrderCount > 0)
            {
                ViewBag.BasketOrders = await basketOrdersAsync(); // استفاده از await
            }
       

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
        private async Task<List<BasketOrder>> basketOrdersAsync()
        {
            var basket = LoadBasketFromSession();
            blFood blFood = new blFood();
            List<BasketOrder> basketOrders = new List<BasketOrder>(); // لیست برای ذخیره سفارشات

            foreach (var order in basket.Orders)
            {
                var food = await blFood.GetFoodById(order.FoodId); // بارگذاری غذا بر اساس ID

                var basketOrder = new BasketOrder
                {
                    Food = food, // غذا
                    Count = (byte)order.Count, // تعداد
                    Price = order.Price // قیمت
                };

                basketOrders.Add(basketOrder); // اضافه کردن به لیست
            }

            return basketOrders; // برگرداندن لیست سفارشات
        }





        [HttpPost]
        public async Task<IActionResult> GetFoodsByMenuId(int menuId)
        {
            var foods = await _blf.GetFoodsByMenuId(menuId);
            return Json(foods);
        }

        [HttpPost]
        public IActionResult CreateReservation(Models.Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                BE.Reservation res = new BE.Reservation();
                blReservation blr = new blReservation();

                res.Name = reservation.Name;
                res.PersonCount = reservation.PersonCount;
                res.Message = reservation.Message;
                res.Phone = reservation.Phone;
                res.ReservationDate = reservation.ReservationDate;
                res.ReservationTime = reservation.ReservationTime;
                
                blr.SaveReservation(res);
               
                ViewBag.SuccessMessage = "!رزرو شما با موفقیت انجام شد";
            }

            return View(); 
        }

    }

}   
