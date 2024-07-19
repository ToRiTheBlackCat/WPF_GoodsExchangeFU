using Repositories;
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
    /// Interaction logic for RatingsAndCommentsWindow.xaml
    /// </summary>
    public partial class RatingsAndCommentsWindow : Window
    {
        public int ExchangeId { get; set; }
        public int RaterId {  get; set; }
        private Exchange _exchange = null;

        private UserService _service = new();
        private ExchangeService _ex_service = new();
        public RatingsAndCommentsWindow()
        {
            InitializeComponent();
        }

        private void RateButton_Click(object sender, RoutedEventArgs e)
        {
            Rating rating = new()
            {
                ExchangeId = _exchange.ExchangeId,
                UserId = _exchange.Product.UserId,
                Score = decimal.Parse((string)(RatingsComboBox.SelectedValue as ComboBoxItem).Content),
                RatingDate = (DateTime)RateDatePicker.SelectedDate,
            };
            bool isRated = _service.FindRatingByExId(rating.ExchangeId);
            if (isRated)   //Rating already
            {
                MessageBox.Show("This Exchange ID was rated and commented", "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _service.AddRatingAndComment(rating);
            MessageBox.Show("Add rating and comment successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var user = _service.GetUserById(RaterId);
            RaterNameTextBlock.Text = user.UserName;
            RaterNameTextBlock.IsEnabled = false;
            RatingsComboBox.SelectedValue = Content;
            RatingsComboBox.SelectedIndex = 4;
            RateDatePicker.SelectedDate = DateTime.Now;
            RateDatePicker.IsEnabled = false;
            _exchange = _ex_service.GetExchange(ExchangeId);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        
    }
}
