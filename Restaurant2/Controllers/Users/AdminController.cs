using BE;
using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant2.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace Restaurant2.Controllers.Users
{
	[Authorize(Roles = "admin")]
	public class AdminController : Controller
	{
		private IWebHostEnvironment environment;
		public AdminController(IWebHostEnvironment _environment)
		{
			environment = _environment;
		}
		private readonly blFood _blf = new blFood();
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult CreateMenu()
		{

			return View();
		}
		[HttpPost]
		public IActionResult CreateMenu(Models.Menu menu)
		{
			blMenu blmenu = new blMenu();
			BE.Menu m = new BE.Menu();
			m.Name = menu.Name;
			blmenu.Create(m);
			return RedirectToAction("Index", "Admin");
		}



		//[HttpGet]
		//public async Task<IActionResult> CreateFood()
		//{
		//    blMenu blMenu = new blMenu();
		//    var data = await blMenu.ReadAsync();
		//    ViewBag.Menus = data.ToList();
		//    return View();
		//}


		[HttpPost]
		public IActionResult CreateFood(Models.Food food)
		{
			blFood blFood = new blFood();
			BE.Food f = new BE.Food();
			f.Name = food.Name;
			f.Description = food.Description;

			if (int.TryParse(food.Price, out int price))
			{
				f.Price = price;
			}
			else
			{

				ModelState.AddModelError("Price", "فرمت قیمت معتبر نیست");

				f.Price = 0;
			}
			f.Star = food.Star;
			f.MenuId = food.MenuId;
			UploadFile upf = new UploadFile(environment);
			if (food.Photo != null)
			{
				f.Photo = upf.Upload(food.Photo);
			}
			blFood.Create(f);
			return RedirectToAction("Index", "Admin");
		}


		[HttpGet]
		public async Task<IActionResult> ManageMenu(int menuId)
		{
			BLL.blMenu blm = new BLL.blMenu();
			ViewBag.Menus = await blm.ReadAsync();

			if (menuId > 1)
			{
				var foods = await _blf.GetFoodsByMenuId(menuId);
				if (foods != null)
				{
					ViewBag.Firstfoods = foods;
				}
				else
				{
					ViewBag.Firstfoods = new List<BE.Food>();
				}
			}
			else
			{
				menuId = 2;
				var foods = await _blf.GetFoodsByMenuId(menuId);
				if (foods != null)
				{
					ViewBag.Firstfoods = foods;
				}
				else
				{
					ViewBag.Firstfoods = new List<BE.Food>();
				}
			}

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateFood(Models.Food b)
		{
			blFood blFood = new blFood();
			BE.Food Food = new BE.Food();
			UploadFile upf = new UploadFile(environment);
			Food.Id = b.Id;
			Food.Name = b.Name;
			if (int.TryParse(b.Price, out int price))
			{
				Food.Price = price;
			}
			else
			{

				ModelState.AddModelError("Price", "فرمت قیمت معتبر نیست");

				Food.Price = 0;
			}
			Food.Description = b.Description;
			Food.Star = b.Star;
			Food.MenuId = b.MenuId;
			if (b.Photo != null)
			{
				Food.Photo = upf.Upload(b.Photo);
			}
			else
			{
				BE.Food lastFood = new BE.Food();
				lastFood = await blFood.GetFoodById(Food.Id);
				if (lastFood.Photo != null)
				{
					var photoBytes = Convert.FromBase64String(lastFood.Photo);
				}
			}
			return RedirectToAction("ManageFood", "Admin");
		}
		public JsonResult JsonSearch()
		{
			return Json(new { redirect = "Search" });
		}

		public async Task<IActionResult> Search(string s)
		{
			if (string.IsNullOrEmpty(s))
			{
				return View("ManageMenu", new List<BE.Food>());
			}

			JArray jArray;
			try
			{
				jArray = JArray.Parse(s);
			}
			catch (Exception ex)
			{
				// Log the exception
				return View("ManageMenu", new List<BE.Food>());
			}

			List<string> split = new List<string>();
			foreach (dynamic item in jArray)
			{
				split.Add(item.tag.ToString());
			}

			blFood blFood = new blFood();
			List<BE.Food> listFood = await blFood.GetFoodsByName(split);

			return View("ManageMenu", listFood);
		}

	}
}

