using BookStore.WebUI.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookStore.WebUI.ViewComponents.DefaultComponents
{
    public class _DefaultPopulerBooksComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultPopulerBooksComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            // API endpoint: Categories + Products included
            var responseMessage = await client.GetAsync("https://localhost:7227/api/Categories/GetCategoriesWithProducts");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                // To view JSON data for debugging purposes:
                Console.WriteLine("API'den Gelen Veri: " + jsonData);

                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

                // Filter products if there are empty categories
                var filledCategories = values
                    ?.Where(c => c.Products != null && c.Products.Any())
                    .ToList() ?? new List<ResultCategoryDto>();

                return View(filledCategories);
            }

            // Send empty list if API fails
            return View(new List<ResultCategoryDto>());
        }
    }
}