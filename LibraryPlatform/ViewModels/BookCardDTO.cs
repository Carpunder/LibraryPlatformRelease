using LibraryPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPlatform.ViewModels
{
    public class BookCardDTO
    {
        public BookCardDTO(BookCard bookCard)
        {
            CopyId = bookCard.Copy.CopyId;
            BookName = bookCard.Copy.Book.Title;
            Author = bookCard.Copy.Book.Author;
            Publisher = bookCard.Copy.Book.Publisher.Name;
            DateOfIssue = bookCard.DateOfIssue.ToShortDateString();
            DateOfService = bookCard.DateOfService.ToShortDateString();
            CodeNumber = bookCard.Copy.Library.CodeNumber;
            CopyNumber = bookCard.Copy.CopyNumber;
            CopyLibNumber = CodeNumber + CopyNumber.ToString();
            if (bookCard.IsReturned)
            {
                IsReturned = "Да";
            }
            else
            {
                IsReturned = "Нет";
            }
        }

        public Guid CopyId { get; set; }
        public string CopyLibNumber { get; set; }
        public int CopyNumber { get; set; }
        public string CodeNumber { get; set; }
        public string BookName { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        public string DateOfIssue { get; set; }
        public string DateOfService { get; set; }

        public string IsReturned { get; set; }
    }
}
