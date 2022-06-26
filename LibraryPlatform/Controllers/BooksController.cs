using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows;
using LibraryPlatform.Models;
using LibraryPlatform.ViewModels;

namespace LibraryPlatform.Controllers
{
    public class BooksController
    {
        private readonly AppDbContext _context;

        public BooksController()
        {
            _context = new AppDbContext();
        }

        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        public List<Book> GetAll() => _context.Books.Include("Publisher").ToList();
        public List<BookDTO> GetAllDto()
        {
            var books = new List<BookDTO>();
            foreach(var book in _context.Books.Include("Publisher").ToList())
            {
                books.Add(new BookDTO(book));
            }
            return books;
        }

        public Book GetByName(string bookTitle) { return _context.Books.FirstOrDefault(x => x.Title == bookTitle); }

        public void AddBook(Book book)
        {
            var error = "";
            if(!ValidatorController.TryValidate(book, out error))
            {
                MessageBox.Show(error);
                return;
            }

            try
            {
                _context.Books.Add(book);
                _context.SaveChanges();
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }

        }


         public bool AddBookAdmin(Book book)
        {
            try
            {
                if(book.Title == null ||
                    book.Author == null ||
                    book.Genre == null)
                    return false;
                _context.Books.Add(new Book
                {
                    Genre = book.Genre,
                    Count = book.Count,
                    Title = book.Title,
                    Author = book.Author,
                    DateOfPublication = book.DateOfPublication,
                    BookId = book.BookId,
                    Pages = book.Pages,
                    PublisherId = book.PublisherId,
                });
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool UpdateBook(Book book)
        {
            try
            {
                if (book.Title == null ||
                   book.Author == null ||
                   book.Genre == null)
                    return false;
                var temp = _context.Books.FirstOrDefault(x => x.BookId == book.BookId);
                temp.Genre = book.Genre;
                temp.Count = book.Count;
                temp.Title = book.Title;
                temp.Author = book.Author;
                temp.DateOfPublication = book.DateOfPublication;
                temp.BookId = book.BookId;
                temp.Pages = book.Pages;
                temp.PublisherId = book.PublisherId;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool DeleteBook(Book book)
        {
            try
            {
                var temp = _context.Books.FirstOrDefault(x => x.BookId == book.BookId);
                _context.Books.Remove(temp);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}