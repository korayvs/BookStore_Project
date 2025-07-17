using BookStore.BusinessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMailsController : ControllerBase
    {
        private readonly IUserMailService _userMailService;

        public UserMailsController(IUserMailService userMailService)
        {
            _userMailService = userMailService;
        }

        [HttpGet]
        public IActionResult GetUserMails()
        {
            var values = _userMailService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateUserMail(UserMail userMail)
        {
            _userMailService.TAdd(userMail);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteUserMail(int id)
        {
            _userMailService.TDelete(id);
            return Ok("Silme işlemi başarılı");
        }

        [HttpPut]
        public IActionResult UpdateUserMail(UserMail userMail)
        {
            _userMailService.TUpdate(userMail);
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpGet("GetUserMailById")]
        public IActionResult GetUserMailById(int id)
        {
            var value = _userMailService.TGetById(id);
            return Ok(value);
        }
    }
}
