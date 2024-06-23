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
using Test5.Classes;
using Test5.Models;

namespace Test5.Views
{
    /// <summary>
    /// Логика взаимодействия для EditOrderWindow.xaml
    /// </summary>
    public partial class EditOrderWindow : Window
    {
        private Orders _orders;
        public EditOrderWindow(Orders orders)
        {
            InitializeComponent();
            _orders = orders;
            CmbBxProduct.ItemsSource = ConnectDBClass.connection.Products.Select(x => x.NameProduct).ToList();
            TxbDescription.Text = orders.Description;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var product = ConnectDBClass.connection.Products.FirstOrDefault(x => x.NameProduct == CmbBxProduct.Text);
            _orders.ProductId = product?.Id;
            _orders.Description = TxbDescription.Text;
            
            ConnectDBClass.connection.SaveChanges();
        }
    }
}
