using Business.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibraryProject.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        IMemberService memberManager;
        IBookService bookManager;
        ILateFeeService latefeeManager;
        ICategoryService categoryManager;
        IContactService contactManager;
        public StatisticsController(IMemberService memberManager,
            IBookService bookManager, ILateFeeService latefeeManager,
            ICategoryService categoryManager, IContactService contactManager)
        {
            this.memberManager = memberManager;
            this.bookManager = bookManager;
            this.latefeeManager = latefeeManager;
            this.categoryManager = categoryManager;
            this.contactManager = contactManager;
        }

        public ActionResult Index()
        {
            var deger1 = memberManager.GetAll().Count();
            var deger2 = bookManager.GetAll().Count();
            var deger3 = bookManager.GetByStatusFalse().Count();
            var deger4 = latefeeManager.TotalAmaount();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            
            return View();
        }
        public ActionResult Air()
        {
            return View();
        }
        public ActionResult AirCard()
        {
            return View();
        }
        public ActionResult Gallery()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddImage(HttpPostedFileBase httpPostedFile)
        {
            if (httpPostedFile.ContentLength > 0)
            {
                string imagepath = Path.Combine(Server.MapPath("~/web2/resimler"), Path.GetFileName(httpPostedFile.FileName));
                httpPostedFile.SaveAs(imagepath);
            }
            return RedirectToAction("Gallery");
        }
        public ActionResult LinqCard()
        {
            var deger1 = bookManager.GetAll().Count();
            var deger2 = memberManager.GetAll().Count();
            var deger3 = latefeeManager.TotalAmaount();
            var deger4 = bookManager.GetByStatusFalse().Count();
            var deger5 = categoryManager.GetAll().Count();
            var deger9 = bookManager.BestPublishing();
            var deger11 = contactManager.GetAll().Count();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            ViewBag.dgr5 = deger5;
            ViewBag.dgr9 = deger9;
            ViewBag.dgr11 = deger11;
            return View();
        }
    }
}