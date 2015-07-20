using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Utils
{
    public class CustomViewEngine : RazorViewEngine
    {

        public CustomViewEngine()
        {
            //AreaViewLocationFormats = new[]
            //{
            //    "~/Areas/Admin/Views/{1}/{0}.cshtml"
            //};

            //ViewLocationFormats = new[] 
            //{
            //    "~/Areas/Admin/Views/{1}/{0}.cshtml"
            //};

            //MasterLocationFormats = new[] 
            //{
            //    "~/Areas/Admin/Views/{1}/{0}.cshtml"
            //};

            PartialViewLocationFormats = new[] 
            {
                "~/Views/Shared/Home/{0}.cshtml"
            };
        }
    }
}
