using System.Windows;
using System.Windows.Input;

namespace LibraryPlatform.Views.Admin
{
    public partial class AdminLogin : Window
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void enterButton_Click(object sender, RoutedEventArgs e)
        {
            if(passwordBox.Password.ToLower() == "admin")
            {
                var admin = new AdminWindow { Owner = this.Owner };
                admin.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный пароль");
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                enterButton_Click(sender, e);
            }
        }
    }
}