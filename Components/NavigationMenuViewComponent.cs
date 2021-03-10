using BookSeller.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSeller.Components
{
    // A view componenet = small,reusable application logic 
    //of some sort that builds in the app and is dropped on the page
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
            // building a viewbag component, creating a nullable property; 
            // category refers to the category in the route data(the endpoint in startup.cs)
            ViewBag.SelectedCategory = RouteData?.Values["category"];
 
            return View(repository.Books
                .Select(b => b.Category)
                .Distinct()
                .OrderBy(b => b));
        }
    }
}
