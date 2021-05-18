using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MvcLibraryProject.Controllers
{
    public class MemberController : Controller
    {
        IMemberService _memberManager;
        IBookRecordService _bookRecordManager;
        public MemberController(IMemberService memberManager, IBookRecordService bookRecordManager)
        {
            _memberManager = memberManager;
            _bookRecordManager = bookRecordManager;
        }

        // GET: Member
        public ActionResult Index(int page=1)
        {
            var value = _memberManager.GetAll().ToPagedList(page,3);
            return View(value);
        }
        [HttpGet]
        public ActionResult AddMember()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMember(Member member)
        {
            if (!ModelState.IsValid)
            {
                return View("AddMember");
            }
            _memberManager.Add(member);
            return View();
        }
        public ActionResult DeleteMember(int id)
        {
            _memberManager.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult GetMember(int id)
        {
            var value = _memberManager.GetById(id);
            return View("GetMember", value);
        }
        public ActionResult UpdateMember(Member member)
        {
            _memberManager.Update(member);
            return RedirectToAction("Index");
        }
        public ActionResult MembersBooks(int id)
        {

            var value = _bookRecordManager.GetMembersBook(id);
            var membername = _memberManager.GetById(id).Name;
            var memberlastname = _memberManager.GetById(id).LastName;
            ViewBag.dgr1 = membername;
            ViewBag.dgr2 = memberlastname;
            return View(value);
        }
        
    }
}