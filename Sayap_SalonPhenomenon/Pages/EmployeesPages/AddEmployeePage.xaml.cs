using Sayap_SalonPhenomenon.Database;
using System.Text;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Sayap_SalonPhenomenon.Pages.EmployeesPages
{
    /// <summary>
    /// Логика взаимодействия для AddEmployeePage.xaml
    /// </summary>
    public partial class AddEmployeePage : Page
    {
        private Masters _currentMasters = new Masters();
        public AddEmployeePage()
        {
            InitializeComponent();
            DataContext = _currentMasters;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.MainFrame.Navigate(new EmployeesPage());
        }

        private void SaveChangesRec_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentMasters.MasterName))
                errors.AppendLine("Введите имя");
            if (string.IsNullOrWhiteSpace(_currentMasters.MasterSurname))
                errors.AppendLine("Введите фамилию");
            if (string.IsNullOrWhiteSpace(_currentMasters.MasterPatronymic))
                errors.AppendLine("Введите Отчество");
            if (string.IsNullOrWhiteSpace(_currentMasters.MasterPhoneNumber))
                errors.AppendLine("Введите номер телефона");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentMasters.IDMaster == 0)
                SalonEntities.GetContext().Masters.Add(_currentMasters);

            try
            {
                SalonEntities.GetContext().SaveChanges();
                MessageBox.Show("Запись добавлена");
                AdminFrame.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
