using Sayap_SalonPhenomenon.Database;
using Sayap_SalonPhenomenon.Pages;
using System.Windows;

namespace Sayap_SalonPhenomenon
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DbConnect.modelOdb = new SalonEntities();
            AdminFrame.MainFrame = myFrame;
            AdminFrame.MainFrame.Navigate(new Autorization());
        }

        private void BackToAutorization_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.MainFrame.Navigate(new Autorization());
        }
    }
}
