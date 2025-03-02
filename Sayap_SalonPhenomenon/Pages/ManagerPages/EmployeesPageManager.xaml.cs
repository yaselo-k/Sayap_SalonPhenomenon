using Sayap_SalonPhenomenon.Database;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Sayap_SalonPhenomenon.Pages.ManagerPages
{
    /// <summary>
    /// Логика взаимодействия для EmployeesPageManager.xaml
    /// </summary>
    public partial class EmployeesPageManager : Page
    {
        public EmployeesPageManager()
        {
            InitializeComponent();
            MastersDataGrid.ItemsSource = SalonEntities.GetContext().Masters.ToList();
        }

        private void BackMasters_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.MainFrame.Navigate(new MainManagerPage());
        }
    }
}
