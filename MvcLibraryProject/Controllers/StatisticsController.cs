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
        public ActionResult Index()
        {
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
    }
}