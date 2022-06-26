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

namespace LibraryPlatform.Views.LibraryFound
{
    /// <summary>
    /// Логика взаимодействия для LibraryFoundMainWindow.xaml
    /// </summary>
    public partial class LibraryFoundMainWindow : Window
    {
        public LibraryFoundMainWindow()
        {
            InitializeComponent();
        }

        private void publishersButton_Click(object sender, RoutedEventArgs e)
        {
            var publisherWindow = new PublisherWindow { Owner = this };
            publisherWindow.Show();
        }

        private void booksButton_Click(object sender, RoutedEventArgs e)
        {
            var bookWindow = new BookWindow { Owner = this };
            bookWindow.Show();

        }
    }
}
