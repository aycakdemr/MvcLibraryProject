using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibraryProject.Controllers
{
    [AllowAnonymous]
    public class SettingController : Controller
    {
        // GET: Settings
        IAdminService adminService;

        public SettingController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        public ActionResult Index()
        {
            var value = adminService.GetAll();
            return View(value);

        }
        [HttpGet]
        public ActionResult NewAdmin()
        {
            
            return View();

        }
        [HttpPost]
        public ActionResult NewAdmin(Admin admin)
        {
            adminService.Add(admin);
            return RedirectToAction("Index");

        }
        public ActionResult DeleteAdmin(int id)
        {
            adminService.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GetAdmin(int id)
        {
            var value = adminService.GetById(id);
            return View("GetAdmin", value);
        }
        [HttpPost]
        public ActionResult UpdateAdmin(Admin admin)
        {
            adminService.Update(admin);
            return RedirectToAction("Index");
        }
    }
}