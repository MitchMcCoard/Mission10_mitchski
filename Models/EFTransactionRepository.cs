using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission10_mitchski.Models
{
    public class EFTransactionRepository : ITransactionRepository
    {
        private BookstoreContext context { get; set; }

        public EFTransactionRepository(BookstoreContext temp)
        {
            context = temp;    
        }

        public IQueryable<Transaction> Transactions => context.Transactions.Include(x => x.LineItems).ThenInclude(x => x.Book);


        public void SaveTransaction(Transaction transaction)
        {
            context.AttachRange(transaction.LineItems.Select(x => x.Book));

            if (transaction.TransactionID == 0)
            {
                context.Transactions.Add(transaction);
            }

            context.SaveChanges();
        }

    }
}
