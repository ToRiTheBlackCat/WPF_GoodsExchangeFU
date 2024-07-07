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
    /// Interaction logic for ManageExchangeWindow.xaml
    /// </summary>
    public partial class ManageExchangeWindow : Window
    {
        private ExchangeService _exchangeService = new();
        public ManageExchangeWindow()
        {
            InitializeComponent();
            LoadExchange();
        }

        private void LoadExchange()
        {
            List<Exchange> exchanges = _exchangeService.GetAllExchange();
            ExchangesDataGrid.ItemsSource = exchanges;
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            LoadExchange();
        }
    }
}
