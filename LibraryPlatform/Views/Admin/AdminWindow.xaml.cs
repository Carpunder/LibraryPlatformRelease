using System.Windows;
using LibraryPlatform.Controllers;
using LibraryPlatform.Views.LibraryFound;
using LibraryPlatform.Models;
using System.Windows.Forms;
using ClosedXML.Excel;
using LibraryPlatform.ViewModels;
using System.Collections.Generic;

namespace LibraryPlatform.Views.Admin
{
    public partial class AdminWindow : Window
    {
        private ControllerContext _controllers;
        private readonly AppDbContext _context;
        public AdminWindow()
        {
            _context = new AppDbContext();
            _controllers = new ControllerContext(_context);
            InitializeComponent();
        }

        private void booksButton_Click(object sender, RoutedEventArgs e)
        {
            var adminBookWindow = new AdminBookWindow();
            adminBookWindow.detailsButton.Visibility = Visibility.Hidden;
            adminBookWindow.Show();
            Close();
        }

        private void foundButton_Click(object sender, RoutedEventArgs e)
        {
            var libFoundWindow = new LibraryFoundMainWindow();
            libFoundWindow.Show();
            Close();
        }

        private void reportButton_Click(object sender, RoutedEventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "Количечество_выданных_книг_по_жанрам"})
            {
                if(sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            var ws = workbook.AddWorksheet("Книги");
                            ws.FirstCell().InsertData(new Dictionary<string, string> {
                                { $"Отчет по количеству выданных книг по жанрам", $"" },
                                { $"Библиотека: {Values.Values.Library.Number}", $"По адресу {Values.Values.Library.Address}" }
                            });
                            ws.LastRowUsed().RowBelow().RowBelow().RowBelow().FirstCell().InsertTable<ReportDTO>
                                (_controllers.CopiesController.GenerateReport(), false);
                            ws.Columns().AdjustToContents();
                            workbook.SaveAs(sfd.FileName);
                        }
                        System.Windows.MessageBox.Show("Отчет создан");
                    }
                    catch {
                        System.Windows.MessageBox.Show("Ошибка");
                    }
                }
            }
        }
    }
}