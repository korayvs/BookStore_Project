using BookStore.DataAccessLayer.Abstract;
using BookStore.DataAccessLayer.Context;
using BookStore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.EntityFramework
{
    public class EfDashboardDal : IDashboardDal
    {
        private readonly BookStoreContext _context;

        public EfDashboardDal(BookStoreContext context)
        {
            _context = context;
        }



        public List<Product> GetAuthors()
        {
            var values = _context.Products.ToList();
            return values;
        }

        public decimal GetAvarageProductPrice()
        {
            var value = _context.Products.Average(x => x.ProductPrice);
            return decimal.Round(value, 2);
        }

        public int GetCategoryCount()
        {
            return _context.Categories.Count();
        }

        public Category GetCategoryWithLeastProduct()
        {
            var category = _context.Categories.OrderBy(x => x.Products.Count).Select(category => new Category
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
            }).FirstOrDefault();

            return category;
        }

        public Category GetCategoryWithMostProduct()
        {
            var category = _context.Categories.OrderByDescending(x => x.Products.Count).Select(category => new Category
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
            }).FirstOrDefault();

            return category;
        }

        public int GetEmailCount()
        {
            return _context.UserMails.Count();
        }

        public Category GetLastCategory()
        {
            var value = _context.Categories.OrderByDescending(x => x.CategoryId).FirstOrDefault();
            return value;
        }

        public Product GetLastProduct()
        {
            var value = _context.Products.OrderByDescending(x => x.ProductId).FirstOrDefault();
            return value;
        }

        public Quote GetLastQuote()
        {
            var value = _context.Quotes.OrderByDescending(x => x.QuoteId).FirstOrDefault();
            return value;
        }

        public Product GetLeastStockProduct()
        {
            var value = _context.Products.OrderBy(x => x.ProductStock).Select(p => new Product
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                ProductStock = p.ProductStock,
                ProductPrice = p.ProductPrice,
                ImageUrl = p.ImageUrl,
                Description = p.Description,
                AuthorName = p.AuthorName,
                CategoryId = p.CategoryId
            }).FirstOrDefault();
            return value;
        }

        public Product GetMostExpensiveProduct()
        {
            var value = _context.Products
                                .OrderByDescending(x => x.ProductPrice)
                                .Select(p => new Product
                                {
                                    ProductId = p.ProductId,
                                    ProductName = p.ProductName,
                                    ProductStock = p.ProductStock,
                                    ProductPrice = p.ProductPrice,
                                    ImageUrl = p.ImageUrl,
                                    Description = p.Description,
                                    AuthorName = p.AuthorName,
                                    CategoryId = p.CategoryId
                                })
                                .FirstOrDefault();
            return value;
        }


        public int GetProductCount()
        {
            return _context.Products.Count();
        }

        public int GetQuoteCount()
        {
            return _context.Quotes.Count();
        }
    }
}
