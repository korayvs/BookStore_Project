using BookStore.DataAccessLayer.Abstract;
using BookStore.DataAccessLayer.Context;
using BookStore.DataAccessLayer.Repositories;
using BookStore.EntityLayer.Concrete;

namespace BookStore.DataAccessLayer.EntityFramework
{
    public class EfQuoteDal : GenericRepository<Quote>, IQuoteDal
    {
        public EfQuoteDal(BookStoreContext context) : base(context)
        {
        }

        BookStoreContext _context = new BookStoreContext();
        public Quote LastQuote()
        {
            var value = _context.Quotes.OrderByDescending(x => x.QuoteId).FirstOrDefault();
            return value;
        }
    }
}
