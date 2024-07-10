using Repositories.Entities;
using Services;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for DetailProductWindow.xaml
    /// </summary>
    public partial class DetailProductWindow : Window
    {
        public User LoginUser { get; set; }

        private ProductService _service = new();
        public User LoginedUser { get; set; }
        public Product ProductView { get; set; }

        

        public DetailProductWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            CateComboBox.ItemsSource = new ProductService().GetProductTypesUI();
            CateComboBox.DisplayMemberPath = nameof(ProductType.TypeName);
            CateComboBox.SelectedValuePath = nameof(ProductType.TypeId);

            CateComboBox.SelectedIndex = 0;
            //===================

            txtPdctName.Text = ProductView.ProductName;
            txtPdctDesc.Text = ProductView.ProductDescription;
            txtPdctPrice.Text = $"{ProductView.ProductPrice}";
            CateComboBox.SelectedValue = ProductView.TypeId;

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

        string filePath;
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
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

                int cate = (int)CateComboBox.SelectedValue;
                int userId = LoginedUser.UserId;

                // Create Product
                ProductService productService = new ProductService();
                productService.UpdateProduct(new Product()
                {
                    ProductId = ProductView.ProductId,
                    ProductName = name,
                    ProductDescription = desc,
                    ProductPrice = price,
                    ProductImage = System.IO.Path.GetFileName(filePath),
                    Status = 1,
                    TypeId = cate,
                    UserId = userId,
                });

                // Save image to file
                var mainDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
                var fileName = System.IO.Path.GetFileName(filePath);
                Directory.CreateDirectory(System.IO.Path.Combine(mainDirectory, "UserImages"));
                var uploadPath = System.IO.Path.Combine(mainDirectory, "UserImages", fileName);



                File.Copy(filePath, uploadPath, true);

                // Success!!!
                System.Windows.MessageBox.Show($"Product update successfully!", "Create Product",
                       MessageBoxButton.OK, MessageBoxImage.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Invalid input values. {ex.Message}", "Create Product",
                       MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void ChooseImageButton_Click(object sender, RoutedEventArgs e)
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
    }
}
