using Repositories;
using Repositories.Entities;
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
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        private int _userID;
        private int _productID;

        public ReportWindow()
        {
            InitializeComponent();
            
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string detail = ReportContentTextBox.Text;
            SaveReport(_userID, _productID, detail);
            MessageBox.Show("Report submitted!");
            this.Close();
        }

        private void SaveReport(int userID, int productID, string detail)
        {
            using (var context = new GoodsExchangeFudbContext())
            {
                var report = new Report
                {
                    UserId = userID,
                    ProductId = productID,
                    Detail = detail,
                    ReportDate = DateTime.Now,
                    Status = 0 
                };
                context.Reports.Add(report);
                context.SaveChanges();
            }
        }
    }
}
