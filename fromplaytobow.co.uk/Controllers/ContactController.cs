using System.Configuration;
using FPTB.Services.Infrastructure;
using fromplaytobow.co.uk.Models;
using System.Web.Mvc;

namespace fromplaytobow.co.uk.Controllers
{
    public class ContactController : Controller
    {

        private readonly IEmailService _messageService;

        public ContactController(IEmailService messageService)
        {
            _messageService = messageService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendMessage(string txtEmail, string txtMessage, string txtName = "")
        {
            if(string.IsNullOrEmpty(txtMessage) || string.IsNullOrEmpty(txtEmail))
            {
                return View("MessageFailed");
            }
            var adminEmail = ConfigurationManager.AppSettings["InfoEmail"];
            var result = _messageService.SendEmail(txtEmail, txtName, "FTB Admin", adminEmail, "[FromPlayToBow] - User Contact", txtMessage);

            var model = new MessageVM
            {
                Name = txtName,
                Email = txtEmail
            };

            return View("MessageSent", model);
        }
    }
}
