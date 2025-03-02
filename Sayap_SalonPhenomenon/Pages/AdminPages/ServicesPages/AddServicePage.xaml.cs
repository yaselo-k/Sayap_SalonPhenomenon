using Sayap_SalonPhenomenon.Database;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Sayap_SalonPhenomenon.Pages.AdminPages.ServicesPages
{
    /// <summary>
    /// Логика взаимодействия для AddServicePage.xaml
    /// </summary>
    public partial class AddServicePage : Page
    {
        private Services _currentServices = new Services();
        public AddServicePage()
        {
            InitializeComponent();
            DataContext = _currentServices;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.MainFrame.Navigate(new ServicesPage());
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentServices.NameService))
                errors.AppendLine("Введите имя");
            if (_currentServices.CostService <= 0)
                errors.AppendLine("Введите цену");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentServices.IDService == 0)
                SalonEntities.GetContext().Services.Add(_currentServices);

            try
            {
                SalonEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                AdminFrame.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
