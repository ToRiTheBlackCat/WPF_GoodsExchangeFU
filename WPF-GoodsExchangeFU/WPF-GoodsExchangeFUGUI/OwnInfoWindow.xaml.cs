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
using static System.Net.Mime.MediaTypeNames;

namespace WPF_GoodsExchangeFUGUI
{
    /// <summary>
    /// Interaction logic for OwnInfoWindow.xaml
    /// </summary>
    public partial class OwnInfoWindow : Window
    {
        bool visible = false;
        private MainWindow mainWindow;
        User user = new();

        private UserService _service = new();

        public OwnInfoWindow(User us, MainWindow mainWindow)
        {
            InitializeComponent();
            if(us != null) { user = us; }
            Loaded += LoadData;
            inpPwdVisible.Visibility = Visibility.Hidden;
            this.mainWindow = mainWindow; // Store reference to MainWin
        }

        private void LoadData(object sender, RoutedEventArgs e)
        {
            var status = "";
            txtName.Text = user.UserName;
            txtEmail.Text = user.Email;
            pwdBox.Password = user.Password;
            inpPwdVisible.Text = pwdBox.Password;
            txtPhone.Text = user.Phone;
            if (user.Gender) { btnMale.IsChecked = true; }
            else { btnFemale.IsChecked = true; }
            dateBirthday.SelectedDate = user.Dob.HasValue ? (DateTime?)user.Dob.Value.ToDateTime(TimeOnly.MinValue) : null;
            txtAddress.Text = user.Address;
            if (user.IsBanned) { status = "Your account is banned!"; }
            else { status = "Your account is good!"; }
            tbkAveScore.Text = _service.GetAveScore(user).ToString()+"/5";
            txtStatus.Text = status;
        }

        private void btShowPwd_Click(object sender, RoutedEventArgs e)
        {
            if (visible)
            {
                pwdBox.Password = inpPwdVisible.Text;
                //inpPwdVisible.Text = pwdBox.Password;
                inpPwdVisible.Visibility = Visibility.Hidden;
                visible = false;
            }
            else
            {
                inpPwdVisible.Text = pwdBox.Password;
                //pwdBox.Password = inpPwdVisible.Text;
                inpPwdVisible.Visibility = Visibility.Visible;
                visible = true;
            }
        }

        private void inpPwdVisible_SelectionChanged(object sender, RoutedEventArgs e)
        {
            pwdBox.Password = inpPwdVisible.Text;
        }

        private void pwdBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            inpPwdVisible.Text = pwdBox.Password;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var status = "";
            user.UserName = txtName.Text;
            //user.Email = txtEmail.Text;
            user.Password = pwdBox.Password;
            user.Phone = txtPhone.Text;
            if (btnMale.IsChecked==true) { user.Gender = true; }
            else if (btnFemale.IsChecked == true) { user.Gender = false; }
            user.Dob = DateOnly.FromDateTime((DateTime)dateBirthday.SelectedDate);
            user.Address = txtAddress.Text;
            var valid = notNullCheck(user);
            if(valid) {
                bool check = _service.UpdateUser(user);
                if (check) 
                {
                    MessageBox.Show("Detail updated successfully!");

                    // Update the main window's LoginedUser
                    mainWindow.UpdateLoginedUser(user);
                }
                // Update the main window's LoginedUser
                
            }
            else { MessageBox.Show("Please fill in all fields!"); }
            
        }

        private bool notNullCheck(User user)
        {
            if (!(user.UserName != null
                && user.Password != null
                && user.Phone != null
                && user.Gender != null
                && user.Dob != null
                && user.Address != null))
            { return false; }
            else { return true; }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();   
        }
    }
}
