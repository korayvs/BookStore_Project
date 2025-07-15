using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult Layout()
        {
            return View();
        }
    }
}
