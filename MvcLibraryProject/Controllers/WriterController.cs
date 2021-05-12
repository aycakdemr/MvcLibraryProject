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

        public WriterController(IWriterService writerManager)
        {
            this.writerManager = writerManager;
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
    }
}