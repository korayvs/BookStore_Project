using BookStore.WebUI.Dtos.QuoteDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BookStore.WebUI.Controllers
{
    public class QuoteController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public QuoteController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> QuoteList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7227/api/Quotes");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultQuoteDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public IActionResult CreateQuote()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuote(CreateQuoteDto createQuoteDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createQuoteDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7227/api/Quotes", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("QuoteList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteQuote(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7227/api/Quotes?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("QuoteList");
            }
            return View();
        }

        public async Task<IActionResult> UpdateQuote(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7227/api/Quotes/GetByIdQuote?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateQuoteDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuote(UpdateQuoteDto updateQuoteDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateQuoteDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7227/api/Quotes", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("QuoteList");
            }
            return View();
        }
    }
}
