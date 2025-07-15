using BookStore.EntityLayer.Concrete;

namespace BookStore.WebUI.Dtos.CategoryDtos
{
    public class GetByIdCategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual List<Product>? Products { get; set; }
    }
}
