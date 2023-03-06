using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission10_mitchski.Models.ViewModels
{
    public class PageInfo
    {

        public int TotalNumOfBooks { get; set; }

        public int BooksPerPage { get; set; }

        public int CurrentPage { get; set; }

        //How many pages do we need?
        public int TotalPages => (int)Math.Ceiling((double)TotalNumOfBooks / BooksPerPage);
    }
}
