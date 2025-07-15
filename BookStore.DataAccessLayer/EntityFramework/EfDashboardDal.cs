using BookStore.DataAccessLayer.Abstract;
using BookStore.DataAccessLayer.Context;
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

    }
}
