using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission10_mitchski.Infrastructure;
using Mission10_mitchski.Models;

namespace Mission10_mitchski.Pages
{
    public class CheckoutModel : PageModel
    {
        private IBookstoreReposotory repo { get; }

        public CheckoutModel(IBookstoreReposotory temp)
        {
            repo = temp;
        }

        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            //Set the Attribute ReturnUrl to the return url passed in the hidden field which uses
            //the model in UrlExtensions, or if it's null, set it to "/"
            ReturnUrl = returnUrl ?? "/";   
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }

        public IActionResult OnPost(int BookId, string returnUrl)
        {
            //Load the book from the repo which matches the id passed
            Book bk = repo.Books.FirstOrDefault(x => x.BookId == BookId);
            
            //If the basket exsists, use that. Otherwise, create a new basket
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
            basket.AddItem(bk, 1);

            //Save the basket to the session (in the json page)
            HttpContext.Session.SetJson("basket", basket);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

    }
}
