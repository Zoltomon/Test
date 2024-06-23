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
using System.Windows.Shapes;
using Test4.Models;

namespace Test4.Views.PostWindows
{
    /// <summary>
    /// Логика взаимодействия для MenuPostWindow.xaml
    /// </summary>
    public partial class MenuPostWindow : Window
    {
        private PersonalData _perosnalData;
        public MenuPostWindow(PersonalData personalData)
        {
            InitializeComponent();
            _perosnalData = personalData;
        }

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderPostWindow orderPost = new OrderPostWindow(_perosnalData);
            orderPost.Show();
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductPostWindow productPostWindow = new ProductPostWindow();
            productPostWindow.Show();
        }
    }
}
