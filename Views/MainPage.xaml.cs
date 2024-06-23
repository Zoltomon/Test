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
using Test4.Models;
using System.Data.Entity;
using Test4.Views.PostWindows;
using Test4.Views.EditWindows;

namespace Test4.Views
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
            var conn = ConnectDBClass.connect;
            DataGridProduct.ItemsSource = conn.Orders.Include(q => q.PersonalData).Include(q => q.Products).Include(q => q.Statuses).ToList();
            _personalData = personalData;
            VisibilityButton();
        }

        private void VisibilityButton()
        {
            switch (_personalData.Users.Roles.NameRole)
            {
                case "Администратор":
                    SetButtonVisibility(Visibility.Visible, Visibility.Visible);
                    break;
                case "Менеджер":
                    SetButtonVisibility(Visibility.Visible, Visibility.Collapsed);
                    break;
            }
        }

        private void SetButtonVisibility(Visibility editVisibility, Visibility deleteVisibility)
        {
            foreach (var item in DataGridProduct.Items)
            {
                var row = DataGridProduct.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (row != null)
                {
                    var editButton = DataGridProduct.Columns[3].GetCellContent(row).FindName("BtnEdit") as Button;
                    var deleteButton = DataGridProduct.Columns[3].GetCellContent(row).FindName("BtnDelete") as Button;

                    if (editButton != null)
                        editButton.Visibility = editVisibility;

                    if (deleteButton != null)
                        deleteButton.Visibility = deleteVisibility;
                }
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridProduct.SelectedItem is Orders orders)
            {
                var delete = ConnectDBClass.connect.Orders.FirstOrDefault(x => x.Id == orders.Id);
                if(delete != null)
                {
                    ConnectDBClass.connect.Orders.Remove(delete);
                    ConnectDBClass.connect.SaveChanges();
                    MessageBox.Show("Данные успешно удалены");
                    DataGridProduct.ItemsSource = ConnectDBClass.connect.Orders.Include(q => q.PersonalData).Include(q => q.Products).Include(q => q.Statuses).ToList();
                }
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if(DataGridProduct.SelectedItem is Orders orders)
            {
                OrderEditWindow orderEditWindow = new OrderEditWindow(orders);
                orderEditWindow.Show();
            }
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            DataGridProduct.ItemsSource = ConnectDBClass.connect.Orders.Include(q => q.PersonalData).Include(q => q.Products).Include(q => q.Statuses).ToList();
        }

        private void BtnMenuAdd_Click(object sender, RoutedEventArgs e)
        {
            MenuPostWindow menu = new MenuPostWindow(_personalData);
            menu.Show();
        }
    }
}
