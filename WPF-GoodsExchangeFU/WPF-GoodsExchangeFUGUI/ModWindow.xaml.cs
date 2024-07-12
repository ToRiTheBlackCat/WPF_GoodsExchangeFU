using Repositories.Entities;
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
    /// Interaction logic for ModWindow.xaml
    /// </summary>
    public partial class ModWindow : Window
    {
        private User _loginUser;

        public User LoginedUser
        {
            get { return _loginUser; }
            set { _loginUser = value; }
        }

        public ModWindow()
        {
            InitializeComponent();
        }

        private void HomePageButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new() { LoginedUser = _loginUser };
            mainWindow.ShowDialog();
        }

        private void WaitingProductButton_Click(object sender, RoutedEventArgs e)
        {
            WaitingProductWindow waitingProductWindow = new();
            waitingProductWindow.ShowDialog();
        }

        private void WaitingReportButton_Click(object sender, RoutedEventArgs e)
        {
            WaitingReportWindow waitingReportWindow = new()
            {
                User = LoginedUser
            };
            waitingReportWindow.ShowDialog();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult answer = MessageBox.Show("Do you want to logout and quit?", "Quit", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }
    }
}
