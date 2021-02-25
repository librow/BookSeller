using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSeller.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            BookDBContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<BookDBContext>();
            
            //Checking for any migrations
            if(context.Database.GetPendingMigrations().Any())
            {
                //Migrating info
                context.Database.Migrate();
            }
            //if there isn't data already in the database, it will add this seed data below
            if (!context.Books.Any())
            {
                context.Books.AddRange(

                    new Book
                    {
                        Title = "Unbroken",
                        AuthorFirst = "Laura",
                        AuthorLast = "Hillenbrand",
                        Publisher = "Random House",
                        ISBN = 9780812974492,
                        Classification = "Non-Fiction",
                        Category = "Historical",
                        Price = 13.33,
                        PageNum = 528
                    },

                    new Book
                    {
                        Title = "Deep Work",
                        AuthorFirst = "Cal",
                        AuthorLast = "Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = 9781455586691,
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 14.99,
                        PageNum = 304
                    },

                    new Book
                    {
                        Title = "Sycamore Row",
                        AuthorFirst = "John",
                        AuthorLast = "Grisham",
                        Publisher = "Bantam",
                        ISBN = 9780553393613,
                        Classification = "Fiction",
                        Category = "Thrillers",
                        Price = 15.03,
                        PageNum = 642
                    },

                    new Book
                    {
                        Title = "The Snowball",
                        AuthorFirst = "Alice",
                        AuthorLast = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = 9780553384611,
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 21.54,
                        PageNum = 832
                    },

                    new Book
                    {
                        Title = "Cinder",
                        AuthorFirst = "Marissa",
                        AuthorLast = "Meyer",
                        Publisher = "Square Fish",
                        ISBN = 9781250768889,
                        Classification = "Fiction",
                        Category = "Fantasy",
                        Price = 9.89,
                        PageNum = 448
                    },

                    new Book
                    {
                        Title = "Howl's Moving Castle",
                        AuthorFirst = "Diana",
                        AuthorMid = "Wynne",
                        AuthorLast = "Jones",
                        Publisher = "Greenwillow Books",
                        ISBN = 978 - 0064410342,
                        Classification = "Fiction",
                        Category = "Fantasy",
                        Price = 8.99,
                        PageNum = 336
                    },

                    new Book
                    {
                        Title = "Prey: The Drovers",
                        AuthorFirst = "John",
                        AuthorLast = "Brown",
                        Publisher = "Blacksword Books",
                        ISBN = 9781940427195,
                        Classification = "Fiction",
                        Category = "Fantasy",
                        Price = 12.99,
                        PageNum = 254
                    }
                );
                //saves changes
                context.SaveChanges();
            }
        }
    }
}
