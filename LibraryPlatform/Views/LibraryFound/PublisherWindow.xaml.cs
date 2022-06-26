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
    /// Логика взаимодействия для PublisherWindow.xaml
    /// </summary>
    public partial class PublisherWindow : Window
    {
        private ControllerContext _controllers;
        private readonly AppDbContext _context;
        public PublisherWindow()
        {
            _context = new AppDbContext();
            _controllers = new ControllerContext(_context);
            InitializeComponent();
            publishersDataGrid.ItemsSource = _context.Publishers.ToList();
            
        }

        private void publishersDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if(e.EditAction != DataGridEditAction.Commit)
            {
                return;
            }
            var temp = e.Row.DataContext as Publisher;
            var publisherId = _context.Publishers.FirstOrDefault(x => x.Name == temp.Name);
            if (publisherId != null)
            {
                temp.PublisherId = publisherId.PublisherId;
            }
            if (!_context.Publishers.Where(x => x.PublisherId == temp.PublisherId).Any())
            {
                temp.PublisherId = Guid.NewGuid();
                if (_controllers.PublishersController.AddPublisher(temp))
                {
                    MessageBox.Show("Издатель добавлен");
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
            }
            else
            {
                if (_controllers.PublishersController.UpdatePublisher(temp))
                {
                    MessageBox.Show("Издатель обновлен");
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
            }
            publishersDataGrid.ItemsSource = _context.Publishers.ToList();
        }

        private void publishersDataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Delete)
            {
                return;
            }
            var temp = publishersDataGrid.SelectedItem as Publisher;
            if (_controllers.PublishersController.DeletePublisher(temp))
            {
                MessageBox.Show("Издатель удален");
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
            publishersDataGrid.ItemsSource = _context.Publishers.ToList();
        }
    }
}
