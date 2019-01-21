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
    public class ConsumptionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
            //return View(GetIncomes());
        }

        [HttpPost]
        public ActionResult Index(string filter)
        {
            ViewBag.filter = filter;
            return View();
        }

        public ActionResult GetConsumptions(string filter = null)
        {
            var consumptionsList = db.Consumptions.Where(x => x.User.UserName == User.Identity.Name);
            if (filter != null)
            {
                consumptionsList = consumptionsList.Where(w => w.Category.Contains(filter));
            }
            return View("GetConsumption", consumptionsList.ToList());
        }

        // GET: Consumption/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consumption consumption = await db.Consumptions.FindAsync(id);
            if (consumption == null)
            {
                return HttpNotFound();
            }
            return View(consumption);
        }

        // GET: Consumption/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Consumption/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Sum,Category,DateConsumption,Comment,User")] Consumption consumption)
        {
            var user = db.Users.First(u => u.UserName == User.Identity.Name);
            consumption.User = user;
            if (ModelState.IsValid)
            {
                db.Consumptions.Add(consumption);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(consumption);
        }

        // GET: Consumption/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consumption consumption = await db.Consumptions.FindAsync(id);
            if (consumption == null)
            {
                return HttpNotFound();
            }
            return View(consumption);
        }

        // POST: Consumption/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Sum,Category,DateConsumption,Comment,UserId")] Consumption consumption)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consumption).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(consumption);
        }

        // GET: Consumption/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consumption consumption = await db.Consumptions.FindAsync(id);
            if (consumption == null)
            {
                return HttpNotFound();
            }
            return View(consumption);
        }

        // POST: Consumption/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Consumption consumption = await db.Consumptions.FindAsync(id);
            db.Consumptions.Remove(consumption);
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
