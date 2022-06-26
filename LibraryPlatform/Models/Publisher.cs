using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryPlatform.Models
{
    public class Publisher
    {
        public Publisher()
        {
            PublisherId = Guid.NewGuid();
            Books = new List<Book>();
        }
        public Guid PublisherId { get; set; }
        
        public string Name { get; set; }
        public string Phone { get; set; }
        
        public string City { get; set; }
        
        public List<Book> Books { get; set; }
    }
}