using Business.Abstract;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibraryProject.Controllers
{
    public class LoginController : Controller
    {
        IAuthService authService;

        public LoginController(IAuthService authService)
        {
            this.authService = authService;
        }

        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(MemberForLoginDto member)
        {
            authService.Login(member);
            return RedirectToRoute("/MyPage/Index");
        }
    }
}