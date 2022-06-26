using LibraryPlatform.Controllers;
using LibraryPlatform.Models;
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
    /// Логика взаимодействия для CreateBookWindow.xaml
    /// </summary>
    public partial class CreateBookWindow : Window
    {
        private ControllerContext _controllers;
        private readonly AppDbContext _context;
        public CreateBookWindow()
        {
            _context = new AppDbContext();
            _controllers = new ControllerContext(_context);
            InitializeComponent();
            foreach(var publisher in _context.Publishers)
            {
                publisherComboBox.Items.Add(publisher.Name);
            }
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            try {
                var publisher = _context.Publishers.FirstOrDefault(x => x.Name == publisherComboBox.SelectedValue.ToString());
                var book = new Book {
                    Author = authorTextBox.Text,
                    BookId = Guid.NewGuid(),
                    Count = int.Parse(copyTextBox.Text),
                    DateOfPublication = publicationDate.SelectedDate.Value,
                    Genre = ganreTextBox.Text,
                    Pages = int.Parse(pagesTextBox.Text),
                    Title = nameTextBox.Text,
                    PublisherId = publisher.PublisherId,
                };
                _controllers.BooksController.AddBookAdmin(book);
                MessageBox.Show("Книга добавлена");
            }
            catch {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
