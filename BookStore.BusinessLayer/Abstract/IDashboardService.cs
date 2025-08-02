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
        int TEmailCount();
        int TCategoryCount();
        int TProductCount();
        int TQuoteCount();
        decimal TAverageProductPrice();
        Category TLastCategory();
        Product TLastProduct();
        Quote TLastQuote();
        Category TCategoryWithLeastProduct();
        Category TCategoryWithMostProduct();
        Product TLeastProduct();
        Product TMostExpensiveProduct();
        List<Product> TGetAuthors();
    }
}
