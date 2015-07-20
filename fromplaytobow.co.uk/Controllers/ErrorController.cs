using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fromplaytobow.co.uk.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult AccessDenied(string Message)
        {
            ViewBag.ErrorMessage = Message;
            return View();
        }

    }
}
