using System.Globalization;
using Authentication.Infrastructure;
using Authentication.Models;
using Authentication.Models.Enums;
using CM;
using FPTB.Model;
using FPTB.Services.Infrastructure;
using fromplaytobow.co.uk.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fromplaytobow.co.uk.Controllers
{
    public class AccountController : Controller
    {
        readonly IUserService _userService;
        private readonly IOAuthService _authService;
        private const string Passcode = "LambCurry";

        private int LoginDuration
        {
            get { 
                return (ConfigurationManager.AppSettings["LoginDuration"] != null)?
                    Convert.ToInt32(ConfigurationManager.AppSettings["LoginDuration"]) : 60; 
            }
        }

        public AccountController(IUserService userService, IOAuthService authService)
        {
            _userService = userService;
            _authService = authService;

        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.ReferringUrl = (Request.UrlReferrer != null)? Request.UrlReferrer.AbsoluteUri : "/";

            var page = new HtmlPageVM
            {
                 Title = "LOGIN",
                 ShortIntro = "Use form below to login"
            };
            return View(page);
        }

        [HttpPost]
        public ActionResult LogUser(UserLoginVM model)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.LogUser(model.Password, model.UserName);
                if (user != null)
                {
                    var clientUser = new ClientUser{

                            LanguageId = 0,
                            UserName = user.Email,
                            UserId = user.UserId,
                            Profiles = new List<string>(),
                            Roles = user.Roles.Split(',').ToList(),
                            FullName = user.FirstName + " " + user.SurName,
                            CookieDuration = new TimeSpan(0, 0, LoginDuration, 0),
                            Culture = "",
                            CompanyId = 0,
                            DepartmentId = 0,
                    };

                    _authService.PersistClientUser(clientUser);


                    Response.Redirect(!String.IsNullOrEmpty(model.ReturnUrl) ? model.ReturnUrl : "/");
                }
                else
                {
                    ModelState.AddModelError("FailedLoggin", "The details you provided were not found");
                }
            }

            var page = new HtmlPageVM
            {
                Title = "LOGIN",
                ShortIntro = "Use form below to login"
            };

            return View("Login", page);
        }

        public ActionResult CreateDefaultAdmin(string id)
        {
            if (!Passcode.Equals(id))
            {
                return RedirectToAction("AccessDenied", "Error",
                                        new { Message = "You are not authorized to create users" });
            }

            var user = CreateDefaultUser();
            return View("UserCreated", user);

        }

        private UserDto CreateDefaultUser()
        {
            var newuser = new UserDto
            {
                FirstName = "Joe",
                SurName = "Bolla",
                Created = DateTime.Now,
                Email = "joe_bolla@yahoo.com",
                NoOfVisits = 0,
                Password = Security.Encrypt("steelpan60"),
                Roles = ((int)Roles.CompanyAdmin).ToString(CultureInfo.InvariantCulture)
            };

            return _userService.CreateUser(newuser);
        }
    }
}
