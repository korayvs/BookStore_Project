using BookStore.EntityLayer.Concrete;

namespace BookStore.WebUI.Dtos.CategoryDtos
{
    public class CreateCategoryDto
    {
        public string CategoryName { get; set; }
        public virtual List<Product>? Products { get; set; }
    }
}
