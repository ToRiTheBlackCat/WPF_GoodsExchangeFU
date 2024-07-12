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
        public Exchange SelectedExchange { get; set; }
        public User Rater { get; set; }
        private UserService _service = new();
        public RatingsAndCommentsWindow()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            Rating rating = new()
            {
                ExchangeId = SelectedExchange.ExchangeId,
                UserId = SelectedExchange.Product.UserId,
                Score = (decimal)RatingsComboBox.SelectedValue,
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
            RaterNameTextBlock.Text = Rater.UserName;
            RaterNameTextBlock.IsEnabled = false;
            RatingsComboBox.SelectedValue = decimal.Parse(Content.ToString());
            RatingsComboBox.SelectedIndex = 4;
            RateDatePicker.SelectedDate = DateTime.Now;
            RateDatePicker.IsEnabled = false;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
