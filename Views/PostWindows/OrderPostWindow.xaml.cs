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
    /// Логика взаимодействия для OrderPostWindow.xaml
    /// </summary>
    public partial class OrderPostWindow : Window
    {
        private PersonalData _personalData;
        private const int MaxLength = 100;
        public OrderPostWindow( PersonalData personalData)
        {
            InitializeComponent();
            CmbProduct.ItemsSource = ConnectDBClass.connect.Products.Select(x => x.NameProduct).ToList();
            _personalData = personalData;
        }

        private void TxbPriceProduct_TextChanged(object sender, TextChangedEventArgs e)
        {
            MaxTxbLength.Text = $"{TxbDescription.Text.Length}/{MaxLength}";
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string description = TxbDescription.Text;
                if(description == "")
                {
                    MessageBox.Show("Введите описание");
                }
                var product = ConnectDBClass.connect.Products.FirstOrDefault(x => x.NameProduct == CmbProduct.Text);
                Orders orders = new Orders()
                {
                    ProductId = product.Id,
                    Description = description,
                    Date = DateTime.Now,
                    StatusId = 4,
                    PersonalDataId = _personalData.Id,
                };
                ConnectDBClass.connect.Orders.Add(orders);
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
