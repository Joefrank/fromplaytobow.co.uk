using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fromplaytobow.co.uk.Models
{
    public class HtmlBlockVM
    {
        public int BlockId { get; set; }
        public int Index { get; set; }

        [AllowHtml]
        public string HtmlText { get; set; }
    }
}