using FPTB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FPTB.Data.Repositories.Infrastructure;
using FPTB.Data.Repositories.Implementation;
using AutoMapper;
using FPTB.Data.Model;
using FPTB.Services.Infrastructure;

namespace FPTB.Services.Implementation
{
    public class HtmlPageService : IHtmlPageService
    {
        IPageRepository _pagerepos;

        public HtmlPageService(IPageRepository pagerepos)
        {
            _pagerepos = pagerepos;
        }

        public IEnumerable<HtmlPageDto> ListPages()
        {
            var result = _pagerepos.GetAll();
            return Mapper.Map<IEnumerable<HtmlPage>, IEnumerable<HtmlPageDto>>(result);
        }

        public HtmlPageDto GetPage(string identifier)
        {
            if (string.IsNullOrEmpty(identifier)) return null;

            var page =_pagerepos.Get(x => x.PageIdentifier.ToLower().Trim() == identifier.ToLower().Trim());
            return (page == null)? null : Mapper.Map<HtmlPage, HtmlPageDto>(page);
        }

        public HtmlPageDto GetPage(int id)
        {
            var page = _pagerepos.Get(x => x.PageId == id);
            return (page == null) ? null : Mapper.Map<HtmlPage, HtmlPageDto>(page);
        }

        public int SavePage(HtmlPageDto page)
        {
            var newpage = Mapper.Map<HtmlPageDto, HtmlPage>(page);

            if(page.PageId > 0)
                _pagerepos.Edit(newpage);
            else
                _pagerepos.Add(newpage);

            return _pagerepos.Save();
        }

        public string GetPageGroupFromUrl(string rawUrl)
        {
            if (string.IsNullOrEmpty(rawUrl))
                return string.Empty;

            var tempUrl = rawUrl.Trim();
            return rawUrl.StartsWith("/") ? 
                rawUrl.Substring(1, rawUrl.TrimStart('/').IndexOf("/")) : 
                rawUrl.Substring(0, rawUrl.IndexOf("/"));
        }
    }
}
