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
    /// Interaction logic for OwnProductWindow.xaml
    /// </summary>
    public partial class OwnProductWindow : Window
    {
        public User LoginUser { get; set; }

        private ProductService _service = new();

        List<Product>? prodList;

        public OwnProductWindow()
        {
            InitializeComponent();

        }


        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            prodList = _service.GetProductsByUser(LoginUser.UserId);
            dgrProducts.ItemsSource = null;
            dgrProducts.ItemsSource = prodList;
        }

        private void dgrProducts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Product selected = dgrProducts.SelectedItem as Product;
            DetailProductWindow detailProductWindow = new DetailProductWindow() { ProductView = selected, LoginedUser = LoginUser };
            detailProductWindow.ShowDialog();

            prodList = _service.GetProductsByUser(LoginUser.UserId);
            dgrProducts.ItemsSource = null;
            dgrProducts.ItemsSource = prodList;

        }
    }
}
