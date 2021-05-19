using Business.Abstract;
using Core.Utilities.Security.Hashing;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcLibraryProject.Controllers
{
    [Authorize]
    public class MyPageController : Controller
    {
        IMemberService memberService;
        IBookRecordService bookRecordService;
        IAnnouncementService announcementService;
        IMessageService messageService;

        public MyPageController(IMemberService memberService, IBookRecordService bookRecordService
            , IAnnouncementService announcementService, IMessageService messageService)
        {
            this.memberService = memberService;
            this.bookRecordService = bookRecordService;
            this.announcementService = announcementService;
            this.messageService = messageService;
        }

        // GET: MyPage
        [HttpGet]
       
        public ActionResult Index()
        {
            var usermail = (string)Session["Mail"];
            var userpassword = (string)Session["Password"];
            var value = announcementService.GetAll();
            var d1 = memberService.GetMemberDto(usermail, userpassword).FirstName;
            ViewBag.d1 = d1;
            var d2 = memberService.GetMemberDto(usermail, userpassword).LastName;
            ViewBag.d2 = d2;
            var d3 = memberService.GetMemberDto(usermail, userpassword).Image;
            ViewBag.d3 = d3;
            var d4 = memberService.GetMemberDto(usermail, userpassword).UserName;
            ViewBag.d4 = d4;
            var d5 = memberService.GetMemberDto(usermail, userpassword).Education;
            ViewBag.d5 = d5;
            var d6 = memberService.GetMemberDto(usermail, userpassword).PhoneNumber;
            ViewBag.d6 = d6;
            var d7 = memberService.GetMemberDto(usermail, userpassword).Email;
            ViewBag.d7 = d7;
            var valueId = memberService.GetMemberDto(usermail, userpassword);
            var d8 = bookRecordService.GetDetail(valueId.Id).Count();
            ViewBag.d8 = d8;
            var d9 = messageService.GetByMailReceiver(usermail).Count();
            ViewBag.d9 = d9;
            var d10 = announcementService.GetAll().Count();
            ViewBag.d10 = d10;
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
            var value = bookRecordService.GetMembersBook(user.Id);
            return View(value);
        }
        public ActionResult Announcements()
        {
            var Announcement = announcementService.GetAll();
            return View(Announcement);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Login");
        }
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        public PartialViewResult Partial2()
        {
            var usermail = (string)Session["Mail"];
            var userpassword = (string)Session["Password"];
            var getmember = memberService.GetMemberDto(usermail, userpassword);
            return PartialView("Partial2",getmember);
        }
    }
}