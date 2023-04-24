using EventApp.Modules;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EventApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для ReviewAddPage.xaml
    /// </summary>
    public partial class ReviewAddPage : Page
    {
        int a = 0;
        int b = 5;
        public Review Review { get; set; }
        public ReviewAddPage()
        {
            InitializeComponent();
            Review = new Review();
            DataContext = Review;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Review.ReviewID == 0)
                {
                    EventEntities.GetContext().Reviews.Add(Review);
                }
                EventEntities.GetContext().SaveChanges();
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        private void RatingTb_KeyDown(object sender, KeyEventArgs e)
        {
            if (!((e.Key.GetHashCode() >= 34) && (e.Key.GetHashCode() <= 43)) && !((e.Key.GetHashCode() >= 74) && (e.Key.GetHashCode() <= 83)))
            {
                e.Handled = true;
            }
        }

        private void RatingTb_TextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "012345 ,".IndexOf(e.Text) < 0;
        }

        private void RatingTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(IsGood);
        }

        bool IsGood(char c)
        {
            if (c >= '0' && c <= '5')
                return true;
            return false;
        }
    }
}
