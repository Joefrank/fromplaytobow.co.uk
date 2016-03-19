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

        #region newscontent

        //public ActionResult GetNewsContent(string pagename = null)
        //{
        //    var page = string.IsNullOrEmpty(pagename) ? "index" : pagename;
        //    return GetPageContent(pagename);
        //}

        #endregion

        public ActionResult GetPageContent(string pagename)
        {
            ViewBag.EditMode = false;
            return View("GenericContent", CreateDefaultPage(_pageService.GetPage(pagename)));
        }

        [CustomAuth(Roles.CompanyAdmin, AccessDeniedMessage="You are not authorized to edit this page")]
        [HttpGet]
        public ActionResult EditPageContent(string pagename)
        {
            ViewBag.EditMode = true;
            var page = CreateDefaultPage(_pageService.GetPage(pagename));
            var pageVm = Mapper.Map<HtmlPageDto, HtmlPageVM>(page);
            pageVm.PageIdentifier = pagename;
            pageVm.PageGroup = _pageService.GetPageGroupFromUrl(Request.RawUrl);

            return View("GenericContentEdit", pageVm);
        }

        [CustomAuth(Roles.CompanyAdmin, AccessDeniedMessage = "You are not authorized to modify this page")]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SavePageContent(HtmlPageVM page)
        {
            page.Status = 0;

            if (ModelState.IsValid)
            {
                var pageDto = Mapper.Map<HtmlPageVM, HtmlPageDto>(page);
                page.Status = _pageService.SavePage(pageDto);                                
            }
             
            return View("GenericContentEdit", page);
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
