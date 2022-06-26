using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryPlatform.Models
{
    public class Book
    {
        public Book()
        {
            BookId = Guid.NewGuid();
            DateOfPublication = DateTime.Now;
            Copies = new List<Copy>();
        }
        
        public Guid BookId { get; set; }

        public string Title { get; set; }
        
        public string Author { get; set; }
        
        public DateTime DateOfPublication { get; set; }
        
        public int Pages { get; set; }
        public string Genre { get; set; }
        public int Count { get; set; }
        
        public Guid PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        
        public List<Copy> Copies { get; set; }
    }
}