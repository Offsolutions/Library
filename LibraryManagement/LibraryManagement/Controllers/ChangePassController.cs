using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers
{
    public class ChangePassController : Controller
    {
        SQLHelper objsql = new SQLHelper();
        // GET: ChangePass
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string password)
        {
            string a = HttpContext.User.Identity.Name;
            try
            {

                objsql.ExecuteNonQuery("update tblreceptionists set password='" + password + "' where rid='" + a + "'");
                TempData["Success"] = "Password Change Successfully";
                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }
    }
}