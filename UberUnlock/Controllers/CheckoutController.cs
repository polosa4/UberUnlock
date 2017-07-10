using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UberUnlock.Models;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using Braintree;
using Microsoft.AspNet.Identity;
using UberUnlock.DAL;
using UberUnlock.ViewModel;

namespace UberUnlock.Controllers
{
    public class CheckoutController : Controller
    {
        protected StoreContext db = new StoreContext();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private readonly BraintreeService _emailService;
        private readonly IBraintreeGateway _braintreeGateway;
        public ActionResult Index()
        {
            if (!Request.Cookies.AllKeys.Contains("cart"))
                return RedirectToAction("Index", "Basket");
            MultipleModelInOneView model = new MultipleModelInOneView();
            Checkout modelOne = new Checkout();
            if (User.Identity.IsAuthenticated)
            {
                ApplicationDbContext entities = new ApplicationDbContext();
                var user = entities.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
                if (user != null)
                {
                    modelOne.NameOnCard = user.UserName + " " + user.LastName;
                    modelOne.ContactEmail = user.Email;
                }
            }

            return View(modelOne);
        }
        // GET: Checkout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(Checkout model)
        {
            //Check if the model-state is valid -- this will catch anytime someone hacks your client-side validation (If Valid then Transaction may begin)
            if (ModelState.IsValid)
            {
                var gateway = new BraintreeGateway
                {
                    Environment = Braintree.Environment.SANDBOX,
                    MerchantId = ConfigurationManager.AppSettings["Braintree.MerchantID"],
                    PublicKey = ConfigurationManager.AppSettings["Braintree.PublicKey"],
                    PrivateKey = ConfigurationManager.AppSettings["Braintree.PrivateKey"]
                };

                CustomerSearchRequest searchRequest = new CustomerSearchRequest();
                searchRequest.Email.Is(model.ContactEmail);

                Customer c = null;
                var existingCustomers = await gateway.Customer.SearchAsync(searchRequest);
                if (existingCustomers.Ids.Any())
                {
                    c = existingCustomers.FirstItem;
                }
                else
                {
                    CustomerRequest newCustomer = new CustomerRequest();
                    newCustomer.Email = model.ContactEmail;
                    var customerResult = await gateway.Customer.CreateAsync(newCustomer);
                    if (customerResult.IsSuccess())
                    {
                        c = customerResult.Target;
                    }
                    else
                    {
                        throw new Exception(customerResult.Errors.All().First().Message);
                    }
                }


                string token;

                CreditCardRequest card = new CreditCardRequest();
                card.Number = model.CreditCardNumber;
                card.CVV = model.CreditCardVerificationValue;
                card.ExpirationMonth = model.CreditCardExpirationMonth.ToString().PadLeft(2, '0');
                card.ExpirationYear = model.CreditCardExpirationYear.ToString();
                card.CardholderName = model.NameOnCard;
                card.CustomerId = c.Id;
                var cardResult = await gateway.CreditCard.CreateAsync(card);
                if (cardResult.IsSuccess())
                {


                    token = cardResult.Target.Token;
                }
                else
                {
                    throw new Exception(cardResult.Errors.All().First().Message);
                }


                //HttpCookie cartCookie = Request.Cookies["cart"];
                //var order = db.Orders.Find(int.Parse(cartCookie.Value));

                Braintree.TransactionRequest transaction = new TransactionRequest();
                
                transaction.Amount = new ViewModel.BasketSummaryViewModel().TotalCost; ;
                transaction.CustomerId = c.Id;
                transaction.PaymentMethodToken = token;
                var saleResult = await gateway.Transaction.SaleAsync(transaction);
                if (saleResult.IsSuccess())
                {
                    return RedirectToAction("Index", "Home");
                    //Need to create a Receipt Controller, as well as a View to show receipt, send email confirmation.
                    //Check Joe's Github for inspiration
                }

            }
            return View(model);
        }
    }
}