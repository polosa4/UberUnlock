using System;
using System.Linq;
using System.Web.Mvc;
using UberUnlock.DAL;

namespace UberUnlock
{
    internal class CategoryFilter :IActionFilter
    {
        public CategoryFilter()
        {
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            using (StoreContext db = new StoreContext())
            {
                filterContext.Controller.ViewData["Categories"] = db.Categories.ToList();
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
        }
    }
}