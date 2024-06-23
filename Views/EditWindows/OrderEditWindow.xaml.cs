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
using Test4.Classes;
using Test4.Models;

namespace Test4.Views.EditWindows
{
    /// <summary>
    /// Логика взаимодействия для OrderEditWindow.xaml
    /// </summary>
    public partial class OrderEditWindow : Window
    {
        private Orders _orders;
        private const int MaxLength = 100;
        public OrderEditWindow(Orders orders)
        {
            InitializeComponent();
            _orders = orders;
            TxbDescription.Text = _orders.Description;
            CmbProduct.ItemsSource = ConnectDBClass.connect.Products.Select(x=>x.NameProduct).ToList();
            CmbProduct.SelectedItem = _orders.ProductId;
        }

        private void TxbDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            MaxTxbLength.Text = $"{TxbDescription.Text.Length}/{MaxLength}";
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string description = TxbDescription.Text;
                string selectedPoint = CmbProduct.SelectedItem as string;
                if (description == "")
                {
                    MessageBox.Show("Введите описание");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
