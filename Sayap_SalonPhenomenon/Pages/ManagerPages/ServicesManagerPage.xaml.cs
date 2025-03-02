using Sayap_SalonPhenomenon.Database;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Sayap_SalonPhenomenon.Pages.ManagerPages
{
    /// <summary>
    /// Логика взаимодействия для ServicesManagerPage.xaml
    /// </summary>
    public partial class ServicesManagerPage : Page
    {
        public ServicesManagerPage()
        {
            InitializeComponent();
            ServicesDataGrid.ItemsSource = SalonEntities.GetContext().Services.ToList();
        }

        private void BackPage_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.MainFrame.Navigate(new MainManagerPage());
        }
    }
}
