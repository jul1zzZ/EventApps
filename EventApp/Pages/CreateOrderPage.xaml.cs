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
    /// Логика взаимодействия для CreateOrderPage.xaml
    /// </summary>
    public partial class CreateOrderPage : Page
    {
        public Order Order { get; set; }
        public UserOrder UserOrder { get; set; }
        public CreateOrderPage()
        {
            InitializeComponent();
            Order = new Order();
            EmplCb.ItemsSource = EventEntities.GetContext().Employees.ToList();
            UOrderCb.ItemsSource = EventEntities.GetContext().UserOrders.Where(p => p.StatusID == 1).ToList();
            DataContext = Order;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order.EmployeeID = (EmplCb.SelectedItem as Employee).EmployeeID;
                Order.UOrderID = (UOrderCb.SelectedItem as UserOrder).UOrderID;
                if (Order.OrderID == 0)
                {
                    EventEntities.GetContext().Orders.Add(Order);
                }
                EventEntities.GetContext().SaveChanges();
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }
    }
}
