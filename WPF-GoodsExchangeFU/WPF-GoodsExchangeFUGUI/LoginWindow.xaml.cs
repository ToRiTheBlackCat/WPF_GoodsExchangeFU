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
        private readonly UserService _userService;
        public LoginWindow()
        {
            InitializeComponent();
            _userService = new UserService();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;

            var user = _userService.AuthenticateUser(email, password);
            
            if(user != null)
            {
                MessageBox.Show($"Login successful! Welcome, {user.UserName}");
                switch(user.RoleId) {
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
                    default:
                        MessageBox.Show("Unknown role");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Invalid email or password");
            }

        }


        
    }
}
