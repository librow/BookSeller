using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSeller.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem(Book book, int quantity)
        {
            CartLine line = Lines
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = book,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        //public void RemoveLine(Book book, int quantity) =>
        //    Lines.RemoveAll(x => x.Book.BookId == book.BookId);
        public virtual void RemoveLine(Book book, int quantity)
        {
            CartLine line = Lines
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (line != null && line.Quantity > 1)
            {
                line.Quantity -= quantity;
            }
            else if (line != null)
            {
                Lines.RemoveAll(x => x.Book.BookId == book.BookId);
            }

            //Lines.RemoveAll(x => x.Book.BookId == book.BookId);
        }
            

        public virtual void Clear() => Lines.Clear();

        public double ComputeTotalSum() =>
            Lines.Sum(e => e.Book.Price * e.Quantity);

        // Building a class Cart
        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
        }
    }
}
