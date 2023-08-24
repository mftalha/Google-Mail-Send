using MailKit.Net.Smtp;
using MailSend.Models;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace MailSend.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new();
            //kimden gönderilecek , maili gönderecek kişinin maili
            MailboxAddress mailboxAddressFrom = new("Admin", "talha.0729@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom); // mailin kimden geldiği

            // mail gönderilecek kişinin adı, gönderilecek kişinin mail adresi
            MailboxAddress mailboxAddressTo = new("User", "talha.satir0729@gmail.com");
            mimeMessage.To.Add(mailboxAddressTo);


            BodyBuilder bodyBuilder = new();
            //bodyBuilder.TextBody = "Test Body";
            bodyBuilder.HtmlBody = "<strong>Test Body</strong>";
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = "test mail";//mailRequest.Subject;

            SmtpClient client = new();
            client.Connect("smtp.gmail.com", 587, false);
            // ussbtzdrlkuxburt => google üzerinden aldık 2 aşamalı doğrulamayı açıp altında bişey vardı tıklayınca geliyor. videoda var. => tıklşama şeyi biraz daha aşşagıda veya şifrelerin içinde.
            client.Authenticate("talha.0729@gmail.com", "ussbtzdrlkuxburt"); // kendi şifremizi kabul etmiyor.
            client.Send(mimeMessage);
            client.Disconnect(true);

            return View();
        }
    }
}
