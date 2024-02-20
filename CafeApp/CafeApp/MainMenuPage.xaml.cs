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

namespace CafeApp
{
    /// <summary>
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            PageManager.MainFrame.Navigate(new LoginPage());
            PageManager.MainFrame.RemoveBackEntry();
        }

        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            PageManager.MainFrame.Navigate(new OrdersPage());
            PageManager.MainFrame.RemoveBackEntry();
        }

        private void Employees_Click(object sender, RoutedEventArgs e)
        {
            PageManager.MainFrame.Navigate(new UsersPage());
            PageManager.MainFrame.RemoveBackEntry();
        }

        private void Shifts_Click(object sender, RoutedEventArgs e)
        {
            PageManager.MainFrame.Navigate(new ShiftsPage());
            PageManager.MainFrame.RemoveBackEntry();
        }
    }
}
