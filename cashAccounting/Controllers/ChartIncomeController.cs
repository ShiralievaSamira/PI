using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using cashAccounting.Models;
using Newtonsoft.Json;


namespace cashAccounting.Controllers
{
    [Authorize]
    public class ChartIncomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            try
            {
                ViewBag.DataPoints = JsonConvert.SerializeObject(db.Incomes.ToList(), _jsonSetting);

                return View();
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                return View("Error");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return View("Error");
            }
        }

        public JsonResult GetIncome()
        {
            var incomes = db.Incomes.Where(c => c.User.UserName == User.Identity.Name).OrderBy(i => i.DateIncome);

            return Json(incomes.ToList().Select(c => new { date = $"{c.DateIncome.Year} {c.DateIncome.Month} {c.DateIncome.Day}", price = c.Sum }), JsonRequestBehavior.AllowGet);
        }
        JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
    }
}
