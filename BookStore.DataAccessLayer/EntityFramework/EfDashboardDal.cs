using BookStore.DataAccessLayer.Abstract;
using BookStore.DataAccessLayer.Context;
using BookStore.EntityLayer.Concrete;
using BookStore.WebUI.Dtos.ProductDtos;
using Microsoft.EntityFrameworkCore;
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

        public int EmailCount()
        {
            return _context.UserMails.Count();
        }

        public int CategoryCount()
        {
            return _context.Categories.Count();
        }

        public int ProductCount()
        {
            return _context.Products.Count();
        }

        public int QuoteCount()
        {
            return _context.Quotes.Count();
        }

        public decimal AverageProductPrice()
        {
            var value = _context.Products.Average(x => x.ProductPrice);
            return decimal.Round(value, 2);
        }

        public Category LastCategory()
        {
            var value = _context.Categories.OrderByDescending(x => x.CategoryId).FirstOrDefault();
            return value;
        }

        public Product LastProduct()
        {
            var value = _context.Products.OrderByDescending(x => x.ProductId).FirstOrDefault();
            return value;
        }

        public Quote LastQuote()
        {
            var value = _context.Quotes.OrderByDescending(x => x.QuoteId).FirstOrDefault();
            return value;
        }        

        public Product LastAuthor()
        {
            var value = _context.Products.OrderByDescending(x => x.ProductId).FirstOrDefault();
            return value;
        }

        public List<Product> GetAuthors()
        {
            var values = _context.Products.ToList();
            return values;
        }

        public Category CategoryWithLeastProduct()
        {
            var values = _context.Categories.OrderBy(x => x.Products.Count).Select(category => new Category
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
            }).FirstOrDefault();

            return values;
        }

        public Category CategoryWithMostProduct()
        {
            var values = _context.Categories.OrderByDescending(x => x.Products.Count).Select(category => new Category
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
            }).FirstOrDefault();

            return values;
        }

        public Product LeastProduct()
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

        public Product MostExpensiveProduct()
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
    }
}
