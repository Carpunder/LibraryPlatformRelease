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
    public class LibraryCardsController
    {
        private readonly AppDbContext _context;
        private readonly UsersController _usersController;

        public LibraryCardsController()
        {
            _context = new AppDbContext();
            _usersController = new UsersController(_context);
        }

        public LibraryCardsController(AppDbContext context)
        {
            _context = context;
            _usersController = new UsersController(_context);
        }

        public void CreateUser(User user)
        {
            var libraryCardNumber = 0;
            if (_context.LibraryCards.Where(x => x.LibraryId == Values.Values.CurrentLibraryValue).Select(x => x.LibraryCardNumber).Any())
            {
                libraryCardNumber = _context.LibraryCards.Where(x => x.LibraryId == Values.Values.CurrentLibraryValue).Max(x => x.LibraryCardNumber);
            }
            ++libraryCardNumber;
            if (_usersController.RegisterUser(user))
            {
                var libraryCard = new LibraryCard(user.UserId, libraryCardNumber);
                _context.LibraryCards.Add(libraryCard);
                _context.SaveChanges();
                MessageBox.Show("Читатель зарегестрирован!");
            }
        }

        public List<UserDTO> GetAllReader()
        {
            var usersDto = new List<UserDTO>();
            foreach(var user in _context.LibraryCards.Include("User").Where(x => x.LibraryId == Values.Values.CurrentLibraryValue).OrderBy(x => x.LibraryCardNumber))
            {
                usersDto.Add(new UserDTO(user));
            }
            return usersDto.ToList();
        }
    }
}
