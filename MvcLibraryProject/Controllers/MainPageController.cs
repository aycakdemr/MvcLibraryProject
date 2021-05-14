using Business.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibraryProject.Controllers
{
    public class MainPageController : Controller
    {
        IBookService bookService;
        IAboutService aboutService;
        IContactService contactService;
        public MainPageController(IBookService bookService,IAboutService aboutService, IContactService contactService)
        {
            this.bookService = bookService;
            this.aboutService = aboutService;
            this.contactService = contactService;
        }

        // GET: MainPage
        [HttpGet]
        public ActionResult Index()
        {
            MainPageDto dto = new MainPageDto();
            dto.deger1 = bookService.GetAll();
            dto.deger2 = aboutService.GetAll();
            return View(dto);
        }
        [HttpPost]
        public ActionResult Index(Contact contact)
        {
            contactService.Add(contact);
            return RedirectToAction("Index");
        }
    }
}