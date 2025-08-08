using AutoMapper;
using BookStore.BusinessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
using BookStore.WebApi.Dtos.CategoryDtos;
using BookStore.WebApi.Dtos.ProductDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper, ICategoryService categoryService)
        {
            _productService = productService;
            _mapper = mapper;
            _categoryService = categoryService;
        }        

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _productService.TGetAll();
            var dtos = _mapper.Map<List<ResultProductDto>>(values);
            return Ok(dtos);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            var dtos = _mapper.Map<Product>(createProductDto);
            _productService.TAdd(dtos);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            var dtos = _mapper.Map<Product>(updateProductDto);
            _productService.TUpdate(dtos);
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            _productService.TDelete(id);
            return Ok("Silme işlemi başarılı");
        }

        [HttpGet("GetAllCategories")]
        public IActionResult GetAllCategories()
        {
            var values = _categoryService.TGetAll();
            var dtos = _mapper.Map<List<ResultCategoryDto>>(values);
            return Ok(dtos);
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var values = _productService.TGetById(id);
            var dto = _mapper.Map<GetByIdProductDto>(values);
            return Ok(dto);
        }

        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            return Ok(_productService.TGetProductCount());
        }

        [HttpGet("Last4Books")]
        public IActionResult Last4Books()
        {
            var values = _productService.TGetLast4Books();
            var dtos = _mapper.Map<List<ResultProductDto>>(values);
            return Ok(dtos);
        }

        [HttpGet("BookOfTheDay")]
        public IActionResult BookOfTheDay()
        {
            var values = _productService.TGetBookOfTheDay();
            var dto = _mapper.Map<ResultProductDto>(values);
            return Ok(dto);
        }
    }
}
