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
    /// Interaction logic for WaitingReportWindow.xaml
    /// </summary>
    public partial class WaitingReportWindow : Window
    {
        private ReportService _service = new();
        private ProductService _productService = new();
        private UserService _userService = new();

        public WaitingReportWindow()
        {
            InitializeComponent();
        }

        private void WaitingReport_Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }
        private void LoadDataGrid()
        {
            WaitingReportListGataGrid.ItemsSource = null;
            WaitingReportListGataGrid.ItemsSource = _service.LoadWaitingReportList();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RemoveProductButton_Click(object sender, RoutedEventArgs e)
        {
            Report selected = WaitingReportListGataGrid.SelectedItem as Report;
            if (selected == null)
                MessageBox.Show("Please choose a report to action", "Invalid choice", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to remove this product?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    if (int.TryParse(selected.ProductId.ToString(), out int productId))
                    {
                        _productService.RemoveProduct(productId);
                        MessageBox.Show("Remove product successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    LoadDataGrid();
                }
            }
            LoadDataGrid();
        }

        private void BanUserButton_Click(object sender, RoutedEventArgs e)
        {
            Report selected = WaitingReportListGataGrid.SelectedItem as Report;
            if (selected == null)
                MessageBox.Show("Please choose a report to action", "Invalid choice", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to ban this user?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    if (int.TryParse(selected.User.UserId.ToString(), out int userId))
                    {
                        _userService.BanUser(userId);
                        MessageBox.Show("Ban user successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    LoadDataGrid();
                }
            }
            LoadDataGrid();
        }

        private void MarkDoneButton_Click(object sender, RoutedEventArgs e)
        {
            Report selected = WaitingReportListGataGrid.SelectedItem as Report;
            if (selected == null)
                MessageBox.Show("Please choose a report to mark done", "Invalid choice", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                selected.Status = 1;
                _service.MarkDoneReport(selected);
                MessageBox.Show("Mark done report successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            LoadDataGrid();

        }

    }
}
