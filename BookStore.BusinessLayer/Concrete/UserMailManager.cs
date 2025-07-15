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
    public class UserMailManager : IUserMailService
    {
        private readonly IUserMailDal _userMailDal;

        public UserMailManager(IUserMailDal userMailDal)
        {
            _userMailDal = userMailDal;
        }

        public void TAdd(UserMail entity)
        {
            _userMailDal.Add(entity);
        }

        public void TDelete(int id)
        {
            _userMailDal.Delete(id);
        }

        public List<UserMail> TGetAll()
        {
            return _userMailDal.GetAll();
        }

        public UserMail TGetById(int id)
        {
            return _userMailDal.GetById(id);
        }

        public void TUpdate(UserMail entity)
        {
            _userMailDal.Update(entity);
        }
    }
}
