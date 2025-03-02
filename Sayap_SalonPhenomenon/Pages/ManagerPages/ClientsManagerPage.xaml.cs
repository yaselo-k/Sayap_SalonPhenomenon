using Sayap_SalonPhenomenon.Database;
using System.Linq;
using System.Windows.Controls;

namespace Sayap_SalonPhenomenon.Pages.ManagerPages
{
    /// <summary>
    /// Логика взаимодействия для ClientsManagerPage.xaml
    /// </summary>
    public partial class ClientsManagerPage : Page
    {
        public ClientsManagerPage()
        {
            InitializeComponent();
            ClientsDataGrid.ItemsSource = SalonEntities.GetContext().Clients.ToList();
        }

        private void Back_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            AdminFrame.MainFrame.Navigate(new MainManagerPage());
        }
    }
}
