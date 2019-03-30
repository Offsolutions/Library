using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers
{
    public class BooksController : Controller
    {
        private dbcontext db = new dbcontext();
        public static string img = "";
        // GET: Books
        public async Task<ActionResult> Index()
        {
            var books = db.Books.Include(b => b.Authors).Include(b => b.Categories).Include(b => b.Publishers);
            return View(await books.ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books books = await db.Books.FindAsync(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.Aid = new SelectList(db.Authors, "Aid", "Name");
            ViewBag.Cid = new SelectList(db.Categories, "Cid", "Name");
            ViewBag.Pid = new SelectList(db.Publishers, "Pid", "Name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "boid,Name,ISBN,Cid,Aid,Pid,BookCopies,Price,Copyright,DateRecieved,Notes,Image")] Books books, HttpPostedFileBase file, Helper help)
        {
            if (ModelState.IsValid)
            {
                books.Image = help.uploadfile(file);
                db.Books.Add(books);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Aid = new SelectList(db.Authors, "Aid", "Name", books.Aid);
            ViewBag.Cid = new SelectList(db.Categories, "Cid", "Name", books.Cid);
            ViewBag.Pid = new SelectList(db.Publishers, "Pid", "Name", books.Pid);
            return View(books);
        }

        // GET: Books/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books books = await db.Books.FindAsync(id);
            img = books.Image;
            if (books == null)
            {
                return HttpNotFound();
            }
            ViewBag.Aid = new SelectList(db.Authors, "Aid", "Name", books.Aid);
            ViewBag.Cid = new SelectList(db.Categories, "Cid", "Name", books.Cid);
            ViewBag.Pid = new SelectList(db.Publishers, "Pid", "Name", books.Pid);
            return View(books);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "boid,Name,ISBN,Cid,Aid,Pid,BookCopies,Price,Copyright,DateRecieved,Notes,Image")] Books books, HttpPostedFileBase file, Helper help)
        {
            if (ModelState.IsValid)
            {
                books.Image = file != null ? help.uploadfile(file) : img;
                db.Entry(books).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Aid = new SelectList(db.Authors, "Aid", "Name", books.Aid);
            ViewBag.Cid = new SelectList(db.Categories, "Cid", "Name", books.Cid);
            ViewBag.Pid = new SelectList(db.Publishers, "Pid", "Name", books.Pid);
            return View(books);
        }

        // GET: Books/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books books = await db.Books.FindAsync(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Books books = await db.Books.FindAsync(id);
            db.Books.Remove(books);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
