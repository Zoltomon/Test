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
using Test4.Classes;

namespace Test4.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private AutorizationController _controller;
        public LoginPage(AutorizationController controller)
        {
            InitializeComponent();
            _controller = controller;
        }

        private void BtnAutorization_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string login = TxbLogin.Text;
                string password = TxbPassword.Text;
                var result = _controller.Autorization(login, password);
                if (result != null)
                {
                    switch (result.Users.Statuses.NameStatus)
                    {
                        case "Активен":
                            switch (result.Users.Roles.NameRole)
                            {
                                case "Администратор":
                                    NavigateClass.navigate.Navigate(new MainPage(result));
                                    throw new Exception($"Добро пожаловать в систему ваша роль: {result.Users.Roles.NameRole}");
                                    break;
                                case "Менеджер":
                                    NavigateClass.navigate.Navigate(new MainPage(result));
                                    throw new Exception($"Добро пожаловать в систему ваша роль: {result.Users.Roles.NameRole}");
                                    break;
                            }
                            break;
                        case "Неактивен":
                            MessageBox.Show("Ваш аккаунт неактивен");
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
