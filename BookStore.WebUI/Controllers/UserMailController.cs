using BookStore.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace BookStore.WebUI.Controllers
{
    public class UserMailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserMailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> UserMailList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7227/api/UserMails");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<UserMail>>(jsonData);
                return View(values);
            }
            return View();
        }

        public IActionResult CreateUserMail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserMail(UserMail userMail)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(userMail);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7227/api/UserMails", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("UserMailList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteUserMail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("https://localhost:7227/api/UserMails?id=" + id);
            return RedirectToAction("UserMailList");
        }

        public async Task<IActionResult> UpdateUserMail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7227/api/UserMails/GetUserMailById?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UserMail>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserMail(UserMail userMail)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(userMail);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7227/api/UserMails", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("UserMailList");
            }
            return View();
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

                TempData["SuccessMessage"] = "Mail başarıyla gönderildi.";
            }
            catch (Exception)
            {
                TempData["FailMessage"] = "Mail gönderilirken hata oluştu.";
            }

            return RedirectToAction("UserMailList");
        }
    }
}
