using Sayap_SalonPhenomenon.Database;
using Sayap_SalonPhenomenon.Pages.ManagerPages.RecordsManager;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Sayap_SalonPhenomenon.Pages.ManagerPages
{
    /// <summary>
    /// Логика взаимодействия для MainManagerPage.xaml
    /// </summary>
    public partial class MainManagerPage : Page
    {
        public MainManagerPage()
        {
            InitializeComponent();
            RegistrationsDataGrid.ItemsSource = SalonEntities.GetContext().Registrations.ToList();
        }

        private void BTClients_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.MainFrame.Navigate(new ClientsManagerPage());
        }

        private void BTEmployees_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.MainFrame.Navigate(new EmployeesPageManager());
        }

        private void BTServices_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.MainFrame.Navigate(new ServicesManagerPage());
        }

        private void AddRecord_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.MainFrame.Navigate(new AddRecordManager((sender as Button).DataContext as Registrations));
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

        private void ChangeRecord_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.MainFrame.Navigate(new AddRecordManager((sender as Button).DataContext as Registrations));
        }

        private void BackToAutorization_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.MainFrame.Navigate(new Autorization());
        }
    }
}
