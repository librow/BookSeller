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
                        Author = "Laura Hillenbrand",
                        Publisher = "Random House",
                        ISBN = 9780812974492,
                        Category = "Non-Fiction, Historical",
                        Price = 13.33
                    },

                    new Book
                    {
                        Title = "Deep Work",
                        Author = "Cal Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = 9781455586691,
                        Category = "Non-Fiction, Self-Help",
                        Price = 14.99
                    },

                    new Book
                    {
                        Title = "Sycamore Row",
                        Author = "John Grisham",
                        Publisher = "Bantam",
                        ISBN = 9780553393613,
                        Category = "Fiction, Thrillers",
                        Price = 15.03
                    },

                    new Book
                    {
                        Title = "The Snowball",
                        Author = "Alice Schroeder",
                        Publisher = "Bantam",
                        ISBN = 9780553384611,
                        Category = "Non-Fiction, Biography",
                        Price = 21.54
                    }
                );
                //saves changes
                context.SaveChanges();
            }
        }
    }
}
