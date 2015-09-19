using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPTB.Model
{
    public class HtmlPageDto
    {
        public int PageId { get; set; }
        public int ThemeId { get; set; }

        public string PageIdentifier { get; set; }
        public string Title { get; set; }
        public string ShortIntro { get; set; }
        public string PageGroup { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }

        public List<HtmlBlockDto> HtmlBlocks { get; set; }
    }
}
