using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utils;
using Authentication.Models;
using Authentication.Models.Enums;

namespace fromplaytobow.co.uk.Controllers
{
    [CustomAuth(Roles.CompanyAdmin)]
    public class AdminBaseController : Controller
    {
       
    }
}
