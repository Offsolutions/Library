using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers
{
    public class DashBoardController : Controller
    {
        dbcontext db = new dbcontext();
        // GET: DashBoard
        public ActionResult Index()
        {
            Dahsboard db = new Dahsboard();
            return View(db);
        }
    }
}