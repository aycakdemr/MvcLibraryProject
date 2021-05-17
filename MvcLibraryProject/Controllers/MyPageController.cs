using Business.Abstract;
using Core.Utilities.Security.Hashing;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibraryProject.Controllers
{
    public class MyPageController : Controller
    {
        IMemberService memberService;

        public MyPageController(IMemberService memberService)
        {
            this.memberService = memberService;
        }

        // GET: MyPage
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var usermail = (string)Session["Mail"];
            var userpassword = (string)Session["Password"];
            var value = memberService.GetMemberDto(usermail,userpassword);
            return View(value);
        }
        [HttpPost]
        public ActionResult Index2(MemberForRegisterDto member)
        {

            var user = (string)Session["Mail"];
            var userpassword = (string)Session["Password"];
            var value = memberService.GetByMail(user);
            memberService.UpdateDto(member, member.Password, user);
            return RedirectToAction("Index");
        }
    }
}