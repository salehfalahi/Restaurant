using BE;
using BLL;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Restaurant2.Controllers.Menu
{
    public class FoodPageController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            blFood blFood = new blFood();
            Food Food = await blFood.GetFoodById(id);
            if (Food != null)
            {
                return View(Food);
            }
            return View();
        }
        // ذخیره سبد در Session
        public void SaveBasketToSession(Basket basket)
        {
            HttpContext.Session.SetString("Basket", JsonConvert.SerializeObject(basket));
        }


        // بارگذاری سبد از Session
        public Basket LoadBasketFromSession()
        {
            var basketJson = HttpContext.Session.GetString("Basket");
            return basketJson != null ? JsonConvert.DeserializeObject<Basket>(basketJson) : null;
        }

        [HttpPost]
        public IActionResult AddToBasket(Models.Order order)
        {
            var basket = LoadBasketFromSession() ?? new Basket
            {
                Orders = new List<Order>()
            };
            //blOrder blorder = new blOrder();
           
            var o = new Order
            {
               Price = order.Price,
               Time = DateTime.Now,
               FoodId = order.FoodId,            
               Count = order.Count
            };
            basket.Orders.Add(o);
            SaveBasketToSession(basket);
            //blorder.Create(o);
            return Redirect(Url.Action("Index", "Home") + "#menu");
        }
    }
}
