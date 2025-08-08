using BookStore.WebUI.Dtos.CategoryDtos;
using BookStore.WebUI.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace BookStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ProductList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7227/api/Products");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7227/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

                var categoryList = categories
                    .Select(c => new SelectListItem
                    {
                        Value = c.CategoryId.ToString(),
                        Text = c.CategoryName
                    })
                    .ToList();

                categoryList.Insert(0, new SelectListItem
                {
                    Value = "",
                    Text = "Kategori Seçin",
                    Disabled = true,
                    Selected = true
                });

                ViewBag.CategoryList = categoryList;
                return View();
            }

            ViewBag.CategoryList = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "Kategori Seçin", Disabled = true, Selected = true }
            };
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7227/api/Products", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductList");
            }

            var categoryResponse = await client.GetAsync("https://localhost:7227/api/Categories");
            if (categoryResponse.IsSuccessStatusCode)
            {
                var jsonDataCategory = await categoryResponse.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonDataCategory);
                var categoryList = categories
                    .Select(c => new SelectListItem
                    {
                        Value = c.CategoryId.ToString(),
                        Text = c.CategoryName
                    }).ToList();

                categoryList.Insert(0, new SelectListItem
                {
                    Value = "",
                    Text = "Kategori Seçin",
                    Disabled = true,
                    Selected = true
                });

                ViewBag.CategoryList = categoryList;
            }
            else
            {
                ViewBag.CategoryList = new List<SelectListItem>
                {
                    new SelectListItem { Value = "", Text = "Kategori Seçin", Disabled = true, Selected = true }
                };
            }

            return View();
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7227/api/Products?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductList");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7227/api/Products/GetProduct?id=" + id);
            if (!responseMessage.IsSuccessStatusCode)
            {
                return View();
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);

            var categoryResponse = await client.GetAsync("https://localhost:7227/api/Categories");
            if (categoryResponse.IsSuccessStatusCode)
            {
                var jsonCategories = await categoryResponse.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonCategories);

                var categoryList = categories
                    .Select(c => new SelectListItem
                    {
                        Value = c.CategoryId.ToString(),
                        Text = c.CategoryName,
                        Selected = (c.CategoryId == product.CategoryId)
                    }).ToList();

                categoryList.Insert(0, new SelectListItem
                {
                    Value = "",
                    Text = "Kategori Seçin",
                    Disabled = true
                });

                ViewBag.CategoryList = categoryList;
            }
            else
            {
                ViewBag.CategoryList = new List<SelectListItem>
                {
                    new SelectListItem { Value = "", Text = "Kategori Seçin", Disabled = true }
                };
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7227/api/Products", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductList");
            }

            var categoryResponse = await client.GetAsync("https://localhost:7227/api/Categories");
            if (categoryResponse.IsSuccessStatusCode)
            {
                var jsonCategories = await categoryResponse.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonCategories);

                var categoryList = categories
                    .Select(c => new SelectListItem
                    {
                        Value = c.CategoryId.ToString(),
                        Text = c.CategoryName,
                        Selected = (c.CategoryId == updateProductDto.CategoryId)
                    }).ToList();

                categoryList.Insert(0, new SelectListItem
                {
                    Value = "",
                    Text = "Kategori Seçin",
                    Disabled = true
                });

                ViewBag.CategoryList = categoryList;
            }
            return View(updateProductDto);
        }
    }

    //public void test()
    //{
    //    Random rnd = new Random();
    //    int number = rnd.Next(1,count(+1));
    //}
}

/*
 1 A  --> 1 -> kayıt sırası (Take - Skip)
 2 B  --> 2  
 4 C  --> 3
 7 D  --> 4
 */