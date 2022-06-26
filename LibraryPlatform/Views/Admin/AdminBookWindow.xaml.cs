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
using LibraryPlatform.Controllers;

namespace LibraryPlatform.Views.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminBookWindow.xaml
    /// </summary>
    public partial class AdminBookWindow : Window
    {
        private ControllerContext _controllers;
        private readonly AppDbContext _context;
        public AdminBookWindow()
        {
            _context = new AppDbContext();
            _controllers = new ControllerContext(_context);
            InitializeComponent();
            copiesInLibraryTable.ItemsSource = _controllers.CopiesController.GetAllInLibrary(Values.Values.CurrentLibraryValue).OrderBy(x => x.CopyNumber);
        }

        private void getFromStockButton_Click(object sender, RoutedEventArgs e)
        {
            var register = new FromStockWindow(_controllers);
            register.Show();

        }

        private void getAllBooksButton_Click(object sender, RoutedEventArgs e)
        {
            copiesInLibraryTable.ItemsSource = _controllers.CopiesController.GetAll();
        }

        private void getInLibraryButton_Click(object sender, RoutedEventArgs e)
        {
            copiesInLibraryTable.ItemsSource = _controllers.CopiesController.GetAllInLibrary(Values.Values.CurrentLibraryValue).OrderBy(x => x.CopyNumber);
        }

        private void giveToStockButton_Click(object sender, RoutedEventArgs e)
        {
            var adminBookUnRegisterWindow = new AdminBookUnRegisterWindow { Owner = this };
            adminBookUnRegisterWindow.Show();
        }

        private void detailsButton_Click(object sender, RoutedEventArgs e)
        {
            var bookDetailsWindow = new BookDetailsWindow { Owner = this };
            bookDetailsWindow.Show();
        }
    }
}
