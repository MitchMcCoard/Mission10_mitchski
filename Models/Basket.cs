using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission10_mitchski.Models
{
    public class Basket
    {
        //First part declares, the second part instanshiates
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();
        //Items = new List<BasketLineItem>


        //The virtual class allows the method to be overridden (like when inheriting)
        public virtual void AddItem(Book bk, int qty)
        {
            //Find the book assotiated with that ID
            BasketLineItem line = Items
                .Where(x => x.Book.BookId == bk.BookId)
                .FirstOrDefault();

            if (line == null) // The selected book is not in the cart yet
            {
                Items.Add(new BasketLineItem
                {
                    Book = bk,
                    Quantity = qty
                });
            }
            else
            {
                //If it was already in the basket, then add it to the basket
                line.Quantity += qty;
            }
        }


        public virtual void RemoveItem(Book BkToRemove)
        {
            Items.RemoveAll(x => x.Book.BookId == BkToRemove.BookId);

        }

        public virtual void ClearBasket()
        {
            Items.Clear();
        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);

            return sum;
        }

    }

    public class BasketLineItem
    {
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
