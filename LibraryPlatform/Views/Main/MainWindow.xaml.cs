using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LibraryPlatform.Views.Admin;
using LibraryPlatform.Views.Readers;
using LibraryPlatform.Views.BooksLending;
using LibraryPlatform.Views.ReturnBook;

namespace LibraryPlatform.Views.Main
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow(string libraryNumber)
        {
            InitializeComponent();
            libraryNameLabel.Content = libraryNumber;
        }

        private void adminButton_Click(object sender, RoutedEventArgs e)
        {
            var login = new AdminLogin{Owner = this};
            login.Show();
        }

        private void readersButton_Click(object sender, RoutedEventArgs e)
        {
            var readers = new ReadersMainWindow { Owner = this };
            readers.Show();
        }

        private void booksInLibraryButton_Click(object sender, RoutedEventArgs e)
        {
            var booksWindow = new AdminBookWindow { Owner = this };
            booksWindow.getFromStockButton.Visibility = Visibility.Hidden;
            booksWindow.getAllBooksButton.Visibility = Visibility.Hidden;
            booksWindow.Show();
        }

        private void lendingBooksButton_Click(object sender, RoutedEventArgs e)
        {
            var lendingBooksWindow = new MainBooksLendingWindow { Owner = this };
            lendingBooksWindow.Show();
        }

        private void returnBookButton_Click(object sender, RoutedEventArgs e)
        {
            var booksReturnWindow = new BooksReturnWindow { Owner = this };
            booksReturnWindow.Show();
        }
    }
}
