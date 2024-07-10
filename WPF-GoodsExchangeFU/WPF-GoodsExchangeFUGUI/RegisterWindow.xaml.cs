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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private readonly UserService _userService;
        public RegisterWindow()
        {
            InitializeComponent();
            _userService = new UserService();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string userName = UserNameTextBox.Text;
                string password = PasswordBox.Password;
                string confirmPassword = ConfirmPasswordBox.Password;
                string email = EmailTextBox.Text;
                string phone = PhoneTextBox.Text;
                bool gender = ((ComboBoxItem)GenderComboBox.SelectedItem)?.Content.ToString() == "Male";
                DateTime? dateOfBirth = DateOfBirthPicker.SelectedDate;
                string address = AddressTextBox.Text;

                if (password != confirmPassword)
                {
                    MessageBox.Show("Password does not match!");
                    return;
                }
                if (string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Email cannot be empty!");
                    return;
                }

                if (string.IsNullOrEmpty(phone))
                {
                    MessageBox.Show("Phone number cannot be empty!");
                    return;
                }

                var user = new User
                {
                    UserName = userName,
                    Password = password,
                    Email = email,
                    Phone = phone,
                    Gender = gender,
                    Address = address,
                    Dob = dateOfBirth.HasValue ? DateOnly.FromDateTime(dateOfBirth.Value) : (DateOnly?)null,
                    RoleId = 3,
                    IsBanned = false
                };

                _userService.RegisterUser(user);
                MessageBox.Show("Sign up successfully");
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error{ex.Message}");
            }
        }
    }
}
