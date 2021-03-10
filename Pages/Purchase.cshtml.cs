using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookSeller.Infrastructure;
using BookSeller.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSeller.Pages
{
    public class PurchaseModel : PageModel
    {
        private iBookRepository repository;

        // Constructor
        public PurchaseModel(iBookRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        // Properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        // Methods
        public IActionResult OnPost(long bookId, string returnUrl, string cartAction)
        {
            Book book = repository.Books
                .FirstOrDefault(b => b.BookId == bookId);

            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            if(cartAction == "remove")
            {
                Cart.RemoveLine(book, 1);
            }
            else
            {
                Cart.AddItem(book, 1);
            }
            //HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
