using LibraryPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPlatform.ViewModels
{
    public class UserDTO
    {
        public UserDTO(LibraryCard libraryCard)
        {
            LibraryCardNumber = libraryCard.LibraryCardNumber;
            FIO = libraryCard.User.FIO;
            Phone = libraryCard.User.Phone;
            Address = libraryCard.User.Address;
        }
        public UserDTO() { }
        public int LibraryCardNumber { get; set; }
        public string FIO { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfService { get; set; }

        public override string ToString()
        {
            return $"Номер читательского билета: {LibraryCardNumber}\n\n" +
                $"ФИО:\t{FIO}\n\n" +
                $"Телефон:\t{Phone}\n\n" +
                $"Адрес:\t{Address}\n\n";
        }
    }
}
