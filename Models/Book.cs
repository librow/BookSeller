using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookSeller.Models
{
    public class Book
    {
        [Key]   //sets this property as the primary key
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string AuthorFirst { get; set; }
        [Required]
        public string AuthorLast { get; set; }
#nullable enable
        public string? AuthorMid { get; set; }
#nullable disable
        [Required]
        public string Publisher { get; set; }
        [Required]
        //validates to see if input is formmatted correctly as an ISBN number
        [RegularExpression(@"^(97(8|9))-?\d{9}(\d|X)$", ErrorMessage = "Please enter a valid ISBN 10 or ISBN 13 number. If ISBN 13, confirm it starts with only 978 or 979.")]
        public long ISBN { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Classification { get; set; }
        [Required]
        //validates the price to make sure it's inputted correctly
        [RegularExpression(@"^\d*\.?\d*$", ErrorMessage ="Please enter a valid price (ie. strictly numerical, non-negative values).")]
        public double Price { get; set; }
    }
}
