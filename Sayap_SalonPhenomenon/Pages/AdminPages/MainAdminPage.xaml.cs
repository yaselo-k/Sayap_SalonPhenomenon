using Sayap_SalonPhenomenon.Database;
using Sayap_SalonPhenomenon.Pages.AdminPages.ClientsPages;
using Sayap_SalonPhenomenon.Pages.AdminPages.ServicesPages;
using Sayap_SalonPhenomenon.Pages.EmployeesPages;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Sayap_SalonPhenomenon.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для MainAdminPage.xaml
    /// </summary>
    public partial class MainAdminPage : Page
    {
        public MainAdminPage()
        {
            InitializeComponent();
            RegistrationsDataGrid.ItemsSource = SalonEntities.GetContext().Registrations.ToList();
        }

        private void AddRecord_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.MainFrame.Navigate(new AddRecordPage((sender as Button).DataContext as Registrations));
        }

        private void BTServices_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.MainFrame.Navigate(new ServicesPage());
        }

        private void BTClients_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.MainFrame.Navigate(new ClientsPage());
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                SalonEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            }
        }

        private void DeleteRecord_Click(object sender, RoutedEventArgs e)
        {
            var DeleteRegistration = RegistrationsDataGrid.SelectedItems.Cast<Registrations>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие: {DeleteRegistration.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    SalonEntities.GetContext().Registrations.RemoveRange(DeleteRegistration);
                    SalonEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    RegistrationsDataGrid.ItemsSource = SalonEntities.GetContext().Registrations.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BTEmployees_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.MainFrame.Navigate(new EmployeesPage());
        }

        private void ChangeRecord_Click(object sender, RoutedEventArgs e)
        {
             AdminFrame.MainFrame.Navigate(new AddRecordPage((sender as Button).DataContext as Registrations));
        }

        private void BackToAutorization_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.MainFrame.Navigate(new Autorization());
        }
    }
}
