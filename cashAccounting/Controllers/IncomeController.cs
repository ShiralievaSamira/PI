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
    public class IncomeController : Controller
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

        public ActionResult GetIncomes(string filter = null)
        {
            var incomesList = db.Incomes.Where(x => x.User.UserName == User.Identity.Name);
            if (filter != null)
            {
                incomesList = incomesList.Where(w => w.Category.Contains(filter));
            }
            return View("GetIncome",incomesList.ToList());
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Income income = await db.Incomes.FindAsync(id);
            if (income == null)
            {
                return HttpNotFound();
            }
            return View(income);
        }

        // GET: Income/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Sum,Category,DateIncome,Comment,User")] Income income)
        {
            var user = db.Users.First(u => u.UserName == User.Identity.Name);
            income.User = user;
            if (ModelState.IsValid)
            {
                db.Incomes.Add(income);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(income);
        }

        // GET: Income/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Income income = await db.Incomes.FindAsync(id);
            if (income == null)
            {
                return HttpNotFound();
            }
            return View(income);
        }

        // POST: Income/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Sum,Category,DateIncome,Comment,UserId")] Income income)
        {
            if (ModelState.IsValid)
            {
                db.Entry(income).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(income);
        }

        // GET: Income/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Income income = await db.Incomes.FindAsync(id);
            if (income == null)
            {
                return HttpNotFound();
            }
            return View(income);
        }

        // POST: Income/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Income income = await db.Incomes.FindAsync(id);
            db.Incomes.Remove(income);
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
