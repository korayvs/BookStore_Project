using BookStore.WebUI.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.Controllers
{
    public class DashboardController : Controller
    {
        private LanguageService _localization;
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardController(LanguageService localization, IHttpClientFactory httpClientFactory)
        {
            _localization = localization;
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1)
            });
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> Index()
        {
            #region EnglishLanguage
            ViewBag.Abonelikler = _localization.GetKey("Abonelikler").Value;
            ViewBag.Alıntılar = _localization.GetKey("Alıntılar").Value;
            ViewBag.GenelBilgiler = _localization.GetKey("Genel Bilgiler").Value;
            ViewBag.İstatistikler = _localization.GetKey("İstatistikler").Value;
            ViewBag.Kategoriler = _localization.GetKey("Kategoriler").Value;
            ViewBag.Kitaplar = _localization.GetKey("Kitaplar").Value;
            var currentCulture = Thread.CurrentThread.CurrentCulture.Name;
            #endregion



            return View();
        }
    }
}
