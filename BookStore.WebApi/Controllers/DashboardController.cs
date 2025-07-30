using BookStore.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }



        [HttpGet("GetAuthors")]
        public IActionResult TGetAuthors()
        {
            var values = _dashboardService.TGetAuthors();
            return Ok(values);
        }

        [HttpGet("GetAvarageProductPrice")]
        public IActionResult GetAvarageProductPrice()
        {
            var price = _dashboardService.TGetAvarageProductPrice();
            return Ok(price);
        }

        [HttpGet("GetCategoryCount")]
        public IActionResult GetCategoryCount()
        {
            var value = _dashboardService.TGetCategoryCount();
            return Ok(value);
        }

        [HttpGet("GetCategoryWithLeastProduct")]
        public IActionResult GetCategoryWithLeastProduct()
        {
            var value = _dashboardService.TGetCategoryWithLeastProduct();
            return Ok(value);
        }

        [HttpGet("GetCategoryWithMostProduct")]
        public IActionResult GetCategoryWithMostProduct()
        {
            var value = _dashboardService.TGetCategoryWithMostProduct();
            return Ok(value);
        }

        [HttpGet("GetEmailCount")]
        public IActionResult GetEmailCount()
        {
            var value = _dashboardService.TGetEmailCount();
            return Ok(value);
        }

        [HttpGet("GetLastCategory")]
        public IActionResult GetLastCategory()
        {
            var value = _dashboardService.TGetLastCategory();
            return Ok(value);
        }

        [HttpGet("GetLastProduct")]
        public IActionResult GetLastProduct()
        {
            var value = _dashboardService.TGetLastProduct();
            return Ok(value);
        }

        [HttpGet("GetMostExpensiveProduct")]
        public IActionResult GetMostExpensiveProduct()
        {
            var value = _dashboardService.TGetMostExpensiveProduct();
            return Ok(value);
        }

        [HttpGet("GetProductCount")]
        public IActionResult GetProductCount()
        {
            var value = _dashboardService.TGetProductCount();
            return Ok(value);
        }

        [HttpGet("GetQuoteCount")]
        public IActionResult GetQuoteCount()
        {
            var value = _dashboardService.TGetQuoteCount();
            return Ok(value);
        }

        [HttpGet("GetLastQuote")]
        public IActionResult GetLastQuote()
        {
            var value = _dashboardService.TGetLastQuote();
            return Ok(value);
        }

        [HttpGet("GetLeastStockProduct")]
        public IActionResult GetLeastStockProduct()
        {
            var value = _dashboardService.TGetLeastStockProduct();
            return Ok(value);
        }
    }
}
