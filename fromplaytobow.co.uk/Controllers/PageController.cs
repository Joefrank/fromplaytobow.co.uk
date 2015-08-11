using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Authentication.Models;
using Authentication.Models.Enums;
using AutoMapper;
using FPTB.Services.Infrastructure;
using FPTB.Model;
using fromplaytobow.co.uk.Models;

namespace fromplaytobow.co.uk.Controllers
{
    public class PageController : Controller
    {
        private readonly IHtmlPageService _pageService;

        public PageController(IHtmlPageService pageService)
        {
            _pageService = pageService;
        }

        /// <summary>
        /// Provides a list of all pages with their sections
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPageContent(string idname)
        {
            ViewBag.EditMode = false;
            return View("GenericContent", CreateDefaultPage(_pageService.GetPage(idname)));
        }

        [CustomAuth(Roles.CompanyAdmin, AccessDeniedMessage="You are not authorized to edit this page")]
        [HttpGet]
        public ActionResult EditPageContent(string idname)
        {
            ViewBag.EditMode = true;
            var page = CreateDefaultPage(_pageService.GetPage(idname));
            var pageVm = Mapper.Map<HtmlPageDto, HtmlPageVM>(page);
            pageVm.PageIdentifier = idname;
            return View("GenericContentEdit", pageVm);
        }

        [CustomAuth(Roles.CompanyAdmin, AccessDeniedMessage = "You are not authorized to modify this page")]
        [HttpPost]
        public ActionResult SavePageContent(HtmlPageVM page)
        {
            return !ModelState.IsValid ? RedirectToAction("EditGradeContent", new {idname = page.PageIdentifier}) : null;
        }


        private HtmlPageDto CreateDefaultPage(HtmlPageDto page)
        {
            if (page == null)
            {
                page = new HtmlPageDto();
            }
           
            if(string.IsNullOrEmpty(page.Title)){
                page.Title = "Page Title";
            }

            if (string.IsNullOrEmpty(page.ShortIntro))
            {
                page.ShortIntro = "Page Intro";
            }

            if (page.HtmlBlocks == null || page.HtmlBlocks.Count == 0)
            {
                page.HtmlBlocks = CreateDefaultHtmlBlock();
            }

            return page;
        }

        private List<HtmlBlockDto> CreateDefaultHtmlBlock()
        {
            return new List<HtmlBlockDto>
                {
                    new HtmlBlockDto
                        {
                            HtmlText = "Please enter page content here",
                            Index = 1
                        }
                };
        } 
    }
}
