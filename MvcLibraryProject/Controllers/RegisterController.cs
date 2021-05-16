using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibraryProject.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        IMemberService memberManager;

        public RegisterController(IMemberService memberManager)
        {
            this.memberManager = memberManager;
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Member member)
        {
            memberManager.Add(member);
            return View();
        }
    }
}