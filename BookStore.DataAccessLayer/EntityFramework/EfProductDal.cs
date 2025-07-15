using BookStore.DataAccessLayer.Abstract;
using BookStore.DataAccessLayer.Context;
using BookStore.DataAccessLayer.Repositories;
using BookStore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(BookStoreContext context) : base(context)
        {
        }

        BookStoreContext context = new BookStoreContext();

        public int GetProductCount()
        {
            int value = context.Products.Count();
            return value;
        }

        public List<Product> GetLast4Books()
        {
            var values = context.Products.OrderByDescending(x => x.ProductId).Take(4).ToList();
            return values;
        }

        public Product GetBookOfTheDay()
        {
            Random rnd = new Random();
            int countProducts = context.Products.Count();
            int rndnumber = rnd.Next(1, (countProducts + 1));
            var value = context.Products.Skip(rndnumber - 1).FirstOrDefault();
            return value;
        }
    }
}
