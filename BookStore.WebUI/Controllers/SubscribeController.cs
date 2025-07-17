using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.Controllers
{
    public class SubscribeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
