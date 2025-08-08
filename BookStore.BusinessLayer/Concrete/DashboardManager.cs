using BookStore.BusinessLayer.Abstract;
using BookStore.DataAccessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
using BookStore.WebUI.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLayer.Concrete
{
    public class DashboardManager : IDashboardService
    {
        private readonly IDashboardDal _dashboardDal;

        public DashboardManager(IDashboardDal dashboardDal)
        {
            _dashboardDal = dashboardDal;
        }

        public decimal TAverageProductPrice()
        {
            return _dashboardDal.AverageProductPrice();
        }

        public int TCategoryCount()
        {
            return _dashboardDal.CategoryCount();
        }

        public Category TCategoryWithLeastProduct()
        {
            return _dashboardDal.CategoryWithLeastProduct();
        }

        public Category TCategoryWithMostProduct()
        {
            return _dashboardDal.CategoryWithMostProduct();
        }

        public int TEmailCount()
        {
            return _dashboardDal.EmailCount();
        }

        public List<Product> TGetAuthors()
        {
            return _dashboardDal.GetAuthors();
        }

        public Product TLastAuthor()
        {
            return _dashboardDal.LastAuthor();
        }

        public Category TLastCategory()
        {
            return _dashboardDal.LastCategory();
        }

        public Product TLastProduct()
        {
            return _dashboardDal.LastProduct();
        }

        public Quote TLastQuote()
        {
            return _dashboardDal.LastQuote();
        }

        public Product TLeastProduct()
        {
            return _dashboardDal.LeastProduct();
        }

        public Product TMostExpensiveProduct()
        {
            return _dashboardDal.MostExpensiveProduct();
        }

        public int TProductCount()
        {
            return _dashboardDal.ProductCount();
        }

        public int TQuoteCount()
        {
            return _dashboardDal.QuoteCount();
        }
    }
}
