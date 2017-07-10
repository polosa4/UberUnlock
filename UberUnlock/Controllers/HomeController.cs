using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UberUnlock.DAL;

namespace UberUnlock.Controllers
{
    public class HomeController : Controller
    {
        private StoreContext db = new StoreContext();
        public async Task<ActionResult> Index()
        {
            return View(db.Products.OrderBy(c => c.Name).ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Instructions()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}