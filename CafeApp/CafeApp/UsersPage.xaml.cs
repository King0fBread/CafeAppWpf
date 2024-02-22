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
    /// Interaction logic for UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        public UsersPage()
        {
            InitializeComponent();
        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            PageManager.MainFrame.Navigate(new MainMenuPage());
            PageManager.MainFrame.RemoveBackEntry();
        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            PageManager.MainFrame.Navigate(new UserEditPage((sender as Button).DataContext as User));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                CafeEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGUsers.ItemsSource = CafeEntities.GetContext().Users.ToList();
            }
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            PageManager.MainFrame.Navigate(new UserEditPage(null));
        }
    }
}
