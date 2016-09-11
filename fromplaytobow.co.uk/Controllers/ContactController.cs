using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fromplaytobow.co.uk.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendMessage(string txtEmail, string txtMessage, string txtName = "")
        {
            return null;
        }
    }
}
