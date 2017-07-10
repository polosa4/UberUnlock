using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UberUnlock.Models;
using UberUnlock.ViewModel;
using UberUnlock.ViewModels;

namespace UberUnlock.Controllers
{
    public class BasketController : Controller
    {
        // GET: Basket
        public ActionResult Index()
        {
            Basket basket = Basket.GetBasket();
            BasketViewModel viewModel = new BasketViewModel
            {
                BasketLines = basket.GetBasketLines(),
                TotalCost = basket.GetTotalCost()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToBasket(MultipleModelInOneView viewModel, FormCollection form)
        {
            Basket basket = Basket.GetBasket();
            int quantity = Int32.Parse(form["quantity"]);
            basket.AddToBasket(viewModel.Products.ID, quantity, viewModel.Orders.IMEI);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateBasket(BasketViewModel viewModel)
        {
            Basket basket = Basket.GetBasket();
            basket.UpdateBasket(viewModel.BasketLines);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult RemoveLine(int id)
        {
            Basket basket = Basket.GetBasket();
            basket.RemoveLine(id);
            return RedirectToAction("Index");
        }

        public PartialViewResult Summary()
        {
            Basket basket = Basket.GetBasket();
            BasketSummaryViewModel viewModel = new BasketSummaryViewModel
            {
                NumberOfItems = basket.GetNumberOfItems(),
                TotalCost = basket.GetTotalCost()
            };
            return PartialView(viewModel);
        }
    }
}