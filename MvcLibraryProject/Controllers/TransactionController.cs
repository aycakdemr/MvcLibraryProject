using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibraryProject.Controllers
{
    public class TransactionController : Controller
    {
        IBookRecordService _bookRecordService;

        public TransactionController(IBookRecordService bookRecordService)
        {
            _bookRecordService = bookRecordService;
        }

        // GET: Transaction
        public ActionResult Index()
        {
            var value = _bookRecordService.GetDetailStatusTrue();
            return View(value);
        }
    }
}