using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FPTB.Data.Model
{
    public class HtmlPage
    {
        [Key]
        public int PageId { get; set; }
        public int ThemeId { get; set; }

        public string PageIdentifier { get; set; }
        public string Title { get; set; }
        public string ShortIntro { get; set; }
        public string PageGroup { get; set; }

        public virtual List<HtmlBlock> HtmlBlocks{get; set;}
    }

    public class HtmlBlock{
        [Key]
        public int BlockId { get; set; }
        public int Index { get; set; }

        public string HtmlText { get; set; }
    }

    public class PageGroup
    {
        [Key]
        public int GroupId { get; set; }

        public string GroupName { get; set; }
    }
}
