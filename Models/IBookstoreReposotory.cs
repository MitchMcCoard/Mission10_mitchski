using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission10_mitchski.Models
{
    public interface IBookstoreReposotory
    {
        IQueryable<Book> Books { get; }
    }
}
