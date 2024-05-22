using BE;
using BLL;
using Microsoft.AspNetCore.Mvc;

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
       
    }
}
