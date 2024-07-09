
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
    /// Interaction logic for UserInfoWindow.xaml
    /// </summary>
    public partial class UserInfoWindow : Window
    {
        private UserService _service = new();
        private User selecteddUser;
        public User SelectedUser
        {
            get => selecteddUser;
            set
            {
                selecteddUser = value;
            }
        }
        public UserInfoWindow()
        {
            InitializeComponent();
            Loaded += Window_Loaded;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtName.Text = selecteddUser.UserName;
            txtEmail.Text = selecteddUser.Email;
            txtPhone.Text = selecteddUser.Phone;
            if (selecteddUser.Gender) { txtGender.Text = "Male"; }
            else { txtGender.Text = "Female"; }
            BirthdateDatePicker.SelectedDate = selecteddUser.Dob.Value.ToDateTime(TimeOnly.MinValue);
            txtAddress.Text = selecteddUser.Address;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
