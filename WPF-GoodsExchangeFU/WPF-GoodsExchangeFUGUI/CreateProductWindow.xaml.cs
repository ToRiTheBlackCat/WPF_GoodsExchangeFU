using Repositories.Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Repositories.Models.ProductModels;

namespace WPF_GoodsExchangeFUGUI
{
    /// <summary>
    /// Interaction logic for CreateProductWindow.xaml
    /// </summary>
    public partial class CreateProductWindow : Window
    {
        public CreateProductWindow()
        {
            InitializeComponent();
        }

        public User LoginedUser;

        private void grbCateSelect_Loaded(object sender, RoutedEventArgs e)
        {
            cbxPdctCate.ItemsSource = new ProductService().GetProductTypesUI();
            cbxPdctCate.DisplayMemberPath = nameof(ProductType.TypeName);
            cbxPdctCate.SelectedValuePath = nameof(ProductType.TypeId);

            cbxPdctCate.SelectedIndex = 0;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (LoginedUser.RoleId != 3)
            {
                System.Windows.MessageBox.Show($"You are not allowed to create Product", "Create Product",
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            try
            {
                // Check input
                var name = txtPdctName.Text;
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Name is empty.");

                var desc = txtPdctDesc.Text;
                if (string.IsNullOrEmpty(desc))
                    throw new Exception("Description is empty.");

                if (!int.TryParse(txtPdctPrice.Text, out int price))
                    throw new Exception("Price has to be number.");
                if (price < 0)
                    throw new Exception("Price is invalid.");

                int cate = (int)cbxPdctCate.SelectedValue;
                int userId = LoginedUser.UserId;

                // Create Product
                ProductService productService = new ProductService();
                productService.CreateProductUI(new Product()
                {
                    ProductName = name,
                    ProductDescription = desc,
                    ProductPrice = price,
                    ProductImage = System.IO.Path.GetFileName(filePath),
                    Status = 2,
                    TypeId = cate,
                    UserId = userId,
                });

                // Save image to file
                var mainDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
                var fileName = System.IO.Path.GetFileName(filePath);
                Directory.CreateDirectory(System.IO.Path.Combine(mainDirectory, "UserImages"));
                var uploadPath = System.IO.Path.Combine(mainDirectory, "UserImages", fileName);

                while (System.IO.File.Exists(uploadPath))
                {
                    int count = 0;
                    fileName = $"{count++}{fileName}";
                    uploadPath = System.IO.Path.Combine(mainDirectory, "UserImages", fileName);
                }

                File.Copy(filePath, uploadPath, true);

                // Success!!!
                System.Windows.MessageBox.Show($"Product created successfully!", "Create Product",
                       MessageBoxButton.OK, MessageBoxImage.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Invalid input values. {ex.Message}", "Create Product",
                       MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private string filePath;
        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                txtImageUrl.Text = openFileDialog.FileName;
                imgPdctPic.Source = new BitmapImage(new Uri(filePath));
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
