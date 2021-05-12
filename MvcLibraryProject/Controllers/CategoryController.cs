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
    public class CategoryController : Controller
    {
        // GET: Category
        ICategoryService categoryManager;

        public CategoryController(ICategoryService categoryManager)
        {
            this.categoryManager = categoryManager;
        }

        public ActionResult Index()
        {
            var value = categoryManager.GetAll();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            categoryManager.Add(category);
            return View();
        }
        public ActionResult DeleteCategory(int id)
        {
            categoryManager.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult GetCategory(int id)
        {
            var value = categoryManager.GetById(id);
            return View("GetCategory",value);
        }
        public ActionResult UpdateCategory(Category category)
        {
            categoryManager.Update(category);
            return RedirectToAction("Index");
        }
    }
}