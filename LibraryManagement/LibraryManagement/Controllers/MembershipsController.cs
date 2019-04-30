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
    public class MembershipsController : Controller
    {
        private dbcontext db = new dbcontext();

        // GET: Memberships
        public async Task<ActionResult> Index()
        {
            var memberships = db.Memberships.Include(m => m.Batches).Include(m => m.Departments);
            return View(await memberships.ToListAsync());
        }

        // GET: Memberships/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membership membership = await db.Memberships.FindAsync(id);
            if (membership == null)
            {
                return HttpNotFound();
            }
            return View(membership);
        }

        // GET: Memberships/Create
        public ActionResult Create()
        {
            ViewBag.Bid = new SelectList(db.Batches, "Bid", "BatchNumber");
            ViewBag.Did = new SelectList(db.Departments, "Did", "DepartmentName");
            return View();
        }

        // POST: Memberships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Mid,Did,Bid,Rollno,StudentName,Contact,Idnumber,Status")] Membership membership)
        {
            if (ModelState.IsValid)
            {
                db.Memberships.Add(membership);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Bid = new SelectList(db.Batches, "Bid", "BatchNumber", membership.Bid);
            ViewBag.Did = new SelectList(db.Departments, "Did", "DepartmentName", membership.Did);
            return View(membership);
        }

        // GET: Memberships/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membership membership = await db.Memberships.FindAsync(id);
            if (membership == null)
            {
                return HttpNotFound();
            }
            ViewBag.Bid = new SelectList(db.Batches, "Bid", "BatchNumber", membership.Bid);
            ViewBag.Did = new SelectList(db.Departments, "Did", "DepartmentName", membership.Did);
            return View(membership);
        }

        // POST: Memberships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Mid,Did,Bid,Rollno,StudentName,Contact,Idnumber,Status")] Membership membership)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membership).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Bid = new SelectList(db.Batches, "Bid", "BatchNumber", membership.Bid);
            ViewBag.Did = new SelectList(db.Departments, "Did", "DepartmentName", membership.Did);
            return View(membership);
        }

        // GET: Memberships/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membership membership = await db.Memberships.FindAsync(id);
            if (membership == null)
            {
                return HttpNotFound();
            }
            return View(membership);
        }

        // POST: Memberships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Membership membership = await db.Memberships.FindAsync(id);
            db.Memberships.Remove(membership);
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
