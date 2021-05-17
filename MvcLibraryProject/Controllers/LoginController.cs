using Business.Abstract;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcLibraryProject.Controllers
{
    public class LoginController : Controller
    {
        IAuthService authService;
        IMemberService memberService;
        public LoginController(IAuthService authService,IMemberService memberService)
        {
            this.authService = authService;
            this.memberService = memberService;
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
           
            if ((authService.Login(member)))
            {
                
                FormsAuthentication.SetAuthCookie(member.Email, false);
                var value = memberService.GetByMail(member.Email);
                Session["Mail"] = member.Email;
                Session["Password"] = member.Password;
                return RedirectToAction("Index", "MyPage");
            }
            return View();
        }
    }
}