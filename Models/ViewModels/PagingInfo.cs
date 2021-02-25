using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSeller.Models.ViewModels
{
    public class PagingInfo
    {
        public int TotalNumItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        //creating a total number of pages, rounded up
        public int TotalPages => (int) Math.Ceiling((decimal) TotalNumItems / ItemsPerPage);
    }
}
