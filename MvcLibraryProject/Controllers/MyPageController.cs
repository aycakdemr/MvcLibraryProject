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
        IBookRecordService bookRecordService;

        public MyPageController(IMemberService memberService, IBookRecordService bookRecordService)
        {
            this.memberService = memberService;
            this.bookRecordService = bookRecordService;
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
        public ActionResult MyBooks()
        {
            var mail = (string)Session["Mail"];
            var user = memberService.GetByMail(mail);
            var value = bookRecordService.GetDetail(user.Id);
            return View(value);
        }
    }
}