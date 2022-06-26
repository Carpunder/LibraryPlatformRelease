using LibraryPlatform.Controllers;
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

namespace LibraryPlatform.Views.Admin
{
    /// <summary>
    /// Interaction logic for FromStockWindow.xaml
    /// </summary>
    public partial class FromStockWindow : Window
    {
        public AppDbContext _context;
        public ControllerContext _controllers;
        public FromStockWindow(ControllerContext controllers)
        {
            _context = new AppDbContext();
            _controllers = controllers;
            InitializeComponent();
            foreach (var book in _controllers.BooksController.GetAll())
            {
                booksComboBox.Items.Add(book.Title);
            }
            booksDataGrid.ItemsSource = _controllers.BooksController.GetAllDto();
        }

        private void booksComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var bookName = _context.Books.FirstOrDefault(x => x.Title == booksComboBox.SelectedValue.ToString());
            var avalible = _controllers.BooksController.GetByName(bookName.Title);
            avalibleCountLabel.Content = $"Доступно: {avalible.Count} шт.";
        }

        private void takeBooksButton_Click(object sender, RoutedEventArgs e)
        {
            if(int.TryParse(booksCountTextBox.Text, out var count))
            {
                var bookName = _context.Books.FirstOrDefault(x => x.Title == booksComboBox.SelectedValue.ToString());
                var book = _controllers.BooksController.GetByName(bookName.Title);
                if (_controllers.CopiesController.AddBashGeneratedCopyByBook(book, count))
                {
                    MessageBox.Show("Книги добавлены");
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
