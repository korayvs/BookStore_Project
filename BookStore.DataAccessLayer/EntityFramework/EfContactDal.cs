using BookStore.DataAccessLayer.Abstract;
using BookStore.DataAccessLayer.Context;
using BookStore.DataAccessLayer.Repositories;
using BookStore.EntityLayer.Concrete;

namespace BookStore.DataAccessLayer.EntityFramework
{
    public class EfContactDal : GenericRepository<Contact>, IContactDal
    {
        public EfContactDal(BookStoreContext context) : base(context)
        {
        }

        BookStoreContext context = new BookStoreContext();
        public Contact GetLast1()
        {
            var values = context.Contacts.OrderByDescending(x => x.ContactId).FirstOrDefault();
            return values;
        }
    }
}
