using BookStore.BusinessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly IQuoteService _quoteService;

        public QuotesController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        [HttpGet]
        public IActionResult QuoteList()
        {
            var values = _quoteService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateQuote(Quote quote)
        {
            _quoteService.TAdd(quote);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteQuote(int id)
        {
            _quoteService.TDelete(id);
            return Ok("Silme işlemi başarılı");
        }

        [HttpPut]
        public IActionResult UpdateQuote(Quote quote)
        {
            _quoteService.TUpdate(quote);
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpGet("GetByIdQuote")]
        public IActionResult GetByIdQuote(int id)
        {
            return Ok(_quoteService.TGetById(id));
        }

        [HttpGet("LastQuote")]
        public IActionResult LastQuote()
        {
            return Ok(_quoteService.TLastQuote());
        }
    }
}
