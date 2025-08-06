using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.ViewComponents.DefaultComponents
{
    public class _DefaultImagesComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
