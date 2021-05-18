using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibraryProject.Controllers
{
    public class BookRecordController : Controller
    {
        IBookRecordService _bookRecordService;
        IBookService _bookService;
        IMemberService _memberService;
        IStaffService _staffService;
        public BookRecordController(IBookRecordService bookRecordService, IBookService bookService,IMemberService memberService,IStaffService staffService)
        {
            _bookRecordService = bookRecordService;
            _bookService = bookService;
            _memberService = memberService;
            _staffService = staffService;
        }

        // GET: BookRecord
        public ActionResult Index()
        {
            var value = _bookRecordService.GetDetailStatusFalse();
            return View(value);
        }
        [HttpGet]
        public ActionResult Lend()  //ödünç verme
        {
            List<SelectListItem> deger1 = (from i in _memberService.GetAll()
                                           select new SelectListItem
                                           {
                                               Text = i.Name +" "+i.LastName,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in _bookService.GetByStatusTrue()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            List<SelectListItem> deger3 = (from i in _staffService.GetAll()
                                           select new SelectListItem
                                           {
                                               Text = i.StaffName,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult Lend(BookRecord bookRecord)
        {
            var d1 = _memberService.GetById(bookRecord.MemberId);
            var d2 = _bookService.GetById(bookRecord.BookId);
            var d3 = _staffService.GetById(bookRecord.StaffId);
            bookRecord.MemberId = d1.Id;
            bookRecord.BookId = d2.Id;
            bookRecord.StaffId = d3.Id;
            _bookRecordService.Add(bookRecord);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddBookRecord()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBookRecord(BookRecord bookRecord)
        {
            _bookRecordService.Add(bookRecord);
            return View();
        }
        public ActionResult GetBookRecord(int id)
        {
            var value = _bookRecordService.GetById(id);
            List<SelectListItem> deger1 = (from i in _bookService.GetAll()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in _memberService.GetAll()
                                           select new SelectListItem
                                           {
                                               Text = i.Name + ' ' + i.LastName,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            List<SelectListItem> deger3 = (from i in _staffService.GetAll()
                                           select new SelectListItem
                                           {
                                               Text = i.StaffName,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            DateTime d1 = DateTime.Parse(value.GivingDate.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr4 = d3.TotalDays;

            return View("GetBookRecord", value);
        }
        public ActionResult UpdateBookRecord(BookRecord bookRecord)
        {
            _bookRecordService.Update(bookRecord);
            return RedirectToAction("Index");
        }
    }
}