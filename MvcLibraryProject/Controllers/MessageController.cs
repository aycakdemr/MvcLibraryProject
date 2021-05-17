using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibraryProject.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        IMessageService messageService;

        public MessageController(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        public ActionResult Index()
        {
            var mail = (string)Session["Mail"].ToString();
            var value = messageService.GetByMailReceiver(mail.ToString());
            return View(value);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            var mail = (string)Session["Mail"].ToString();
            message.Sender = mail.ToString();
            message.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            messageService.Add(message);
            return RedirectToAction("AllMessages", "Messages");
        }
        public ActionResult AllMessages()
        {
            var mail = (string)Session["Mail"].ToString();
            var value = messageService.GetByMailSender(mail.ToString());
            return View(value);
        }
    }
}