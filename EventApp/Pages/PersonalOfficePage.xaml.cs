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
    /// Логика взаимодействия для PersonalOfficePage.xaml
    /// </summary>
    public partial class PersonalOfficePage : Page
    {
        public PersonalOfficePage()
        {
            InitializeComponent();
            NameTb.Text = AuthStorage.Surname;
            SurnameTb.Text = AuthStorage.Name;
            PatrTb.Text = AuthStorage.Patronymic;
            ClientLb.ItemsSource = EventEntities.GetContext().UserOrders.Where(p => p.UserID == AuthStorage.UserID).ToList();

        }
    }
}
