using LibraryPlatform.Controllers;
using LibraryPlatform.Models;
using System.Windows;

namespace LibraryPlatform.Views.Readers
{
    public partial class ReadersMainWindow : Window
    {
        private ControllerContext _controllers;
        private readonly AppDbContext _context;

        public ReadersMainWindow()
        {
            _context = new AppDbContext();
            _controllers = new ControllerContext(_context);
            InitializeComponent();
            readersInLibrary.ItemsSource = _controllers.LibraryCardsController.GetAllReader();
        }

        private void registerUserButton_Click(object sender, RoutedEventArgs e)
        {
            var registerWindow = new ReadersRegisterWindow { Owner = this };
            registerWindow.Show();
        }

        private void getAllBooksButton_Click(object sender, RoutedEventArgs e)
        {
            readersInLibrary.ItemsSource = _controllers.LibraryCardsController.GetAllReader();
        }

        private void readerDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            var readersDetailsWindow = new ReadersDetailsWindow { Owner = this };
            readersDetailsWindow.Show();
        }
    }
}