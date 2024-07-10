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
            
            
        }

       

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Handle text change if needed
        }
    }
}
