using BookStore.EntityLayer.Concrete;
using BookStore.WebApi.Dtos.ProductDtos;

namespace BookStore.WebApi.Dtos.CategoryDtos
{
    public class GetByIdCategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual List<ResultProductDto>? Products { get; set; }
    }
}
