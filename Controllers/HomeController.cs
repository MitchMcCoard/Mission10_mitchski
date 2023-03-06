using Microsoft.AspNetCore.Mvc;
using Mission10_mitchski.Models;
using Mission10_mitchski.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission10_mitchski.Controllers
{
    public class HomeController : Controller
    {
        //private BookstoreContext context { get; set; }

        ////Constructor
        //public HomeController(BookstoreContext temp) => context = temp;

        private IBookstoreReposotory repo;

        public HomeController(IBookstoreReposotory temp)
        {
            repo = temp;
        }

        public IActionResult Index(string category, int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModels
            {
                Books = repo.Books
                .Where(x => x.Category == category || category == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumOfBooks = 
                        (category == null 
                        ? repo.Books.Count() 
                        : repo.Books.Where(x => x.Category == category).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }

            };

            return View(x);
        }
    }
}
