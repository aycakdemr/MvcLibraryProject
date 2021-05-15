using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibraryProject.Controllers
{
    public class StaffController : Controller
    {
        IStaffService _staffManager;

        public StaffController(IStaffService staffManager)
        {
            _staffManager = staffManager;
        }

        // GET: Staff
        public ActionResult Index()
        {
            var value = _staffManager.GetAll();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddStaff()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStaff(Staff staff)
        {
            
            _staffManager.Add(staff);
            return View();
        }
        public ActionResult DeleteStaff(int id)
        {
            _staffManager.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult GetStaff(int id)
        {
            var value = _staffManager.GetById(id);
            return View("GetStaff", value);
        }
        public ActionResult UpdateStaff(Staff staff)
        {
            _staffManager.Update(staff);
            return RedirectToAction("Index");
        }
    }
}