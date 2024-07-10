using Microsoft.IdentityModel.Tokens;
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
using static Repositories.Models.ProductModels;

namespace WPF_GoodsExchangeFUGUI
{
    /// <summary>
    /// Interaction logic for ExchangeWindow.xaml
    /// </summary>
    public partial class ExchangeWindow : Window
    {
        public ExchangeWindow()
        {
            InitializeComponent();
        }

        public User LoginedUser;
        public Product WantedProduct;
        private ProductView YourProduct;

        private void grdWantedProduct_Loaded(object sender, RoutedEventArgs e)
        {
            txtWantedName.Text = WantedProduct.ProductName;
            txtWantedDesc.Text = WantedProduct.ProductDescription;
            txtWantedPrice.Text = $"{WantedProduct.ProductPrice}";
            txtWantedCate.Text = WantedProduct.Type.TypeName;
            txtWantedUser.Text = WantedProduct.User.UserName;

            var mainDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            var uploadPath = System.IO.Path.Combine(mainDirectory, "UserImages", WantedProduct.ProductImage);
            if (!System.IO.File.Exists(uploadPath))
            {
                System.Windows.MessageBox.Show($"Error. Can't find image", "Product Details",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            imgWantedPdct.Source = new BitmapImage(new Uri(uploadPath));
        }

        private void FillYourProduct()
        {
            txtPdctName.Text = YourProduct.ProductName;
            txtPdctDesc.Text = YourProduct.ProductDescription;
            txtPdctPrice.Text = $"{YourProduct.ProductPrice}";
            txtPdctCate.Text = YourProduct.TypeName;
            txtPdctUser.Text = YourProduct.UserName;

            var mainDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            var uploadPath = System.IO.Path.Combine(mainDirectory, "UserImages", YourProduct.ProductImage);
            if (!System.IO.File.Exists(uploadPath))
            {
                System.Windows.MessageBox.Show($"Error. Can't find image", "Product Details",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                imgPdctPic.Source = null;
                return;
            }

            imgPdctPic.Source = new BitmapImage(new Uri(uploadPath));
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            ReloadDataGrid();
        }

        private void ReloadDataGrid()
        {
            lblNoProduct.Visibility = Visibility.Hidden;

            var yourProductList = new ProductService().GetProductsByUser(LoginedUser.UserId);
            if (yourProductList.IsNullOrEmpty())
            {
                lblNoProduct.Visibility = Visibility.Visible;
                return;
            }

            dgvYourProducts.ItemsSource = yourProductList;
        }

        private void dgvYourProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvYourProducts.SelectedItems.Count > 0)
            {
                var selected = (Product)dgvYourProducts.SelectedItems[0]!;
                YourProduct = new ProductView()
                {
                    ProductName = selected.ProductName,
                    ProductDescription = selected.ProductDescription,
                    ProductId = selected.ProductId,
                    ProductImage = selected.ProductImage,
                    ProductPrice = selected.ProductPrice,
                    TypeName = selected.Type.TypeName,
                    UserName = selected.User.UserName
                };
            }

            FillYourProduct();
        }

        private int balanceMult = -1;

        private void btnExchange_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to request Exchange?", "Exchange Confirm?"
                    , MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    if (!int.TryParse(txtBalance.Text.Trim(), out int balance) || balance < 0)
                        throw new Exception("Invalid balance input!");

                    ExchangeService exchangeService = new ExchangeService();
                    exchangeService.MakeExchangeUI(LoginedUser.UserName, WantedProduct.ProductId, YourProduct.ProductId, balanceMult*balance);
                    System.Windows.MessageBox.Show($"Exchange created", "Exchange Create"
                    , MessageBoxButton.OK, MessageBoxImage.Information);

                    this.Close();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show($"Error. {ex.Message}", "Exchange Error!"
                    , MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateProductWindow createProductWindow = new CreateProductWindow()
            {
                LoginedUser = LoginedUser,
            };
            createProductWindow.ShowDialog();

            ReloadDataGrid();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            var rdGroup = LogicalTreeHelper.GetChildren(grdBalanceSelect).OfType<System.Windows.Controls.RadioButton>();
            var checkedBtn = rdGroup.First(btn => btn.IsChecked == true);
            if (((string)checkedBtn.Content).Contains("You"))
                balanceMult = -1;
            else
                balanceMult = 1;
        }
    }
}
