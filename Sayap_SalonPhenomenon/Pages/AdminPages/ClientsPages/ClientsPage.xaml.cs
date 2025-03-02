using Sayap_SalonPhenomenon.Database;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Sayap_SalonPhenomenon.Pages.AdminPages.ClientsPages
{
    /// <summary>
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public ClientsPage()
        {
            InitializeComponent();
            ClientsDataGrid.ItemsSource = SalonEntities.GetContext().Clients.ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.MainFrame.Navigate(new MainAdminPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.MainFrame.Navigate(new AddClientPage());
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                SalonEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                ClientsDataGrid.ItemsSource = SalonEntities.GetContext().Clients.ToList();
            }
        }

      
        private void DeleteClient_Click(object sender, RoutedEventArgs e)
        {
            var DeleteClient = ClientsDataGrid.SelectedItems.Cast<Clients>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие: {DeleteClient.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    SalonEntities.GetContext().Clients.RemoveRange(DeleteClient);
                    SalonEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    ClientsDataGrid.ItemsSource = SalonEntities.GetContext().Clients.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
