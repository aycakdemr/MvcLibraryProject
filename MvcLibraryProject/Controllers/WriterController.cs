using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibraryProject.Controllers
{
    public class WriterController : Controller
    {
        IWriterService writerManager;
        IBookService bookManager;
        public WriterController(IWriterService writerManager, IBookService bookManager)
        {
            this.writerManager = writerManager;
            this.bookManager = bookManager;
        }

        // GET: Writers
        public ActionResult Index()
        {
            var value = writerManager.GetAll();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            writerManager.Add(writer);
            return View();
        }
        public ActionResult DeleteWriter(int id)
        {
            writerManager.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult GetWriter(int id)
        {
            var value = writerManager.GetById(id);
            return View("GetWriter", value);
        }
        public ActionResult UpdateWriter(Writer writer)
        {
            writerManager.Update(writer);
            return RedirectToAction("Index");
        }
        public ActionResult WritersBooks(int id)
        {
            var writer = bookManager.GetWritersBook(id);
            var writername = writerManager.GetById(id).WriterName;
            var writerlastname = writerManager.GetById(id).WriterLastName;
            ViewBag.dgr1 = writername;
            ViewBag.dgr2 = writerlastname;
            return View(writer);
        }
        
    }
}