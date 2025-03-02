using Sayap_SalonPhenomenon.Database;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Sayap_SalonPhenomenon.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для AddRecordPage.xaml
    /// </summary>
    public partial class AddRecordPage : Page
    {
        private Registrations _currentRegistrations = new Registrations();
        public AddRecordPage(Registrations selectedRecord)
        {
            InitializeComponent();

            if (selectedRecord != null)
                _currentRegistrations = selectedRecord;

            DataContext = _currentRegistrations;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.MainFrame.Navigate(new MainAdminPage());
        }

        private void SaveChangesRec_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (DtpAppointmentDate.SelectedDate == null)
            {
                errors.AppendLine("Укажите дату и время");
            }
            else
            {
                _currentRegistrations.DateRegistration = (DateTime)DtpAppointmentDate.SelectedDate;
            }

            if (_currentRegistrations.ClientID <= 0)
                errors.AppendLine("Введите ID клиента");

            if (_currentRegistrations.ServiceID <= 0)
                errors.AppendLine("Введите ID услуги");

            if (_currentRegistrations.MasterID <= 0)
                errors.AppendLine("Введите ID мастера");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentRegistrations.IDRegistration == 0)
                SalonEntities.GetContext().Registrations.Add(_currentRegistrations);

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
