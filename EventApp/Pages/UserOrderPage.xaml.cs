using EventApp.Modules;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Логика взаимодействия для UserOrderPage.xaml
    /// </summary>
    public partial class UserOrderPage : Page
    {
        public UserOrder User { get; set; }

           public DateTime date = DateTime.Now;
        public UserOrderPage()
        {
            InitializeComponent();
            User = new UserOrder();
            DateTime dateTime = date.AddDays(7);
            User.UserID = AuthStorage.UserID;
            User.StatusID = 1;
            EventCb.ItemsSource = EventEntities.GetContext().Services.ToList();
            PlaceCb.ItemsSource = EventEntities.GetContext().Places.ToList();
            DataContext = User;
            MessageBox.Show("Стоимость залога составляет 30% от общей стоимости мероприятия!!!");
            OrgCl.SelectedDate = dateTime;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var newEvent = User;
            {
                User.OrderDate = date;
                User.OrgDate = OrgCl.SelectedDate.Value;
                User.PlaceID = (PlaceCb.SelectedItem as Place).PlaceID;
                // другие свойства
            }
            var existingEvent = EventEntities.GetContext().UserOrders.FirstOrDefault(p => p.OrgDate == newEvent.OrgDate && p.PlaceID == newEvent.PlaceID);
            if (existingEvent != null)
            {
                // Запись уже существует, выводим ошибку в MessageBox
                MessageBox.Show("Мероприятие на данное место и дату уже существует");
                return;
            }
            else
            {
                if (newEvent.OrgDate < newEvent.OrderDate)
                {
                    MessageBox.Show("Дата организации не может быть меньше даты заказа");
                }
                else
                {
                    try
                    {
                        User.ServiceID = (EventCb.SelectedItem as Service).ServiceID;
                        User.PlaceID = (PlaceCb.SelectedItem as Place).PlaceID;
                        if (User.UOrderID == 0)
                        {
                            if (EventCb.SelectedIndex == 0)
                            {
                                User.TotalPrice = 60000;
                                User.Deposit = 20000;
                            }
                            if (EventCb.SelectedIndex == 1)
                            {
                                User.TotalPrice = 45000;
                                User.Deposit = 15000;
                            }
                            else if (EventCb.SelectedIndex == 2)
                            {
                                User.TotalPrice = 80000;
                                User.Deposit = 27000;
                            }
                            else if (EventCb.SelectedIndex == 3)
                            {
                                User.TotalPrice = 90000;
                                User.Deposit = 30000;
                            }
                            else if (EventCb.SelectedIndex == 4)
                            {
                                User.TotalPrice = 100000;
                                User.Deposit = 35000;
                            }
                            User.OrderDate = date;
                            EventEntities.GetContext().UserOrders.Add(User);
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
           
    }
}

