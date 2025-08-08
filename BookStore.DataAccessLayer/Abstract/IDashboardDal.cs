using BookStore.EntityLayer.Concrete;
using BookStore.WebUI.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.Abstract
{
    public interface IDashboardDal
    {
        int EmailCount();
        int CategoryCount();
        int ProductCount();
        int QuoteCount();       
        decimal AverageProductPrice();
        Category LastCategory();
        Product LastProduct();        
        Quote LastQuote();
        Product LastAuthor();
        Category CategoryWithLeastProduct();
        Category CategoryWithMostProduct();
        Product LeastProduct();
        Product MostExpensiveProduct();              
        List<Product> GetAuthors();
    }
}
