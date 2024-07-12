using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic.ApplicationServices;
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
using Repositories.Models;
using static Repositories.Models.ProductModels;
using Repositories.Entities;
namespace WPF_GoodsExchangeFUGUI
{
    public partial class ReportWindow : Window
    {
        public Repositories.Entities.User ReportedUser { get; set; }
        public ProductView ReportedProduct { get; set; }

        private ReportService _service = new();
        public ReportWindow()
        {
            InitializeComponent();
            
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(DetailTextBox.Text))
            {
                MessageBox.Show("Report detail can not be empty", "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Report report = new Report()
            {
                UserId = ReportedUser.UserId,
                ProductId = ReportedProduct.ProductId,
                Detail = DetailTextBox.Text,
                ReportDate = DateTime.Now,
                Status = 0
            };
            _service.CreateReport(report);
            MessageBox.Show("Create report successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ReportedUserTextBlock.Text = ReportedUser.UserName;
            ReportedProductTextBlock.Text = ReportedProduct.ProductName;
            ReportDateDatePicker.SelectedDate = DateTime.Now;
            ReportDateDatePicker.IsEnabled = false;
        }
    }
}
