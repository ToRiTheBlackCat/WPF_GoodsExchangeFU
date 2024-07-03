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
    /// Interaction logic for WaitingProductWindow.xaml
    /// </summary>
    public partial class WaitingProductWindow : Window
    {
        private ProductService _service = new();
        public WaitingProductWindow()
        {
            InitializeComponent();
        }

        private void WaitingProduct_Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }
        private void LoadDataGrid()
        {
            WaitingProductListGataGrid.ItemsSource = null;
            WaitingProductListGataGrid.ItemsSource = _service.LoadWaitingProductList();
        }

        private void AcceptProductButton_Click(object sender, RoutedEventArgs e)
        {
            Product selected = WaitingProductListGataGrid.SelectedItem as Product;
            if (selected == null)
                MessageBox.Show("Please choose a product to accept", "Invalid product", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                selected.Status = 1;
                _service.ModAcceptProduct(selected);
                MessageBox.Show("Accept product successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            LoadDataGrid();
        }

        private void DenyProductButton_Click(object sender, RoutedEventArgs e)
        {
            Product selected = WaitingProductListGataGrid.SelectedItem as Product;
            if (selected == null)
                MessageBox.Show("Please choose a product to deny", "Invalid product", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                selected.Status = 0;
                _service.ModAcceptProduct(selected);
                MessageBox.Show("Deny product successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            LoadDataGrid();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
