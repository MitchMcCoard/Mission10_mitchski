using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission10_mitchski.Models.ViewModels
{
    public class BooksViewModels
    {
        //This is a class for aggregating all of the neccessary inputs needed for a specific view
        //In this case, the index page to view all of the books
        public IQueryable<Book> Books { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
