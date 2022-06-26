using LibraryPlatform.Models;
using LibraryPlatform.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LibraryPlatform.Controllers
{
    public class CopiesController
    {
        private readonly AppDbContext _context;

        public CopiesController()
        {
            _context = new AppDbContext();
        }

        public CopiesController(AppDbContext context)
        {
            _context = context;
        }

        public List<ReportDTO> GenerateReport()
        {
            var reportData = new List<ReportDTO>();
            foreach (var copy in _context.BookCards.Include("Copy").Include("Copy.Book").GroupBy(x => x.Copy.Book.Genre))
            {
                reportData.Add(new ReportDTO
                {
                    Жанр = copy.Key,
                    Количество = copy.Count(),
                });
            }
            return reportData;
        }

        public List<ReportDTO> GenerateBookCardReport()
        {
            var reportData = new List<ReportDTO>();
            foreach (var copy in _context.BookCards.Include("Copy").Include("Copy.Book").GroupBy(x => x.Copy.Book.Genre))
            {
                reportData.Add(new ReportDTO
                {
                    Жанр = copy.Key,
                    Количество = copy.Count(),
                });
            }
            return reportData;
        }

        public List<CopyDTO> GetAll()
        {
            var copies = new List<CopyDTO>();
            foreach (var copy in _context.Copies.Include("Book").Include("Book.Publisher").Include("Library")
                .Where(x => x.IsAvailable == true))
            {
                copies.Add(new CopyDTO(copy));
            }
            return copies.ToList();
        }

        public Copy GetCopyIdByLibNumber(string copyLibNumber)
        {
            var copyNumber = Convert.ToInt32(copyLibNumber.Substring(2));
            return _context.Copies.Include("Book").FirstOrDefault(x => x.CopyNumber == copyNumber && x.LibraryId == Values.Values.CurrentLibraryValue);
        }
        public List<Copy> GetAllInStock()
        {
            return _context.Copies.Include("Book").Where(x => x.InLibrary == false).ToList();
        }

        public List<string> GetBookTitles()
        {
            return GetAllInLibrary(Values.Values.CurrentLibraryValue).Select(x => x.BookName).Distinct().ToList();
        }

        public List<CopyDTO> GetAllInLibrary(Guid libraryId) {
            var copies = new List<CopyDTO>();
            foreach(var copy in _context.Copies.Include("Book.Publisher").Include("Library").Where(x => x.LibraryId == libraryId && x.IsAvailable == true))
            {
                copies.Add(new CopyDTO(copy));
            }
            return copies.Distinct().ToList();
        }

        private void AddCopy(Copy copy)
        {
            var error = "";
            if (!ValidatorController.TryValidate(copy, out error))
            {
                MessageBox.Show(error);
                return;
            }

            try
            {
                _context.Copies.Add(copy);
                _context.SaveChanges();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void AddGeneratedCopyByBook(Book book)
        {
            var temp = 0;
            if (_context.Copies.Where(x => x.LibraryId == Values.Values.CurrentLibraryValue).Select(x => x.CopyNumber).Any())
            {
                temp = _context.Copies.Where(x => x.LibraryId == Values.Values.CurrentLibraryValue).Max(x => x.CopyNumber);
            }
            var copy = new Copy {
                BookId = book.BookId,
                CopyNumber = ++temp,
                LibraryId = Values.Values.CurrentLibraryValue,
                InLibrary = true,
                IsAvailable = true
            };
                var error = "";
                if (!ValidatorController.TryValidate(copy, out error))
                {
                    MessageBox.Show(error);
                    return;
                }

                try
                {
                    _context.Copies.Add(copy);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

            _context.SaveChanges();
        }

        public bool AddBashGeneratedCopyByBook(Book book, int booksCount)
        {
            var findedBook = _context.Books.FirstOrDefault(x => x.BookId == book.BookId);
            if(findedBook != null && Enumerable.Range(1, findedBook.Count).Contains(booksCount))
            {
                for (int i = 0; i < booksCount; i++)
                {
                    AddGeneratedCopyByBook(book);
                    findedBook.Count--;
                }
            }
            else
            {
                MessageBox.Show($"Неверное количество. Доступно ({findedBook.Count})");
                return false;
            }

            _context.SaveChanges();
            return true;
        }

        public void AddCopyFromStock(Book book, int count)
        {
            var copiesInStock = _context.Copies.Where(c => c.BookId == book.BookId && c.LibraryId == Values.Values.CurrentLibraryValue).ToList();
            var library = _context.Libraries.FirstOrDefault(x => x.LibraryId == Values.Values.CurrentLibraryValue);

            if (copiesInStock.Count() > count)
            {
                MessageBox.Show($"Доступно {copiesInStock.Count()} книг");
                return;
            }

            for (int i = 0; i < count; i++)
            {
                copiesInStock[i].LibraryId = Values.Values.CurrentLibraryValue;
                copiesInStock[i].Library = library;
                copiesInStock[i].InLibrary = true;
            }

            _context.SaveChanges();
        }

        public void RegisterCopy(Copy copy, Library library)
        {
            copy.LibraryId = library.LibraryId;
            copy.Library = library;

            
            _context.SaveChanges();
        }

        public void UnRegisterCopyByLibNumber(string copyLibNumber)
        {
            var copyId = GetCopyIdByLibNumber(copyLibNumber);
            var book = _context.Books.FirstOrDefault(x => x.BookId == copyId.BookId);
            book.Count++;
            copyId.InLibrary = false;
            copyId.IsAvailable = false;

            _context.SaveChanges();
        }

        public void RegisterBathCopy(List<Copy> copies, Library library)
        {
            foreach (var copy in copies)
            {
                RegisterCopy(copy, library);
            }

            _context.SaveChanges();
        }

    }
}
