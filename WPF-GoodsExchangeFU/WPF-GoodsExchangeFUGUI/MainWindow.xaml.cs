using Repositories.Entities;
using Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace WPF_GoodsExchangeFUGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            //new ProductService().GetProductsUI("search", "name",new int[] { });
        }
        private User loginedUser;
        public User LoginedUser
        {
            get => loginedUser;
            set
            {
                loginedUser = value;
                OnPropertyChanged(nameof(LoginedUser));
            }
        }
        public void UpdateLoginedUser(User updatedUser)
        {
            LoginedUser = updatedUser;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void cbxOrder_Loaded(object sender, RoutedEventArgs e)
        {
            txtPriceTo.Text = "0";
            Dictionary<string, string> cbxValues = new Dictionary<string, string>
            {
                { "Name by A-Z", "name" },
                { "Name by Z-A", "name_desc"},
                { "Price Asc", "price"},
                { "Price Desc", "price_desc"}
            };
            
            foreach (var p in cbxValues)
            {
                cbxOrder.Items.Add(new ComboBoxItem()
                {
                    Content = p.Key,
                    Tag = p.Value,
                });
            }
            cbxOrder.SelectedIndex = 0;

            FillDataGrid();
        }

        private void rdbtn_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void rdbtn_Click(object sender, RoutedEventArgs e)
        {
            var group = LogicalTreeHelper.GetChildren(grbCateSelect).OfType<System.Windows.Controls.RadioButton>();
            var checkBtn = group.First(btn => btn.IsChecked == true);
            //if (checkBtn.Equals(sender)) 
            //{
            //    checkBtn.IsChecked = false;
            //    return;
            //}
            string checkedValue = (string)checkBtn.Tag;
            if (int.TryParse(checkedValue, out int result))
                if (result != SelectedCate)
                    SelectedCate = result;
                else
                {
                    SelectedCate = 0;
                    checkBtn.IsChecked = false;
                }
              
            txtSearch.Clear();
            txtPriceFrom.Text = "0";
            txtPriceTo.Text = "0";
            FromPrice = 0;
            ToPrice = 999999999;
            cbxOrder.SelectedIndex = 0;

            FillDataGrid();

        }

        private int SelectedCate = 0;
        private int FromPrice = 0;
        private int ToPrice = 999999999;
        public void FillDataGrid()
        {
            if (dgvProducts.ItemsSource == null)
                dgvProducts.Items.Clear();
            dgvProducts.ItemsSource = new ProductService().GetProductsUI(txtSearch.Text.Trim(), (string)(cbxOrder.SelectedItem as ComboBoxItem).Tag, SelectedCate, FromPrice, ToPrice);
        }

        private void cbxOrder_DropDownClosed(object sender, EventArgs e)
        {
            FillDataGrid();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!int.TryParse(txtPriceFrom.Text.Trim(), out int priceFrom) || !int.TryParse(txtPriceTo.Text.Trim(), out int priceTo))
                    throw new Exception("Price has to be number.");

                if (priceFrom == 0 && priceTo == 0)
                    priceTo = 999999999;
                if (priceFrom < 0 || priceTo < 0 || priceFrom > priceTo)
                {
                    throw new Exception("Invalid Price values.");
                }

                FromPrice = priceFrom;
                ToPrice = priceTo;

                FillDataGrid();
                txtSearch.Clear();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Invalid Search values. {ex.Message}", "Search",
                       MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtSearch.Clear();
            txtPriceFrom.Text = "0";
            txtPriceTo.Text = "0";
            FromPrice = 0;
            ToPrice = 999999999;
            cbxOrder.SelectedIndex = 0;
            FillDataGrid();
        }

        private void dgvProducts_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (dgvProducts.SelectedItems.Count == 1)
            {
                if (LoginedUser == null)
                {
                    System.Windows.MessageBox.Show($"You are not logged-in. Please login", "System",
                           MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }

                var selectedProduct = dgvProducts.SelectedItems[0];
                // Direct to ProductDetail Window
                DetailWindow window = new DetailWindow()
                {
                    ProductView = selectedProduct as Repositories.Models.ProductModels.ProductView,
                    LoginedUser = LoginedUser
                };
                window.ShowDialog();
            }
            Console.WriteLine(dgvProducts.SelectedItems);
            dgvProducts.SelectedIndex = -1;
             
            FillDataGrid();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (LoginedUser == null)
            {
                System.Windows.MessageBox.Show($"You are not logged-in. Please login", "System",
                       MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            CreateProductWindow createProductWindow = new CreateProductWindow()
            {
                LoginedUser = LoginedUser,
            };
            createProductWindow.ShowDialog();


            txtSearch.Clear();
            txtPriceFrom.Text = "0";
            txtPriceTo.Text = "0";
            FromPrice = 0;
            ToPrice = 999999999;
            cbxOrder.SelectedIndex = 0;
            FillDataGrid();
        }

        private void btnCreate_Copy_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void MyProfileButton_Click(object sender, RoutedEventArgs e)
        {
            OwnInfoWindow ownInfoWindow = new OwnInfoWindow(loginedUser, this);
            ownInfoWindow.ShowDialog();

        }

        private void MyProductButton_Click(object sender, RoutedEventArgs e)
        {
            OwnProductWindow ownProductWindow = new OwnProductWindow();
            ownProductWindow.LoginUser = loginedUser;
            ownProductWindow.ShowDialog();
        }

        private void MyExchangeButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}