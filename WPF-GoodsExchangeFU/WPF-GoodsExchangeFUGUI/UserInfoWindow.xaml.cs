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
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            List<User> user = _service.GetUserByName(searchUser.Text);
            dgrUser.ItemsSource = user;
        }
    }
}
