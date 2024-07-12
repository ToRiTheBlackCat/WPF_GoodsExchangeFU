using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using Repositories;
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
using static Repositories.Models.ExchangeModel;

namespace WPF_GoodsExchangeFUGUI
{
    /// <summary>
    /// Interaction logic for OwnExchangeWindow.xaml
    /// </summary>
    public partial class OwnExchangeWindow : Window
    {
        public OwnExchangeWindow()
        {
            InitializeComponent();
        }

        public void LoadDataGrid()
        {
            ExchangeService exchangeService = new ExchangeService();
            var source = exchangeService.GetOwnExchange(_userId);

            YourExchangesDataGrid.ItemsSource = source;

            CancelButton.Visibility = Visibility.Hidden;
            CancelButton.IsEnabled = false;

            //====Second tab====
            ProductService productService = new ProductService();
            var yourProduct = productService.GetProductsByUser(_userId);
            YourProductGrid.ItemsSource = yourProduct;
        }

        public required int _userId { get; set; }

        private OwnExchangeView? _selectedExchange;
        private void YourExchangesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (YourExchangesDataGrid.SelectedItems.Count > 0)
            {
                _selectedExchange = YourExchangesDataGrid.SelectedItems[0] as OwnExchangeView;
                FillExchangeDetails();
            }
        }

        public void FillExchangeDetails()
        {
            if (_selectedExchange == null)
            {
                WantedProductText.Text = null;
                SellerText.Text = null;
                YourProductText.Text = null;
                BalanceText.Text = null;
                DatePicker.SelectedDate = DateTime.Now;
                StatussText.Text = "Undefined";
                return;
            }
                

            WantedProductText.Text = _selectedExchange.WantedProductName;
            SellerText.Text = _selectedExchange.SellerName;
            YourProductText.Text = _selectedExchange.OwnProductName;
            BalanceText.Text = $"{_selectedExchange.Balance}";
            DatePicker.SelectedDate = _selectedExchange.CreateDate.ToDateTime(TimeOnly.MinValue);
            switch (_selectedExchange.Status)
            {
                case 2:
                    StatussText.Text = "Pending";
                    break;
                case 1:
                    StatussText.Text = "Accepted";
                    break;
                case 0:
                    StatussText.Text = "Declined";
                    break;
            }

            if (_selectedExchange.Status == 2)
            {
                CancelButton.Visibility = Visibility.Visible;
                CancelButton.IsEnabled = true;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ExchangeService exchangeService = new ExchangeService();
            if (_selectedExchange != null)
            {
                try
                {
                    exchangeService.CancelExchange(_selectedExchange.ExchangeId);
                    MessageBox.Show("Cancel successfully", "Cancel Exchange", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Exception: {ex.Message}", "Cancel Exchange", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an exchange to cancel", "Cancel Exchange", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            _selectedExchange = null;
            FillExchangeDetails();
            LoadDataGrid();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private Product _selectedProduct;
        private void YourProductGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (YourProductGrid.SelectedItems.Count > 0)
            {
                _selectedProduct = YourProductGrid.SelectedItems[0] as Product;
                FillProductExchangeGrid();
            }
        }

        private void FillProductExchangeGrid()
        {
            ExchangeService exchangeService = new ExchangeService();
            var productExchange = exchangeService.GetSentExchange(_selectedProduct.ProductId);
            ProductExchangeGrid.ItemsSource = productExchange;
        }

        private ReceivedExchangeView? _selectedReceivedExchange;
        private void ProductExchangeGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductExchangeGrid.SelectedItems.Count > 0)
            {
                _selectedReceivedExchange = ProductExchangeGrid.SelectedItems[0] as ReceivedExchangeView;
                FillSentExchangeDetails();
            }
        }
        
        private void FillSentExchangeDetails()
        {
            if (_selectedReceivedExchange == null)
            {
                YourProductText1.Text = null;
                OfferProductText.Text = null;
                BuyerText.Text = null;
                BalanceText1.Text = null;
                DatePicker1.SelectedDate = DateTime.Now;

                return;
            }
                

            YourProductText1.Text = _selectedReceivedExchange.OwnProductName;
            OfferProductText.Text = _selectedReceivedExchange.OfferProductName;
            BuyerText.Text = _selectedReceivedExchange.BuyerName;
            BalanceText1.Text = $"{_selectedReceivedExchange.OfferBalance}";
            DatePicker1.SelectedDate = _selectedReceivedExchange.CreateDate.ToDateTime(TimeOnly.MinValue);
        }

        private void DeclineButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedReceivedExchange == null)
            {
                MessageBox.Show("Please select an exchange to Decline", "Decline Exchange", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            try
            {
                ExchangeService exchangeService = new ExchangeService();
                exchangeService.UserDeclineExchange(_selectedReceivedExchange.ExchangeId);
                MessageBox.Show("Decline successfully", "Decline Exchange", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception: {ex.Message}", "Decline Exchange", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            _selectedReceivedExchange = null;
            FillSentExchangeDetails();
            LoadDataGrid();
            FillProductExchangeGrid();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedReceivedExchange == null)
            {
                MessageBox.Show("Please select an exchange to Accept", "Accept Exchange", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            try {
                ExchangeService exchangeService = new ExchangeService();
                exchangeService.UserAcceptExchange(_selectedReceivedExchange.ExchangeId);
                MessageBox.Show("Accept successfully", "Accept Exchange", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception: {ex.Message}", "Accept Exchange", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            _selectedReceivedExchange = null;
            FillSentExchangeDetails();
            LoadDataGrid();
            FillProductExchangeGrid();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }
    }
}
