using Services;
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

namespace WPF_GoodsExchangeFUGUI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private  UserService _userService = new();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmailTextBox.Text) || string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                MessageBox.Show("Please enter both email and password.", "Incomplete Data", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;

            var user = _userService.AuthenticateUser(email, password);

            if (user != null)
            {
                MessageBox.Show($"Login successful! Welcome, {user.UserName}");
                switch (user.RoleId)
                {
                    case 1:
                        AdminWindow adminWindow = new AdminWindow();
                        adminWindow.Show();
                        this.Close();
                        break;
                    case 2:
                        ModWindow modWindow = new ModWindow();
                        modWindow.Show();
                        this.Close();
                        break;
                    case 3:
                        MainWindow mainWindow = new MainWindow()
                        {
                            LoginedUser = user,
                        };
                        mainWindow.Show();
                        this.Close();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Account not found", "Incorrect email or password", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult answer = MessageBox.Show("Do you want to logout and quit?", "Quit", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }
    }
}
