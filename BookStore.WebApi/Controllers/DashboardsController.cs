using BookStore.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardsController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardsController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet("EmailCount")]
        public IActionResult EmailCount()
        {
            var value = _dashboardService.TEmailCount();
            return Ok(value);
        }

        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            var value = _dashboardService.TCategoryCount();
            return Ok(value);
        }

        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            var value = _dashboardService.TProductCount();
            return Ok(value);
        }

        [HttpGet("QuoteCount")]
        public IActionResult QuoteCount()
        {
            var value = _dashboardService.TQuoteCount();
            return Ok(value);
        }

        [HttpGet("AverageProductPrice")]
        public IActionResult AverageProductPrice()
        {
            var price = _dashboardService.TAverageProductPrice();
            return Ok(price);
        }

        [HttpGet("LastCategory")]
        public IActionResult LastCategory()
        {
            var value = _dashboardService.TLastCategory();
            return Ok(value);
        }

        [HttpGet("LastProduct")]
        public IActionResult LastProduct()
        {
            var value = _dashboardService.TLastProduct();
            return Ok(value);
        }

        [HttpGet("LastQuote")]
        public IActionResult LastQuote()
        {
            var value = _dashboardService.TLastQuote();
            return Ok(value);
        }

        [HttpGet("LastAuthor")]
        public IActionResult LastAuthor()
        {
            var value = _dashboardService.TLastAuthor();
            return Ok(value);
        }

        [HttpGet("GetAuthors")]
        public IActionResult GetAuthors()
        {
            var values = _dashboardService.TGetAuthors();
            return Ok(values);
        }

        [HttpGet("CategoryWithLeastProduct")]
        public IActionResult CategoryWithLeastProduct()
        {
            var value = _dashboardService.TCategoryWithLeastProduct();
            return Ok(value);
        }

        [HttpGet("CategoryWithMostProduct")]
        public IActionResult CategoryWithMostProduct()
        {
            var value = _dashboardService.TCategoryWithMostProduct();
            return Ok(value);
        }

        [HttpGet("LeastProduct")]
        public IActionResult LeastProduct()
        {
            var value = _dashboardService.TLeastProduct();
            return Ok(value);
        }

        [HttpGet("MostExpensiveProduct")]
        public IActionResult MostExpensiveProduct()
        {
            var value = _dashboardService.TMostExpensiveProduct();
            return Ok(value);
        }
    }
}
