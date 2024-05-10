using BE;
using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            Food f = new Food();
            f.Name = food.Name;
            f.Description = food.Description;
            f.Price = food.Price;
            f.Star = food.Star;


            f.MenuId = food.FoodMenuId;
           
            UploadFile upf = new UploadFile(environment);
            if (food.Photo != null)
            {
                f.Photo = upf.Upload(food.Photo);
            }
            blFood.Create(f);
            return RedirectToAction("Index", "Admin");
        }

        //[HttpGet]
        //public ActionResult Blog(int id)
        //{
        //    blCardBlog blCardBlog = new blCardBlog();
        //    CardBlog? blog = new CardBlog();
        //    blog = blCardBlog.SearchById(id);
        //    if (blog != null)
        //    {
        //        ViewBag.CardBlogTopics = blog.CardBlogTopics;
        //        ViewBag.Blogger = blog.Blogger;
        //        ViewBag.BlogContinuations = blog.BlogContinuations;
        //        return View(blog);
        //    }
        //    return View(blog);
        //}
        //[HttpGet]
        //public async Task<IActionResult> Show()
        //{
        //    blCardBlog blCardBlog = new blCardBlog();
        //    var data = await blCardBlog.ReadAsync();
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
        //public IActionResult Create(Models.Blog.CardBlog b)
        //{
        //    blCardBlog blcard = new blCardBlog();
        //    CardBlog card = new CardBlog();
        //    card.Title = b.Title;
        //    card.Description = b.Description;
        //    card.Subtitle = b.Subtitle;
        //    card.Views = b.Views;
        //    if (b.TopicCardBlogs != null)
        //    {
        //        foreach (var id in b.TopicCardBlogs)
        //        {
        //            var topicCardBlog = new CardBlogTopic
        //            {
        //                TopicId = id,
        //                CardBlogId = card.Id
        //            };

        //            card.CardBlogTopics.Add(topicCardBlog);
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
        //public void Update(Models.Blog.CardBlog b)
        //{
        //    blCardBlog blcard = new blCardBlog();
        //    CardBlog CardBlog = new CardBlog();
        //    CardBlog.Id = b.Id;
        //    CardBlog.Title = b.Title;
        //    CardBlog.Description = b.Description;
        //    CardBlog.Subtitle = b.Subtitle;
        //    CardBlog.Views = b.Views;
        //    if (b.Photo != null)
        //    {
        //        UploadFile upf = new UploadFile(environment);
        //        CardBlog.Photo = upf.Upload(b.Photo);
        //    }
        //    blcard.Update(CardBlog);
        //}
        //[HttpPost]

        //public async Task<ActionResult> IncrementViews(CardBlog cardBlog)
        //{
        //    blCardBlog blcard = new blCardBlog();
        //    int cardId = cardBlog.Id;
        //    await blcard.ViewAdder(cardId);
        //    return Json(new { success = true });
        //}



        //public async Task<IActionResult> Edit(int Id)
        //{
        //    blCardBlog blCardBlog = new blCardBlog();
        //    var card = blCardBlog.SearchById(Id);

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
