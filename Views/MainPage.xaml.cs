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
using Test5.Classes;
using Test5.Models;
using System.Data.Entity;

namespace Test5.Views
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private PersonalData _personalData;
        public MainPage(PersonalData personalData)
        {
            InitializeComponent();
            _personalData = personalData;
            DataGridOrders.ItemsSource = ConnectDBClass.connection.Orders.Include(x => x.PersonalData).Include(x => x.Statuses).ToList();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(DataGridOrders.SelectedItem is Orders orders)
            {
                var delete = ConnectDBClass.connection.Orders.FirstOrDefault(r => r.Id == orders.Id);
                ConnectDBClass.connection.Orders.Remove(delete);
                ConnectDBClass.connection.SaveChanges();
                MessageBox.Show("Данные удалены");
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if(DataGridOrders.SelectedItem is Orders orders)
            {
                EditOrderWindow editOrderWindow = new EditOrderWindow(orders);
                editOrderWindow.ShowDialog();
            }
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            DataGridOrders.ItemsSource = ConnectDBClass.connection.Orders.Include(x => x.PersonalData).Include(x => x.Statuses).ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
