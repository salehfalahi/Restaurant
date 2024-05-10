using Microsoft.AspNetCore.Mvc;

namespace Restaurant2.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            BLL.blMenu blm = new BLL.blMenu();
            ViewBag.Menus = await blm.ReadAsync();
            return View();
        }
    
    }
}
