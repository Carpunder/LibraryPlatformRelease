using LibraryPlatform.Controllers;
using LibraryPlatform.Models;
using System.Windows;

namespace LibraryPlatform.Views.Readers
{
    public partial class ReadersRegisterWindow : Window
    {
        private ControllerContext _controllers;
        private readonly AppDbContext _context;
        public ReadersRegisterWindow()
        {
            _context = new AppDbContext();
            _controllers = new ControllerContext(_context);
            InitializeComponent();
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            var user = new User(fioTextBox.Text, passportTextBox.Text, phoneTextBox.Text, addressTextBox.Text);
            _controllers.LibraryCardsController.CreateUser(user);
            Close();
        }
    }
}
