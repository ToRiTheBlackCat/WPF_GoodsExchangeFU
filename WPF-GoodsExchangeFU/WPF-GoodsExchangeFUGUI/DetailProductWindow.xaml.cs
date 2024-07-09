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
    /// Interaction logic for DetailProductWindow.xaml
    /// </summary>
    public partial class DetailProductWindow : Window
    {
        public User LoginUser { get; set; }

        private ProductService _service = new();

        List<Product>? prodList;

        public DetailProductWindow()
        {
            InitializeComponent();
            Loaded += dgrProductInfo_Loaded;
        }

        private void dgrProductInfo_Loaded(object sender, RoutedEventArgs e)
        {
            prodList = _service.GetProductsByUser(LoginUser.UserId);
            dgrProductInfo.ItemsSource = prodList;
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dgrProductInfo.SelectedItem == null)
            {
                MessageBox.Show("Please choose an account to update!");
            }
            else 
            {
                Product prod = dgrProductInfo.SelectedItem as Product;
                _service.UpdateProduct(prod);
                dgrProductInfo_Loaded(sender, e);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgrProductInfo.SelectedItem == null)
            {
                MessageBox.Show("Please choose an account to update!");
            }
            else
            {
                Product prod = dgrProductInfo.SelectedItem as Product;
                var result = System.Windows.MessageBox.Show("Are you sure you want to delete this entry?", "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    _service.RemoveProduct(prod.ProductId);
                    dgrProductInfo_Loaded(sender, e);
                }
                else if (result == MessageBoxResult.No)
                {

                }
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            prodList = _service.GetProductsByName(inpSearch.Text);
            dgrProductInfo.ItemsSource = prodList;
        }
    }
}
