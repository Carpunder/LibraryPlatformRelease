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
    /// Логика взаимодействия для AdminBookUnRegisterWindow.xaml
    /// </summary>
    public partial class AdminBookUnRegisterWindow : Window
    {
        private ControllerContext _controllers;
        private readonly AppDbContext _context;
        public AdminBookUnRegisterWindow()
        {
            _context = new AppDbContext();
            _controllers = new ControllerContext(_context);
            InitializeComponent();
            booksComboBox.ItemsSource = _controllers.CopiesController.GetAllInLibrary(Values.Values.CurrentLibraryValue)
                .OrderBy(x => x.CopyLibNumber).Select(x => x.CopyLibNumber);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _controllers.CopiesController.UnRegisterCopyByLibNumber(booksComboBox.SelectedValue.ToString());
                MessageBox.Show("Книга списана");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
