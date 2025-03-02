using Sayap_SalonPhenomenon.Database;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Sayap_SalonPhenomenon.Pages.AdminPages.ServicesPages
{
    /// <summary>
    /// Логика взаимодействия для ServicesPage.xaml
    /// </summary>
    public partial class ServicesPage : Page
    {
        public ServicesPage()
        {
            InitializeComponent();
            ServicesDataGrid.ItemsSource = SalonEntities.GetContext().Services.ToList();
        }

        private void BackPage_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.MainFrame.Navigate(new MainAdminPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.MainFrame.Navigate(new AddServicePage());
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                SalonEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var DeleteService = ServicesDataGrid.SelectedItems.Cast<Services>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие: {DeleteService.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) 
            {
                try
                {
                    SalonEntities.GetContext().Services.RemoveRange(DeleteService);
                    SalonEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    ServicesDataGrid.ItemsSource = SalonEntities.GetContext().Services.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

        }
    }
}
