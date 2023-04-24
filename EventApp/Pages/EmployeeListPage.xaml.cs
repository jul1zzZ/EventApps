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
    /// Логика взаимодействия для EmployeeListPage.xaml
    /// </summary>
    public partial class EmployeeListPage : Page
    {
        public List<Employee> Employees { get; set; }
        public EmployeeListPage()
        {
            InitializeComponent();
            EmplData.ItemsSource = null;
            Employees = EventEntities.GetContext().Employees.ToList();
            EmplData.ItemsSource = Employees;
            DataContext = this;

            List<Post> posts = EventEntities.GetContext().Posts.ToList();
            posts.Insert(0, new Post
            {
                Name = "Все"
            });
            FiltCb.ItemsSource = posts;
            FiltCb.DisplayMemberPath = "Name";
            FiltCb.SelectedIndex = 0;
        }

        private void Update()
        {
            List<Employee> employees = EventEntities.GetContext().Employees.ToList();
            if (FiltCb.SelectedIndex > 0)
            {
                employees = employees.Where(p => p.PostID == (FiltCb.SelectedItem as Post).PostID).ToList();
            }
            EmplData.ItemsSource = employees;
        }

        private void FiltCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }
    }
}
