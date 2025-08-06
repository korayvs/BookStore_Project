using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.ViewComponents.AdminComponents
{
    public class _AdminScriptsComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
