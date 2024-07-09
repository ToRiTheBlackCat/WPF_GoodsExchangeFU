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
        public UserInfoWindow()
        {
            InitializeComponent();
            Loaded += Window_Loaded;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string gender, status;
            try
            {
                User user = _service.GetUserByName(searchUser.Text);
                if (user != null)
                {
                    txtName.Text = user.UserName;
                    txtEmail.Text = user.Email;
                    txtPhone.Text = user.Phone;
                    if (user.Gender) { gender = "Male"; }
                    else { gender = "Female"; }
                    txtGender.Text = gender;
                    txtBirthday.Text = user.Dob.ToString();
                    txtAddress.Text = user.Address;
                    if (user.IsBanned) { status = "This user is banned!"; }
                    else { status = "This user is good!"; }
                    txtStatus.Text = status;
                }
            } catch (Exception ex) { }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtName.Text = null;
            txtEmail.Text = null;
            txtPhone.Text = null;
            txtGender.Text = null;
            txtBirthday.Text = null;
            txtAddress.Text = null;
            txtStatus.Text = null;
        }
    }
}
