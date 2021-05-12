using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibraryProject.Controllers
{
    public class BookController : Controller
    {
        IBookService bookManager;
        ICategoryService categoryManager;
        IWriterService writerManager;


        public BookController(IBookService bookManager, ICategoryService categoryManager, IWriterService writerManager)
        {
            this.bookManager = bookManager;
            this.categoryManager = categoryManager;
            this.writerManager = writerManager;
        }

        // GET: Book
        public ActionResult Index(String p)
        {
              var books = bookManager.GetDetails();
            

            if (!string.IsNullOrEmpty(p))
            {
                 books = bookManager.SearchBook(p);
            }
            return View(books);
        }
        [HttpGet]
        public ActionResult AddBook()
        {
            List<SelectListItem> deger1 = (from i in categoryManager.GetAll()
                                           select new SelectListItem
                                           {
                                               Text = i.CategoryName,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2= (from i in writerManager.GetAll()
                                           select new SelectListItem
                                           {
                                               Text = i.WriterName+' '+i.WriterLastName,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            return View();
        }
        [HttpPost]
        public ActionResult AddBook(Book book)
        {
            var ktg = categoryManager.GetById(book.CategoryId);
            var wrt = writerManager.GetById(book.WriterId);
            book.Category = ktg;
            book.Writer = wrt;
            bookManager.Add(book);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteBook(int id)
        {
            bookManager.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult GetBook(int id)
        {
            var value = bookManager.GetById(id);
            List<SelectListItem> deger1 = (from i in categoryManager.GetAll()
                                           select new SelectListItem
                                           {
                                               Text = i.CategoryName,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in writerManager.GetAll()
                                           select new SelectListItem
                                           {
                                               Text = i.WriterName + ' ' + i.WriterLastName,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            return View("GetBook", value);
        }
        public ActionResult UpdateBook(Book book)
        {
            bookManager.Update(book);
            return RedirectToAction("Index");
        }
    }
}