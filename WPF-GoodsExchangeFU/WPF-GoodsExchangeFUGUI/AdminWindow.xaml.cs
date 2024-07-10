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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void Quit_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult answer = MessageBox.Show("Do you want to logout and quit?", "Quit", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }

        private void ManageAccount_Click(object sender, RoutedEventArgs e)
        {
            ManageAccountWindow manageAccountWindow = new ManageAccountWindow();
            manageAccountWindow.ShowDialog();
        }

        private void ManageExchange_Click(object sender, RoutedEventArgs e)
        {
            ManageExchangeWindow manageExchangeWindow = new ManageExchangeWindow();
            manageExchangeWindow.ShowDialog();
        }
    }
}
