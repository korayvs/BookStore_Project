using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.ViewComponents.AdminComponents
{
    public class _AdminSidebarComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
