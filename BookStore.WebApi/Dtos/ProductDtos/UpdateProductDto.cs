using BookStore.EntityLayer.Concrete;

namespace BookStore.WebApi.Dtos.ProductDtos
{
    public class UpdateProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
        public string ImageUrl { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    }
}
