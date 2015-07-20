using Authentication.Models.Enums;
using AutoMapper;
using FPTB.Model;
using FPTB.Services.Infrastructure;
using fromplaytobow.co.uk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CM;

namespace fromplaytobow.co.uk.Controllers
{
    public class AdminHomeController : AdminBaseController
    {
        private readonly IUserService _userservice;
       
        public AdminHomeController(IUserService userservice)
        {
            _userservice = userservice;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(NewUserVM user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var newuser = Mapper.Map<NewUserVM, UserDto>(user);
            
            var saveduser = _userservice.CreateUser(newuser);

            return View("UserCreated", saveduser);
        }

       
    }
}
