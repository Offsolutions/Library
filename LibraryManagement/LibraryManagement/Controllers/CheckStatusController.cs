using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers
{
    public class CheckStatusController : Controller
    {
       
        dbcontext db = new dbcontext();
        // GET: CheckStatus
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string id)
        {
            return View(db.IssueBooks.Where(x => x.IdCard == id).ToList());
        }
        public ActionResult check()
        {
            return View();
        }
        [HttpPost]
        public ActionResult check(string id)
        {

            Membership mm = db.Memberships.FirstOrDefault(x => x.Idnumber == id);
            if(mm!=null)
            {
                Session["id"] = mm.Mid;
                return View(db.IssueBooks.Where(x => x.IdCard == id).ToList());
            }
            else
            {
                TempData["Danger"] = "Card Number Not Found";
                return View();
            }
            
        }
        public ActionResult Add(int id)
        {
            int ids = Convert.ToInt32(id);
            db.Configuration.ProxyCreationEnabled = false;
            Membership member = db.Memberships.Find(id);

          

            return PartialView("~/Views/CheckStatus/AddBook.cshtml", member);
        }
        [HttpPost]
        public ActionResult CreateBook([Bind(Include ="Mid,IdCard,Bid,IssueDate,LastDate,Fine,Status")] IssueBook books,int bookid)
        {
            
            if (ModelState.IsValid)
            {
                Books book = db.Books.Find(bookid);
                Setting ss = db.Settings.First();
                if (book.BookCopies > ss.BookAlert)
                {
                    books.Bid = bookid;
                    books.Status = "Issue";
                    books.fine = 0;
                    db.IssueBooks.Add(books);
                    db.SaveChanges();
                    #region Update Book Quantity

                    book.BookCopies = book.BookCopies - 1;

                    db.Entry(book).State = EntityState.Modified;
                    db.SaveChangesAsync();
                    #endregion
                    TempData["Success"] = "Issue Book Successfully";
                }
                else
                {
                    TempData["Success"] = "Quantity Not Sufficient";
                    return RedirectToAction("add",new { id=books.Mid});
                }

                
            }
            return RedirectToAction("add", new { id = books.Mid }); 
        }
        public ActionResult IssueList()
        {
            return View(db.IssueBooks.ToList());
        }
        public ActionResult ReturnBook(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            IssueBook books = new IssueBook();
            Setting ss = db.Settings.FirstOrDefault();
            books = db.IssueBooks.Where(x => x.Sid == id).First();
            DateTime todaydate = System.DateTime.Now;
            var diff = (todaydate.Day- books.LastDate.Day);
            if (Convert.ToInt32(diff) < 0)
            {
                books.returnfine = 0;
            }
            else
            {
                books.returnfine = ss.Fine * Convert.ToInt32(diff);
            }

            return PartialView("~/Views/CheckStatus/ReturnBook.cshtml", books);
        }
        public ActionResult Return([Bind(Include = "Sid,Mid,IdCard,Bid,IssueDate,LastDate,ReturnDate,fine,Status,returnfine")] IssueBook issue)
        {
            if (ModelState.IsValid)
            {
                if (issue.returnfine == issue.fine)
                {
                    issue.Status = "Return";
                    db.Entry(issue).State = EntityState.Modified;
                    db.SaveChanges();

                    if (issue.ReturnDate == null)
                    {
                        Books bb = db.Books.Find(issue.Bid);
                        bb.BookCopies = bb.BookCopies + 1;
                        db.Entry(bb).State = EntityState.Modified;
                        db.SaveChanges();
                        TempData["Success"] = "Update Records Successfully";

                    }
                    else
                    {
                        TempData["Success"] = "Return Book Successfully";

                    }
                }
                else
                {
                    TempData["Success"] = "Deposit Fine";
                }
                
                
                return RedirectToAction("check");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            IssueBook books = new IssueBook();
            Setting ss = db.Settings.FirstOrDefault();
            books = db.IssueBooks.Where(x => x.Sid == id).First();
            DateTime todaydate = System.DateTime.Now;
            var diff = (todaydate.Day - books.LastDate.Day);
            books.fine = ss.Fine * Convert.ToInt32(diff);

            return PartialView("~/Views/CheckStatus/ReturnBook.cshtml", books);

        }
     }
}