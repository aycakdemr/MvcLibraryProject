using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcLibraryProject.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        IAdminService adminService;

        public AdminLoginController(IAdminService adminService)
        {
            this.adminService = adminService;
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin)
        {

            if ((adminService.Login(admin)))
            {
                
                FormsAuthentication.SetAuthCookie(admin.Email, false);
                Session["Email"] = admin.Email.ToString();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return View();
            }
            
        }
    }
}