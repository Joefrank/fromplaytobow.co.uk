using FPTB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPTB.Services.Infrastructure
{
    public interface IHtmlPageService
    {
        IEnumerable<HtmlPageDto> ListPages();

        HtmlPageDto GetPage(string identifier);

        HtmlPageDto GetPage(int id);

        int SavePage(HtmlPageDto page);
    }
}
