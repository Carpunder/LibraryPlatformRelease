using LibraryPlatform.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPlatform.ViewModels
{
    public class CopyDTO
    {
        public CopyDTO(Copy copy)
        {
            CopyId = copy.CopyId;
            BookName = copy.Book.Title;
            LibraryNumber = copy.Library.Number;
            Author = copy.Book.Author;
            Publisher = copy.Book.Publisher.Name;
            YearOfPublishing = copy.Book.DateOfPublication.Year.ToString();
            PublisherCity = copy.Book.Publisher.City;
            CodeNumber = copy.Library.CodeNumber;
            CopyNumber = copy.CopyNumber;
            CopyLibNumber = CodeNumber + CopyNumber.ToString();
        }

        public Guid CopyId { get; set; }
        public string CopyLibNumber { get; set; }
        public int CopyNumber { get; set; }
        public string CodeNumber { get; set; }

        public string BookName { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        public string YearOfPublishing { get; set; }

        public string PublisherCity { get; set; }

        public string LibraryNumber { get; set; }

        public override string ToString()
        {
            return $"Номер книги:\t{CopyLibNumber}\n\n" +
                $"Название Книги:\t{BookName}\n\n" +
                $"Автор:\t\t{Author}\n\n" +
                $"Издание:\t{Publisher}\n\n" +
                $"Год издания:\t{YearOfPublishing}\n\n" +
                $"Город издания:\t{PublisherCity}\n\n";
        }

    }
}
