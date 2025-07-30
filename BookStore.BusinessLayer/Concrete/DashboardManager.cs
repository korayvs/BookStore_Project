using BookStore.BusinessLayer.Abstract;
using BookStore.DataAccessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
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



        public List<Product> TGetAuthors()
        {
            return _dashboardDal.GetAuthors();
        }

        public decimal TGetAvarageProductPrice()
        {
            return _dashboardDal.GetAvarageProductPrice();
        }

        public int TGetCategoryCount()
        {
            return _dashboardDal.GetCategoryCount();
        }

        public Category TGetCategoryWithLeastProduct()
        {
            return _dashboardDal.GetCategoryWithLeastProduct();
        }

        public Category TGetCategoryWithMostProduct()
        {
            return _dashboardDal.GetCategoryWithMostProduct();
        }

        public int TGetEmailCount()
        {
            return _dashboardDal.GetEmailCount();
        }

        public Category TGetLastCategory()
        {
            return _dashboardDal.GetLastCategory();
        }

        public Product TGetLastProduct()
        {
            return _dashboardDal.GetLastProduct();
        }

        public Quote TGetLastQuote()
        {
            return _dashboardDal.GetLastQuote();
        }

        public Product TGetLeastStockProduct()
        {
            return _dashboardDal.GetLeastStockProduct();
        }

        public Product TGetMostExpensiveProduct()
        {
            return _dashboardDal.GetMostExpensiveProduct();
        }

        public int TGetProductCount()
        {
            return _dashboardDal.GetProductCount();
        }

        public int TGetQuoteCount()
        {
            return _dashboardDal.GetQuoteCount();
        }
    }
}
