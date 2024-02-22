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
        private List<User> _availableUsers;
        public UsersPage()
        {
            InitializeComponent();

            _availableUsers = CafeEntities.GetContext().Users.ToList();
            DGUsers.ItemsSource = _availableUsers;
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
            //if(Visibility == Visibility.Visible)
            //{
            //    CafeEntities.GetContext().Users.ToList();
            //    DGUsers.ItemsSource = CafeEntities.GetContext().Users.ToList();
            //}
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            PageManager.MainFrame.Navigate(new UserEditPage(null));
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            var usersForRemoval = DGUsers.SelectedItems.Cast<User>().ToList();
            if (MessageBox.Show("Удалить работника?", "Подтвердите удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                CafeEntities.GetContext().Users.RemoveRange(usersForRemoval);
                CafeEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные удалены!");

                DGUsers.ItemsSource = CafeEntities.GetContext().Users.ToList();
            }
        }
    }
}
