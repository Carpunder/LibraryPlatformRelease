using LibraryPlatform.Controllers;
using LibraryPlatform.Models;
using LibraryPlatform.ViewModels;
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
    /// Логика взаимодействия для BookWindow.xaml
    /// </summary>
    public partial class BookWindow : Window
    {
        private ControllerContext _controllers;
        private readonly AppDbContext _context;
        public BookWindow()
        {
            _context = new AppDbContext();
            _controllers = new ControllerContext(_context);
            InitializeComponent();
            var books = _context.Books.Include("Publisher").ToList();
            booksdataGrid.ItemsSource = books;
            comboBoxColum.ItemsSource = _context.Publishers.ToList(); ;
        }

        private void booksdataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Delete)
            {
                return;
            }
            var temp = booksdataGrid.SelectedItem as Book;
            if (_controllers.BooksController.DeleteBook(temp))
            {
                MessageBox.Show("Книга удалена");
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
            booksdataGrid.ItemsSource = _context.Books.ToList();
        }

        private void booksdataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction != DataGridEditAction.Commit)
            {
                return;
            }
            var temp = e.Row.DataContext as Book;
            temp.PublisherId = temp.Publisher.PublisherId;
            var bookId = _context.Books.FirstOrDefault(x => x.Title == temp.Title);
            if(bookId != null)
            {
                temp.BookId = bookId.BookId;
            }
            if (!_context.Books.Where(x => x.BookId == temp.BookId).Any())
            { 
                temp.BookId = Guid.NewGuid();
                if (_controllers.BooksController.AddBookAdmin(temp))
                {
                    MessageBox.Show("Книга добавлена");
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
            }
            else
            {
                if (_controllers.BooksController.UpdateBook(temp))
                {
                    MessageBox.Show("Книга обновлена");
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
            }
            booksdataGrid.ItemsSource = _context.Books.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var createBookWindow = new CreateBookWindow { Owner = this };
            createBookWindow.Show();
        }
    }
}
