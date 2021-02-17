using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSeller.Models
{
    //inherits from context class provided by the system
    public class BookDBContext : DbContext
    {
        //constructer, method called when instance of object is built the first time
        //requiring a DbContextOptions class of a specific type, in this case, BookDBContext
        //takes from base options, which is the class itself
        public BookDBContext (DbContextOptions<BookDBContext> options) : base (options)
        {

        }

        //property, DbSet is a built in type, the type of object we're building, Book (from Book.cs model)
        public DbSet<Book> Books { get; set; }
    }
}
