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
    /// Логика взаимодействия для OrderListPage.xaml
    /// </summary>
    public partial class OrderListPage : Page
    {
        public List<Order> Orders { get; set; }
        public OrderListPage()
        {
            InitializeComponent();
            Orderdata.ItemsSource = null;
            Orders = EventEntities.GetContext().Orders.ToList();
            DataContext = this;
            Orderdata.ItemsSource = Orders;
            
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.CreateOrderPage());
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            List<Order> orders = EventEntities.GetContext().Orders.ToList();
            Orderdata.ItemsSource = orders;
        }
    }
}
