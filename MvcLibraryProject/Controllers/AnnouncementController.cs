using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibraryProject.Controllers
{
    public class AnnouncementController : Controller
    {
        IAnnouncementService announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            this.announcementService = announcementService;
        }



        // GET: Announcement
        public ActionResult Index()
        {
            var value = announcementService.GetAll();
            return View(value);
        }
        [HttpGet]
        public ActionResult NewAnnouncement()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewAnnouncement(Announcement announcement)
        {
            announcementService.Add(announcement);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAnnouncement(int id)
        {
           announcementService.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult AnnouncementDetail(int id)
        {
            var value = announcementService.GetById(id);
            return View(value);
        }
        public ActionResult UpdateAnnouncement(Announcement announcement)
        {
            announcementService.Update(announcement);
            return RedirectToAction("Index");
        }
        
    }
}