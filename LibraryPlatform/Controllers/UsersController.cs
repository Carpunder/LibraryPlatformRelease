using LibraryPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace LibraryPlatform.Controllers
{
    public class UsersController
    {
        private readonly AppDbContext _context;

        public UsersController()
        {
            _context = new AppDbContext();
        }

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        public bool RegisterUser(User user)
        {
            if(!Regex.IsMatch(user.Phone,@"^\+375(44|29|33|25)[0-9][0-9][0-9][0-9][0-9][0-9][0-9]"))
            {
                MessageBox.Show("Неверный номер телефона");
                return false;
            }

            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

        public User GetUserByName(string name)
        {
            var user = _context.Users.FirstOrDefault(x => x.FIO == name);
            if(user == null)
            {
                return null;
            }
            return user;
        }
    }
}
