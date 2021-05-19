using Business.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibraryProject.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        // GET: Register

        IAuthService authService;

        public RegisterController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(MemberForRegisterDto member)
        {
            authService.Register(member,member.Password);
            return View();
        }
    }
}