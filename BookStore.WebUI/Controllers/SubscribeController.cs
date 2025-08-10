using BookStore.EntityLayer.Concrete;
using BookStore.WebUI.Dtos.UserMailDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace BookStore.WebUI.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SubscribeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> UserMailList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7227/api/UserMails");
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = await responseMessage.Content.ReadAsStringAsync();
                var mails = JsonConvert.DeserializeObject<List<ResultUserMailDto>>(result);
                return View(mails);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewMail([FromBody] CreateUserMailDto email)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(email);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7227/api/UserMails", content);
            return Json(email);
        }

        [HttpPost]
        public async Task<IActionResult> SendMail(int id)
        {

            try
            {
                // Get the user's email address from the API
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync("https://localhost:7227/api/UserMails/GetUserMailById?id=" + id);

                if (!response.IsSuccessStatusCode)
                {
                    TempData["FailMessage"] = "E-posta bilgisi alınamadı.";
                    return RedirectToAction("UserMailList");
                }

                var jsonData = await response.Content.ReadAsStringAsync();
                var subscribeEmail = JsonConvert.DeserializeObject<UserMail>(jsonData);

                if (subscribeEmail == null || string.IsNullOrEmpty(subscribeEmail.UserEmail))
                {
                    TempData["FailMessage"] = "Geçerli bir e-posta adresi bulunamadı.";
                    return RedirectToAction("UserMailList");
                }

                // Prepare the mail model
                var model = new AutoMail
                {
                    ToEmail = subscribeEmail.UserEmail
                };

                if (string.IsNullOrWhiteSpace(model.Subject) || string.IsNullOrWhiteSpace(model.Body))
                {
                    TempData["FailMessage"] = "Konu ve içerik boş olamaz.";
                    return RedirectToAction("UserMailList");
                }

                // Send mail with SMTP client
                var smtpClient = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("koray9707@gmail.com", "dkcl kqos mgpi kqlh"),
                    EnableSsl = true
                };

                var mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("koray9707@gmail.com", "BOOKSAW");
                mailMessage.Subject = model.Subject;
                mailMessage.Body = model.Body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(model.ToEmail);

                await smtpClient.SendMailAsync(mailMessage);

                TempData["SuccessMessage"] = "Abonelik maili gönderildi.";
            }
            catch (Exception)
            {
                TempData["FailMessage"] = "Mail gönderilirken bir hata oluştu.";
            }

            return RedirectToAction("UserMailList");
        }

        public IActionResult CreateSubscribe()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubscribe(CreateUserMailDto createUserMail)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createUserMail);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7227/api/UserMails", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("UserMailList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteSubscribe(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7227/api/UserMails?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("UserMailList");
            }
            return View();
        }

        public async Task<IActionResult> UpdateSubscribe(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7227/api/UserMails/GetUserMailById?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateUserMailDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSubscribe(UpdateUserMailDto updateUserMail)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateUserMail);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7227/api/UserMails", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("UserMailList");
            }
            return View();
        }
    }
}
