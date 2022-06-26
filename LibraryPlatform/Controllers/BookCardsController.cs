using LibraryPlatform.Models;
using LibraryPlatform.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LibraryPlatform.Controllers
{
    public class BookCardsController
    {
        private readonly AppDbContext _context;

        public BookCardsController()
        {
            _context = new AppDbContext();
        }

        public BookCardsController(AppDbContext context)
        {
            _context = context;
        }

        private void AddBookCard(BookCard bookCard)
        {
            var error = "";
            if (!ValidatorController.TryValidate(bookCard, out error))
            {
                MessageBox.Show(error);
                return;
            }

            try
            {
                _context.BookCards.Add(bookCard);
                _context.SaveChanges();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    
        public void RegisterBookCard(Guid copyId, LibraryCard libraryCard)
        {
            var copy = _context.Copies.Include("Book").Include("Library").FirstOrDefault(x => x.CopyId == copyId && x.Library.LibraryId == Values.Values.CurrentLibraryValue && x.IsAvailable == true);

            var bookCard = new BookCard(copy);
            copy.InLibrary = false;
            copy.IsAvailable = false;
            bookCard.LibraryCard = libraryCard;
            bookCard.Copy = copy;

            _context.BookCards.Add(bookCard);
            _context.SaveChanges();
        }

        public void ReturnCopy(int libraryCardNumber, string copyLibNumber)
        {
            var copyNumber = Convert.ToInt32(copyLibNumber.Substring(2));
            var copy = _context.Copies.FirstOrDefault(x => x.CopyNumber == copyNumber && x.LibraryId == Values.Values.CurrentLibraryValue);
            var bookCards = GetDebtBooksByLibraryCardIdNotDTO(libraryCardNumber);
            var bookCard = bookCards.FirstOrDefault(x => x.CopyId == copy.CopyId);
            bookCard.IsReturned = true;
            copy.InLibrary = true;
            copy.IsAvailable = true;
            _context.SaveChanges();
        }

        public List<BookCardDTO> GetDebtBooksByLibraryCardId(int libraryCardNumber)
        {
            var bookDeptList = new List<BookCardDTO>();
            var booksDept = _context.BookCards
                .Include("LibraryCard").Include("LibraryCard.User")
                .Include("Copy")
                .Include("Copy.Book").Include("Copy.Book.Publisher").Include("Copy.Library")
                .Where(x => x.LibraryCard.LibraryCardNumber == libraryCardNumber && x.IsReturned == false && x.LibraryCard.LibraryId == Values.Values.CurrentLibraryValue)
                .ToList();

            var test = booksDept.Count;

            foreach (var book in booksDept)
            {
                bookDeptList.Add(new BookCardDTO(book));
            }

            return bookDeptList;
        }

        public List<BookCardDTO> GetDebtBooksByLibraryCardIdForReport(int libraryCardNumber)
        {
            var bookDeptList = new List<BookCardDTO>();
            var booksDept = _context.BookCards
                .Include("LibraryCard").Include("LibraryCard.User")
                .Include("Copy")
                .Include("Copy.Book").Include("Copy.Book.Publisher").Include("Copy.Library")
                .Where(x => x.LibraryCard.LibraryCardNumber == libraryCardNumber && x.LibraryCard.LibraryId == Values.Values.CurrentLibraryValue);

            foreach (var book in booksDept)
            {
                bookDeptList.Add(new BookCardDTO(book));
            }

            return bookDeptList;
        }

        public List<BookCard> GetDebtBooksByLibraryCardIdNotDTO(int libraryCardNumber)
        {
            var booksDept = _context.BookCards
                .Include("LibraryCard").Include("LibraryCard.User")
                .Include("Copy")
                .Include("Copy.Book").Include("Copy.Book.Publisher").Include("Copy.Library")
                .Where(x => x.LibraryCard.LibraryCardNumber == libraryCardNumber && x.IsReturned == false)
                .ToList();

            return booksDept;
        }

        public List<BookCardDTO> GetDebtBooksByUserName(string fio)
        {
            var bookDeptList = new List<BookCardDTO>();
            var booksDept = _context.BookCards.Include("LibraryCard").Include("LibraryCard.User").Include("Copy")
                .Include("Copy.Book").Include("Copy.Book.Publisher").Where(x => x.LibraryCard.User.FIO == fio);

            foreach (var book in booksDept)
            {
                bookDeptList.Add(new BookCardDTO(book));
            }

            return bookDeptList;
        }
    }
}
