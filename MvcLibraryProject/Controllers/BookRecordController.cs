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

        public BookRecordController(IBookRecordService bookRecordService)
        {
            _bookRecordService = bookRecordService;
        }

        // GET: BookRecord
        public ActionResult Index()
        {
            var value = _bookRecordService.GetDetails();
            return View(value);
        }
        public ActionResult Lend()  //ödünç verme
        { 
            return View();
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
    }
}