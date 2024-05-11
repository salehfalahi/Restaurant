using BE;
using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant2.Models;

namespace Restaurant2.Controllers.Users
{
    [Authorize(Roles ="admin")]
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



        [HttpGet]
        public async Task<IActionResult> CreateFood()
        {
            blMenu blMenu = new blMenu();
            var data = await blMenu.ReadAsync();
            ViewBag.Menus = data.ToList();
            return View();
        }


        [HttpPost]
        public IActionResult CreateFood(Models.Food food)
        {
            blFood blFood = new blFood();
            BE.Food f = new BE.Food();
            f.Name = food.Name;
            f.Description = food.Description;
            f.Price = food.Price;
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
        public async Task<IActionResult> ManageFood(int menuId)
        {
			BLL.blMenu blm = new BLL.blMenu();
			ViewBag.Menus = await blm.ReadAsync();
			if (menuId > 1)
			{
				ViewBag.Firstfoods = await _blf.GetFoodsByMenuId(menuId);
			}
			else
			{
				menuId = 2;
				ViewBag.Firstfoods = await _blf.GetFoodsByMenuId(menuId);
			}
			blFood blFood = new blFood();
            var data = await blFood.ReadAsync();
            var model = data.ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult ManageFood(Models.Food b)
        {
            blFood blFood = new blFood();
            BE.Food Food = new BE.Food();
            Food.Id = b.Id;
            Food.Name = b.Name;
            Food.Price = b.Price;
            Food.Description = b.Description;
            Food.Star = b.Star;
            Food.MenuId = b.MenuId;
            if (b.Photo != null)
            {
                UploadFile upf = new UploadFile(environment);
                Food.Photo = upf.Upload(b.Photo);
            }
			_blf.ManageFood(Food);
            return RedirectToAction("ManageFood", "Admin");
        }

        //[HttpGet]
        //public ActionResult Blog(int id)
        //{
        //    blFood blFood = new blFood();
        //    Food? blog = new Food();
        //    blog = blFood.SearchById(id);
        //    if (blog != null)
        //    {
        //        ViewBag.FoodTopics = blog.FoodTopics;
        //        ViewBag.Blogger = blog.Blogger;
        //        ViewBag.BlogContinuations = blog.BlogContinuations;
        //        return View(blog);
        //    }
        //    return View(blog);
        //}
        //[HttpGet]
        //public async Task<IActionResult> Show()
        //{
        //    blFood blFood = new blFood();
        //    var data = await blFood.ReadAsync();
        //    var model = data.ToList();
        //    return View(model);
        //}
        //[HttpGet]
        //public async Task<IActionResult> Create()
        //{
        //    blBlogger blBlogger = new blBlogger();
        //    var data = await blBlogger.ReadAsync();
        //    ViewBag.Bloggers = data.ToList();

        //    blTopic topic = new blTopic();
        //    var topics = await topic.ReadAsync();
        //    ViewBag.Topics = topics.ToList();

        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Create(Models.Blog.Food b)
        //{
        //    blFood blcard = new blFood();
        //    Food card = new Food();
        //    card.Title = b.Title;
        //    card.Description = b.Description;
        //    card.Subtitle = b.Subtitle;
        //    card.Views = b.Views;
        //    if (b.TopicFoods != null)
        //    {
        //        foreach (var id in b.TopicFoods)
        //        {
        //            var topicFood = new FoodTopic
        //            {
        //                TopicId = id,
        //                FoodId = card.Id
        //            };

        //            card.FoodTopics.Add(topicFood);
        //        }
        //    }

        //    card.BloggerId = b.BloggerId;
        //    card.DateTime = DateTime.Now;
        //    UploadFile upf = new UploadFile(environment);
        //    if (b.Photo != null)
        //    {
        //        card.Photo = upf.Upload(b.Photo);
        //    }
        //    blcard.Create(card);
        //    return RedirectToAction("Index", "Admin");
        //}
        //[HttpPost]
        //public void Update(Models.Blog.Food b)
        //{
        //    blFood blcard = new blFood();
        //    Food Food = new Food();
        //    Food.Id = b.Id;
        //    Food.Title = b.Title;
        //    Food.Description = b.Description;
        //    Food.Subtitle = b.Subtitle;
        //    Food.Views = b.Views;
        //    if (b.Photo != null)
        //    {
        //        UploadFile upf = new UploadFile(environment);
        //        Food.Photo = upf.Upload(b.Photo);
        //    }
        //    blcard.Update(Food);
        //}
        //[HttpPost]

        //public async Task<ActionResult> IncrementViews(Food Food)
        //{
        //    blFood blcard = new blFood();
        //    int cardId = Food.Id;
        //    await blcard.ViewAdder(cardId);
        //    return Json(new { success = true });
        //}



        //public async Task<IActionResult> Edit(int Id)
        //{
        //    blFood blFood = new blFood();
        //    var card = blFood.SearchById(Id);

        //    blBlogger blBlogger = new blBlogger();
        //    var data = await blBlogger.ReadAsync();
        //    ViewBag.Bloggers = data.ToList();

        //    blTopic topic = new blTopic();
        //    var topics = await topic.ReadAsync();
        //    ViewBag.Topics = topics.ToList();

        //    return View(card);
        //}
    }
}
