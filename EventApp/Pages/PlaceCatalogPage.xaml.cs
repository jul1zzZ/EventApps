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
    /// Логика взаимодействия для PlaceCatalogPage.xaml
    /// </summary>
    public partial class PlaceCatalogPage : Page
    {
        public PlaceCatalogPage()
        {
            InitializeComponent();
            PlaceLb.ItemsSource = EventEntities.GetContext().Places.ToList();
        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
