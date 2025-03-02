using Sayap_SalonPhenomenon.Database;
using Sayap_SalonPhenomenon.Pages.AdminPages;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Sayap_SalonPhenomenon.Pages.EmployeesPages
{
    /// <summary>
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        public EmployeesPage()
        {
            InitializeComponent();
            MastersDataGrid.ItemsSource = SalonEntities.GetContext().Masters.ToList();
        }

        private void BackMasters_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.MainFrame.Navigate(new MainAdminPage());
        }

        private void DeleteMaster_Click(object sender, RoutedEventArgs e)
        {
            var DeleteMaster = MastersDataGrid.SelectedItems.Cast<Masters>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие: {DeleteMaster.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    SalonEntities.GetContext().Masters.RemoveRange(DeleteMaster);
                    SalonEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    MastersDataGrid.ItemsSource = SalonEntities.GetContext().Masters.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void AddNewMaster_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.MainFrame.Navigate(new AddEmployeePage());
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SalonEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            MastersDataGrid.ItemsSource = SalonEntities.GetContext().Masters.ToList();
        }
    }
}
