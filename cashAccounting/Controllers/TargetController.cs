using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cashAccounting.Models;

namespace cashAccounting.Controllers
{
    [Authorize]
    public class TargetController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public async Task<ActionResult> Index()
        {
            return View(await db.Targets.Where(t => t.User.UserName == User.Identity.Name).ToListAsync());
        }

        // GET: Target/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Target target = await db.Targets.FindAsync(id);
            if (target == null)
            {
                return HttpNotFound();
            }
            return View(target);
        }

        // GET: Target/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Target/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Category,Name,Currency,StartDate,FinalDate,MonthlyFee,Comment,UserId")] Target target)
        {
            target.User = db.Users.First(u => u.UserName == User.Identity.Name);
            if (ModelState.IsValid)
            {
                db.Targets.Add(target);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(target);
        }

        // GET: Target/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Target target = await db.Targets.FindAsync(id);
            if (target == null)
            {
                return HttpNotFound();
            }
            return View(target);
        }

        // POST: Target/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Category,Name,Currency,StartDate,FinalDate,MonthlyFee,Comment,UserId")] Target target)
        {
            if (ModelState.IsValid)
            {
                db.Entry(target).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(target);
        }

        // GET: Target/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Target target = await db.Targets.FindAsync(id);
            if (target == null)
            {
                return HttpNotFound();
            }
            return View(target);
        }

        // POST: Target/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Target target = await db.Targets.FindAsync(id);
            db.Targets.Remove(target);
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
