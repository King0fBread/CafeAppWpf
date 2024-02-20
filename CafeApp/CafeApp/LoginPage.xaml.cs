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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            int authResult = AuthenticateUser(NameTextBox.Text, Int32.Parse(UserTypeIDTextBox.Text));
            switch (authResult)
            {
                case 0:
                    PageManager.MainFrame.Navigate(new MainMenuPage());
                    PageManager.MainFrame.RemoveBackEntry();
                    break;
                case 1:
                    MessageBox.Show("Неверный айди!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    Console.WriteLine(UserTypeIDTextBox.Text);
                    UserTypeIDTextBox.Clear();
                    NameTextBox.Clear();
                    break;
                case 2:
                    MessageBox.Show("Неверное имя!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    UserTypeIDTextBox.Clear();
                    NameTextBox.Clear();
                    break;
            }
        }
        private int AuthenticateUser(string userNameInput, int userTypeIDInput)
        {
            var context = CafeEntities.GetContext().Users.FirstOrDefault(p => p.UserName == userNameInput);
            if(context !=null)
            {
                
                if(userTypeIDInput == context.UserTypeID)
                {
                    return 0;
                }
                //wrong id
                return 1;
            }
            return 2;
        }
    }
}
