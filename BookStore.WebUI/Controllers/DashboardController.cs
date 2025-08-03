using BookStore.EntityLayer.Concrete;
using BookStore.WebUI.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Globalization;

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
            ViewBag.İstatistikler = _localization.GetKey("İstatistikler").Value;
            ViewBag.Abonelikler = _localization.GetKey("Abonelikler").Value;
            ViewBag.Alıntılar = _localization.GetKey("Alıntılar").Value;
            ViewBag.GenelBilgiler = _localization.GetKey("Genel Bilgiler").Value;            
            ViewBag.Kategoriler = _localization.GetKey("Kategoriler").Value;
            ViewBag.Kitaplar = _localization.GetKey("Kitaplar").Value;
            var currentCulture = Thread.CurrentThread.CurrentCulture.Name;

            #region Widgets

            var client = _httpClientFactory.CreateClient();

            var values = await client.GetAsync("https://localhost:7227/api/Dashboards/EmailCount");
            if (values.IsSuccessStatusCode)
            {
                var count = await values.Content.ReadAsStringAsync();
                var emailCount = Convert.ToInt32(count);
                ViewBag.EmailCount = emailCount;
            }

            var values2 = await client.GetAsync("https://localhost:7227/api/Dashboards/CategoryCount");
            if (values2.IsSuccessStatusCode)
            {
                var count = await values2.Content.ReadAsStringAsync();
                var categoryCount = Convert.ToInt32(count);
                ViewBag.CategoryCount = categoryCount;
            }

            var values3 = await client.GetAsync("https://localhost:7227/api/Dashboards/ProductCount");
            if (values3.IsSuccessStatusCode)
            {
                var count = await values2.Content.ReadAsStringAsync();
                var productCount = Convert.ToInt32(count);
                ViewBag.ProductCount = productCount;
            }

            var values4 = await client.GetAsync("https://localhost:7227/api/Dashboards/QuoteCount");
            if (values4.IsSuccessStatusCode)
            {
                var count = await values3.Content.ReadAsStringAsync();
                var quoteCount = Convert.ToInt32(count);
                ViewBag.QuoteCount = quoteCount;
            }

            var values5 = await client.GetAsync("https://localhost:7227/api/Dashboards/AverageProductPrice");
            if (values5.IsSuccessStatusCode)
            {
                var avgPrice = await values5.Content.ReadAsStringAsync();
                Console.WriteLine("API'dan Gelen Ortalama Fiyat: " + avgPrice);

                var price = Convert.ToDecimal(avgPrice.Replace(',', '.'), CultureInfo.InvariantCulture);

                ViewBag.AvgPrice = price.ToString("C2", new CultureInfo("tr")).TrimStart('¤');
            }

            var values6 = await client.GetAsync("https://localhost:7227/api/Dashboards/LastProduct");
            if (values6.IsSuccessStatusCode)
            {
                var value = await values6.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<Product>(value);
                ViewBag.LastProduct = product;
            }
            var values7 = await client.GetAsync("https://localhost:7227/api/Dashboards/LastCategory");
            if (values7.IsSuccessStatusCode)
            {
                var value = await values7.Content.ReadAsStringAsync();
                var category = JsonConvert.DeserializeObject<Category>(value);
                ViewBag.LastCategory = category;
            }

            var values8 = await client.GetAsync("https://localhost:7227/api/Dashboards/LastQuote");
            if (values8.IsSuccessStatusCode)
            {
                var value = await values8.Content.ReadAsStringAsync();
                var quote = JsonConvert.DeserializeObject<Quote>(value);
                ViewBag.LastQuote = quote;
            }

            var values9 = await client.GetAsync("https://localhost:7227/api/Dashboards/LeastProduct");
            if (values9.IsSuccessStatusCode)
            {
                var value = await values9.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<Product>(value);
                ViewBag.LeastProduct = product;
            }

            var values10 = await client.GetAsync("https://localhost:7227/api/Dashboards/MostExpensiveProduct");
            if (values10.IsSuccessStatusCode)
            {
                var value = await values10.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<Product>(value);
                ViewBag.MostExpensiveProduct = product;
            }

            var values11 = await client.GetAsync("https://localhost:7227/api/Dashboards/GetAuthors");
            if (values11.IsSuccessStatusCode)
            {
                var getAuthors = await values11.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<Product>>(getAuthors);
                var last5Product = products.TakeLast(5);
                var productsForAuhtor = products.TakeLast(8);
                ViewBag.ProductsForAuhtor = productsForAuhtor;
                ViewBag.Last5Products = last5Product;
            }

            #endregion

            return View();
        }
    }
}
