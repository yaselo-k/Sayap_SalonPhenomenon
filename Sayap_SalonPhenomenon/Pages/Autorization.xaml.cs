using Sayap_SalonPhenomenon.Database;
using Sayap_SalonPhenomenon.Pages.AdminPages;
using Sayap_SalonPhenomenon.Pages.ManagerPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sayap_SalonPhenomenon.Pages
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Page
    {
        public Autorization()
        {
            InitializeComponent();
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = DbConnect.modelOdb.Users.FirstOrDefault(x =>
                x.Login == LoginTextBox.Text && x.Password == PasswordBox.Password);
                if (user == null)
                {
                    MessageBox.Show("Такого пользователя не существует");
                }
                else
                {
                    switch (user.RoleID)
                    {
                        case 1:
                            MessageBox.Show("Здравствуйте, " + user.Username);
                            AdminFrame.MainFrame.Navigate(new MainAdminPage());
                            break;

                        case 2:
                            MessageBox.Show("Здравствуйте " + user.Username);
                            AdminFrame.MainFrame.Navigate(new MainManagerPage());
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message.ToString() + "Критическая ошибка приложения");
            }
        }
    }
}
