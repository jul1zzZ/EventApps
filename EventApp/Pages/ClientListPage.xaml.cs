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
    /// Логика взаимодействия для ClientListPage.xaml
    /// </summary>
    public partial class ClientListPage : Page
    {
        public List<User> Users { get; set; }
        public ClientListPage()
        {
            InitializeComponent();
            ClientData.ItemsSource = null;
            Users = EventEntities.GetContext().Users.Where(p => p.RoleID == 1).ToList();
            DataContext = this;
            ClientData.ItemsSource = Users;
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            List<User> users = EventEntities.GetContext().Users.Where(p => p.RoleID == 1).ToList();
            ClientData.ItemsSource = users;
        }
    }
}
