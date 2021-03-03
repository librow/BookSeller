using BookSeller.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSeller.Components
{
    public class NavigationMenuViewComponent : ViewComponent 
    {
        private iBookRepository repository;

        // Constructor
        public NavigationMenuViewComponent(iBookRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
 
            return View(repository.Books
                .Select(b => b.Category)
                .Distinct()
                .OrderBy(b => b));
        }
    }
}
