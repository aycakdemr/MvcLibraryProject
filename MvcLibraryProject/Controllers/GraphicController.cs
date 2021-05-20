using Business.Abstract;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibraryProject.Controllers
{
    public class GraphicController : Controller
    {
        // GET: Graphic
        IBookService bookService;

        public GraphicController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VisualizeBookRecord()
        {
            return Json(liste());
        }
        public List<Graphic> liste()
        {
            List<Graphic> cs = new List<Graphic>();
            cs.Add(new Graphic()
            {
                BookCount = bookService.GetAll().Count,
                Publisher = bookService.BestPublishing()

            });
            return cs;
        }
    }
}