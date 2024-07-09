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
            Loaded += dgrProducts_Loaded;
            //LoginUser = us;
        }

        private void dgrProducts_Loaded(object sender, RoutedEventArgs e)
        {
            prodList = _service.GetProductsByUser(LoginUser.UserId);
            dgrProducts.ItemsSource = prodList;
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            prodList = _service.GetProductsByName(searchProduct.Text);
            dgrProducts.ItemsSource = prodList;
        }
    }
}
