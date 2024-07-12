using Repositories.Entities;
using Repositories.Models;
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
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {
        private UserService service = new();
        public DetailWindow()
        {
            InitializeComponent();
        }

        public ProductModels.ProductView ProductView { get; set; }

        public User LoginedUser { get; set; }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            btnRemove.IsEnabled = false;
            btnRemove.Visibility = Visibility.Hidden;
            if (LoginedUser.UserName.Equals(ProductView.UserName))
            {
                btnExchange.IsEnabled = false;
                btnReport.IsEnabled = false;
            }

            if (LoginedUser.RoleId == 2) 
            {
                btnExchange.IsEnabled = false;
                btnReport.IsEnabled = false;
                btnExchange.Visibility = Visibility.Hidden;
                btnReport.Visibility = Visibility.Hidden;
                btnRemove.IsEnabled = true;
                btnRemove.Visibility = Visibility.Visible;
            }
                
            txtPdctName.Text = ProductView.ProductName;
            txtPdctDesc.Text = ProductView.ProductDescription;
            txtPdctPrice.Text = $"{ProductView.ProductPrice}";
            txtPdctCate.Text = ProductView.TypeName;
            txtPdctUser.Text = ProductView.UserName;

            var mainDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            var uploadPath = System.IO.Path.Combine(mainDirectory, "UserImages", ProductView.ProductImage);
            if (!System.IO.File.Exists(uploadPath))
            {
                System.Windows.MessageBox.Show($"Error. Can't find image", "Product Details",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            imgPdctPic.Source = new BitmapImage(new Uri(uploadPath));
        }

        //private void SelectImage_Click(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.Filter = "Image Files (*.jpg; *.png; *.bmp)|*.jpg;*.png;*.bmp";

        //    var mainDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
        //    var uploadPath = System.IO.Path.Combine(mainDirectory, "UserImages", ProductView.ProductImage);

        //    imgPdctPic.Source = new BitmapImage(new Uri(uploadPath));

        //    //if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    //{
        //    //    string imagePath = openFileDialog.FileName;
        //    //    imgPdctPic.Source = new BitmapImage(new Uri(imagePath));
        //    //}
        //    Console.WriteLine(System.AppDomain.CurrentDomain.BaseDirectory);

        //}

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userName = txtPdctUser.Text.Trim();
                if (string.IsNullOrEmpty(userName))
                    throw new Exception("User field is empty!");

                
                var reportedUser = service.GetUserByName(userName);
                if (reportedUser == null)
                    throw new Exception($"No user with this name (\"{userName}\")!");

                //Show Report window
                ReportWindow reportWindow = new ReportWindow()
                {
                    ReportedUser = reportedUser,
                    ReportedProduct = ProductView
                };
                reportWindow.ShowDialog();
                //=================
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Error. {ex.Message}", "Product Details",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to REMOVE this object?", "Remove Confirm?"
                    , MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes) 
                {
                    ProductService service = new ProductService();
                    service.RemoveProductUI(ProductView.ProductId);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Error! {ex.Message}", "Remove",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnExchange_Click(object sender, RoutedEventArgs e)
        {
           

            ProductService service = new ProductService();
            
            var WantedProduct = service.GetProduct(ProductView.ProductId);
            if (WantedProduct == null || WantedProduct.Status != 1)
            {
                System.Windows.MessageBox.Show($"Error. Product not available for exchange.", "Product Details",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
                
            var buyer = new UserService().GetUserByName(LoginedUser.UserName);

            ExchangeWindow exchangeWindow = new ExchangeWindow()
            {
                WantedProduct = WantedProduct,
                LoginedUser = buyer
            };
            exchangeWindow.ShowDialog();
            this.Close();
        }

        private void btnViewProfile_Click(object sender, RoutedEventArgs e)
        {
            UserInfoWindow userInfoWindow = new UserInfoWindow() 
            { 
            SelectedUser = service.GetUserByName(ProductView.UserName)
            };
            userInfoWindow.ShowDialog();

        }
    }
}
