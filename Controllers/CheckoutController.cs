using Microsoft.AspNetCore.Mvc;
using Mission10_mitchski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission10_mitchski.Controllers
{
    public class CheckoutController : Controller
    {
        private ITransactionRepository repo { get; set; }
        private Basket basket { get; set; }

        public CheckoutController(ITransactionRepository temp, Basket b)
        {
            repo = temp; 
            basket = b;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Transaction());
        }

        [HttpPost]
        public IActionResult Checkout(Transaction transaction)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty!");
            }

            if (ModelState.IsValid)
            {
                transaction.LineItems = basket.Items.ToArray();
                repo.SaveTransaction(transaction);
                basket.ClearBasket();

                return RedirectToPage("/TransactionCompleted");
            }
            else
            {
                return View();
            }

        }
    }
}
