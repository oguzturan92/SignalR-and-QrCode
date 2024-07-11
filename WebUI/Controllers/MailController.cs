using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using WebUI.Dtos.MailDto;

namespace WebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.mailActive = "active";
            return View();
        }

        [HttpPost]
        public IActionResult Index(CreateMailDto createMailDto)
        {
            // NUGET EKLE : dotnet add package MailKit --version 4.7.0 
            // NAMESPACE EKLE : using MailKit.Net.Smtp;
            // NAMESPACE EKLE : using MimeKit;

            // 1- mimeMessage nesnesi türettik
            MimeMessage mimeMessage = new MimeMessage();

            // 2- Gönderici Adı ve Mail bilgisini aldık
            MailboxAddress mailboxSenderAddress = new MailboxAddress(createMailDto.SenderMail, createMailDto.SenderMail);

            // mimeMessage içine, kimden gideceği bilgileri eklendi
            mimeMessage.From.Add(mailboxSenderAddress);

            // 3- Alıcı Adı ve Mail bilgisini aldık
            MailboxAddress mailboxReceiverAddress = new MailboxAddress(createMailDto.SenderMail, createMailDto.ReceiverMail);

            // mimeMessage içine, kime gideceği bilgileri eklendi
            mimeMessage.To.Add(mailboxReceiverAddress);

            // mail konu bilgisi eklendi
            mimeMessage.Subject = createMailDto.Subject;
            // mail içerik eklendi
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = createMailDto.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();


            // smtp nesnesi oluşturuldu
            SmtpClient smtpClient = new SmtpClient();

            // gönderen mail bilgileri girildi. host(smtp.office365.com), port(587), enableSSL(false) bilgileri
            smtpClient.Connect(createMailDto.SenderMailHost, createMailDto.SenderMailPort, createMailDto.SenderMailEnableSSL);

            // mail gönderene ait mail ve mail şifre bilgilerini smtpClient'e gönderdik
            smtpClient.Authenticate(createMailDto.SenderMail, createMailDto.SenderMailPassword);

            // mimeMessage nesnesini smtpClient'e send ettik
            smtpClient.Send(mimeMessage);

            smtpClient.Disconnect(true);

            TempData["icon"] = "success";
            TempData["text"] = "Mail gönderildi.";
            return RedirectToAction("Index", "Mail");
        }
    }
}