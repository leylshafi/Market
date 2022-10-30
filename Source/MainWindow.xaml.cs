using Source.FakeRepositoy;
using Source.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Source;

public partial class MainWindow : Window
{
    public ObservableCollection<Product> products=new();
    public ObservableCollection<Product> BoughtProducts=new();
    
    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
        for (int i = 0; i < FakeProducts.Products.Count; i++)
        {
            products.Add(FakeProducts.Products[i]);
        }
        for (int i = 0; i < products.Count; i++)
        {
            itms.Items.Add(products[i]);
        }
        
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        itms.Items.Clear();
        for (int i = 0; i < products.Count; i++)
        {
            if(products[i].Name== searchBox.Text)
                itms.Items.Add(products[i]);
        }
        if(searchBox.Text==String.Empty)
        {
            for (int i = 0; i < products.Count; i++)
            {
                itms.Items.Add(products[i]);
            }
        }
    }

    

    private void RepeatButton_Click(object sender, RoutedEventArgs e)
    {
        if(sender is RepeatButton btn)
        {
            if(btn.Content.ToString()=="-")
            {
                for (int i = 0; i < itms.Items.Count; i++)
                {
                    if (itms.Items[i] is Product pr)
                    {
                        if (pr.Name == btn.Tag.ToString())
                        {
                            if ((--pr.Count) < 0)
                                pr.Count = 0;
                           
                            itms.Items.RemoveAt(i);
                            itms.Items.Add((Product)pr);
                            float.TryParse(totalPrice.Content.ToString(), out float total);
                            float.TryParse(pr.Price, out float price);
                            total -=price;
                            totalPrice.Content = total.ToString();
                            if(pr.Count==0)
                                BoughtProducts.Remove(pr);
                            break;
                        }

                    }
                }
            }
            else
            {
                for (int i = 0; i < itms.Items.Count; i++)
                {
                    if (itms.Items[i] is Product pr)
                    {
                        if (pr.Name == btn.Tag.ToString())
                        {
                            ++pr.Count;
                            itms.Items.RemoveAt(i);
                            itms.Items.Add((Product)pr);
                            float.TryParse(totalPrice.Content.ToString(), out float total);
                            float.TryParse(pr.Price, out float price);
                            total +=  price;
                            totalPrice.Content = total.ToString();
                            if(pr.Count==1)
                                BoughtProducts.Add(pr);
                            break;
                        }

                    }
                }
            }
        }
    }


    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
       Buy buy = new Buy(BoughtProducts,totalPrice.Content.ToString());
       buy.ShowDialog();
       Application.Current.Shutdown();
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("It will be update", "Information",MessageBoxButton.OK,MessageBoxImage.Information);
    }
}
