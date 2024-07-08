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
    /// Interaction logic for RatingsAndCommentsWindow.xaml
    /// </summary>
    public partial class RatingsAndCommentsWindow : Window
    {
        private int _exchangeID;
        private int _userID;

        public RatingsAndCommentsWindow(int exchangeID, int userID)
        {
            InitializeComponent();
            _exchangeID = exchangeID;
            _userID = userID;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            decimal score = (decimal)RatingSlider.Value;
            string comment = CommentTextBox.Text;
            SaveRating(_exchangeID, _userID, score, comment);
            MessageBox.Show("Rating and comment submitted!");
            this.Close();
        }

        private void SaveRating(int exchangeID, int userID, decimal score, string comment)
        {
            using (var context = new GoodsExchangeFudbContext())
            {
                var rating = new Rating
                {
                    ExchangeId = exchangeID,
                    UserId = userID,
                    Score = score,
                    Comment = comment,
                    RatingDate = DateTime.Now
                };
                context.Ratings.Add(rating);
                context.SaveChanges();
            }
        }
    }
}
