using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSeller.Models
{
    public class EFBookRepository : iBookRepository
    {
        //Property
        private BookDBContext _context;

        //Constructor
        public EFBookRepository(BookDBContext context)
        {
            _context = context;
        }
        //Creating an IQueryable of the model Book which is assigned the info from _context.Books
        public IQueryable<Book> Books => _context.Books;
    }
}
