using FPTB.Services.Infrastructure;
using fromplaytobow.co.uk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fromplaytobow.co.uk.Controllers
{
    public class ContactController : Controller
    {

        private IMessageService _messageService;

        public ContactController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendMessage(string txtEmail, string txtMessage, string txtName = "")
        {

            var result = _messageService.SendMessage(txtName, txtEmail, "[FromPlayToBow] - User Contact", txtMessage);
            var model = new MessageVM
            {
                Name = txtName,
                Email = txtEmail
            };

            return View("MessageSent", model);
        }
    }
}
