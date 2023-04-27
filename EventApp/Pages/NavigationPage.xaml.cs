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
    /// Логика взаимодействия для NavigationPage.xaml
    /// </summary>
    public partial class NavigationPage : Page
    {
        public NavigationPage()
        {
            InitializeComponent();
            if (AuthStorage.RoleID == 1)
            {
                OrderBtn.Visibility = Visibility.Hidden;
                ClientBtn.Visibility = Visibility.Hidden;
                EMployeeBtn.Visibility = Visibility.Hidden;
            }
            if (AuthStorage.RoleID !=1 )
            {
                CreateBtn.Visibility = Visibility.Hidden;
            }
        }

        private void EventBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.EventPage());
        }

        private void PlaceBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.PlaceCatalogPage());
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.UserOrderPage());
        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.OrderListPage());
        }

        private void ClientBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ClientListPage());
        }

        private void EMployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.EmployeeListPage()); 
        }

        private void ReviewBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.ReviewPage());
        }

        private void LkBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.PersonalOfficePage());
        }
    }
}
