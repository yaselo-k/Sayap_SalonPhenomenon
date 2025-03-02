using Sayap_SalonPhenomenon.Database;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Sayap_SalonPhenomenon.Pages.AdminPages.ClientsPages
{
    /// <summary>
    /// Логика взаимодействия для AddClientPage.xaml
    /// </summary>
    public partial class AddClientPage : Page
    {
        private Clients _currentClients = new Clients();
        public AddClientPage()
        {
            InitializeComponent();
            DataContext = _currentClients;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.MainFrame.Navigate(new ClientsPage());
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentClients.NameClient))
                errors.AppendLine("Введите имя");
            if (string.IsNullOrWhiteSpace(_currentClients.SurnameClient))
                errors.AppendLine("Введите фамилию");
            if (string.IsNullOrWhiteSpace(_currentClients.PhoneNumberClient))
                errors.AppendLine("Введите номер телефона");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentClients.IDClient == 0)
                SalonEntities.GetContext().Clients.Add(_currentClients);

            try
            {
                SalonEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                AdminFrame.MainFrame.GoBack();
            }
            catch (Exception  ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
