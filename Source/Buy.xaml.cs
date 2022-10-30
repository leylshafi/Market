using Source.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Source
{
    /// <summary>
    /// Interaction logic for Buy.xaml
    /// </summary>
    public partial class Buy : Window
    {
        public ObservableCollection<Product> boughtProducts { get; set; }= new ObservableCollection<Product>();
        public Buy(ObservableCollection<Product> BoughtProducts,string total)
        {

            InitializeComponent();
            price.Content = total;
            for (int i = 0; i < BoughtProducts.Count; i++)
            {
                boughtProducts.Add(BoughtProducts[i]);
                listView.Items.Add(BoughtProducts[i]);
                
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new();
            sb.Append("You bought: ");
            sb.Append("\n");
            for (int i = 0; i < boughtProducts.Count; i++)
            {
                sb.Append(boughtProducts[i]);
                sb.Append("\n");
            }
            sb.Append($"\n You should pay {price.Content}");
            sb.Append("\n Good Bye!!!");
            MessageBox.Show(sb.ToString());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            price.Content = "0";
            boughtProducts.Clear();
            listView.Items.Clear();
        }
    }
}
