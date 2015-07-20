using System;
using System.Web;
using System.Web.Mvc;

namespace fromplaytobow.co.uk.Helpers.Custom
{
    public static class HtmlHelpers
    {
        private const string TextboxDefaultClass = "nicdark_bg_grey2 nicdark_radius nicdark_shadow grey small subtitle";
 
        public static HtmlString TextToggler(this HtmlHelper helper, bool editmode, string text)
        {
            return new HtmlString(editmode ?
                string.Format(@"<input type=""text"" value=""{0}"" class=""{1}"" />", text, TextboxDefaultClass)
                :
                string.Format(@"<span>{0}</span>", text));
        }

        public static string TextToggler(this HtmlHelper helper, bool editmode, string text, string attribs)
        {
            return editmode ?
                string.Format(@"<input type=""text"" {0} value=""{1}"" />", attribs, text)
                :
                string.Format(@"<span {0}>{1}</span>", attribs, text);
        }

        public static HtmlString RichTextToggler(this HtmlHelper helper, bool editmode, string text, string attribs)
        {
            return new HtmlString(editmode ?

                string.Format(@"<textarea {0}>{1}</textarea>",attribs, text)
                :
                string.Format(@"<div>{0}</div>", text));
        }
    }
}
