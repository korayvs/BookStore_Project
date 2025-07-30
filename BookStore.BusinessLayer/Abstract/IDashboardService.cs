using BookStore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLayer.Abstract
{
    public interface IDashboardService
    {


        int TGetCategoryCount();
        int TGetProductCount();
        int TGetQuoteCount();
        int TGetEmailCount();
        Product TGetLastProduct();
        Category TGetLastCategory();
        Quote TGetLastQuote();
        Product TGetLeastStockProduct();
        Category TGetCategoryWithMostProduct();
        Category TGetCategoryWithLeastProduct();
        Product TGetMostExpensiveProduct();
        decimal TGetAvarageProductPrice();
        List<Product> TGetAuthors();
    }
}
