using BookStore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.Abstract
{
    public interface IDashboardDal
    {


        int GetCategoryCount();
        int GetProductCount();
        int GetQuoteCount();
        int GetEmailCount();
        Product GetLastProduct();
        Category GetLastCategory();
        Quote GetLastQuote();
        Category GetCategoryWithMostProduct();
        Category GetCategoryWithLeastProduct();
        Product GetMostExpensiveProduct();
        Product GetLeastStockProduct();
        decimal GetAvarageProductPrice();
        List<Product> GetAuthors();
    }
}
