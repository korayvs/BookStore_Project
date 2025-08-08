using BookStore.EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;

namespace BookStore.WebUI.Dtos.CategoryDtos
{
    public class CreateCategoryDto
    {
        [Required(ErrorMessage = "Lütfen bir kategori seçin.")]
        public string CategoryName { get; set; }
        public virtual List<Product>? Products { get; set; }
    }
}
