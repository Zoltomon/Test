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
namespace Test4.Views.PostWindows
{
    /// <summary>
    /// Логика взаимодействия для ProductPostWindow.xaml
    /// </summary>
    public partial class ProductPostWindow : Window
    {
        public ProductPostWindow()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = TxbNameProduct.Text;
                decimal price = decimal.Parse(TxbPriceProduct.Text);
                if(name == "" || price == 0)
                {
                    MessageBox.Show("Добавьте данные");
                }
                Products products = new Products()
                {
                    NameProduct = name,
                    Price = price,
                };
                ConnectDBClass.connect.Products.Add(products);
                ConnectDBClass.connect.SaveChanges();
                MessageBox.Show("Данные успешно сохранены");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
