using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSeller.Models
{
    //template, defines structure to control what's done in the class
    public interface iBookRepository
    {
        IQueryable<Book> Books { get; }
    }
}
