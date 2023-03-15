using Microsoft.AspNetCore.Mvc;
using Mission10_mitchski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission10_mitchski.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Basket cart { get; set; }
        public CartSummaryViewComponent(Basket cartService)
        {
            cart = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
