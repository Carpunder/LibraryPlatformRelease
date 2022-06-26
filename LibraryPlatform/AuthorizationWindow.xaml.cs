using LibraryPlatform.Controllers;
using LibraryPlatform.Models;
using LibraryPlatform.Views.Main;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryPlatform
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        protected readonly AppDbContext _context;

        List<string> userNames = new List<string>
        {
            "Александрова Кристина Ярославовна",
            "Антонова Валерия Николаевна",
            "Безруков Алексей Дмитриевич",
            "Богданов Леонид Андреевич",
            "Бондарев Антон Максимович",
            "Борисова Юлия Алексеевна",
            "Бородин Михаил Константинович",
            "Васильев Роман Владимирович",
            "Васильев Михаил Андреевич",
            "Власов Александр Серафимович",
            "Воронова Яна Алексеевна",
            "Герасимова Алиса Игоревна",
            "Громов Егор Артёмович",
            "Демина София Константиновна",
            "Дмитриева Мария Марковна",
            "Дорохова Лилия Робертовна",
            "Дорохова София Михайловна",
            "Дроздова Екатерина Александровна",
            "Дьяков Артём Артёмович",
            "Евдокимова Арина Ильинична",
            "Емельянова Полина Сергеевна",
            "Ефремов Ярослав Матвеевич",
            "Жукова Ева Александровна",
            "Журавлев Марк Константинович",
            "Зубов Артём Владимирович",
            "Зуева Вероника Елисеевна",
            "Иванов Георгий Степанович",
        };
        List<string> addressList = new List<string> {
            "ул. Абрикосовая",
            "ул. Авакяна",
            "ул. Бехтерева",
            "ул. Брилевская",
            "ул. Ватутина",
            "ул. Вокзальная",
            "ул. Енисейская",
            "ул. Жлобинская",
            "ул. Купревича",
            "ул. Заливная",
            "ул. Заречная",
            "ул. Зеленая",
            "ул. Затишье",
            "ул. Зимняя",
            "ул. Любанская",
            "ул. Малая",
            "ул. Малявки",
            "ул. Матусевича",
            "ул. Макаренко",
            "ул. Мележа",
            "ул. Обойная",
            "ул. Одинцова",
            "ул. Полиграфическая",
            "ул. Путейская",
            "ул. Светлая",
            "ул. Семенова",
            "ул. Федотова"
        };

        public void GenerateTest()
        {
            LibraryCardsController libraryCardsController = new LibraryCardsController();
            var random = new Random();
            var randomPhoneCode = new List<int> { 29, 33, 44, 25 };
            foreach(var userName in userNames)
            {
                var randomCode = randomPhoneCode[random.Next(randomPhoneCode.Count)];
                var phone = $"+375{randomCode}" +
                    $"{random.Next(1, 7)}{random.Next(1, 9)}{random.Next(0, 9)}" +
                    $"{random.Next(0, 9)}{random.Next(0, 9)}" +
                    $"{random.Next(0, 9)}{random.Next(0, 9)}";
                var pasport = $"MP" +
                    $"{random.Next(1, 7)}{random.Next(1, 9)}{random.Next(0, 9)}" +
                    $"{random.Next(0, 9)}{random.Next(0, 9)}" +
                    $"{random.Next(0, 9)}{random.Next(0, 9)}";
                var randomAdress = addressList[random.Next(addressList.Count)];
                var address = $"{randomAdress} {random.Next(1, 99)}";

                var user = new User
                {
                    FIO = userName,
                    Address = address,
                    Passport = pasport,
                    Phone = phone,
                    UserId = Guid.NewGuid(),
                };
                libraryCardsController.CreateUser(user);
            }
        }

        public AuthorizationWindow()
        {
            _context = new AppDbContext();
            if (!_context.Database.Exists())
            {
                try
                {
                    var libraryStock = new LibraryStock ();
                    var library = new Library
                    {
                        LibraryId = Guid.NewGuid(),
                        Address = "Кошевого 10",
                        Number = "Библиотека-филиал 6",
                        CodeNumber = "AA",
                        Login = "admin",
                        Password = "admin",
                        LibraryStockId = libraryStock.LibraryStockId,
                        LibraryStock = libraryStock
                    };
                    _context.Database.Create();
                    _context.LibraryStocks.Add(libraryStock);
                    _context.Libraries.Add(library);
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            
            InitializeComponent();
        }

        private void enterButton_Click(object sender, RoutedEventArgs e)
        {
            var libary = _context.Libraries.FirstOrDefault(x => x.Login == loginTextBox.Text);
            if (libary != null && libary.Password == passwordBox.Password)
            {
                Values.Values.CurrentLibraryValue = libary.LibraryId;
                Values.Values.Library = libary;
                var mainWindow = new MainWindow(libary.Number);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                enterButton_Click(sender, e);
            }
        }
    }
}
