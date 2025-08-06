using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.ViewComponents.AdminComponents
{
    public class _AdminBreadCrumbComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
