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
    /// Interaction logic for UserEditPage.xaml
    /// </summary>
    public partial class UserEditPage : Page
    {
        private User _currentUser = new User();
        public UserEditPage(User selectedUser)
        {
            InitializeComponent();
            if(selectedUser != null)
            {
                _currentUser = selectedUser;
            }
            DataContext = _currentUser;
            UserNameBox.Text = _currentUser.UserName;
            UserIDBox.Text = _currentUser.UserTypeID.ToString();
        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            //StringBuilder errors = new StringBuilder();
            //if (string.IsNullOrWhiteSpace(_currentUser.UserName) || string.IsNullOrWhiteSpace(_currentUser.UserTypeID.ToString()))
            //    errors.Append("Указаны не все данные");

            //if(errors.Length > 0)
            //{
            //    MessageBox.Show(errors.ToString());
            //    return;
            //}
            if (_currentUser.UserID == 0)
            {
                User user = new User(UserNameBox.Text, int.Parse(UserIDBox.Text));
                CafeEntities.GetContext().Users.Add(user);
            }

            CafeEntities.GetContext().SaveChanges();

            MessageBox.Show("Успешно изменено");

            PageManager.MainFrame.Navigate(new UsersPage());
            PageManager.MainFrame.RemoveBackEntry();


        }
            
    }
}
