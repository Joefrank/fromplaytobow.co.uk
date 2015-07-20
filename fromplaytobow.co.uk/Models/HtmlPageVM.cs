using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace fromplaytobow.co.uk.Models
{
    public class HtmlPageVM
    {
        public int PageId { get; set; }
        public int ThemeId { get; set; }

        [Required(ErrorMessage = "Page identifier is required")]
        public string PageIdentifier { get; set; }


        [Required(ErrorMessage = "Page title is required")]
        public string Title { get; set; }
        
        public string ShortIntro { get; set; }
        
        [Required(ErrorMessage = "Page group is required")]
        public string PageGroup { get; set; }

        public List<HtmlBlockVM> HtmlBlocks { get; set; }
    }
}