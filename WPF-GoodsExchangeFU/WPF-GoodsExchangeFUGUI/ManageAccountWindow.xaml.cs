using Repositories.Entities;
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
    /// Interaction logic for ManageAccountWindow.xaml
    /// </summary>
    public partial class ManageAccountWindow : Window
    {
        private  UserService _userService = new(); 
        public ManageAccountWindow()
        {
            InitializeComponent();
            LoadAccount();
        }

        private void LoadAccount()
        {
            List<User> users = _userService.GetAllUSer();
            AccountsDataGrid.ItemsSource = users;
        }

        private void CreateModButton_Click(object sender, RoutedEventArgs e)
        {
            string username = NewUsernameTextBox.Text;
            string email = NewEmailTextBox.Text;
            string password = NewPasswordBox.Password;
            string phone = NewPhoneTextBox.Text;    

            if(!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(username)&& !string.IsNullOrWhiteSpace(password))
            {
                User user = new User()
                {
                    UserName = username,
                    Email = email,
                    Password = password,
                    Phone = phone,
                    RoleId = 2
                };
                _userService.CreateUser(user);
                LoadAccount();
                ClearInpuFields();
            }
            else
            {
                MessageBox.Show("Please fill all field");
            }
        }

        private void ClearInpuFields()
        {
            NewUsernameTextBox.Clear();
            NewEmailTextBox.Clear();
            NewPasswordBox.Clear();
            NewPhoneTextBox.Clear();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            LoadAccount();
            ClearInpuFields ();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
           MessageBoxResult result = MessageBox.Show("Do you sure want to delete this user?", "Confirm",MessageBoxButton.YesNo,MessageBoxImage.Question);
            if(result == MessageBoxResult.No)
                return;
            
            if(sender is FrameworkElement frameworkElement && frameworkElement.DataContext is User user) 
            {
                _userService.DeleteUser(user.UserId);
                LoadAccount();
            }
        }
    }
}
