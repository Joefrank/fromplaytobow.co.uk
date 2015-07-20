using FPTB.Services.Infrastructure;
using fromplaytobow.co.uk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fromplaytobow.co.uk.Controllers
{
    public class AdminPageController : AdminBaseController
    {
        IHtmlPageService _pageservice;

        public AdminPageController(IHtmlPageService pageservice)
        {
            _pageservice = pageservice;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListPages()
        {
            var pages = _pageservice.ListPages();
            return View("PageList", pages);
        }

        public ActionResult CreatePage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePage(HtmlPageVM model)
        {
            return View();
        }
    }
}
