using ClosedXML.Excel;
using LibraryPlatform.Controllers;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LibraryPlatform.Views.Admin
{
    /// <summary>
    /// Логика взаимодействия для BookDetailsWindow.xaml
    /// </summary>
    public partial class BookDetailsWindow : Window
    {
        private ControllerContext _controllers;
        private readonly AppDbContext _context;
        public BookDetailsWindow()
        {
            _context = new AppDbContext();
            _controllers = new ControllerContext(_context);
            InitializeComponent();
            foreach (var book in _controllers.CopiesController.GetAllInLibrary(Values.Values.CurrentLibraryValue).OrderBy(x => x.CopyLibNumber))
            {
                bookCardComboBox.Items.Add(book.CopyLibNumber);
            }
        }

        private void exportButton_Click(object sender, RoutedEventArgs e)
        {
            var copy = _controllers.CopiesController.GetCopyIdByLibNumber(bookCardComboBox.SelectedValue.ToString());
            var userList = _context.BookCards
                .Include("Copy")
                .Include("Copy.Book")
                .Include("Copy.Library")
                .Include("LibraryCard")
                .Include("LibraryCard.User")
                .Where(x => x.CopyId == copy.CopyId).ToList();
            var bookCardReportDTO = new List<BookCardReportDTO>();
            foreach (var user in userList)
            {
                bookCardReportDTO.Add(new BookCardReportDTO
                {
                    Адрес = user.LibraryCard.User.Address,
                    ФИО = user.LibraryCard.User.FIO,
                    НомерЧитательскогоБилета = user.LibraryCard.LibraryCardNumber,
                    Телефон = user.LibraryCard.User.Phone,
                    ДатаВыдачи = user.DateOfIssue,
                    ДатаВозврата = user.DateOfService,
                });
            }

            var fromDate = bookCardReportDTO.Min(x => x.ДатаВыдачи).ToShortDateString();
            var toDate = bookCardReportDTO.Max(x => x.ДатаВыдачи).ToShortDateString();

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx",
                FileName = $"Отчет_Экземпляр({bookCardComboBox.SelectedValue.ToString()})" })
            {
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            var ws = workbook.AddWorksheet("Читатели");

                            ws.FirstCell().InsertData(new Dictionary<string, string> {
                                { $"Отчет экземпляра No: {bookCardComboBox.SelectedValue}", $"" },
                                { $"Библиотека: {userList[0].Copy.Library.Number}", $"По адресу {userList[0].Copy.Library.Address}" },
                                { $"С: {fromDate}", $"По: {toDate}" },
                            });
                            ws.LastRowUsed().RowBelow().RowBelow().FirstCell().InsertTable<BookCardReportDTO>
                                (bookCardReportDTO, false);
                            ws.LastRowUsed().RowBelow().RowBelow().RowBelow().FirstCell().InsertData(new Dictionary<string, string> {
                                { "Номер книги:", $"{bookCardComboBox.SelectedValue}" },
                                { "Название книги:", $"{userList[0].Copy.Book.Title}" },
                                { "Количество читателей:", $"{bookCardReportDTO.Count}" },
                            });
                            ws.Columns().AdjustToContents();
                            workbook.SaveAs(sfd.FileName);
                        }
                        System.Windows.MessageBox.Show("Отчет создан");
                    }
                    catch(Exception ex)
                    {
                        System.Windows.MessageBox.Show("Ошибка");
                    }
                }
            }
        }

        private void bookCardComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var copy = _controllers.CopiesController.GetCopyIdByLibNumber(bookCardComboBox.SelectedValue.ToString());
            var userList = _context.BookCards.Include("LibraryCard").Include("LibraryCard.User").Where(x => x.CopyId == copy.CopyId).ToList();
            var usersDTO = new List<UserDTO>();
            foreach (var user in userList)
            {
                usersDTO.Add(new UserDTO
                {
                    Address = user.LibraryCard.User.Address,
                    FIO = user.LibraryCard.User.FIO,
                    LibraryCardNumber = user.LibraryCard.LibraryCardNumber,
                    Phone = user.LibraryCard.User.Phone,
                    DateOfIssue = user.DateOfIssue,
                    DateOfService = user.DateOfService,
                });
            }
            copiesDataGrid.ItemsSource = usersDTO;
        }
    }
}
