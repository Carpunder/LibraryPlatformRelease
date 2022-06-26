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

namespace LibraryPlatform.Views.Readers
{
    /// <summary>
    /// Логика взаимодействия для ReadersDetailsWindow.xaml
    /// </summary>
    public partial class ReadersDetailsWindow : Window
    {
        private ControllerContext _controllers;
        private readonly AppDbContext _context;
        public ReadersDetailsWindow()
        {
            _context = new AppDbContext();
            _controllers = new ControllerContext(_context);
            InitializeComponent();
            foreach (var reader in _controllers.LibraryCardsController.GetAllReader().OrderBy(x => x.LibraryCardNumber))
            {
                readersComboBox.Items.Add(reader.LibraryCardNumber);
            }
        }

        private void readersComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int.TryParse(readersComboBox.SelectedValue.ToString(), out int libCardNum);
            var bookCards = _controllers.BookCardsController.GetDebtBooksByLibraryCardIdForReport(libCardNum);
            copiesDataGrid.ItemsSource = bookCards;
        }

        private void exportButton_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(readersComboBox.SelectedValue.ToString(), out int libCardNum);
            var bookCards = _controllers.BookCardsController.GetDebtBooksByLibraryCardIdForReport(libCardNum);
            var bookCardReportDTO = new List<ReadersReportDTO>();
            foreach (var user in bookCards)
            {
                bookCardReportDTO.Add(new ReadersReportDTO
                {
                    Автор = user.Author,
                    Возвращена = user.IsReturned,
                    ДатаВозврата = DateTime.Parse(user.DateOfService),
                    ДатаВыдачи = DateTime.Parse(user.DateOfIssue),
                    Издатель = user.Publisher,
                    НазваниеКниги = user.BookName,
                    НомерЭкземпляра = user.CopyLibNumber
                });
            }
            var fromDate = bookCardReportDTO.Min(x => x.ДатаВыдачи).ToShortDateString();
            var toDate = bookCardReportDTO.Max(x => x.ДатаВыдачи).ToShortDateString();
            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Excel Workbook|*.xlsx",
                FileName = $"Отчет_Читатель({readersComboBox.SelectedValue.ToString()})"
            })
            {
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        var user = _context.LibraryCards.Include("User").FirstOrDefault(x => x.LibraryCardNumber == libCardNum).User;
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            var ws = workbook.AddWorksheet("Экземпляры");
                            ws.FirstCell().InsertData(new Dictionary<string, string> {
                                { $"Отчет читателя No: {readersComboBox.SelectedValue}", $"" },
                                { $"Библиотека: {Values.Values.Library.Number}", $"По адресу {Values.Values.Library.Address}" },
                                { $"С: {fromDate}", $"По: {toDate}" },
                            });
                            ws.LastRowUsed().RowBelow().RowBelow().RowBelow().FirstCell().InsertTable<ReadersReportDTO>
                                (bookCardReportDTO, false);
                            ws.LastRowUsed().RowBelow().RowBelow().RowBelow().FirstCell().InsertData(new Dictionary<string, string> {
                                { "Номер читательского билета:", $"{readersComboBox.SelectedValue}" },
                                { "ФИО читателя:", $"{user.FIO}" },
                                { "Количество экземпляров:", $"{bookCardReportDTO.Count}" },
                                { "Возвращено экземпляров:", $"{bookCardReportDTO.Where(x => x.Возвращена == "Да").LongCount()}"},
                                { "Не возвращено экземпляров:", $"{bookCardReportDTO.Where(x => x.Возвращена == "Нет").LongCount()}" }
                            });
                            ws.Columns().AdjustToContents();
                            workbook.SaveAs(sfd.FileName);
                        }
                        System.Windows.MessageBox.Show("Отчет создан");
                    }
                    catch
                    {
                        System.Windows.MessageBox.Show("Ошибка");
                    }
                }
            }
        }
    }
}
