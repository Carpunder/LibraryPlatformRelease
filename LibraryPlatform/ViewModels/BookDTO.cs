using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryPlatform.Models;

namespace LibraryPlatform.ViewModels
{
    public class BookDTO
    {
        public BookDTO(Book book)
        {
            BookId = book.BookId;
            Title = book.Title;
            Author = book.Author;
            PublisherName = book.Publisher.Name;
            YearOfPublication = book.DateOfPublication.Year.ToString();
            Genre = book.Genre;
            Count = book.Count;
        }
        
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string PublisherName { get; set; }
        public string YearOfPublication { get; set; }
        public string Genre { get; set; }
        public int Count { get; set; }
    }
}
